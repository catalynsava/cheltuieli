/*
 * Created by visual studio code.
 * User: Catalin
 * Date: 03.04.2020
 * Time: 10:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace cheltuieli
{
	partial class sqlform
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox sqltextbox;
		private System.Windows.Forms.Button button1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqltextbox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// sqltextbox
			// 
			this.sqltextbox.Location = new System.Drawing.Point(5, 5);
			this.sqltextbox.Multiline = true;
			this.sqltextbox.Name = "sqltextbox";
			this.sqltextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.sqltextbox.Size = new System.Drawing.Size(877, 445);
			this.sqltextbox.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(804, 456);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(79, 26);
			this.button1.TabIndex = 1;
			this.button1.Text = "executare";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// sqlform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(885, 488);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.sqltextbox);
			this.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.MaximizeBox = false;
			this.Name = "sqlform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "sql";
			this.Load += new System.EventHandler(this.SqlformLoad);
			this.Resize+=new System.EventHandler(this.SqlformResize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
