/*
 * Created by visual studio code.
 * User: Catalin
 * Date: 03.04.2020
 * Time: 10:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace cheltuieli
{
	/// <summary>
	/// Description of sqlform.
	/// </summary>
	public partial class sqlform : Form
	{
		public sqlform()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(sqltextbox.Lines.Length>0){
				string sqlstring = sqltextbox.Lines[sqltextbox.Lines.Length - 1];
				if(String.Equals(sqlstring.Substring(0,6).ToUpper(),"SELECT")==true){
					try{
						using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
							using(Global.cmd=new SQLiteCommand()){
								Global.cmd.Connection=Global.cnn;
								Global.cmd.CommandText=sqlstring;
								using(Global.dr=Global.cmd.ExecuteReader()){
									sqltextbox.Text+="\r\n";
									sqltextbox.Text+="execut: "+sqlstring+"\r\n";
									if(Global.dr.HasRows){
										for(int i=0;i<Global.dr.FieldCount;i++){
											if(i==0){
												sqltextbox.Text+=Global.dr.GetName(i);
											}else{
												sqltextbox.Text+="\t" + Global.dr.GetName(i);;
											}
										}
										sqltextbox.Text+="\r\n";
									}
									while (Global.dr.Read()){
										for(int x=0;x<Global.dr.FieldCount;x++){
											if(x==0){
												sqltextbox.Text+=Global.dr[x].ToString();
											}else{
												sqltextbox.Text+="\t" + Global.dr[x].ToString();
											}
										}
										sqltextbox.Text+="\r\n";
									}
									Global.dr.Close();
								}
								Global.cmd.Dispose();
							}
							Global.tranzactie.Dispose();
						}
					}catch(Exception err){
						Global.eroare="\r\nGetType:\t"+err.GetType() +
									"\r\nMessage:\t"+ err.Message+
									"\r\nSource:\t\t"+ err.Source+
									"\r\nTargetSite:\t"+ err.TargetSite+
									"\r\nStackTrace:\t"+ err.StackTrace+
									"\r\nData:\t\t"+ err.Data;
						sqltextbox.Text+=Global.eroare;
					
						Global.eroare=string.Empty;
						//Global.tranzactie.Rollback();
					}finally{
						sqlstring=string.Empty;
						Global.tranzactie.Dispose();
						Global.cmd.Dispose();
						Global.dr.Close();
					}
				}else{
					try{
						using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
							using(Global.cmd=new SQLiteCommand()){
						      	Global.cmd.Connection=Global.cnn;
						      	Global.cmd.CommandText=sqlstring;
								Global.cmd.ExecuteNonQuery();
						      	Global.tranzactie.Commit();
						      	Global.cmd.Dispose();
							}
							Global.tranzactie.Dispose();
						}
					}catch(Exception err){
						Global.eroare="\r\nGetType:\t"+err.GetType() +
									"\r\nMessage:\t"+ err.Message+
									"\r\nSource:\t\t"+ err.Source+
									"\r\nTargetSite:\t"+ err.TargetSite+
									"\r\nStackTrace:\t"+ err.StackTrace+
									"\r\nData:\t\t"+ err.Data;
						sqltextbox.Text+=Global.eroare;
					
						Global.eroare=string.Empty;
						//Global.tranzactie.Rollback();
					}finally{
						sqlstring=string.Empty;
						Global.tranzactie.Dispose();
						Global.cmd.Dispose();
					}
				}
			}
		}
		void SqlformLoad(object sender, EventArgs e)
		{
			sqltextbox.Top=0;
			sqltextbox.Left=0;
			sqltextbox.Height=this.ClientSize.Height-button1.Height;
			sqltextbox.Width=this.ClientSize.Width;
			
			button1.Top=sqltextbox.Height;
			button1.Left=this.ClientSize.Width-button1.Width;
						
		}
		void SqlformResize(object sender, EventArgs e){
			sqltextbox.Top=0;
			sqltextbox.Left=0;
			sqltextbox.Height=this.ClientSize.Height-button1.Height;
			sqltextbox.Width=this.ClientSize.Width;
			
			button1.Top=sqltextbox.Height;
			button1.Left=this.ClientSize.Width-button1.Width;
		}
	}
}
