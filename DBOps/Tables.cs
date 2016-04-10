using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DBOps
{
	public class Tables
	{
		public static string[] TableNames = {
												"Student",
												"Book",
											};

		public static DataSet GetTables()
		{
			DataSet dataSet = new DataSet();
			dataSet.Tables.Add(GetStudentTable());
			dataSet.Tables.Add(GetBookTable());

			return dataSet;
		}

		public static DataTable GetTableByName(string tableName)
		{
			DataTable table;
			switch (tableName)
			{
				case "Student":
					table = GetStudentTable();
					break;
				case "Book":
					table = GetBookTable();
					break;
				default:
					table = new DataTable();
					break;
			}
			return table;
		}

		public static DataTable GetBookTable()
		{
			DataTable table = new DataTable("Book");
			table.Columns.Add("id", typeof(int));
			table.Columns.Add("name", typeof(string));
			table.Columns.Add("author", typeof(string));
			table.Columns.Add("pub_date", typeof(DateTime));

			return table;
		}

		public static DataTable GetStudentTable()
		{
			DataTable table = new DataTable("Student");
			table.Columns.Add("id", typeof(int));
			table.Columns.Add("name", typeof(string));
			table.Columns.Add("class", typeof(string));

			return table;
		}
	}
}
