using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DBOps
{
	public class MsSqlOps
	{
		private SqlConnection conn;
		private SqlCommand cmd;

		public MsSqlOps()
		{
			//
		}

		public MsSqlOps(string connStr)
		{
			this.connect(connStr);
		}

		public void Open()
		{
			if (this.conn.State == ConnectionState.Closed)
			{
				this.conn.Open();
			}
		}

		public void close()
		{
			if (this.conn.State != ConnectionState.Closed)
			{
				this.conn.Close();
			}
		}

		public void connect(string connStr)
		{
			this.conn = new SqlConnection(connStr);
			this.conn.Open();
			this.cmd = this.conn.CreateCommand();
			this.cmd.CommandType = CommandType.Text;
		}

		public SqlDataReader query(string sqlStr)
		{
			this.cmd.CommandText = sqlStr;

			return this.cmd.ExecuteReader();
		}

		public int nonQuery(string sqlStr)
		{
			this.cmd.CommandText = sqlStr;

			return this.cmd.ExecuteNonQuery();
		}

		public object scalar(string sqlStr)
		{
			this.cmd.CommandText = sqlStr;

			return this.cmd.ExecuteScalar();
		}

		public SqlDataAdapter select(string sqlStr)
		{
			this.cmd.CommandText = sqlStr;
			SqlDataAdapter adapter = new SqlDataAdapter(this.cmd);

			return adapter;
		}

		public void updateDataSet(DataSet dataSet)
		{
			foreach (DataTable table in dataSet.Tables)
			{
				updateDataTable(table);
			}
		}

		public void updateDataTable(DataTable table)
		{
			var sql = string.Format("select top 1 * from {0}", table.TableName);
			SqlDataAdapter adapter = select(sql);
			SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
			adapter.Update(table);
			cmdBuilder.RefreshSchema();
			cmdBuilder.Dispose();
			adapter.Dispose();
		}

		// 主动获取表结构
		public DataTable getTable(string tableName)
		{
			DataTable table = new DataTable(tableName);
			SqlDataAdapter adapter = select("select top 1 * from " + tableName);
			adapter.Fill(table);
			adapter.Dispose();
			table.Clear();

			return table;
		}
	}
}
