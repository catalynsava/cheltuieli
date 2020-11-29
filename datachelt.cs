/*
 * Created by visual studio code
 * User: Catalin
 * Date: 05.06.2020
 * Time: 10:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace cheltuieli
{
	/// <summary>
	/// Description of datachelt.
	/// </summary>
	public partial class datachelt : Form
	{
		public datachelt()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnsetClick(object sender, EventArgs e)
		{
			DateTime datamea=calendar.SelectionStart;
			
			string tempstring="";
			tempstring=datamea.ToShortDateString();
			if(tempstring.Length==10){
				Global.zicheltuieli=tempstring.Substring(0,2);
				Global.lunacheltuieli=tempstring.Substring(3,2);
				Global.ancheltuieli=tempstring.Substring(6,4);
			}
			Global.frmruleaza.linkLabel1.Text= Global.zicheltuieli + "." + Global.lunacheltuieli + "." + Global.ancheltuieli;
			this.Hide();
		}
	}
}
