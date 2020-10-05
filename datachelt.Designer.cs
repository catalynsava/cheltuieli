/*
 * Created by visual studio code
 * User: Catalin
 * Date: 05.06.2020
 * Time: 10:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace cheltuieli
{
	partial class datachelt
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MonthCalendar calendar;
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
			this.calendar = new System.Windows.Forms.MonthCalendar();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// calendar
			// 
			this.calendar.Location = new System.Drawing.Point(44, 8);
			this.calendar.MaxSelectionCount = 1;
			this.calendar.Name = "calendar";
			this.calendar.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(189, 218);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(54, 30);
			this.button1.TabIndex = 4;
			this.button1.Text = "set";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.BtnsetClick);
			// 
			// datachelt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(286, 256);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.calendar);
			this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "datachelt";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "datachelt";
			this.ResumeLayout(false);

		}
	}
}
