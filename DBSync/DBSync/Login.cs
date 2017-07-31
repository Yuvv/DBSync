using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBSync
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();
		}

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			DBSync parentForm = (DBSync)this.Owner;
			try
			{
				SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

				builder.Add("Server", this.textBoxServerName.Text);
				if (this.comboBoxAuth.SelectedIndex == 0)
				{
					builder.Add("Integrated Security", "SSPI");
				}
				else if (this.comboBoxAuth.SelectedIndex == 1)
				{
					builder.Add("UID", this.textBoxUserName.Text);
					builder.Add("PWD", this.textBoxPassword.Text);
					builder.Add("Network Library", "DBMSSOCN");
				}

				parentForm.dbConn = new SqlConnection(builder.ConnectionString);
				parentForm.dbConn.Open();
				parentForm.dbCmd = parentForm.dbConn.CreateCommand();
				parentForm.dbCmd.CommandType = CommandType.Text;

				// write settings back
				parentForm.connSetting["Server"] = this.textBoxServerName.Text;
				parentForm.connSetting["AuthType"] = this.comboBoxAuth.SelectedIndex;
				parentForm.connSetting["UID"] = this.textBoxUserName.Text;
				parentForm.connSetting["PWD"] = this.textBoxPassword.Text;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void Login_Shown(object sender, EventArgs e)
		{
			DBSync parentForm = (DBSync)this.Owner;
			try
			{
				this.textBoxServerName.Text = parentForm.connSetting["Server"].ToString();
				this.comboBoxAuth.SelectedIndex = int.Parse(parentForm.connSetting["AuthType"].ToString());
				this.textBoxUserName.Text = parentForm.connSetting["UID"].ToString();
				this.textBoxPassword.Text = parentForm.connSetting["PWD"].ToString();
				this.comboBoxAuth_SelectedIndexChanged(sender, e);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void comboBoxAuth_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBoxAuth.SelectedIndex == 0)
			{
				this.labelUserName.Enabled = false;
				this.labelUserPassword.Enabled = false;
				this.textBoxUserName.Enabled = false;
				this.textBoxPassword.Enabled = false;
			}
			else if (this.comboBoxAuth.SelectedIndex == 1)
			{
				this.labelUserName.Enabled = true;
				this.labelUserPassword.Enabled = true;
				this.textBoxUserName.Enabled = true;
				this.textBoxPassword.Enabled = true;
			}
			else
			{
				MessageBox.Show("AuthType setting seems wrong!");
			}
		}
	}
}
