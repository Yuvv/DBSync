using System;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using log4net;

namespace DBSync {
	public partial class DBSync: Form {
		public SqlConnection dbConn = null;
		public SqlCommand dbCmd = null;

		public JObject connSetting = null;
		public JArray syncTables = null;
		public static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public DBSync() {
			InitializeComponent();
		}

		/// <summary>
		/// Create a trigger table with identity column and a trigger for insert.
		/// And then insert all data in old table into new trigger table.
		/// </summary>
		/// <param name="database">the database that table lived</param>
		/// <param name="table">the table</param>
		private void createTriggerAndTable(string database, string table) {
			// add trigger table
			this.dbCmd.CommandText = string.Format(
					"select column_name,data_type,character_maximum_length as max_length from " +
					"[{0}].information_schema.columns where table_name='{1}'",
					database, table);
			SqlDataReader reader = this.dbCmd.ExecuteReader();
			StringCollection strColl = new StringCollection();
			strColl.Add("myid int identity(1,1)");	// add identity column
			while (reader.Read()) {
				if (reader.IsDBNull(2)) {
					strColl.Add(reader[0].ToString() + " " + reader[1].ToString());
				} else {
					strColl.Add(string.Format("[{0}] {1}({2})",
						reader[0].ToString(), reader[1].ToString(), reader[2].ToString()));
				}
			}
			string[] strs = new string[strColl.Count];
			strColl.CopyTo(strs, 0);
			reader.Close();
			this.dbCmd.CommandText = string.Format(
				"use [{0}];if object_id('tgrtable4{1}','u') is not null drop table [tgrtable4{2}];" +
				"create table tgrtable4{3}({4});",
				database, table, table, table, string.Join(",", strs));
			this.dbCmd.ExecuteNonQuery();
			log.Info(string.Format("create trigger table for {0} done!", table));

			// create trigger for insert
			strs = new string[strColl.Count - 1];
			for (int i = 1; i < strColl.Count; i++) {
				strs[i - 1] = strColl[i].Split(' ')[0];
			}
			this.dbCmd.CommandText = string.Format(
				"create trigger [tgr4{0}] on [{1}] for insert as\n" +
				"begin\n" +
				"insert into [tgrtable4{2}] ({3})\n" +
				"select {4} from inserted;\n" +
				"end",
				table, table, table,
				string.Join(",", strs), string.Join(",", strs));
			this.dbCmd.ExecuteNonQuery();
			log.Info(string.Format("create trigger for {0} done!", table));

			// insert existed data into trigger table
			this.dbCmd.CommandText = string.Format(
				"insert into [tgrtable4{0}] ({1})\n" +
				"select {2} from [{3}];",
				table, string.Join(",", strs), string.Join(",", strs), table);
			this.dbCmd.ExecuteNonQuery();
			log.Info(string.Format("insert existed data into {0} done!", table));
		}

		/// <summary>
		/// Execute a SQL query and show query result at data grid view.
		/// </summary>
		/// <param name="sqlStr">the sql to be executed</param>
		private void showQueryResult(string sqlStr) {
			try {
				this.dbCmd.CommandText = sqlStr;
				DataTable rTable = new DataTable();
				SqlDataAdapter adapter = new SqlDataAdapter(this.dbCmd);
				adapter.Fill(rTable);
				this.dataGridViewQueryResult.DataSource = rTable;
				adapter.Dispose();
				this.tabControlResultInfo.SelectedTab = this.tabPageResult;
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void buttonStart_Click(object sender, EventArgs e) {
			if (this.dbConn != null) {
				MessageBox.Show(this.dbConn.ConnectionString);
			}
		}

		private void DBSync_Shown(object sender, EventArgs e) {
			StreamReader reader = new StreamReader("setting.json");
			JObject setting = JObject.Parse(reader.ReadToEnd());
			this.connSetting = (JObject)setting["Connection"];
			this.syncTables = (JArray)setting["Tables"];
			reader.Close();
			log.Info("Load setting OK!");

			Login loginForm = new Login();
			loginForm.ShowDialog(this);
			log.Info("Database opened!");

			TreeNode node = new TreeNode(
				this.connSetting["Server"].ToString());
			node.ImageIndex = 2;
			this.treeViewDBTables.Nodes.Add(node);

			foreach (var table in this.syncTables) {
				Match match = Regex.Match(table["name"].ToString(), @"\[([\w ]+)\]..\[([\w ]+)\]");
				ListViewItem item = new ListViewItem(match.Groups[2].ToString());
				item.SubItems.Add(match.Groups[1].ToString());
				item.SubItems.Add(table["ident_col"].ToString());
				item.SubItems.Add(table["last_id"].ToString());
				item.SubItems.Add(table["origin_table"].ToString());
				item.ImageIndex = 0;
				this.listViewAddedTable.Items.Add(item);
			}
		}

		private void treeViewDBTables_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
			if (e.Node.Level == 0 && e.Node.Nodes.Count == 0) {
				this.dbCmd.CommandText = "select name from master..sysdatabases where sid!=0x01;";
			} else if (e.Node.Level == 1 && e.Node.Nodes.Count == 0) {
				this.dbCmd.CommandText = string.Format(
						"select name from [{0}]..sysobjects where xtype='u' and name != 'sysdiagrams'",
						e.Node.Text);
			} else {
				if (e.Node.Level == 2) {
					string sql = string.Format(
					"select column_name,data_type,character_maximum_length as max_length from " +
					"[{0}].information_schema.columns where table_name='{1}'",
					e.Node.Parent.Text, e.Node.Text);
					this.showQueryResult(sql);
				}
				return;
			}
			SqlDataReader reader = this.dbCmd.ExecuteReader();
			while (reader.Read()) {
				TreeNode node = new TreeNode(reader["name"].ToString());
				node.ImageIndex = node.SelectedImageIndex = e.Node.Level == 0 ? 0 : 1;
				e.Node.Nodes.Add(node);
			}
			reader.Close();
			e.Node.Expand();
		}

		private void DBSync_FormClosing(object sender, FormClosingEventArgs e) {
			if (this.dbCmd != null) {
				this.dbConn.Close();
				log.Info("stoping...");
			}

			StreamWriter sw = new StreamWriter("setting.json");
			JObject setting = new JObject();
			setting.Add("Connection", this.connSetting);
			setting.Add("Tables", this.syncTables);
			sw.Write(setting.ToString());
			sw.Close();
			log.Info("settings write back done!");
		}

		private void textBoxQuery_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.F5) {
				e.Handled = true;
				this.showQueryResult(this.textBoxQuery.Text);
			}
		}

