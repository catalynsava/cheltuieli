using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data.SQLite;

namespace cheltuieli
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        void LOGINbtnClick(object sender, EventArgs e)
		{
			verificausernameparola();
		}
		void LoginLoad(object sender, EventArgs e)
		{
			AcceptButton = LOGINbtn;
			Global.conectare();
		}
		
		void passwordBOXKeyUp(object sender, KeyEventArgs e){
			if (e.KeyValue == 13){
				verificausernameparola();
			}
		}
		void verificausernameparola(){
				try{
					string strsql="SELECT ID, USERNAME, PASS FROM administrare WHERE ";
					strsql+="USERNAME='" + usernameBOX.Text + "'";
					strsql+=" AND PASS='" + passwordBOX.Text + "';";
					using(Global.cmd=new SQLiteCommand(strsql, Global.cnn)){
						using(Global.dr=Global.cmd.ExecuteReader()){
							if(Global.dr.Read()==true){
								Global.username=Global.dr["USERNAME"].ToString();
								Global.password=Global.dr["PASS"].ToString();
								Global.id=Global.dr["id"].ToString();
								
								Global.frmruleaza=new frmCheltuieli();
	
								Global.frmruleaza.Visible=true;
								this.Hide();
							}
							if(Global.dr.IsClosed==false){
								Global.dr.Close();
							}
						}
						Global.cmd.Dispose();
					}
				}catch(Exception ex){
					Debug.Print(ex.Message);
				}

		}
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked==true){
            	passwordBOX.PasswordChar = char.Parse("\0");
				passwordBOX.Select();
			}else{
				passwordBOX.PasswordChar = char.Parse("*");
				passwordBOX.Select();
			}
		}
    }
}
