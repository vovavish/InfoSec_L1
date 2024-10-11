namespace InfoSec_Lab1_3
{
    partial class AdminForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.txtNewUsername = new System.Windows.Forms.TextBox();
            this.txtUsernameToBlock = new System.Windows.Forms.TextBox();
            this.txtUsernameRestrictions = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnChangeAdminPassword = new System.Windows.Forms.Button();
            this.btnBlockUser = new System.Windows.Forms.Button();
            this.btnTogglePasswordRestrictions = new System.Windows.Forms.Button();
            this.btnViewUsers = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 413);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 25);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 15;
            this.lstUsers.Location = new System.Drawing.Point(502, 57);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(286, 379);
            this.lstUsers.TabIndex = 1;
            // 
            // txtNewUsername
            // 
            this.txtNewUsername.Location = new System.Drawing.Point(19, 59);
            this.txtNewUsername.Name = "txtNewUsername";
            this.txtNewUsername.Size = new System.Drawing.Size(263, 23);
            this.txtNewUsername.TabIndex = 2;
            // 
            // txtUsernameToBlock
            // 
            this.txtUsernameToBlock.Location = new System.Drawing.Point(19, 128);
            this.txtUsernameToBlock.Name = "txtUsernameToBlock";
            this.txtUsernameToBlock.Size = new System.Drawing.Size(263, 23);
            this.txtUsernameToBlock.TabIndex = 3;
            // 
            // txtUsernameRestrictions
            // 
            this.txtUsernameRestrictions.Location = new System.Drawing.Point(19, 205);
            this.txtUsernameRestrictions.Name = "txtUsernameRestrictions";
            this.txtUsernameRestrictions.Size = new System.Drawing.Size(263, 23);
            this.txtUsernameRestrictions.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Новый пользователь";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(305, 57);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(112, 24);
            this.btnAddUser.TabIndex = 6;
            this.btnAddUser.Text = "Добавить";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnChangeAdminPassword
            // 
            this.btnChangeAdminPassword.Location = new System.Drawing.Point(299, 413);
            this.btnChangeAdminPassword.Name = "btnChangeAdminPassword";
            this.btnChangeAdminPassword.Size = new System.Drawing.Size(118, 25);
            this.btnChangeAdminPassword.TabIndex = 7;
            this.btnChangeAdminPassword.Text = "Сменить пароль";
            this.btnChangeAdminPassword.UseVisualStyleBackColor = true;
            this.btnChangeAdminPassword.Click += new System.EventHandler(this.btnChangeAdminPassword_Click);
            // 
            // btnBlockUser
            // 
            this.btnBlockUser.Location = new System.Drawing.Point(305, 123);
            this.btnBlockUser.Name = "btnBlockUser";
            this.btnBlockUser.Size = new System.Drawing.Size(104, 43);
            this.btnBlockUser.TabIndex = 8;
            this.btnBlockUser.Text = "Заблокировать\\разблокировать";
            this.btnBlockUser.UseVisualStyleBackColor = true;
            this.btnBlockUser.Click += new System.EventHandler(this.btnBlockUser_Click);
            // 
            // btnTogglePasswordRestrictions
            // 
            this.btnTogglePasswordRestrictions.Location = new System.Drawing.Point(305, 194);
            this.btnTogglePasswordRestrictions.Name = "btnTogglePasswordRestrictions";
            this.btnTogglePasswordRestrictions.Size = new System.Drawing.Size(112, 54);
            this.btnTogglePasswordRestrictions.TabIndex = 9;
            this.btnTogglePasswordRestrictions.Text = "Откл\\вкл ограничения на пароль";
            this.btnTogglePasswordRestrictions.UseVisualStyleBackColor = true;
            this.btnTogglePasswordRestrictions.Click += new System.EventHandler(this.btnTogglePasswordRestrictions_Click);
            // 
            // btnViewUsers
            // 
            this.btnViewUsers.Location = new System.Drawing.Point(557, 27);
            this.btnViewUsers.Name = "btnViewUsers";
            this.btnViewUsers.Size = new System.Drawing.Size(177, 23);
            this.btnViewUsers.TabIndex = 10;
            this.btnViewUsers.Text = "Посмотреть пользователей";
            this.btnViewUsers.UseVisualStyleBackColor = true;
            this.btnViewUsers.Click += new System.EventHandler(this.btnViewUsers_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Изменить доступ пользователя к программе";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Изменить наличие ограничений на пароль";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProgramToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutProgramToolStripMenuItem.Text = "О программе";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.aboutProgramToolStripMenuItem_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnViewUsers);
            this.Controls.Add(this.btnTogglePasswordRestrictions);
            this.Controls.Add(this.btnBlockUser);
            this.Controls.Add(this.btnChangeAdminPassword);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsernameRestrictions);
            this.Controls.Add(this.txtUsernameToBlock);
            this.Controls.Add(this.txtNewUsername);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.btnExit);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnExit;
        private ListBox lstUsers;
        private TextBox txtNewUsername;
        private TextBox txtUsernameToBlock;
        private TextBox txtUsernameRestrictions;
        private Label label1;
        private Button btnAddUser;
        private Button btnChangeAdminPassword;
        private Button btnBlockUser;
        private Button btnTogglePasswordRestrictions;
        private Button btnViewUsers;
        private Label label2;
        private Label label3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem aboutProgramToolStripMenuItem;
    }
}