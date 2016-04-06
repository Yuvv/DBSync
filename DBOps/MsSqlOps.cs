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
			// TODO: 搞清楚commandtype各个类型意义以及应该使用adapter还是cmd
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

		public void update(DataSet addedDataSet)
		{
			foreach (DataTable table in addedDataSet.Tables)
			{
				// TODO: 每次全部查出，效率问题？经测试只选一个也可以
				var sql = string.Format("select top 1 * from {0}", table.TableName);
				SqlDataAdapter adapter = select(sql);
				SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
				adapter.Update(table);
				cmdBuilder.Dispose();
				adapter.Dispose();
			}
		}

		// UNDONE: 通过此方式来实现同步
		// 主动获取表结构
		public DataTable getTable(string tableName)
		{
			DataTable table = new DataTable(tableName);
			// TODO: 条件小于0？
			SqlDataAdapter adapter = select("select * from " + tableName + " where id<0");
			adapter.Fill(table);
			adapter.Dispose();

			return table;
		}
	}
}
