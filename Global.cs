using System;
using System.Diagnostics;
using System.IO;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace cheltuieli
{
    static class Global
    {
        static string _ancheltuieli="";
		static string _lunacheltuieli="";
		static string _zicheltuieli="";
		
		static string _user = "";
		static string _password= "";
		static string _id="";
		//static string _sqllista="SELECT a.ID, a.PRIORITATE, a.DENUMIRE, a.MAGAZIN, a.SCURT, a.DESCRIERE, a.VALOARE, a.NEVOIE, a.PERIOADA, a.DATA, a.ACTIV, a.O FROM lista a ORDER BY a.PRIORITATE, a.DENUMIRE, a.VALOARE;";
		
        //static string _sqllista="";
        static string _sqllista=Global.GetSetting("sql");
		
		static string _eroare="";
		
		static bool _conectat=false;
		
		public static frmCheltuieli frmruleaza;
		
		public static SQLiteConnection cnn;
		public static SQLiteTransaction tranzactie;
		public static SQLiteCommand cmd;
		public static SQLiteDataReader dr;
		
		public static string sqllista
    		{
        		get { return _sqllista; }
        		set { _sqllista = value; }
    		}
		public static string ancheltuieli
    		{
        		get { return _ancheltuieli; }
        		set { _ancheltuieli = value; }
    		}
		public static string lunacheltuieli
    		{
        		get { return _lunacheltuieli; }
        		set { _lunacheltuieli = value; }
    		}
		public static string zicheltuieli
    		{
        		get { return _zicheltuieli; }
        		set { _zicheltuieli = value; }
    		}
		public static string username
    		{
        		get { return _user; }
        		set { _user = value; }
    		}
		public static string password
    		{
        		get { return _password; }
        		set { _password = value; }
    		}
		public static string id
    		{
        		get { return _id; }
        		set { _id = value; }
    		}
		public static string eroare
    		{
        		get { return _eroare; }
        		set { _eroare = value; }
    		}
		public static bool conectat
    		{
        		get { return _conectat; }
    		}
		public static bool  conectare(){
			var strBuilder=new SQLiteConnectionStringBuilder();
			strBuilder.DataSource=AppDomain.CurrentDomain.BaseDirectory + "cheltuieli.db";
			strBuilder.Version=3;
			strBuilder.WaitTimeout=30;
			strBuilder.UseUTF16Encoding=true;
			strBuilder.Pooling=true;
			strBuilder.PageSize=1024;
			
			try{
				cnn=new SQLiteConnection(strBuilder.ConnectionString);
				cnn.Open();

				_conectat=true;
			 	return true; 
			}catch(Exception ex){
				Debug.Print(ex.Message);
				_conectat=false;
			 	return false; 
			}
		}
		
		public static bool deconectare(){
			cnn.Close();
			cnn.Dispose();
			_conectat=false;
			return true;
		}
		
		
		public static string exportsql(string tablename){
			string insertsql="";
			string strreturnat;
			bool primul=true;
			using(Global.tranzactie=Global.cnn.BeginTransaction(IsolationLevel.Serializable)){
				
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText="SELECT sql FROM main.sqlite_master WHERE name='" + tablename + "';";
					//Debug.Print("SELECT sql FROM main.sqlite_master WHERE name='" + tablename + "';");
					using(Global.dr=Global.cmd.ExecuteReader()){
						Global.dr.Read();
						
						insertsql=dr["sql"].ToString();
						dr.Close();
						insertsql+=";";
						//Debug.Print(insertsql);
						strreturnat=insertsql;
					}
					cmd.Dispose();
				}
				
				using(Global.cmd=new SQLiteCommand()){
					Global.cmd.Connection=Global.cnn;
					Global.cmd.CommandText="SELECT * FROM " + tablename + ";";
					using(Global.dr=Global.cmd.ExecuteReader()){
						while (Global.dr.Read()){
							insertsql="INSERT INTO "+tablename+" VALUES(";
							primul=true;
							for(int x=0;x<dr.FieldCount;x++){
								if(primul==false){
									insertsql+=", ";
								}
								
								switch(dr.GetFieldType(x).ToString()){
									case "System.String":
										insertsql+="'" + dr.GetValue(x).ToString() + "'";
										break;
									case "System.Int16":
										insertsql+= dr.GetValue(x).ToString() ;
										break;
									case "System.DateTime":
										
										try{
											insertsql+="'" + ((DateTime)dr.GetValue(x)).ToShortDateString() + "'";
											//Debug.Print(dr.GetValue(x).ToString());
										}catch(Exception e){
											Debug.Print(e.Message);
										}
										break;
									case "System.Byte":
										insertsql+="" + dr.GetValue(x).ToString() + "";
										break;
									case "System.Decimal":
										insertsql+="" + dr.GetValue(x).ToString().Replace(",",".") + "";
										break;
								}
								primul=false;
							}
							insertsql+=");\r\n";
							//Debug.Print(insertsql);
							strreturnat+=insertsql;
						}
						
						Global.dr.Close();
					}
					Global.cmd.Dispose();
				}
				Global.tranzactie.Dispose();
				return strreturnat;
			}
		}
		public static bool scriebackup(string strcontinutsql){
			string strfisier=DateTime.Now.Day.ToString().PadLeft(2,'0')+"."+DateTime.Now.Month.ToString().PadLeft(2,'0')+"."+DateTime.Now.Year.ToString().PadLeft(4,'0')+"."+DateTime.Now.Hour.ToString().PadLeft(2,'0')+"."+DateTime.Now.Minute.ToString().PadLeft(2,'0');
			using (var fisier = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory+ @"backups\" + strfisier+ ".sql")){
				fisier.Write(strcontinutsql);
				return true;
			}
		}
		
		static Global(){
			_zicheltuieli=DateTime.Now.Day.ToString().PadLeft(2,'0');
			_lunacheltuieli=DateTime.Now.Month.ToString().PadLeft(2,'0');
			_ancheltuieli+=DateTime.Now.Year.ToString().PadLeft(4,'0');
		}
		
		public static string GetSetting(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}

		public static void SetSetting(string key, string value)
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			//make changes
			config.AppSettings.Settings[key].Value = value;
			
			
			//save to apply changes
			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
			
			Debug.Print(GetSetting(key));
		}
    }
}
