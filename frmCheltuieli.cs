using System;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace cheltuieli
{
    public partial class frmCheltuieli : Form
    {
        string lucru;
		string iddenumire;
		int nrcitestedenumire;
		int nrzileramase;
		int ptnrzile;
		int nrsaptamani;
	
		decimal totalzi;
		decimal totallunadinzi;
		decimal totallunadin3zile;
		decimal totalsaptamana;
		decimal totallunadinsaptamana;
		decimal totalluna;
		decimal totalocazional;
	
      
	public frmCheltuieli(){
		InitializeComponent();
	}
	
	void frmCheltuieli_Load(object sender, EventArgs e){
		
        	
        label8.Text=Global.id;
		gridactive.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		
			
		string strsql="";
		strsql+="UPDATE lista SET NEVOIE=1, DATA=date() WHERE lista.DATA<= date('now', '-1 day') AND lista.PERIOADA='1. zi' AND lista.ACTIV=1;";
		strsql+="UPDATE lista SET NEVOIE=1, DATA=date() WHERE lista.DATA<= date('now', '-3 day') and lista.PERIOADA='2. 3 zile' AND lista.ACTIV=1;";
		strsql+="UPDATE lista set NEVOIE=1, DATA=date() WHERE lista.DATA<= date('now', '-7 day') and lista.PERIOADA='3. săptămână' AND lista.ACTIV=1;";
		strsql+="UPDATE lista set NEVOIE=1, DATA=date() WHERE lista.DATA<= date('now', '-1 month') and lista.PERIOADA='4. lună' AND lista.ACTIV=1;";
		strsql+="UPDATE lista set NEVOIE=1, DATA=date() WHERE lista.DATA<= date('now', '-1 year') and lista.PERIOADA='5. an' AND lista.ACTIV=1;";
		strsql+="UPDATE lista set NEVOIE=1 WHERE (lista.DATA= date('now', '+1 day') or lista.DATA= date('now', '+2 day') or lista.DATA= date('now', '+3 day')) and lista.PERIOADA='7. memento' AND lista.ACTIV=1;";
		
		using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
			using(Global.cmd=new SQLiteCommand()){
		      		Global.cmd.Connection=Global.cnn;
		      		Global.cmd.CommandText=strsql;
		      		try{
		      			Global.cmd.ExecuteNonQuery();
		      			Global.tranzactie.Commit();
		      		}catch(Exception err){
		      			MessageBox.Show("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
		      			Global.tranzactie.Rollback();
		      		}
		      		Global.cmd.Dispose();
			}
			Global.tranzactie.Dispose();
		}
		
			nrzile();
			incarcadatagrid();
			if(gridactive.RowCount>0){
				cautaMagazin(gridactive.Rows[0].Cells[0].Value.ToString(),gridactive.Rows[0].Cells[1].Value.ToString());
			}else{
				incarcalistbox("","","1");
			}
			
			autocomplet();
			
			linkLabel1.Text=Global.zicheltuieli + "." + Global.lunacheltuieli + "." + Global.ancheltuieli;
			
			if (listDenumiri.Items.Count > 0)
			{
			   button2.Enabled = true;
			   button3.Enabled = true;
			   button4.Enabled = true;
			   btnda.Enabled = false;
			   btnnu.Enabled = false;
			}
			else
			{
			   	button2.Enabled = true;
			   	button3.Enabled = false;
			   	button4.Enabled = false;
			  	btnda.Enabled = false;
			  	btnnu.Enabled = false;
			}
			
			radioButton1.AutoCheck = false;
			radioButton2.AutoCheck = false;
			radioButton3.AutoCheck = false;
			textdenumire.ReadOnly = true;
			textmagazin.ReadOnly=true;
			textscurt.ReadOnly=true;
			textum.ReadOnly = true;
			textpret.ReadOnly = true;
			checkNevoie.AutoCheck = false;
			checkActiv.AutoCheck=false;
			checkChelt.AutoCheck=false;
			checkVenit.AutoCheck=false;
			textstart.ReadOnly = true;
			textperioada.ReadOnly = true;
			button10.Enabled=false;
			
			
			
		    textcautadenumiri.Top = 0;
			textcautadenumiri.Left = 0;
			
			btntoate.Top=textcautadenumiri.Height;
			btntoate.Left= 0;
			
			btnactive.Top=textcautadenumiri.Height;
			btnactive.Left =btntoate.Width ;
			
			btninactive.Top=textcautadenumiri.Height;
			btninactive.Left=btntoate.Width+btnactive.Width;
				
	
			listDenumiri.Top = textcautadenumiri.Height+btninactive.Height; ;
			listDenumiri.Left = 0;
			listDenumiri.Height = this.ClientSize.Height - textcautadenumiri.Height-btninactive.Height ;
	
			gridactive.Top = 0;
			gridactive.Left = this.ClientSize.Width - gridactive.Width;
			gridactive.Height = this.ClientSize.Height;
	
			panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
			panel1.Left =  listDenumiri.Width ;

        }
	void frmCheltuieli_UnLoad(object sender, FormClosingEventArgs e)
        {
        	try{
				if(Global.conectat==true){
					//string stradministrare=Global.exportsql("administrare");
					Global.SetSetting("sql", Global.sqllista);
					string strlista=Global.exportsql("lista");
					string strcheltuieli=Global.exportsql("cheltuieli");
					Global.scriebackup(strlista+strcheltuieli);

					
					Global.deconectare();
					Application.Exit();
				}
				if(Global.conectat==false){
					Application.Exit();
				}
        	}catch(Exception err){
        		MessageBox.Show(err.ToString());
        	}
        }
	void frmCheltuieli_Resize(object sender, EventArgs e)
        {
			textcautadenumiri.Top = 0;
			textcautadenumiri.Left = 0;
				
			btntoate.Top=textcautadenumiri.Height;
			btntoate.Left= 0;
				
			btnactive.Top=textcautadenumiri.Height;
			btnactive.Left =btntoate.Width ;
				
			btninactive.Top=textcautadenumiri.Height;
			btninactive.Left=btntoate.Width+btnactive.Width;
					
		
			listDenumiri.Top = textcautadenumiri.Height+btninactive.Height; ;
			listDenumiri.Left = 0;
			listDenumiri.Height = this.ClientSize.Height - textcautadenumiri.Height-btninactive.Height ;
		
			gridactive.Top = 0;
			gridactive.Left = this.ClientSize.Width - gridactive.Width;
			gridactive.Height = this.ClientSize.Height;
		
			panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
			panel1.Left = listDenumiri.Width;
        }
	void Button1Click(object sender, EventArgs e)
		{
			var fromAddress = new MailAddress("catalynsava@gmail.com");
			const string fromPassword = "sava1760506catalin";
			var toAddress = new MailAddress(textemail.Text);

			const string subject = "cheltuieli";
			string body = textExport.Text;

			SmtpClient smtp = new System.Net.Mail.SmtpClient{
		   		Host = "smtp.gmail.com",
		   		Port = 587,
		   		EnableSsl = true,
		   		DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
		   		UseDefaultCredentials = false,
		   		Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
			};

		using (var message = new MailMessage(fromAddress, toAddress)
		{
		   Subject = subject,
		   Body = body
		})

		   smtp.Send(message);
		   label6.Text = "email trimis...";
		}
	private void Button2Click(object sender, EventArgs e)
        {
		lucru = "ADAUGARE";
		label7.Text="salvați?...";
		radioButton1.AutoCheck = true;
		radioButton2.AutoCheck = true;
		radioButton3.AutoCheck = true;
		textdenumire.ReadOnly = false;
		textmagazin.ReadOnly=false;
		textscurt.ReadOnly=false;
		
		textum.ReadOnly = false;
		textpret.ReadOnly = false;
		//checkInLista.AutoCheck=true;
		checkNevoie.AutoCheck = true;
		checkNevoie.Checked = false;
		checkActiv.AutoCheck=true;
		checkActiv.Checked=false;
		checkChelt.AutoCheck =true;
		checkChelt.Checked=false;
		checkVenit.AutoCheck=true;
		checkVenit.Checked=false;
		textstart.ReadOnly = false;
		textperioada.ReadOnly = false;
		button10.Enabled=true;

		textdenumire.Text = "";
		//textmagazin.Text="";
		//textscurt.Text="";
		textum.Text = "";
		textpret.Text = "";
		if(linkLabel1.Text =="................."){
			textstart.Text = DateTime.Today.ToShortDateString();
		}else{
			textstart.Text =linkLabel1.Text;
		}
		
		
		textperioada.Text = "6. ocazional";
		
		button2.Enabled = false;
		button3.Enabled = false;
		button4.Enabled = false;
		btnda.Enabled = true;
		btnnu.Enabled = true;

		textdenumire.Select();
        }
	private void Button3Click(object sender, EventArgs e)
        {
		lucru = "MODIFICARE";
		label7.Text="salvați?...";
		radioButton1.AutoCheck = true;
		radioButton2.AutoCheck = true;
		radioButton3.AutoCheck = true;

		textdenumire.ReadOnly = false;
		textmagazin.ReadOnly=false;
		textscurt.ReadOnly=false;
		textum.ReadOnly = false;
		textpret.ReadOnly = false;
		//checkInLista.AutoCheck=true;
		checkNevoie.AutoCheck = true;
		checkActiv.AutoCheck=true;
		checkChelt.AutoCheck=true;
		checkVenit.AutoCheck=true;
		textstart.ReadOnly = false;
		textperioada.ReadOnly = false;
		button10.Enabled=true;

		button2.Enabled = false;
		button3.Enabled = false;
		button4.Enabled = false;
		btnda.Enabled = true;
		btnnu.Enabled = true;

		listDenumiri.Enabled = false;
		gridactive.Enabled=false;

		textmagazin.Select();
        }
	void Button4Click(object sender, EventArgs e)
        {
        lucru = "STERGERE";
        checkChelt.Checked=false;
        checkVenit.Checked=false;
		button2.Enabled = false;
		button3.Enabled = false;
		button4.Enabled = false;
		btnda.Enabled = true;
		btnnu.Enabled = true;
        }
	void Button5Click(object sender, EventArgs e)
		{
			textExport.Text = makeemailbody("1") + nrzilerestplata.Text.PadLeft(52);
			System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\lista.txt", textExport.Text);
		}
	void button6Click(object sender, EventArgs e)
        {
		Process.Start("notepad.exe", Directory.GetCurrentDirectory() + @"\lista.txt");
		label6.Text = "export efectuat...";
        }
	void Button6Click(object sender, EventArgs e)
		{
			Process.Start("notepad.exe", Directory.GetCurrentDirectory() + @"\lista.txt");
			label6.Text = "export efectuat...";
		}
	void Button7Click(object sender, EventArgs e)
		{
			textExport.Text = makeemailbody("2") + nrzilerestplata.Text.PadLeft(52);
			File.WriteAllText(Directory.GetCurrentDirectory() + @"\lista.txt", textExport.Text);
		}
	void Button8Click(object sender, EventArgs e)
		{
			textExport.Text = makeemailbody("3") + nrzilerestplata.Text.PadLeft(52);
			File.WriteAllText(Directory.GetCurrentDirectory() + @"\lista.txt", textExport.Text);
		}
	void Button9Click(object sender, EventArgs e)
		{
			int lunaVar=0;
			if((DateTime.Now.Month-1)==0){
				lunaVar=12;
			}else{
				lunaVar=DateTime.Now.Month-1;
			}

			string strcheltuieli="";
			string sqlsel = "";
			string wheresql1="";
			string groupby=" GROUP BY cheltuieli.AN, cheltuieli.LUNA, cheltuieli.ZIUA, cheltuieli.MAGAZIN";
			string groupby2=" GROUP BY cheltuieli.AN, cheltuieli.LUNA, cheltuieli.ZIUA";
			string orderby=" ORDER BY AN, LUNA, ZIUA, MAGAZIN, ORDINE;";

			
			
			if(int.Parse(DateTime.Now.Day.ToString())<=5){
				wheresql1=" WHERE " + 
							"cheltuieli.LUNA=" + lunaVar.ToString() +
						" OR " + "" +
							"(" + "" +
								"cheltuieli.LUNA=" + DateTime.Now.Month.ToString() +
							" AND " + 
								"cheltuieli.ZIUA<=5 " +
							")";
			} else if(int.Parse(DateTime.Now.Day.ToString())>5){
				wheresql1=" WHERE "+ 
							"cheltuieli.LUNA=" + DateTime.Now.Month.ToString() +
						" AND " + 
							"cheltuieli.ZIUA>5";
			}
			
			sqlsel="SELECT 0 AS ORDINE, ID, DENUMIRE, MAGAZIN, DESCRIERE, AN, LUNA, ZIUA, VALOARE, SEMN FROM cheltuieli";
			sqlsel += wheresql1;
			
			sqlsel += " UNION ALL";
			
			sqlsel += " SELECT 1 AS ORDINE, '', 'TOTAL', MAGAZIN, '', cheltuieli.AN, cheltuieli.LUNA, cheltuieli.ZIUA, ROUND(SUM(cheltuieli.SEMN || cheltuieli.VALOARE),2), '' FROM cheltuieli";
			sqlsel += wheresql1;
			sqlsel += groupby;
			
			sqlsel += " UNION ALL";
			
			sqlsel += " SELECT 2 AS ORDINE, '', 'TOTAL', 'ZZZ' AS MAGAZIN, '', cheltuieli.AN, cheltuieli.LUNA, cheltuieli.ZIUA, ROUND(SUM(cheltuieli.SEMN || cheltuieli.VALOARE),2), '' FROM cheltuieli";
			sqlsel += wheresql1;
			sqlsel += groupby2;
			
			
			sqlsel += orderby;
			
			try{
				using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
					using(Global.cmd=new SQLiteCommand()){
						Global.cmd.Connection=Global.cnn;
						Global.cmd.CommandText=sqlsel;
						using(Global.dr=Global.cmd.ExecuteReader()){
							if(DateTime.Now.Day<=5){
								strcheltuieli+= " " + ("cheltuieli : " + DateTime.Now.AddMonths(-1).ToString("MMMM")  + " / " +DateTime.Now.AddMonths(-1).Year + "." ).PadLeft(52) + " \r\n";
							}else{
								strcheltuieli+= " " + ("cheltuieli : " + DateTime.Now.ToString("MMMM")  + " / " + DateTime.Now.Year.ToString()+ "." ).PadLeft(52) + " \r\n";
							}
							while (Global.dr.Read()){
								if(Global.dr["denumire"].ToString()=="TOTAL"){
									if(Global.dr["MAGAZIN"].ToString()=="ZZZ"){
										strcheltuieli+= " " + ("TOTAL" + " " + Global.dr["ZIUA"].ToString().PadLeft(2,'0') + "." + Global.dr["LUNA"].ToString().PadLeft(2,'0')+"."+ Global.dr["AN"].ToString()).PadRight(37);
										strcheltuieli+=string.Format("{0:0.00}", (Global.dr["VALOARE"])).PadLeft(10)  + " lei. \r\n";
										strcheltuieli+="-----------------".PadRight(61)+ "\r\n";
									}else{
										strcheltuieli+= " " + ("TOTAL" + " " + Global.dr["MAGAZIN"].ToString()).PadRight(37);
										strcheltuieli+=string.Format("{0:0.00}", ( Global.dr["VALOARE"])).PadLeft(10)  + " lei. \r\n\r\n";
									}
									
								}else{
									strcheltuieli+= " " + Global.dr["DENUMIRE"].ToString().PadRight(21);
									strcheltuieli+= " " + Global.dr["DESCRIERE"].ToString().PadRight(15);
									strcheltuieli+= string.Format("{0:0.00}", ( Global.dr["VALOARE"])).PadLeft(10)  + " lei. \r\n";  
								}
							}
							Global.dr.Close();
						}
						Global.cmd.Dispose();
					}
					Global.tranzactie.Dispose();
				}
			}catch(Exception err){
				Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			}
			
			
			try{
				
				sqlsel = "SELECT ROUND(SUM(cheltuieli.SEMN || cheltuieli.VALOARE),2) as total FROM cheltuieli";
				sqlsel += wheresql1;
				
				using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
					using(Global.cmd=new SQLiteCommand()){
						Global.cmd.Connection=Global.cnn;
						Global.cmd.CommandText=sqlsel;
						using(Global.dr=Global.cmd.ExecuteReader()){
							Global.dr.Read();
							strcheltuieli+= " " + "total".ToString().PadRight(27) + Global.dr["TOTAL"].ToString().PadLeft(20) + " lei. \r\n";
							if(int.Parse(DateTime.Now.Day.ToString())<=5){
								strcheltuieli+= " " + ("cheltuieli : " + DateTime.Now.AddMonths(-1).ToString("MMMM")  + " / " +DateTime.Now.AddMonths(-1).Year.ToString()+ "." ).PadLeft(52) + " \r\n";
							}else{
								strcheltuieli+= " " + ("cheltuieli : " + DateTime.Now.ToString("MMMM")  + " / " + DateTime.Now.Year.ToString()+ "." ).PadLeft(52) + " \r\n";
							}
							Global.dr.Close();
						}
						Global.cmd.Dispose();
					}
					Global.tranzactie.Dispose();
				}
			}catch(Exception err){
				Debug.Print( err.InnerException + "\r\n" + err.Message + "\r\n" + err.StackTrace);
			}finally{
				Global.cmd.Dispose();
				Global.dr.Close();
			}
			
			
			//---------------------------------------------------------------------/
			decimal totalvenituridouble=0;
			decimal totalcheltuielidouble=0;
			try{
				sqlsel="SELECT cheltuieli.SEMN, ROUND(SUM(cheltuieli.SEMN || cheltuieli.VALOARE),2) as total FROM cheltuieli";
				groupby=" GROUP BY cheltuieli.SEMN;";
				
				
				sqlsel += wheresql1;
				sqlsel += groupby;
				
				using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
					using(Global.cmd=new SQLiteCommand()){
						Global.cmd.Connection=Global.cnn;
						Global.cmd.CommandText=sqlsel;
						using(Global.dr=Global.cmd.ExecuteReader()){
							while(Global.dr.Read()){
								if(Global.dr["SEMN"].ToString()=="+"){
									totalvenituridouble=Convert.ToDecimal(Global.dr["total"].ToString());
									//totalvenituridouble=Math.Round(totalvenituridouble, 2);
									strcheltuieli+= "\r\n " + "venituri:".ToString().PadRight(27) + totalvenituridouble.ToString("0.00").PadLeft(20) + " lei. \r\n";
								}
								if(Global.dr["SEMN"].ToString()=="-"){
									totalcheltuielidouble=Convert.ToDecimal(Global.dr["TOTAL"].ToString());
									//totalcheltuielidouble=Math.Round(totalcheltuielidouble, 2);
									strcheltuieli+= " " + "cheltuieli:".ToString().PadRight(27) + totalcheltuielidouble.ToString("0.00").PadLeft(20) + " lei. \r\n";
								}
							}
							strcheltuieli+= " " + "venituri-cheltuieli:".PadRight(27) + (totalvenituridouble+totalcheltuielidouble).ToString("0.00").PadLeft(20) + " lei. \r\n";
							
							Global.dr.Close();
						}
						Global.cmd.Dispose();
					}
					Global.tranzactie.Dispose();
				}
			}catch(Exception err){
				Debug.Print( err.InnerException + "\r\n" + err.Message + "\r\n" + err.StackTrace);
			}finally{
				Global.cmd.Dispose();
				Global.dr.Close();
			}//*/
			//---------------------------------------------------------------------
			
			textExport.Text =strcheltuieli;
			strcheltuieli="";
			System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\lista.txt", textExport.Text);
		}
	
	void BtndaClick(object sender, EventArgs e){
		
		string uuid=string.Empty;
		string sqlinsert;
		string sqlupdate;
		int prioritate = 3;
		int nevoie = 0;
		int activ=0;
		
		switch (lucru){
				case "ADAUGARE":
				uuid=System.Guid.NewGuid().ToString().ToUpper();
				if (radioButton1.Checked == true)
				{
					prioritate = 1;
				}
				else if (radioButton2.Checked == true)
				{
					prioritate = 2;
				}
				else if (radioButton3.Checked == true)
				{
					prioritate = 3;
				}
				else
				{
					prioritate = 9;
				}
				if (checkNevoie.Checked == true)
				{
					nevoie = 1;
				}else{
					nevoie=0;
				}
				if (checkActiv.Checked == true)
				{
					activ = 1;
				}else{
					activ=0;
				}
				sqlinsert = "INSERT INTO lista (";
				sqlinsert+="ID, ";
				sqlinsert+="PRIORITATE, ";
				sqlinsert+="DENUMIRE, ";
				sqlinsert+="MAGAZIN, ";
				sqlinsert+="SCURT, ";
				sqlinsert+="DESCRIERE, ";
				sqlinsert+="VALOARE, ";
				sqlinsert+="NEVOIE, ";
				sqlinsert+="PERIOADA, ";
				sqlinsert+="DATA, ";
				sqlinsert+="ACTIV, ";
				sqlinsert+="O) ";
				sqlinsert+="VALUES (";
				sqlinsert+="'" + uuid + "', ";
				sqlinsert+="" + prioritate + ", ";
				sqlinsert+="'" + textdenumire.Text + "', ";
				sqlinsert+="'" + textmagazin.Text + "', ";
				sqlinsert+="'" + textscurt.Text + "', ";
				sqlinsert+="'" + textum.Text + "', ";
				sqlinsert+="" + textpret.Text.Replace(",",".") + ", ";
				sqlinsert+="" + nevoie + ", ";
				if(textperioada.Text==""){
					sqlinsert+="'" + "NULL" + "', ";
				}else{
					sqlinsert+="'" + textperioada.Text + "', ";
				}
				
				sqlinsert+="'" + textstart.Text.Substring(6, 4) + "-" + textstart.Text.Substring(3, 2) + "-" + textstart.Text.Substring(0, 2) + "', ";
				sqlinsert+="" + activ+", ";
				sqlinsert+="'" + button10.Text+"'";
				sqlinsert+=");";
				
				try{
					using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
						using(Global.cmd=new SQLiteCommand()){
					      	Global.cmd.Connection=Global.cnn;
					      	Global.cmd.CommandText=sqlinsert;
							Global.cmd.ExecuteNonQuery();
					      	Global.tranzactie.Commit();
					      	Global.cmd.Dispose();
						}
						Global.tranzactie.Dispose();
					}
				}catch(Exception err){
					Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			      	Global.tranzactie.Rollback();
				}
				
				incarcalistbox(Global.sqllista,textdenumire.Text,"");
				incarcadatagrid();
				break;
			case "MODIFICARE":
				if (radioButton1.Checked == true)
				{
					prioritate = 1;
				}
				else if (radioButton2.Checked == true)
				{
					prioritate = 2;
				}
				else if (radioButton3.Checked == true)
				{
					prioritate = 3;
				}
				else
				{
					prioritate = 9;
				}

				if (Equals(checkNevoie.Checked, true)) {
					nevoie = 1;
				}
				
				if (Equals(checkActiv.Checked, true)) {
					activ = 1;
				}
				
				sqlupdate = "UPDATE lista SET " +
					"PRIORITATE = " + prioritate + ", " +
					"DENUMIRE = '" + textdenumire.Text + "', " +
					"MAGAZIN = '" + textmagazin.Text + "', " +
					"SCURT = '" + textscurt.Text + "', " +
					"DESCRIERE = '" + textum.Text + "', " +
					"VALOARE = " + textpret.Text.Replace(",",".") + ", " +
					"NEVOIE = " + nevoie + ", " +
					"ACTIV = " + activ + ", " ;
					if(textperioada.Text==""){
					sqlupdate+="PERIOADA = " + "NULL" + ", " ;
					}else{
					sqlupdate+="PERIOADA = '" +textperioada.Text + "', " ;
					}
					
					sqlupdate+="DATA = '" + textstart.Text.Substring(6, 4) + "-" + textstart.Text.Substring(3, 2) + "-" + textstart.Text.Substring(0, 2) + "', "+
					"O = '" + button10.Text + "' " +
							"WHERE " +
					"ID = '" + iddenumire + "';";
				try{
					using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
						using(Global.cmd=new SQLiteCommand()){
					      	Global.cmd.Connection=Global.cnn;
					      	Global.cmd.CommandText=sqlupdate;
							Global.cmd.ExecuteNonQuery();
					      	Global.tranzactie.Commit();
					      	Global.cmd.Dispose();
						}
						Global.tranzactie.Dispose();
					}
				}catch(Exception err){
					Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			      	Global.tranzactie.Rollback();
				}
				incarcalistbox(Global.sqllista,textdenumire.Text,"");
				incarcadatagrid();
				break;
			case "STERGERE":
				string sqldelete = "DELETE FROM lista WHERE DENUMIRE = '" + textdenumire.Text + "';";
				try{
					using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
						using(Global.cmd=new SQLiteCommand()){
					      	Global.cmd.Connection=Global.cnn;
					      	Global.cmd.CommandText=sqldelete;
							Global.cmd.ExecuteNonQuery();
					      	Global.tranzactie.Commit();
					      	Global.cmd.Dispose();
						}
						Global.tranzactie.Dispose();
					}
				}catch(Exception err){
					Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			      	Global.tranzactie.Rollback();
				}
				incarcalistbox(Global.sqllista,"","");
				incarcadatagrid();
				break;
		}
		

		if((checkChelt.Checked==true | checkVenit.Checked==true) & lucru != "STERGERE"){
			uuid=Guid.NewGuid().ToString().ToUpper();
			string strsql="INSERT INTO cheltuieli (ID, DENUMIRE, MAGAZIN, DESCRIERE, AN, LUNA, ZIUA, VALOARE, SEMN) VALUES (";
			strsql+= "'" + uuid+"', ";
			strsql+= "'" + textdenumire.Text  + "'" + ", ";
			strsql+= "'" + textmagazin.Text  + "'" + ", ";
			strsql+= "'" + textum.Text  + "'" + ", ";
			strsql+= "" + Global.ancheltuieli  + "" + ", ";
			strsql+= "" + Global.lunacheltuieli  + "" + ", ";
			strsql+= "" + Global.zicheltuieli  + "" + ", ";
			strsql+= "" + textpret.Text.Replace(",",".")   + "" + ", ";
			strsql+= "'" + button10.Text   + "'" + ");";
			try{
				using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
						using(Global.cmd=new SQLiteCommand()){
					      	Global.cmd.Connection=Global.cnn;
					      	Global.cmd.CommandText=strsql;
							Global.cmd.ExecuteNonQuery();
					      	Global.tranzactie.Commit();
					      	Global.cmd.Dispose();
						}
						Global.tranzactie.Dispose();
					}
			}catch(Exception err){
				MessageBox.Show( err.InnerException + "\r\n" + err.Message + "\r\n" + err.StackTrace);
			}
		}
		
		checkChelt.Checked=false;
		checkVenit.Checked=false;
		
		radioButton1.AutoCheck = false;
		radioButton2.AutoCheck = false;
		radioButton3.AutoCheck = false;
		textdenumire.ReadOnly = true;
		textmagazin.ReadOnly=true;
		textscurt.ReadOnly =true;
		textum.ReadOnly = true;
		textpret.ReadOnly = true;
		checkNevoie.AutoCheck = false;
		checkActiv.AutoCheck=false;
		checkChelt.AutoCheck=false;
		checkVenit.AutoCheck=false;
		textstart.ReadOnly = true;
		textperioada.ReadOnly = true;
		button10.Enabled=false;

		if(listDenumiri.Items.Count>0){
		   	button2.Enabled = true;
		   	button3.Enabled = true;
		   	button4.Enabled = true;
		   	btnda.Enabled = false;
		   	btnnu.Enabled=false;
		}else{
			button2.Enabled = true;
			button3.Enabled = false;
			button4.Enabled = false;
			btnda.Enabled = false;
			btnnu.Enabled=false;
		}

		listDenumiri.Enabled = true;
		label7.Text="";
		gridactive.Enabled=true;
	}
	
	void BtnnuClick(object sender, EventArgs e)
		{
			citestedenumire();
			radioButton1.AutoCheck = false;
			radioButton2.AutoCheck = false;
			radioButton3.AutoCheck = false;
			textdenumire.ReadOnly = true;
			textmagazin.ReadOnly=true;
			textscurt.ReadOnly=true;
			textum.ReadOnly = true;
			textpret.ReadOnly = true;
			checkNevoie.AutoCheck = false;
			checkActiv.AutoCheck=false;
			checkChelt.AutoCheck=false;
			checkVenit.AutoCheck=false;
			textstart.ReadOnly = true;
			textperioada.ReadOnly = true;
			button10.Enabled=false;
	
			if(listDenumiri.Items.Count>0){
				button2.Enabled = true;
				button3.Enabled = true;
				button4.Enabled = true;
				btnda.Enabled = false;
				btnnu.Enabled = false;
			}
			else
			{
				button2.Enabled = true;
				button3.Enabled = false;
				button4.Enabled = false;
				btnda.Enabled = false;
				btnnu.Enabled = false;
			}

			listDenumiri.Enabled = true;
			gridactive.Enabled=true;
			label7.Text="";
			
			checkChelt.Checked=false;
			checkVenit.Checked=false;
		}
	void BtnactiveClick(object sender, EventArgs e)
		{
			incarcalistbox(Global.sqllista,"","DA");
		}
	void BtninactiveClick(object sender, EventArgs e)
		{
			incarcalistbox(Global.sqllista,"","NU");
		}
	void textcautadenumiri_keyup(object sender, KeyEventArgs e){
		if(e.KeyCode==Keys.Enter){
		   cautalistbox(textcautadenumiri.Text);
		}
		if (e.KeyData == (Keys.Control | Keys.F)){
			var cautarenoua=new cautafrm();
			cautarenoua.Show();
		}
		if (e.KeyData == (Keys.Control | Keys.E)){
			var executafrm=new sqlform();
			executafrm.Show();
		}
	}
	void textcautadenumiri_keydown(object sender, KeyEventArgs e){
		if(e.KeyCode==Keys.Enter){
			e.Handled = true;
        	e.SuppressKeyPress = true;
		}
		if (e.KeyData == (Keys.Control | Keys.F)){
			e.Handled = true;
        	e.SuppressKeyPress = true;
		}
		if (e.KeyData == (Keys.Control | Keys.E)){
			e.Handled = true;
        	e.SuppressKeyPress = true;
		}
		
	}
	void ListDenumiriSelectedIndexChanged(object sender, EventArgs e)
		{
			citestedenumire();
			totalcheltuieli(); 
		}
	void ListDenumiriKeyUp(object sender, KeyEventArgs e){
		if (e.KeyData == (Keys.Control | Keys.F)){
			var cautarenoua=new cautafrm();
			cautarenoua.Show();
		}
	}
	
	void GridactiveCellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex==-1)
			{
				cautaMagazin(
								gridactive.Rows[0].Cells[0].Value.ToString(),
								gridactive.Rows[0].Cells[1].Value.ToString()
							);
				//cautalistbox(gridactive.Rows[0].Cells[0].Value.ToString()+"."+gridactive.Rows[e.RowIndex].Cells[1].Value.ToString());
			}else{
				cautaMagazin(
					gridactive.Rows[e.RowIndex].Cells[0].Value.ToString(),
					gridactive.Rows[e.RowIndex].Cells[1].Value.ToString()
				);
				//cautalistbox(gridactive.Rows[e.RowIndex].Cells[0].Value.ToString()+"."+gridactive.Rows[e.RowIndex].Cells[1].Value.ToString());
			}
			//checkChelt.Checked=false;
		}
	void CheckNevoieCheckedChanged(object sender, EventArgs e)
		{
			if(checkNevoie.Checked ==false & button10.Text=="-" & lucru!=string.Empty){
				checkChelt.Checked=true;
				checkVenit.Checked=false;
			}else if(checkNevoie.Checked ==false & button10.Text=="+"){
				checkChelt.Checked=false;
				checkVenit.Checked=true;
			}else{
				checkChelt.Checked =false ;
				checkVenit.Checked=false;
			}
		}
	void totalcheltuieli(){
        textExport.Text = makeemailbody("1") + nrzilerestplata.Text.PadLeft(52);
    }
	public void incarcalistbox(string strsql, string denumire, string activ){
		int x = 0;
		string strdenumiri;
		bool gasitdenumire = false;
		int gasitla=0;
		listDenumiri.Items.Clear();
		
		if(strsql==""){
			strdenumiri = "SELECT t.DENUMIRE, t.MAGAZIN, t.SCURT, t.O FROM lista t ORDER BY t.PRIORITATE, t.DENUMIRE, t.VALOARE;";
			if(activ=="DA"){
				strdenumiri = "SELECT t.DENUMIRE, t.MAGAZIN, t.SCURT, t.O FROM lista t WHERE t.ACTIV=1 ORDER BY t.PRIORITATE, t.DENUMIRE, t.VALOARE;";
			}
			if(activ=="NU"){
				strdenumiri = "SELECT t.DENUMIRE, t.MAGAZIN, t.SCURT, t.O FROM lista t WHERE t.ACTIV=0 ORDER BY t.PRIORITATE, t.DENUMIRE, t.VALOARE;";
			}
			if(activ==""){
				strdenumiri = "SELECT t.DENUMIRE, t.MAGAZIN, t.SCURT, t.O FROM lista t ORDER BY t.PRIORITATE, t.DENUMIRE, t.VALOARE;";
			}
		}else{
			strdenumiri=strsql;
		}
		
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=strdenumiri;
					//MessageBox.Show(strdenumiri);
					using(Global.dr=Global.cmd.ExecuteReader()){
						while (Global.dr.Read()){
							listDenumiri.Items.Add(Global.dr["O"].ToString()+"."+Global.dr["DENUMIRE"].ToString());
							textcautadenumiri.AutoCompleteCustomSource.Add(Global.dr["O"].ToString()+"."+Global.dr["DENUMIRE"].ToString());
							//textcautadenumiri.AutoCompleteCustomSource.Add(Global.dr["DENUMIRE"].ToString());
							textdenumire.AutoCompleteCustomSource.Add(Global.dr["DENUMIRE"].ToString());
							textmagazin.AutoCompleteCustomSource.Add(Global.dr["MAGAZIN"].ToString());
							textscurt.AutoCompleteCustomSource.Add(Global.dr["SCURT"].ToString());
							//textmagazin.AutoCompleteCustomSource.Add(Global.dr["MAGAZIN"].ToString());
							
							if (Global.dr["DENUMIRE"].ToString()==denumire){
								gasitla=x;
								gasitdenumire = true;
							}
							x++;	
						}
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
			
			if(gasitdenumire==true){
				listDenumiri.SelectedIndex = gasitla;
			}
			
			if(gasitdenumire==false && listDenumiri.Items.Count>0 ){
				listDenumiri.SelectedIndex = 0;
			}

			Global.sqllista=strsql;
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
	}
	private void cautaMagazin(string semn, string denumireaAsta){
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				string sqlMagazin="";
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText="SELECT t.MAGAZIN FROM lista t WHERE t.DENUMIRE='" + denumireaAsta + "';";
					using(Global.dr=Global.cmd.ExecuteReader()){
						if(Global.dr.Read()){
							sqlMagazin="SELECT t.DENUMIRE, t.MAGAZIN, t.SCURT, t.O FROM lista t "
							+ "WHERE t.MAGAZIN='" + Global.dr["MAGAZIN"].ToString() + "' "
							+ "ORDER BY t.PRIORITATE, t.DENUMIRE, t.VALOARE;";
							Console.WriteLine(sqlMagazin);
							incarcalistbox(sqlMagazin, denumireaAsta, "DA");	
						}
							
						
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
	}
	private void cautalistbox(string denumireaasta)
        {
			for (int x = 0; x <= listDenumiri.Items.Count-1; x++)
			{
			//if(listDenumiri.Items[x].ToString()=="-."+denumireaasta | listDenumiri.Items[x].ToString()=="+."+denumireaasta){
			if(listDenumiri.Items[x].ToString()==denumireaasta){
				listDenumiri.SelectedIndex = x;
				break;
			}
			}
        }
	void incarcadatagrid()
        {
		string strdenumiri;
		gridactive.Rows.Clear();
		strdenumiri = "SELECT lista.O, "+
						"lista.DENUMIRE, " +
						"lista.PRIORITATE, " +
						"lista.valoare, " +
						"lista.DATA, " +
						"lista.PERIOADA, " +
						"lista.ACTIV " +
				"FROM lista WHERE " +
						"lista.NEVOIE=1 AND " +
						"lista.ACTIV=1 " +
				"ORDER BY lista.PRIORITATE, lista.PERIOADA;";
           
		gridactive.RowsDefaultCellStyle.BackColor = Color.White;
		gridactive.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
		int i = 0;
		DateTime dataStart;
		
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=strdenumiri;
					using(Global.dr=Global.cmd.ExecuteReader()){
						while (Global.dr.Read()){
							gridactive.Rows.Add();
	
							gridactive.Rows[i].Cells[0].Value = Global.dr[0].ToString();
						   	gridactive.Rows[i].Cells[1].Value = Global.dr[1].ToString();
						   	gridactive.Rows[i].Cells[2].Value = Global.dr[2].ToString();
						   	gridactive.Rows[i].Cells[3].Value = Global.dr[3].ToString();
						   	dataStart = (DateTime)Global.dr[4];
						   	gridactive.Rows[i].Cells[4].Value = dataStart.ToShortDateString();
						   	
						   	gridactive.Rows[i].Cells[5].Value = Global.dr[5].ToString();
						   	i++;
						}
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
    }
	private void citestedenumire()
        {
		string strDenumireSel;
		DateTime strDataSart;
		strDenumireSel = "SELECT lista.* from lista WHERE lista.DENUMIRE='" + listDenumiri.Text.Substring(2) + "';";
		
		nrcitestedenumire=nrcitestedenumire+1;
		
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=strDenumireSel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						Global.dr.Read();
							
						//###################################################################
						radioButton1.AutoCheck = true;
						radioButton2.AutoCheck = true;
						radioButton3.AutoCheck = true;
						
						iddenumire = Global.dr["ID"].ToString();
						switch (Global.dr["PRIORITATE"].ToString()){
							case "1":
								radioButton1.Checked = true;
								break;
							case "2":
								radioButton2.Checked = true;
								break;
							case "3":
								radioButton3.Checked = true;
								break;
						}
						radioButton1.AutoCheck = false;
						radioButton2.AutoCheck = false;
						radioButton3.AutoCheck = false;
						
						textdenumire.Text = Global.dr["DENUMIRE"].ToString();
						textmagazin.Text = Global.dr["MAGAZIN"].ToString();
						textscurt.Text = Global.dr["SCURT"].ToString();
						textum.Text = Global.dr["DESCRIERE"].ToString();
						textpret.Text = Global.dr["VALOARE"].ToString();
						if (Global.dr["NEVOIE"].ToString() == "1"){
							checkNevoie.Checked = true;
						}else{
							checkNevoie.Checked = false;
						}
						if (Global.dr["ACTIV"].ToString() == "1"){
							checkActiv.Checked = true;
						}else{
							checkActiv.Checked = false;
						}
						strDataSart = (DateTime)Global.dr["DATA"];
						textstart.Text = strDataSart.ToShortDateString();
						textperioada.Text = Global.dr["PERIOADA"].ToString();
						button10.Text=Global.dr["O"].ToString();
						//###################################################################
						
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}

		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
       }
	string makeemailbody(string prior)
        {
		//'double dblResult=0;
		string strreturn;
		string sqlsel;
		decimal totalLunaDen=0;

		//prioritate 1 perioadă zi
		strreturn = prior + ".--------------------------------\r\n";
		sqlsel = "SELECT lista.* FROM lista WHERE lista.PRIORITATE='" + prior + "' AND lista.NEVOIE=1 AND lista.ACTIV=1 AND lista.PERIOADA='1. zi';";
		//Debug.Print(sqlsel);
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						strreturn = strreturn + "zilnice: \r\n";
						while (Global.dr.Read()){
							totalLunaDen=ptnrzile * decimal.Parse(Global.dr["VALOARE"].ToString());
							strreturn+= " " + Global.dr["DENUMIRE"].ToString().PadRight(20) + string.Format("{0:0.00}", decimal.Parse(Global.dr["VALOARE"].ToString())).PadLeft(7);
							strreturn+= " " + "lei. lună: " + string.Format("{0:0.00}", (totalLunaDen)).PadLeft(7)  + " lei. \r\n";
						}
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		
		sqlsel = "SELECT ROUND(SUM(VALOARE),2) as TOT FROM lista WHERE PRIORITATE=" + prior + " AND NEVOIE=1 AND ACTIV=1 AND PERIOADA='1. zi';";
		//Debug.Print(sqlsel);
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						Global.dr.Read();
						//#####################################################################
						if (string.IsNullOrEmpty(Global.dr[0].ToString())){
							totalzi = 0;
						}else{
							totalzi = decimal.Parse(Global.dr[0].ToString());
						}
								
						totallunadinzi= ptnrzile*totalzi;
						strreturn+= " " + "total/zi".PadRight(20) + string.Format("{0:0.00}",totalzi).PadLeft(7);
						strreturn+= " " + "lei. lună: " + string.Format("{0:0.00}",totallunadinzi).PadLeft(7) + " lei. \r\n";
						//#####################################################################
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		
		//####################################  2. 3 zile  ##########################################
		sqlsel = "SELECT lista.* FROM lista WHERE lista.PRIORITATE=1 AND lista.NEVOIE=1 AND lista.ACTIV=1 AND lista.PERIOADA='2. 3 zile';";
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						strreturn = strreturn + "2 - 3 zile: \r\n";
						while (Global.dr.Read()){
							totalLunaDen=(ptnrzile/3)*decimal.Parse(Global.dr["VALOARE"].ToString());
							strreturn+= " " + Global.dr["DENUMIRE"].ToString().PadRight(20) + string.Format("{0:0.00}", decimal.Parse(Global.dr["VALOARE"].ToString())).PadLeft(7);
							strreturn+= " " + "lei. lună: " + string.Format("{0:0.00}", (totalLunaDen)).PadLeft(7)  + " lei. \r\n";
						}
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		
		sqlsel = "SELECT ROUND(SUM(VALOARE),2) AS TOT FROM lista WHERE PRIORITATE=" + prior + " AND NEVOIE=1 AND ACTIV=1 AND PERIOADA='2. 3 zile';";
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						Global.dr.Read();
						//#####################################################################
						if (string.IsNullOrEmpty(Global.dr[0].ToString())){
							totalzi = 0;
						}else{
							totalzi = decimal.Parse(Global.dr[0].ToString());
						}
								
						totallunadin3zile= ptnrzile/3*totalzi;
						strreturn+= " " + "total/la 3 zile".PadRight(20) + string.Format("{0:0.00}",totalzi).PadLeft(7);
						strreturn+= " " + "lei. lună: " + string.Format("{0:0.00}",totallunadin3zile).PadLeft(7) + " lei. \r\n";
						//#####################################################################
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		//###########################################################################################
		//####################################  7 zile  ##########################################
		sqlsel = "SELECT lista.* FROM lista WHERE PERIOADA='3. săptămână' AND lista.PRIORITATE=" + prior + " AND NEVOIE=1 AND ACTIV=1;";
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						strreturn = strreturn + "săptămânale: \r\n";
						while (Global.dr.Read()){
							totalLunaDen=nrsaptamani*decimal.Parse(Global.dr["VALOARE"].ToString());
							strreturn+= " " + Global.dr["DENUMIRE"].ToString().PadRight(20) + string.Format("{0:0.00}",Global.dr["VALOARE"]).PadLeft(7);
							strreturn+= " " + "lei. lună: " + string.Format("{0:0.00}", (totalLunaDen)).PadLeft(7)  + " lei. \r\n";
						}
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		
		sqlsel = "SELECT ROUND(SUM(VALOARE),2) AS TOT FROM lista WHERE PRIORITATE='" + prior + "' AND NEVOIE=1 AND ACTIV=1 AND PERIOADA='3. săptămână';";
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						Global.dr.Read();
						//#####################################################################
						if (string.IsNullOrEmpty(Global.dr[0].ToString())){
							totalsaptamana = 0;
						}else{
							totalsaptamana = decimal.Parse(Global.dr[0].ToString());
						}
						totallunadinsaptamana = nrsaptamani * totalsaptamana;
									
						strreturn+=  " " + "total/săptămână".PadRight(20) + string.Format("{0:0.00}",totalsaptamana).PadLeft(7) ;		
						strreturn+= " " + "lei. lună: " + string.Format("{0:0.00}",totallunadinsaptamana).PadLeft(7) + " lei. \r\n";
						//#####################################################################
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		//###########################################################################################
		//####################################  30 zile  ############################################
		sqlsel = "SELECT lista.* FROM lista WHERE lista.PRIORITATE=" + prior + " AND lista.NEVOIE=1 AND lista.PERIOADA='4. lună' AND lista.ACTIV=1;";
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						strreturn = strreturn + "lunare: \r\n";
						while (Global.dr.Read()){
							strreturn = strreturn + "  " + Global.dr["DENUMIRE"].ToString().PadRight(20) + string.Format("{0:0.00}",Global.dr["VALOARE"]).PadLeft(7) + " lei." + "\r\n";
						}
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		
		sqlsel = "SELECT ROUND(SUM(VALOARE),2) AS TOT FROM lista WHERE PRIORITATE=" + prior + " AND lista.NEVOIE=1 AND lista.PERIOADA='4. lună' AND lista.ACTIV=1;";
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						Global.dr.Read();
						//#####################################################################
						if (string.IsNullOrEmpty(Global.dr[0].ToString())){
							totalluna = 0;
						}else{
							totalluna = decimal.Parse(Global.dr[0].ToString());
						}
						strreturn = strreturn + "  " + "total/lună".PadRight(20) + string.Format("{0:0.00}",totalluna).PadLeft(7) + " lei. \r\n";
						//#####################################################################
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		//###########################################################################################
		//####################################  ocazional  ############################################
		sqlsel = "SELECT lista.* FROM lista WHERE lista.PRIORITATE=" + prior + " AND lista.NEVOIE=1 AND lista.PERIOADA='6. ocazional' AND lista.ACTIV=1;";
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						strreturn = strreturn + "ocazional: \r\n";
						while (Global.dr.Read()){
							strreturn = strreturn + "  " + Global.dr["DENUMIRE"].ToString().PadRight(20) + string.Format("{0:0.00}",Global.dr["VALOARE"]).PadLeft(7) + " lei." + "\r\n";
						}
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		
		sqlsel = "SELECT ROUND(SUM(VALOARE),2) AS TOT FROM lista WHERE lista.PRIORITATE=" + prior + " AND lista.NEVOIE=1 AND lista.PERIOADA='6. ocazional' AND lista.ACTIV=1;";
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						Global.dr.Read();
						//#####################################################################
						if (string.IsNullOrEmpty(Global.dr[0].ToString())){
							totalocazional = 0;
						}else{
							totalocazional = decimal.Parse(Global.dr[0].ToString());
						}
						strreturn = strreturn + "  " + "total/ocazional".PadRight(20) + string.Format("{0:0.00}",totalocazional).PadLeft(7) + " lei. \r\n";
						//#####################################################################
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		//###########################################################################################
		//#################################  tot general lună  ######################################
		decimal totalgeneral = 0;
		totalgeneral = totallunadinzi + totallunadin3zile + totallunadinsaptamana + totalluna+totalocazional;
				
		strreturn = strreturn + "total lunar general: \r\n";
		strreturn = strreturn + "  " + " ".PadRight(20) + string.Format("{0:0.00}", totalgeneral).PadLeft(7) + " lei. \r\n";
		//###########################################################################################
		//####################################  perioadă an  ########################################
		sqlsel = "SELECT lista.* FROM lista WHERE lista.PRIORITATE=" + prior + " AND lista.NEVOIE=1 AND lista.PERIOADA='5. an' AND lista.ACTIV=1";
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						strreturn = strreturn + "anuale: \r\n";
						while (Global.dr.Read()){
							strreturn = strreturn + "  " + Global.dr["DENUMIRE"].ToString().PadRight(20) + string.Format("{0:0.00}",Global.dr["VALOARE"]).PadLeft(7) + " lei." + "\r\n";
						}
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		
		sqlsel = "SELECT ROUND(SUM(VALOARE),2) AS TOT FROM lista WHERE lista.PRIORITATE=" + prior + " AND lista.NEVOIE=1 AND lista.PERIOADA='5. an' AND lista.ACTIV=1;";
		try{
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText=sqlsel;
					using(Global.dr=Global.cmd.ExecuteReader()){
						Global.dr.Read();
						//#####################################################################
						strreturn = strreturn + "  " + "total".PadRight(20) + string.Format("{0:0.00}",Global.dr[0]).PadLeft(7) + " lei. \r\n";
						//#####################################################################
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
			}
		}catch(Exception err){
			Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
			Global.tranzactie.Rollback();
		}
		return strreturn;
	}
	void autocomplet()
        {
		textperioada.AutoCompleteCustomSource.Add("1. zi");
		textperioada.AutoCompleteCustomSource.Add("2. 3 zile");
		textperioada.AutoCompleteCustomSource.Add("3. săptămână");
		textperioada.AutoCompleteCustomSource.Add("4. 2 săptămâni");
		textperioada.AutoCompleteCustomSource.Add("5. lună");
		textperioada.AutoCompleteCustomSource.Add("6. an");
		textperioada.AutoCompleteCustomSource.Add("7. ocazional");
		textperioada.AutoCompleteCustomSource.Add("8. memento");
	}
	void nrzile(){
		string strsql="";
		
		DateTime azi=DateTime.Now;
		bool azibool=false;
		nrzileramase=0;

		if (azi.Day == 5){
			azibool=true;
			strsql = "SELECT julianday(date('now','start of month','+1 month','+4 day')) - julianday(date('now','-1 day'));";
		}else if (azi < DateTime.Parse("5." + azi.Month.ToString() + "." + azi.Year.ToString())){
			azibool=false;
			strsql = "SELECT julianday(date('now','start of month','+4 day')) - julianday(date('now','-1 day'));";
		}else{
			azibool=false;
			strsql = "SELECT julianday(date('now','start of month','+1 month','+4 day')) - julianday(date('now','-1 day'));;";
		}
		
		if(azibool==false){
			try{
				using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
					using(Global.cmd=new SQLiteCommand()){
						Global.cmd.Connection=Global.cnn;
						Global.cmd.CommandText=strsql;
						using(Global.dr=Global.cmd.ExecuteReader()){
							Global.dr.Read();
							//#####################################################################
							nrzileramase = int.Parse(Global.dr[0].ToString());
							ptnrzile=nrzileramase;
							//#####################################################################
							Global.dr.Close();
						}
						Global.cmd.Dispose();
					}
					Global.tranzactie.Dispose();
				}
			}catch(Exception err){
				Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
				Global.tranzactie.Rollback();
			}
		}else{
			try{
				using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
					using(Global.cmd=new SQLiteCommand()){
						Global.cmd.Connection=Global.cnn;
						Global.cmd.CommandText=strsql;
						using(Global.dr=Global.cmd.ExecuteReader()){
							Global.dr.Read();
							//#####################################################################
							nrzileramase = int.Parse(Global.dr[0].ToString());
							ptnrzile=nrzileramase;
							//#####################################################################
							Global.dr.Close();
						}
						Global.cmd.Dispose();
					}
					Global.tranzactie.Dispose();
				}
			}catch(Exception err){
				Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
				Global.tranzactie.Rollback();
			}
		}

		if (ptnrzile % 7 > 0){
		   nrsaptamani = (int)(ptnrzile / 7) + 1;
		}else{
		   nrsaptamani = (int)(ptnrzile / 7);
		}
      		
		if(nrzileramase==0){
			nrzilerestplata.Text="astăzi rest de plată pt " + ptnrzile + " zile.";
		}else{
			nrzilerestplata.Text = nrzileramase.ToString() + " zile până la rest de plată.";
      	}
      }
		void Button10Click(object sender, EventArgs e)
		{
			if(button10.Text=="-"){
				button10.Text="+";
			}else{
				button10.Text="-";
			}
		}
		void BtntoateClick(object sender, EventArgs e)
		{
			//Global.sqllista="SELECT t.ID, t.PRIORITATE, t.DENUMIRE, t.MAGAZIN, t.SCURT, t.DESCRIERE, t.VALOARE, t.NEVOIE, t.PERIOADA, t.DATA, t.ACTIV, t.O FROM lista t ORDER BY t.PRIORITATE, t.DENUMIRE, t.VALOARE;";
			Global.sqllista="SELECT t.DENUMIRE, t.MAGAZIN, t.SCURT, t.O FROM lista t ORDER BY t.PRIORITATE, t.DENUMIRE, t.VALOARE;";
			incarcalistbox(Global.sqllista,"","DA");
		}
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			datachelt setezdata=new datachelt();
			setezdata.Visible=true;
		}
		void TextumTextChanged(object sender, EventArgs e)
		{
			// TODO: Implement TextumTextChanged
			string text=textum.Text;
			int start=0;
			string valoare="";
			char charT;
			bool acum=false;
			if(text.Length>0){
				for(int x=0;x<text.Length ;x++){
					if(text.Substring(x,1)==@"/"){
						acum=true;
						start=x;
					}
				}
				for(int i=start;i<text.Length;i++){
					charT=Convert.ToChar(text.Substring(i,1));
					if(acum=true && (Char.IsNumber(charT) || text.Substring(i,1)=="," || text.Substring(i,1)==".")){
						valoare+=text.Substring(i,1);
					}
				}
			}
			textpret.Text=valoare;
			acum=false ;
		}
		
		void TextDenumireGotFocus(object sender, EventArgs e)
		{
			string charsright="";
			if(textdenumire.Text.Length>3){
				charsright=textdenumire.Text.Substring(textdenumire.Text.Length -3,3);
			}
			if(lucru=="ADAUGARE" & charsright!=textscurt.Text){
				textdenumire.Text +="." + textscurt.Text;
				textdenumire.SelectionStart=0;
			}
			charsright="";
		}
		void textmagazinLostFocus(object sender, EventArgs e)
		{
			string sqlSelScurt="SELECT SCURT FROM lista t WHERE t.MAGAZIN='" + textmagazin.Text + "';";
			if(lucru=="ADAUGARE"){
				textdenumire.Text ="";
			}
			
			try{
				using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
					using(Global.cmd=new SQLiteCommand()){
						Global.cmd.Connection=Global.cnn;
						Global.cmd.CommandText=sqlSelScurt;
						using(Global.dr=Global.cmd.ExecuteReader()){
							if(Global.dr.Read()){
								textscurt.Text =Global.dr["SCURT"].ToString();
							}else{
								textscurt.Text ="";
							}
							Global.dr.Close();
						}
						Global.cmd.Dispose();
					}
					Global.tranzactie.Dispose();
				}
			}catch(Exception err){
				Debug.Print("GetType:"+err.GetType().Name+"\r\n Source:"+ err.Source + "\r\n Message:" + err.Message + "\r\n StackTrace:" + err.StackTrace);
				Global.tranzactie.Rollback();
			}
		}
		
		void textpret_KeyPress(object sender, KeyPressEventArgs e)
		{
		    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
		        (e.KeyChar != '.' && e.KeyChar != ','))
		    {
		            e.Handled = true;
		    }
		
		    // only allow one decimal point
		    if (
		    	(
		    		e.KeyChar == '.' 
		    		||
		    		e.KeyChar==','
		    	) 
		    	&&
		    	(
		    		(sender as TextBox).Text.IndexOf('.') > -1 
		    		||
		    		(sender as TextBox).Text.IndexOf(',') > -1
		    	)
		    )
		    	
		    {
		        e.Handled = true;
		    }
		   
		}

    }
}