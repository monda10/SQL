
namespace Oracle_test_v1
{
    partial class LoginSystem
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.tb_pw = new System.Windows.Forms.TextBox();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.Login_pw = new System.Windows.Forms.Label();
            this.Login_id = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Login);
            this.groupBox1.Controls.Add(this.tb_pw);
            this.groupBox1.Controls.Add(this.tb_login);
            this.groupBox1.Controls.Add(this.Login_pw);
            this.groupBox1.Controls.Add(this.Login_id);
            this.groupBox1.Location = new System.Drawing.Point(178, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 460);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 173);
            this.panel1.TabIndex = 5;
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(165, 55);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "접속";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // tb_pw
            // 
            this.tb_pw.Location = new System.Drawing.Point(277, 28);
            this.tb_pw.Name = "tb_pw";
            this.tb_pw.Size = new System.Drawing.Size(100, 21);
            this.tb_pw.TabIndex = 3;
            this.tb_pw.TextChanged += new System.EventHandler(this.tb_pw_TextChanged);
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(89, 28);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(100, 21);
            this.tb_login.TabIndex = 2;
            this.tb_login.TextChanged += new System.EventHandler(this.tb_id_TextChanged);
            // 
            // Login_pw
            // 
            this.Login_pw.AutoSize = true;
            this.Login_pw.Location = new System.Drawing.Point(209, 33);
            this.Login_pw.Name = "Login_pw";
            this.Login_pw.Size = new System.Drawing.Size(62, 12);
            this.Login_pw.TabIndex = 1;
            this.Login_pw.Text = "PassWord";
            // 
            // Login_id
            // 
            this.Login_id.AutoSize = true;
            this.Login_id.Location = new System.Drawing.Point(31, 33);
            this.Login_id.Name = "Login_id";
            this.Login_id.Size = new System.Drawing.Size(52, 12);
            this.Login_id.TabIndex = 0;
            this.Login_id.Text = "Login_id";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 455);
            this.panel2.TabIndex = 6;
            // 
            // LoginSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 633);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LoginSystem";
            this.Text = "LoginSystem";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_pw;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.Label Login_pw;
        private System.Windows.Forms.Label Login_id;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}