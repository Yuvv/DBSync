using System;
using System.Collections.Generic;
using System.Text;

namespace DBSyncSender
{
	class TableItem
	{
		public string tableName;
		public string identColumn;
		public int lastID;
		public bool plusItem;
		public int backoffTime;
		public int backoffCycle;

		public TableItem(string name, string col = "ID", int id = 0,
			bool plus = false, int time = 0, int cycle = 2)
		{
			this.tableName = name;
			this.identColumn = col;
			this.lastID = id;
			this.plusItem = plus;
			this.backoffTime = time;
			this.backoffCycle = cycle;
		}
	}
}
