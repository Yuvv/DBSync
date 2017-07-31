namespace DBSync
{
	partial class TableSetting
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelDatabase = new System.Windows.Forms.Label();
			this.labelSyncTable = new System.Windows.Forms.Label();
			this.labelIdentCol = new System.Windows.Forms.Label();
			this.labelLastID = new System.Windows.Forms.Label();
			this.textBoxDatabase = new System.Windows.Forms.TextBox();
			this.textBoxSyncTable = new System.Windows.Forms.TextBox();
			this.textBoxIdentCol = new System.Windows.Forms.TextBox();
			this.numericUpDownLastID = new System.Windows.Forms.NumericUpDown();
			this.labelOriginTable = new System.Windows.Forms.Label();
			this.textBoxOriginTable = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastID)).BeginInit();
			this.SuspendLayout();
			// 
			// labelDatabase
			// 
			this.labelDatabase.AutoSize = true;
			this.labelDatabase.Location = new System.Drawing.Point(38, 17);
			this.labelDatabase.Name = "labelDatabase";
			this.labelDatabase.Size = new System.Drawing.Size(44, 17);
			this.labelDatabase.TabIndex = 0;
			this.labelDatabase.Text = "数据库";
			// 
			// labelSyncTable
			// 
			this.labelSyncTable.AutoSize = true;
			this.labelSyncTable.Location = new System.Drawing.Point(38, 44);
			this.labelSyncTable.Name = "labelSyncTable";
			this.labelSyncTable.Size = new System.Drawing.Size(44, 17);
			this.labelSyncTable.TabIndex = 1;
			this.labelSyncTable.Text = "同步表";
			// 
			// labelIdentCol
			// 
			this.labelIdentCol.AutoSize = true;
			this.labelIdentCol.Location = new System.Drawing.Point(26, 71);
			this.labelIdentCol.Name = "labelIdentCol";
			this.labelIdentCol.Size = new System.Drawing.Size(56, 17);
			this.labelIdentCol.TabIndex = 2;
			this.labelIdentCol.Text = "标识字段";
			// 
			// labelLastID
			// 
			this.labelLastID.AutoSize = true;
			this.labelLastID.Location = new System.Drawing.Point(37, 97);
			this.labelLastID.Name = "labelLastID";
			this.labelLastID.Size = new System.Drawing.Size(45, 17);
			this.labelLastID.TabIndex = 3;
			this.labelLastID.Text = "同步ID";
			// 
			// textBoxDatabase
			// 
			this.textBoxDatabase.Location = new System.Drawing.Point(88, 14);
			this.textBoxDatabase.Name = "textBoxDatabase";
			this.textBoxDatabase.Size = new System.Drawing.Size(147, 23);
			this.textBoxDatabase.TabIndex = 4;
			// 
			// textBoxSyncTable
			// 
			this.textBoxSyncTable.Location = new System.Drawing.Point(88, 41);
			this.textBoxSyncTable.Name = "textBoxSyncTable";
			this.textBoxSyncTable.Size = new System.Drawing.Size(147, 23);
			this.textBoxSyncTable.TabIndex = 5;
			// 
			// textBoxIdentCol
			// 
			this.textBoxIdentCol.Location = new System.Drawing.Point(88, 68);
			this.textBoxIdentCol.Name = "textBoxIdentCol";
			this.textBoxIdentCol.Size = new System.Drawing.Size(147, 23);
			this.textBoxIdentCol.TabIndex = 6;
			// 
			// numericUpDownLastID
			// 
			this.numericUpDownLastID.Location = new System.Drawing.Point(88, 97);
			this.numericUpDownLastID.Name = "numericUpDownLastID";
			this.numericUpDownLastID.Size = new System.Drawing.Size(147, 23);
			this.numericUpDownLastID.TabIndex = 7;
			// 
			// labelOriginTable
			// 
			this.labelOriginTable.AutoSize = true;
			this.labelOriginTable.Location = new System.Drawing.Point(26, 129);
			this.labelOriginTable.Name = "labelOriginTable";
			this.labelOriginTable.Size = new System.Drawing.Size(56, 17);
			this.labelOriginTable.TabIndex = 8;
			this.labelOriginTable.Text = "原数据表";
			// 
			// textBoxOriginTable
			// 
			this.textBoxOriginTable.Location = new System.Drawing.Point(88, 123);
			this.textBoxOriginTable.Name = "textBoxOriginTable";
			this.textBoxOriginTable.Size = new System.Drawing.Size(147, 23);
			this.textBoxOriginTable.TabIndex = 9;
			// 
			// TableSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(271, 164);
			this.Controls.Add(this.textBoxOriginTable);
			this.Controls.Add(this.labelOriginTable);
			this.Controls.Add(this.numericUpDownLastID);
			this.Controls.Add(this.textBoxIdentCol);
			this.Controls.Add(this.textBoxSyncTable);
			this.Controls.Add(this.textBoxDatabase);
			this.Controls.Add(this.labelLastID);
			this.Controls.Add(this.labelIdentCol);
			this.Controls.Add(this.labelSyncTable);
			this.Controls.Add(this.labelDatabase);
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "TableSetting";
			this.Text = "TableSetting";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastID)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelDatabase;
		private System.Windows.Forms.Label labelSyncTable;
		private System.Windows.Forms.Label labelIdentCol;
		private System.Windows.Forms.Label labelLastID;
		private System.Windows.Forms.TextBox textBoxDatabase;
		private System.Windows.Forms.TextBox textBoxSyncTable;
		private System.Windows.Forms.TextBox textBoxIdentCol;
		private System.Windows.Forms.NumericUpDown numericUpDownLastID;
		private System.Windows.Forms.Label labelOriginTable;
		private System.Windows.Forms.TextBox textBoxOriginTable;

	}
}