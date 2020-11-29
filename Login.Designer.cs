namespace cheltuieli
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
		System.Windows.Forms.TextBox usernameBOX;
		System.Windows.Forms.TextBox passwordBOX;
		System.Windows.Forms.Button LOGINbtn;
		System.Windows.Forms.Label label1;
		System.Windows.Forms.Label label2;
		System.Windows.Forms.CheckBox checkBox1;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameBOX = new System.Windows.Forms.TextBox();
			this.passwordBOX = new System.Windows.Forms.TextBox();
			this.LOGINbtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// usernameBOX
			// 
			this.usernameBOX.Location = new System.Drawing.Point(78, 9);
			this.usernameBOX.Name = "usernameBOX";
			this.usernameBOX.Size = new System.Drawing.Size(105, 23);
			this.usernameBOX.TabIndex = 0;
			this.usernameBOX.Text = "admin";
			// 
			// passwordBOX
			// 
			this.passwordBOX.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.passwordBOX.Location = new System.Drawing.Point(78, 36);
			this.passwordBOX.Name = "passwordBOX";
			this.passwordBOX.PasswordChar = '*';
			this.passwordBOX.Size = new System.Drawing.Size(105, 23);
			this.passwordBOX.TabIndex = 0;
			this.passwordBOX.Text = "102938";
			this.passwordBOX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.passwordBOXKeyUp);
			// 
			// LOGINbtn
			// 
			this.LOGINbtn.Location = new System.Drawing.Point(76, 80);
			this.LOGINbtn.Name = "LOGINbtn";
			this.LOGINbtn.Size = new System.Drawing.Size(66, 32);
			this.LOGINbtn.TabIndex = 2;
			this.LOGINbtn.Text = "login";
			this.LOGINbtn.UseVisualStyleBackColor = true;
			this.LOGINbtn.Click += new System.EventHandler(this.LOGINbtnClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "username:";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label2.Location = new System.Drawing.Point(9, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 18);
			this.label2.TabIndex = 4;
			this.label2.Text = "password:";
			// 
			// checkBox1
			// 
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBox1.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.checkBox1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBox1.Location = new System.Drawing.Point(70, 62);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(129, 19);
			this.checkBox1.TabIndex = 16;
			this.checkBox1.Text = "arată parola";
			this.checkBox1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(215, 121);
			this.Controls.Add(this.LOGINbtn);
			this.Controls.Add(this.passwordBOX);
			this.Controls.Add(this.usernameBOX);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "login";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "cheltuieli";
			this.Load += new System.EventHandler(this.LoginLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
			/*this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";*/
        }

        #endregion
    }
}

