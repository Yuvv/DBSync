using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBSync
{
	public partial class TableSetting : Form
	{
		public TableSetting(
			string database,
			string name,
			string identity_column,
			int last_id,
			string origin_table)
		{
			InitializeComponent();

			this.textBoxDatabase.Text = database;
			this.textBoxSyncTable.Text = name;
			this.textBoxIdentCol.Text = identity_column;
			this.numericUpDownLastID.Value = last_id;
			this.textBoxOriginTable.Text = origin_table;

			if (origin_table.Equals(""))
			{
				this.labelOriginTable.Enabled = false;
				this.textBoxOriginTable.Enabled = false;
			}
		}
	}
}
