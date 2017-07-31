namespace DBSync
{
    partial class Login
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
			this.labelServerName = new System.Windows.Forms.Label();
			this.labelAuthType = new System.Windows.Forms.Label();
			this.labelUserName = new System.Windows.Forms.Label();
			this.labelUserPassword = new System.Windows.Forms.Label();
			this.buttonLogin = new System.Windows.Forms.Button();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.textBoxUserName = new System.Windows.Forms.TextBox();
			this.textBoxServerName = new System.Windows.Forms.TextBox();
			this.comboBoxAuth = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// labelServerName
			// 
			this.labelServerName.AutoSize = true;
			this.labelServerName.Location = new System.Drawing.Point(48, 23);
			this.labelServerName.Name = "labelServerName";
			this.labelServerName.Size = new System.Drawing.Size(68, 17);
			this.labelServerName.TabIndex = 0;
			this.labelServerName.Text = "服务器名称";
			// 
			// labelAuthType
			// 
			this.labelAuthType.AutoSize = true;
			this.labelAuthType.Location = new System.Drawing.Point(60, 51);
			this.labelAuthType.Name = "labelAuthType";
			this.labelAuthType.Size = new System.Drawing.Size(56, 17);
			this.labelAuthType.TabIndex = 1;
			this.labelAuthType.Text = "身份验证";
			// 
			// labelUserName
			// 
			this.labelUserName.AutoSize = true;
			this.labelUserName.Location = new System.Drawing.Point(72, 78);
			this.labelUserName.Name = "labelUserName";
			this.labelUserName.Size = new System.Drawing.Size(44, 17);
			this.labelUserName.TabIndex = 2;
			this.labelUserName.Text = "用户名";
			// 
			// labelUserPassword
			// 
			this.labelUserPassword.AutoSize = true;
			this.labelUserPassword.Location = new System.Drawing.Point(84, 102);
			this.labelUserPassword.Name = "labelUserPassword";
			this.labelUserPassword.Size = new System.Drawing.Size(32, 17);
			this.labelUserPassword.TabIndex = 3;
			this.labelUserPassword.Text = "密码";
			// 
			// buttonLogin
			// 
			this.buttonLogin.Location = new System.Drawing.Point(192, 138);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(75, 23);
			this.buttonLogin.TabIndex = 4;
			this.buttonLogin.Text = "登录";
			this.buttonLogin.UseVisualStyleBackColor = true;
			this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxPassword.Location = new System.Drawing.Point(122, 99);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(145, 23);
			this.textBoxPassword.TabIndex = 6;
			// 
			// textBoxUserName
			// 
			this.textBoxUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxUserName.Location = new System.Drawing.Point(122, 75);
			this.textBoxUserName.Name = "textBoxUserName";
			this.textBoxUserName.Size = new System.Drawing.Size(145, 23);
			this.textBoxUserName.TabIndex = 7;
			// 
			// textBoxServerName
			// 
			this.textBoxServerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxServerName.Location = new System.Drawing.Point(122, 20);
			this.textBoxServerName.Name = "textBoxServerName";
			this.textBoxServerName.Size = new System.Drawing.Size(145, 23);
			this.textBoxServerName.TabIndex = 8;
			// 
			// comboBoxAuth
			// 
			this.comboBoxAuth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.comboBoxAuth.FormattingEnabled = true;
			this.comboBoxAuth.Items.AddRange(new object[] {
            "Windows 身份验证",
            "SQL Server 身份验证"});
			this.comboBoxAuth.Location = new System.Drawing.Point(122, 48);
			this.comboBoxAuth.Name = "comboBoxAuth";
			this.comboBoxAuth.Size = new System.Drawing.Size(145, 25);
			this.comboBoxAuth.TabIndex = 9;
			this.comboBoxAuth.SelectedIndexChanged += new System.EventHandler(this.comboBoxAuth_SelectedIndexChanged);
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(303, 183);
			this.Controls.Add(this.comboBoxAuth);
			this.Controls.Add(this.textBoxServerName);
			this.Controls.Add(this.textBoxUserName);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.buttonLogin);
			this.Controls.Add(this.labelUserPassword);
			this.Controls.Add(this.labelUserName);
			this.Controls.Add(this.labelAuthType);
			this.Controls.Add(this.labelServerName);
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Login";
			this.Text = "Login";
			this.Shown += new System.EventHandler(this.Login_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelServerName;
        private System.Windows.Forms.Label labelAuthType;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelUserPassword;
		private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.ComboBox comboBoxAuth;
    }
}