		private void buttonSyncTableMode_Click(object sender, EventArgs e) {
			if (this.buttonSyncTableMode.ImageIndex == 4) {
				// grid mode to detail
				this.buttonSyncTableMode.ImageIndex = 3;
				this.listViewAddedTable.View = View.Details;
			} else {
				// detail mode to grid
				this.buttonSyncTableMode.ImageIndex = 4;
				this.listViewAddedTable.View = View.LargeIcon;
			}
		}

		private void treeViewDBTables_ItemDrag(object sender, ItemDragEventArgs e) {
			if (((TreeNode)e.Item).Level == 2) {
				DoDragDrop(e.Item, DragDropEffects.Copy);
			}
		}

		private void tabControlResultInfo_DragEnter(object sender, DragEventArgs e) {
			this.tabControlResultInfo.SelectedTab = this.tabPageSyncTable;
			e.Effect = DragDropEffects.Copy;
		}

		private void listViewAddedTable_DragEnter(object sender, DragEventArgs e) {
			e.Effect = DragDropEffects.Copy;
		}

		private void listViewAddedTable_DragDrop(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false)) {
				TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
				ListViewItem item = new ListViewItem(node.Text);
				item.SubItems.Add(node.Parent.Text);
				item.ImageIndex = 0;
				//TODO: COL,ID,...
				this.dbCmd.CommandText = string.Format(
					"select name from {0}.sys.all_columns where " +
					"[object_id]=object_id('[{1}]..[{2}]') and is_identity=1;",
					node.Parent.Text,
					node.Parent.Text,
					node.Text);
				SqlDataReader reader = this.dbCmd.ExecuteReader();
				if (reader.Read()) {
					item.SubItems.Add(reader[0].ToString());
					item.SubItems.Add("0");
					item.SubItems.Add(node.Text);
					this.syncTables.Add(new JObject(
						new JProperty("name", "[" + node.Parent.Text + "]..[" + node.Text + "]"),
						new JProperty("ident_col", reader[0].ToString()),
						new JProperty("last_id", 0),
						new JProperty("origin_table", node.Text)));
					this.listViewAddedTable.Items.Add(item);
					reader.Close();
				} else {
					reader.Close();
					if (DialogResult.OK == MessageBox.Show(
						"Would you like to create a table with identity column " +
						"and create insert trigger?", "OK?",
						MessageBoxButtons.OKCancel)) {
						this.createTriggerAndTable(node.Parent.Text, node.Text);
						item.Text = "tgrtable4" + item.Text;
						item.SubItems.Add("myid");
						item.SubItems.Add("0");
						item.SubItems.Add(node.Text);
						this.syncTables.Add(new JObject(
							new JProperty("name", "[" + node.Parent.Text + "]..[tgrtable4" + node.Text + "]"),
							new JProperty("ident_col", "myid"),
							new JProperty("last_id", 0),
							new JProperty("origin_table", node.Text)));
						this.listViewAddedTable.Items.Add(item);
					}
				}
			}
		}

		// update tree view node when press F5 key
		private void treeViewDBTables_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.F5) {
				this.treeViewDBTables.SelectedNode.Collapse();
				this.treeViewDBTables.SelectedNode.Nodes.Clear();
				this.treeViewDBTables_NodeMouseDoubleClick(sender,
					new TreeNodeMouseClickEventArgs(
						this.treeViewDBTables.SelectedNode,
						System.Windows.Forms.MouseButtons.Left,
						2, 0, 0));
			}
		}

		// delete item when press DELETE key. also delete trigger and trigger table in database.
		private void listViewAddedTable_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete) {
				foreach (ListViewItem item in this.listViewAddedTable.SelectedItems) {
					JObject t = null;
					foreach (var table in this.syncTables) {
						if (table["name"].ToString() ==
							"[" + item.SubItems[1].Text + "]..[" + item.Text + "]") {
							t = (JObject)table;
							break;
						}
					}
					if (t != null) {
						this.syncTables.Remove(t);
					}
					if (item.Text != item.SubItems[3].Text) {
						this.dbCmd.CommandText = string.Format(
						"use [{0}];drop trigger tgr4{1};drop table {2}",
						item.SubItems[1].Text,
						item.SubItems[4].Text, item.Text);
						this.dbCmd.ExecuteNonQuery();
					}
					this.listViewAddedTable.Items.Remove(item);
				}
			}
		}
	}
}
