namespace DBSync
{
	partial class DBSync
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBSync));
			this.treeViewDBTables = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.dataGridViewQueryResult = new System.Windows.Forms.DataGridView();
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControlResultInfo = new System.Windows.Forms.TabControl();
			this.tabPageResult = new System.Windows.Forms.TabPage();
			this.tabPageSyncTable = new System.Windows.Forms.TabPage();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.buttonSyncTableMode = new System.Windows.Forms.Button();
			this.listViewAddedTable = new System.Windows.Forms.ListView();
			this.table = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.identity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lastid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.origin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.textBoxQuery = new System.Windows.Forms.TextBox();
			this.splitContainerTables = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.database = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueryResult)).BeginInit();
			this.menuStripMain.SuspendLayout();
			this.tabControlResultInfo.SuspendLayout();
			this.tabPageResult.SuspendLayout();
			this.tabPageSyncTable.SuspendLayout();
			this.splitContainerTables.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeViewDBTables
			// 
			this.treeViewDBTables.AllowDrop = true;
			this.treeViewDBTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewDBTables.ImageIndex = 2;
			this.treeViewDBTables.ImageList = this.imageList1;
			this.treeViewDBTables.Indent = 12;
			this.treeViewDBTables.Location = new System.Drawing.Point(3, 3);
			this.treeViewDBTables.Name = "treeViewDBTables";
			this.treeViewDBTables.SelectedImageIndex = 2;
			this.treeViewDBTables.Size = new System.Drawing.Size(208, 429);
			this.treeViewDBTables.TabIndex = 0;
			this.treeViewDBTables.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewDBTables_ItemDrag);
			this.treeViewDBTables.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDBTables_NodeMouseDoubleClick);
			this.treeViewDBTables.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeViewDBTables_KeyUp);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "database_16.ico");
			this.imageList1.Images.SetKeyName(1, "table_16.ico");
			this.imageList1.Images.SetKeyName(2, "instance_16.ico");
			this.imageList1.Images.SetKeyName(3, "list_16.ico");
			this.imageList1.Images.SetKeyName(4, "grid_16.ico");
			// 
			// dataGridViewQueryResult
			// 
			this.dataGridViewQueryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewQueryResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewQueryResult.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewQueryResult.Name = "dataGridViewQueryResult";
			this.dataGridViewQueryResult.RowTemplate.Height = 23;
			this.dataGridViewQueryResult.Size = new System.Drawing.Size(471, 200);
			this.dataGridViewQueryResult.TabIndex = 2;
			// 
			// menuStripMain
			// 
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(704, 25);
			this.menuStripMain.TabIndex = 3;
			this.menuStripMain.Text = "menuStripMain";
			// 
			// 连接ToolStripMenuItem
			// 
			this.连接ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.退出ToolStripMenuItem});
			this.连接ToolStripMenuItem.Name = "连接ToolStripMenuItem";
			this.连接ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
			this.连接ToolStripMenuItem.Text = "连接";
			// 
			// 打开ToolStripMenuItem
			// 
			this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
			this.打开ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
			this.打开ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.打开ToolStripMenuItem.Text = "打开";
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.退出ToolStripMenuItem.Text = "退出";
			// 
			// 设置ToolStripMenuItem
			// 
			this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem1});
			this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
			this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
			this.设置ToolStripMenuItem.Text = "工具";
			// 
			// 设置ToolStripMenuItem1
			// 
			this.设置ToolStripMenuItem1.Name = "设置ToolStripMenuItem1";
			this.设置ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
			this.设置ToolStripMenuItem1.Text = "设置";
			// 
			// 帮助ToolStripMenuItem
			// 
			this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem1,
            this.关于ToolStripMenuItem});
			this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
			this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
			this.帮助ToolStripMenuItem.Text = "帮助";
			// 
			// 帮助ToolStripMenuItem1
			// 
			this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
			this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
			this.帮助ToolStripMenuItem1.Text = "帮助信息";
			// 
			// 关于ToolStripMenuItem
			// 
			this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
			this.关于ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.关于ToolStripMenuItem.Text = "关于";
			// 
			// tabControlResultInfo
			// 
			this.tabControlResultInfo.AllowDrop = true;
			this.tabControlResultInfo.Controls.Add(this.tabPageResult);
			this.tabControlResultInfo.Controls.Add(this.tabPageSyncTable);
			this.tabControlResultInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlResultInfo.Location = new System.Drawing.Point(0, 0);
			this.tabControlResultInfo.Name = "tabControlResultInfo";
			this.tabControlResultInfo.SelectedIndex = 0;
			this.tabControlResultInfo.Size = new System.Drawing.Size(485, 236);
			this.tabControlResultInfo.TabIndex = 4;
			this.tabControlResultInfo.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabControlResultInfo_DragEnter);
			// 
			// tabPageResult
			// 
			this.tabPageResult.Controls.Add(this.dataGridViewQueryResult);
			this.tabPageResult.Location = new System.Drawing.Point(4, 26);
			this.tabPageResult.Name = "tabPageResult";
			this.tabPageResult.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageResult.Size = new System.Drawing.Size(477, 206);
			this.tabPageResult.TabIndex = 0;
			this.tabPageResult.Text = "结果";
			this.tabPageResult.UseVisualStyleBackColor = true;
			// 
			// tabPageSyncTable
			// 
			this.tabPageSyncTable.Controls.Add(this.textBox1);
			this.tabPageSyncTable.Controls.Add(this.buttonSyncTableMode);
			this.tabPageSyncTable.Controls.Add(this.listViewAddedTable);
			this.tabPageSyncTable.Location = new System.Drawing.Point(4, 26);
			this.tabPageSyncTable.Name = "tabPageSyncTable";
			this.tabPageSyncTable.Size = new System.Drawing.Size(477, 206);
			this.tabPageSyncTable.TabIndex = 2;
			this.tabPageSyncTable.Text = "同步表";
			this.tabPageSyncTable.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(181, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(263, 23);
			this.textBox1.TabIndex = 2;
			// 
			// buttonSyncTableMode
			// 
			this.buttonSyncTableMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSyncTableMode.ImageIndex = 4;
			this.buttonSyncTableMode.ImageList = this.imageList1;
			this.buttonSyncTableMode.Location = new System.Drawing.Point(450, 2);
			this.buttonSyncTableMode.Name = "buttonSyncTableMode";
			this.buttonSyncTableMode.Size = new System.Drawing.Size(24, 24);
			this.buttonSyncTableMode.TabIndex = 1;
			this.buttonSyncTableMode.UseVisualStyleBackColor = true;
			this.buttonSyncTableMode.Click += new System.EventHandler(this.buttonSyncTableMode_Click);
			// 
			// listViewAddedTable
			// 
			this.listViewAddedTable.AllowDrop = true;
			this.listViewAddedTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewAddedTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.table,
            this.database,
            this.identity,
            this.lastid,
            this.origin});
			this.listViewAddedTable.FullRowSelect = true;
			this.listViewAddedTable.LargeImageList = this.imageList1;
			this.listViewAddedTable.Location = new System.Drawing.Point(3, 32);
			this.listViewAddedTable.Name = "listViewAddedTable";
			this.listViewAddedTable.Size = new System.Drawing.Size(471, 154);
			this.listViewAddedTable.TabIndex = 0;
			this.listViewAddedTable.UseCompatibleStateImageBehavior = false;
			this.listViewAddedTable.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewAddedTable_DragDrop);
			this.listViewAddedTable.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewAddedTable_DragEnter);
			this.listViewAddedTable.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewAddedTable_KeyUp);
			// 
			// table
			// 
			this.table.Text = "TABLE";
			// 
			// identity
			// 
			this.identity.Text = "IDENTITY";
			this.identity.Width = 88;
			// 
			// lastid
			// 
			this.lastid.Text = "LAST ID";
			// 
			// origin
			// 
			this.origin.Text = "ORIGIN TABLE";
			this.origin.Width = 90;
			// 
			// textBoxQuery
			// 
			this.textBoxQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxQuery.Location = new System.Drawing.Point(0, 5);
			this.textBoxQuery.Margin = new System.Windows.Forms.Padding(5);
			this.textBoxQuery.Multiline = true;
			this.textBoxQuery.Name = "textBoxQuery";
			this.textBoxQuery.Size = new System.Drawing.Size(480, 188);
			this.textBoxQuery.TabIndex = 5;
			this.textBoxQuery.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxQuery_KeyUp);
			// 
			// splitContainerTables
			// 
			this.splitContainerTables.Location = new System.Drawing.Point(0, 0);
			this.splitContainerTables.Name = "splitContainerTables";
			this.splitContainerTables.Size = new System.Drawing.Size(150, 100);
			this.splitContainerTables.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Margin = new System.Windows.Forms.Padding(5);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.textBoxQuery);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tabControlResultInfo);
			this.splitContainer2.Panel2MinSize = 100;
			this.splitContainer2.Size = new System.Drawing.Size(485, 436);
			this.splitContainer2.SplitterDistance = 198;
			this.splitContainer2.SplitterWidth = 2;
			this.splitContainer2.TabIndex = 7;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 25);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.treeViewDBTables);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer3.Size = new System.Drawing.Size(704, 436);
			this.splitContainer3.SplitterDistance = 215;
			this.splitContainer3.TabIndex = 8;
			// 
			// database
			// 
			this.database.Text = "DATABASE";
			// 
			// DBSync
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(704, 461);
			this.Controls.Add(this.splitContainer3);
			this.Controls.Add(this.menuStripMain);
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MainMenuStrip = this.menuStripMain;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "DBSync";
			this.Text = "DBSync";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DBSync_FormClosing);
			this.Shown += new System.EventHandler(this.DBSync_Shown);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueryResult)).EndInit();
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.tabControlResultInfo.ResumeLayout(false);
			this.tabPageResult.ResumeLayout(false);
			this.tabPageSyncTable.ResumeLayout(false);
			this.tabPageSyncTable.PerformLayout();
			this.splitContainerTables.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewDBTables;
		private System.Windows.Forms.DataGridView dataGridViewQueryResult;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.ToolStripMenuItem 连接ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem1;
		private System.Windows.Forms.TabControl tabControlResultInfo;
		private System.Windows.Forms.TabPage tabPageResult;
		private System.Windows.Forms.TextBox textBoxQuery;
		private System.Windows.Forms.ListView listViewAddedTable;
		private System.Windows.Forms.SplitContainer splitContainerTables;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.TabPage tabPageSyncTable;
		private System.Windows.Forms.ColumnHeader table;
		private System.Windows.Forms.ColumnHeader identity;
		private System.Windows.Forms.ColumnHeader lastid;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button buttonSyncTableMode;
		private System.Windows.Forms.ColumnHeader origin;
		private System.Windows.Forms.ColumnHeader database;
	}
}

