namespace FlyHunter
{
	partial class Form2
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			this.panelMain = new System.Windows.Forms.Panel();
			this.imgFly = new System.Windows.Forms.PictureBox();
			this.lblScore = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.listAllUsers = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgFly)).BeginInit();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.BackColor = System.Drawing.Color.White;
			this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelMain.Controls.Add(this.imgFly);
			this.panelMain.Location = new System.Drawing.Point(13, 61);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(250, 300);
			this.panelMain.TabIndex = 0;
			// 
			// imgFly
			// 
			this.imgFly.Image = ((System.Drawing.Image)(resources.GetObject("imgFly.Image")));
			this.imgFly.Location = new System.Drawing.Point(200, 250);
			this.imgFly.Name = "imgFly";
			this.imgFly.Size = new System.Drawing.Size(50, 50);
			this.imgFly.TabIndex = 0;
			this.imgFly.TabStop = false;
			// 
			// lblScore
			// 
			this.lblScore.AutoSize = true;
			this.lblScore.Location = new System.Drawing.Point(294, 87);
			this.lblScore.Name = "lblScore";
			this.lblScore.Size = new System.Drawing.Size(13, 13);
			this.lblScore.TabIndex = 1;
			this.lblScore.Text = "0";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(269, 65);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(60, 13);
			this.lblName.TabIndex = 2;
			this.lblName.Text = "Your Score";
			// 
			// listAllUsers
			// 
			this.listAllUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listAllUsers.Location = new System.Drawing.Point(272, 163);
			this.listAllUsers.Name = "listAllUsers";
			this.listAllUsers.Size = new System.Drawing.Size(118, 195);
			this.listAllUsers.TabIndex = 3;
			this.listAllUsers.UseCompatibleStateImageBehavior = false;
			this.listAllUsers.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Score";
			this.columnHeader2.Width = 40;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(269, 146);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Other User(s):";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(272, 13);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 5;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(134, 15);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(128, 20);
			this.txtName.TabIndex = 6;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(410, 368);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listAllUsers);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.lblScore);
			this.Controls.Add(this.panelMain);
			this.Name = "Form2";
			this.Text = "Fly Hunter";
			this.panelMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imgFly)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Label lblScore;
		private System.Windows.Forms.PictureBox imgFly;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.ListView listAllUsers;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.TextBox txtName;
	}
}

