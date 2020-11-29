/*
 * Created by visual studio code
 * User: Catalin
 * Date: 25.03.2020
 * Time: 17:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace cheltuieli
{
	/// <summary>
	/// Description of cautafrm.
	/// </summary>
	public partial class cautafrm : Form
	{
		public cautafrm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e){
			string sqlsel="";
			bool anterior=false;
			//sqlsel="SELECT t.ID, t.PRIORITATE, t.DENUMIRE, t.MAGAZIN, t.SCURT, t.DESCRIERE, t.VALOARE, t.NEVOIE,";
			sqlsel="SELECT t.DENUMIRE, t.MAGAZIN, t.SCURT, t.O";
			sqlsel+=" FROM lista t";
			if(prioritatebox.Text !=""){
				anterior=true;
				sqlsel+=" WHERE t.PRIORITATE = " +int.Parse( prioritatebox.Text) + "";
			}
			if(textdenumire.Text !=""){
				if(anterior==true){
					sqlsel+=" AND t.DENUMIRE LIKE '%" + textdenumire.Text + "%'";
					anterior=true ;
				}else{
					sqlsel+=" WHERE t.DENUMIRE LIKE '%" + textdenumire.Text + "%'";
					anterior=true ;
				}
			}
			
			if(textmagazin.Text !=""){
				if(anterior==true){
					sqlsel+=" AND t.MAGAZIN LIKE '%" + textmagazin.Text + "%'";
					anterior=true ;
				}else{
					sqlsel+=" WHERE t.MAGAZIN LIKE '%" + textmagazin.Text + "%'";
					anterior=true ;
				}
			}
			
			if(textum.Text !=""){
				if(anterior==true){
					sqlsel+=" AND t.DESCRIERE LIKE '%" + textum.Text + "%'";
					anterior=true ;
				}else{
					sqlsel+=" WHERE t.DESCRIERE LIKE '%" + textum.Text + "%'";
					anterior=true ;
				}
			}
			
			
			if(textpret.Text !=""){
				double pret=Convert.ToDouble(textpret.Text);
				if(anterior==true){
					sqlsel+=" AND t.VALOARE = " + pret.ToString().Replace(',','.') + "";
					anterior=true ;
				}else{
					sqlsel+=" WHERE t.VALOARE = " + pret.ToString().Replace(',','.') + "";
					anterior=true ;
				}
			}
			
			if(checkNevoie.Checked==true){
				if(anterior==true){
					sqlsel+=" AND t.NEVOIE = " + "true" + "";
					anterior=true ;
				}else{
					sqlsel+=" WHERE t.NEVOIE = " + "true" + "";
					anterior=true ;
				}
			}
			
			if(textperioada.Text!=""){
				if(anterior==true){
					sqlsel+=" AND t.PERIOADA LIKE '%" + textperioada.Text  + "%'";
					anterior=true ;
				}else{
					sqlsel+=" WHERE t.PERIOADA LIKE '%" + textperioada.Text + "%'";
					anterior=true ;
				}
			}
			
			if(textstart.Text!=""){
				if(anterior==true){
					sqlsel+=" AND t.DATA LIKE '%" + textstart.Text  + "%'";
					anterior=true ;
				}else{
					sqlsel+=" WHERE t.DATA LIKE '%" + textstart.Text + "%'";
					anterior=true ;
				}
			}
			
			if(checkActiv.Checked==true){
				if(anterior==true){
					sqlsel+=" AND t.ACTIV = " + "true" + ";";
					anterior=true ;
				}else{
					sqlsel+=" WHERE t.ACTIV = " + "true" + ";";
					anterior=true ;
				}
			}
			
			if(textsemn.Text!=""){
				if(anterior==true){
					if(textsemn.Text=="-"){
						sqlsel+=" AND t.SEMN='-'";
						anterior=true ;
					}else{
						sqlsel+=" AND t.SEMN='+'";
						anterior=true ;
					}
				}else{
					if(textsemn.Text=="-"){
						sqlsel+=" WHERE t.O='-'";
						anterior=true ;
					}else{
						sqlsel+=" WHERE t.O='+'";
						anterior=true ;
					}
					
				}
			}
			
			sqlsel+=" ORDER BY t.DENUMIRE;";
			
			Global.sqllista=sqlsel;
			Global.SetSetting("sql",sqlsel);
			Global.frmruleaza.incarcalistbox(Global.sqllista,"","");
			this.Hide();
		}
	}
}
