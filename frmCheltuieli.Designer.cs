namespace cheltuieli
{
    partial class frmCheltuieli
    {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ListBox listDenumiri;
	private System.Windows.Forms.TextBox textemail;
	private System.Windows.Forms.DataGridView gridactive;
	private System.Windows.Forms.DataGridViewTextBoxColumn denumire;
	private System.Windows.Forms.DataGridViewTextBoxColumn prioritate;
	private System.Windows.Forms.DataGridViewTextBoxColumn pret;
	private System.Windows.Forms.DataGridViewTextBoxColumn start;
	private System.Windows.Forms.DataGridViewTextBoxColumn perioada;
	private System.Windows.Forms.Button button6;
	private System.Windows.Forms.Panel panel1;
	private System.Windows.Forms.Label label6;
	private System.Windows.Forms.TextBox textcautadenumiri;
	private System.Windows.Forms.Label nrzilerestplata;
	private System.Windows.Forms.Button button9;
	private System.Windows.Forms.TextBox textExport;
	private System.Windows.Forms.MaskedTextBox textstart;
	private System.Windows.Forms.Label label7;
	private System.Windows.Forms.Button btnactive;
	private System.Windows.Forms.Button btninactive;
	private System.Windows.Forms.Button btnnu;
	private System.Windows.Forms.Button btnda;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.Button button2;
	private System.Windows.Forms.Button button3;
	private System.Windows.Forms.Button button4;
	private System.Windows.Forms.Button button8;
	private System.Windows.Forms.Button button7;
	private System.Windows.Forms.Button button5;
	private System.Windows.Forms.RadioButton radioButton1;
	private System.Windows.Forms.RadioButton radioButton2;
	private System.Windows.Forms.RadioButton radioButton3;
	private System.Windows.Forms.TextBox textdenumire;
	private System.Windows.Forms.TextBox textscurt;
	private System.Windows.Forms.TextBox textmagazin;
	private System.Windows.Forms.TextBox textperioada;
	private System.Windows.Forms.TextBox textum;
	private System.Windows.Forms.TextBox textpret;
	private System.Windows.Forms.CheckBox checkActiv;
	private System.Windows.Forms.CheckBox checkChelt;
	private System.Windows.Forms.CheckBox checkNevoie;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label9;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.CheckBox checkVenit;
	private System.Windows.Forms.Button button10;
	private System.Windows.Forms.DataGridViewTextBoxColumn O;
	private System.Windows.Forms.Button btntoate;
	public System.Windows.Forms.LinkLabel linkLabel1;
	private System.Windows.Forms.Label label3;
	
	protected override void Dispose(bool disposing){
		if (disposing) {
			if (components != null) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

		void InitializeComponent(){
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

			//System.Drawing.Icon myicon = new System.Drawing.Icon(System.AppDomain.CurrentDomain.BaseDirectory + "icon.ico");
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheltuieli));
			
			this.listDenumiri = new System.Windows.Forms.ListBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.textdenumire = new System.Windows.Forms.TextBox();
			this.textscurt = new System.Windows.Forms.TextBox();
			this.textmagazin = new System.Windows.Forms.TextBox();
			this.textum = new System.Windows.Forms.TextBox();
			this.textpret = new System.Windows.Forms.TextBox();
			this.checkNevoie = new System.Windows.Forms.CheckBox();
			this.textperioada = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.gridactive = new System.Windows.Forms.DataGridView();
			this.O = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.denumire = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.prioritate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pret = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.perioada = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.textemail = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.button10 = new System.Windows.Forms.Button();
			this.checkVenit = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.button9 = new System.Windows.Forms.Button();
			this.checkChelt = new System.Windows.Forms.CheckBox();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.btnnu = new System.Windows.Forms.Button();
			this.btnda = new System.Windows.Forms.Button();
			this.textstart = new System.Windows.Forms.MaskedTextBox();
			this.textExport = new System.Windows.Forms.TextBox();
			this.nrzilerestplata = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.checkActiv = new System.Windows.Forms.CheckBox();
			this.textcautadenumiri = new System.Windows.Forms.TextBox();
			this.btnactive = new System.Windows.Forms.Button();
			this.btninactive = new System.Windows.Forms.Button();
			this.btntoate = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridactive)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listDenumiri
			// 
			this.listDenumiri.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.listDenumiri.FormattingEnabled = true;
			this.listDenumiri.ItemHeight = 16;
			this.listDenumiri.Location = new System.Drawing.Point(3, 69);
			this.listDenumiri.Name = "listDenumiri";
			this.listDenumiri.Size = new System.Drawing.Size(219, 644);
			this.listDenumiri.TabIndex = 0;
			this.listDenumiri.SelectedIndexChanged += new System.EventHandler(this.ListDenumiriSelectedIndexChanged);
			this.listDenumiri.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListDenumiriKeyUp);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.radioButton1.Location = new System.Drawing.Point(43, 0);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(95, 21);
			this.radioButton1.TabIndex = 2;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "prioritate 1";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.radioButton2.Location = new System.Drawing.Point(43, 27);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(95, 21);
			this.radioButton2.TabIndex = 3;
			this.radioButton2.Text = "prioritate 2";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.radioButton3.Location = new System.Drawing.Point(43, 54);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(95, 21);
			this.radioButton3.TabIndex = 4;
			this.radioButton3.Text = "prioritate 3";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// textdenumire
			// 
			this.textdenumire.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.textdenumire.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textdenumire.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textdenumire.Location = new System.Drawing.Point(231, 37);
			this.textdenumire.MaxLength = 20;
			this.textdenumire.Name = "textdenumire";
			this.textdenumire.Size = new System.Drawing.Size(189, 23);
			this.textdenumire.TabIndex = 13;
			this.textdenumire.GotFocus += new System.EventHandler(this.TextDenumireGotFocus);
			// 
			// textscurt
			// 
			this.textscurt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.textscurt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textscurt.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textscurt.Location = new System.Drawing.Point(368, 9);
			this.textscurt.MaxLength = 20;
			this.textscurt.Name = "textscurt";
			this.textscurt.Size = new System.Drawing.Size(52, 23);
			this.textscurt.TabIndex = 12;
			// 
			// textmagazin
			// 
			this.textmagazin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.textmagazin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textmagazin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textmagazin.Location = new System.Drawing.Point(231, 9);
			this.textmagazin.MaxLength = 20;
			this.textmagazin.Name = "textmagazin";
			this.textmagazin.Size = new System.Drawing.Size(135, 23);
			this.textmagazin.TabIndex = 11;
			this.textmagazin.LostFocus += new System.EventHandler(this.textmagazinLostFocus);
			// 
			// textum
			// 
			this.textum.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textum.Location = new System.Drawing.Point(231, 64);
			this.textum.MaxLength = 15;
			this.textum.Name = "textum";
			this.textum.Size = new System.Drawing.Size(189, 23);
			this.textum.TabIndex = 14;
			this.textum.TextChanged += new System.EventHandler(this.TextumTextChanged);
			// 
			// textpret
			// 
			this.textpret.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textpret.Location = new System.Drawing.Point(231, 95);
			this.textpret.Name = "textpret";
			this.textpret.Size = new System.Drawing.Size(147, 23);
			this.textpret.TabIndex = 15;
			this.textpret.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textpret_KeyPress);
			// 
			// checkNevoie
			// 
			this.checkNevoie.AutoSize = true;
			this.checkNevoie.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.checkNevoie.Location = new System.Drawing.Point(43, 161);
			this.checkNevoie.Name = "checkNevoie";
			this.checkNevoie.Size = new System.Drawing.Size(99, 21);
			this.checkNevoie.TabIndex = 16;
			this.checkNevoie.Text = "este nevoie";
			this.checkNevoie.UseVisualStyleBackColor = true;
			this.checkNevoie.CheckedChanged += new System.EventHandler(this.CheckNevoieCheckedChanged);
			// 
			// textperioada
			// 
			this.textperioada.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.textperioada.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textperioada.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textperioada.Location = new System.Drawing.Point(231, 157);
			this.textperioada.Name = "textperioada";
			this.textperioada.Size = new System.Drawing.Size(189, 23);
			this.textperioada.TabIndex = 17;
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button2.Location = new System.Drawing.Point(132, 196);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 44);
			this.button2.TabIndex = 16;
			this.button2.Text = "adaug..";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button3.Location = new System.Drawing.Point(197, 196);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 44);
			this.button3.TabIndex = 17;
			this.button3.Text = "modif..";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button4.Location = new System.Drawing.Point(262, 196);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(64, 44);
			this.button4.TabIndex = 18;
			this.button4.Text = "șterge";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(8, 231);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(32, 26);
			this.button5.TabIndex = 54;
			this.button5.Text = "1";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// gridactive
			// 
			this.gridactive.AllowUserToAddRows = false;
			this.gridactive.AllowUserToDeleteRows = false;
			this.gridactive.AllowUserToResizeColumns = false;
			this.gridactive.AllowUserToResizeRows = false;
			this.gridactive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.gridactive.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.gridactive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridactive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.O,
			this.denumire,
			this.prioritate,
			this.pret,
			this.start,
			this.perioada});
			this.gridactive.Location = new System.Drawing.Point(707, 8);
			this.gridactive.Name = "gridactive";
			this.gridactive.ReadOnly = true;
			this.gridactive.RowHeadersVisible = false;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.gridactive.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.gridactive.RowTemplate.Height = 24;
			this.gridactive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridactive.ShowCellErrors = false;
			this.gridactive.ShowCellToolTips = false;
			this.gridactive.ShowEditingIcon = false;
			this.gridactive.ShowRowErrors = false;
			this.gridactive.Size = new System.Drawing.Size(535, 700);
			this.gridactive.TabIndex = 20;
			this.gridactive.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridactiveCellContentClick);
			// 
			// O
			// 
			this.O.HeaderText = "o";
			this.O.Name = "O";
			this.O.ReadOnly = true;
			this.O.Width = 20;
			// 
			// denumire
			// 
			this.denumire.HeaderText = "denumire";
			this.denumire.MaxInputLength = 20;
			this.denumire.Name = "denumire";
			this.denumire.ReadOnly = true;
			this.denumire.Width = 198;
			// 
			// prioritate
			// 
			this.prioritate.HeaderText = "prio";
			this.prioritate.MaxInputLength = 5;
			this.prioritate.Name = "prioritate";
			this.prioritate.ReadOnly = true;
			this.prioritate.Width = 30;
			// 
			// pret
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle1.Format = "N2";
			dataGridViewCellStyle1.NullValue = "0";
			this.pret.DefaultCellStyle = dataGridViewCellStyle1;
			this.pret.HeaderText = "pret";
			this.pret.MaxInputLength = 20;
			this.pret.Name = "pret";
			this.pret.ReadOnly = true;
			this.pret.Width = 70;
			// 
			// start
			// 
			this.start.HeaderText = "start";
			this.start.Name = "start";
			this.start.ReadOnly = true;
			this.start.Width = 90;
			// 
			// perioada
			// 
			this.perioada.HeaderText = "perioada";
			this.perioada.Name = "perioada";
			this.perioada.ReadOnly = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(156, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 17);
			this.label1.TabIndex = 22;
			this.label1.Text = "denumire:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(156, 12);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(63, 17);
			this.label9.TabIndex = 22;
			this.label9.Text = "magazin:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(156, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 17);
			this.label2.TabIndex = 23;
			this.label2.Text = "descriere:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(156, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 17);
			this.label4.TabIndex = 25;
			this.label4.Text = "start:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(156, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 17);
			this.label5.TabIndex = 26;
			this.label5.Text = "memento:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(367, 636);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(45, 40);
			this.button1.TabIndex = 33;
			this.button1.Text = "send";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textemail
			// 
			this.textemail.Location = new System.Drawing.Point(3, 636);
			this.textemail.MinimumSize = new System.Drawing.Size(274, 4);
			this.textemail.Name = "textemail";
			this.textemail.Size = new System.Drawing.Size(360, 23);
			this.textemail.TabIndex = 34;
			this.textemail.Text = "catalynsava@gmail.com";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(418, 636);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(45, 40);
			this.button6.TabIndex = 44;
			this.button6.Text = "txt";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.button10);
			this.panel1.Controls.Add(this.checkVenit);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.button9);
			this.panel1.Controls.Add(this.checkChelt);
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.button8);
			this.panel1.Controls.Add(this.button7);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.btnnu);
			this.panel1.Controls.Add(this.btnda);
			this.panel1.Controls.Add(this.textstart);
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.textExport);
			this.panel1.Controls.Add(this.nrzilerestplata);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.textemail);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.button6);
			this.panel1.Controls.Add(this.checkNevoie);
			this.panel1.Controls.Add(this.textpret);
			this.panel1.Controls.Add(this.textperioada);
			this.panel1.Controls.Add(this.textum);
			this.panel1.Controls.Add(this.textdenumire);
			this.panel1.Controls.Add(this.textmagazin);
			this.panel1.Controls.Add(this.textscurt);
			this.panel1.Controls.Add(this.radioButton1);
			this.panel1.Controls.Add(this.radioButton2);
			this.panel1.Controls.Add(this.radioButton3);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.checkActiv);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Location = new System.Drawing.Point(228, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(473, 706);
			this.panel1.TabIndex = 46;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(156, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 17);
			this.label3.TabIndex = 62;
			this.label3.Text = "valoare:";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.linkLabel1.LinkColor = System.Drawing.Color.DimGray;
			this.linkLabel1.Location = new System.Drawing.Point(6, 678);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(108, 18);
			this.linkLabel1.TabIndex = 61;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = ".................";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(378, 87);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(36, 36);
			this.button10.TabIndex = 60;
			this.button10.Text = "-";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.Button10Click);
			// 
			// checkVenit
			// 
			this.checkVenit.Location = new System.Drawing.Point(42, 102);
			this.checkVenit.Name = "checkVenit";
			this.checkVenit.Size = new System.Drawing.Size(91, 28);
			this.checkVenit.TabIndex = 59;
			this.checkVenit.Text = "venit";
			this.checkVenit.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label8.Location = new System.Drawing.Point(120, 678);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(345, 16);
			this.label8.TabIndex = 58;
			this.label8.Text = "...";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(418, 231);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(41, 31);
			this.button9.TabIndex = 57;
			this.button9.Text = "c...";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.Button9Click);
			// 
			// checkChelt
			// 
			this.checkChelt.Location = new System.Drawing.Point(43, 129);
			this.checkChelt.Name = "checkChelt";
			this.checkChelt.Size = new System.Drawing.Size(91, 28);
			this.checkChelt.TabIndex = 56;
			this.checkChelt.Text = "cheltuieli";
			this.checkChelt.UseVisualStyleBackColor = true;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(78, 231);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(32, 26);
			this.button8.TabIndex = 53;
			this.button8.Text = "3";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.Button8Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(43, 231);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(32, 26);
			this.button7.TabIndex = 52;
			this.button7.Text = "2";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label7.Location = new System.Drawing.Point(329, 184);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 17);
			this.label7.TabIndex = 50;
			this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// btnnu
			// 
			this.btnnu.Location = new System.Drawing.Point(372, 201);
			this.btnnu.Name = "btnnu";
			this.btnnu.Size = new System.Drawing.Size(46, 39);
			this.btnnu.TabIndex = 49;
			this.btnnu.Text = "nu";
			this.btnnu.UseVisualStyleBackColor = true;
			this.btnnu.Click += new System.EventHandler(this.BtnnuClick);
			// 
			// btnda
			// 
			this.btnda.Location = new System.Drawing.Point(326, 201);
			this.btnda.Name = "btnda";
			this.btnda.Size = new System.Drawing.Size(46, 39);
			this.btnda.TabIndex = 48;
			this.btnda.Text = "da";
			this.btnda.UseVisualStyleBackColor = true;
			this.btnda.Click += new System.EventHandler(this.BtndaClick);
			// 
			// textstart
			// 
			this.textstart.Location = new System.Drawing.Point(231, 125);
			this.textstart.Mask = "00/00/0000";
			this.textstart.Name = "textstart";
			this.textstart.Size = new System.Drawing.Size(189, 23);
			this.textstart.TabIndex = 16;
			this.textstart.ValidatingType = typeof(System.DateTime);
			// 
			// textExport
			// 
			this.textExport.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.textExport.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textExport.ForeColor = System.Drawing.SystemColors.MenuText;
			this.textExport.Location = new System.Drawing.Point(6, 263);
			this.textExport.Multiline = true;
			this.textExport.Name = "textExport";
			this.textExport.ReadOnly = true;
			this.textExport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textExport.Size = new System.Drawing.Size(457, 368);
			this.textExport.TabIndex = 47;
			// 
			// nrzilerestplata
			// 
			this.nrzilerestplata.AutoSize = true;
			this.nrzilerestplata.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.nrzilerestplata.Location = new System.Drawing.Point(123, 243);
			this.nrzilerestplata.MinimumSize = new System.Drawing.Size(280, 0);
			this.nrzilerestplata.Name = "nrzilerestplata";
			this.nrzilerestplata.Size = new System.Drawing.Size(280, 17);
			this.nrzilerestplata.TabIndex = 46;
			this.nrzilerestplata.Text = "...";
			this.nrzilerestplata.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.SystemColors.WindowText;
			this.label6.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(3, 663);
			this.label6.MinimumSize = new System.Drawing.Size(360, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(360, 14);
			this.label6.TabIndex = 45;
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkActiv
			// 
			this.checkActiv.Location = new System.Drawing.Point(43, 192);
			this.checkActiv.Name = "checkActiv";
			this.checkActiv.Size = new System.Drawing.Size(80, 24);
			this.checkActiv.TabIndex = 55;
			this.checkActiv.Text = "activ...";
			this.checkActiv.UseVisualStyleBackColor = true;
			// 
			// textcautadenumiri
			// 
			this.textcautadenumiri.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.textcautadenumiri.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textcautadenumiri.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textcautadenumiri.Location = new System.Drawing.Point(3, 8);
			this.textcautadenumiri.Name = "textcautadenumiri";
			this.textcautadenumiri.Size = new System.Drawing.Size(219, 23);
			this.textcautadenumiri.TabIndex = 47;
			this.textcautadenumiri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textcautadenumiri_keydown);
			this.textcautadenumiri.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textcautadenumiri_keyup);
			// 
			// btnactive
			// 
			this.btnactive.Location = new System.Drawing.Point(78, 36);
			this.btnactive.Name = "btnactive";
			this.btnactive.Size = new System.Drawing.Size(73, 26);
			this.btnactive.TabIndex = 48;
			this.btnactive.Text = "activ";
			this.btnactive.UseVisualStyleBackColor = true;
			this.btnactive.Click += new System.EventHandler(this.BtnactiveClick);
			// 
			// btninactive
			// 
			this.btninactive.Location = new System.Drawing.Point(150, 36);
			this.btninactive.Name = "btninactive";
			this.btninactive.Size = new System.Drawing.Size(73, 26);
			this.btninactive.TabIndex = 49;
			this.btninactive.Text = "inactiv";
			this.btninactive.UseVisualStyleBackColor = true;
			this.btninactive.Click += new System.EventHandler(this.BtninactiveClick);
			// 
			// btntoate
			// 
			this.btntoate.Location = new System.Drawing.Point(6, 36);
			this.btntoate.Name = "btntoate";
			this.btntoate.Size = new System.Drawing.Size(73, 26);
			this.btntoate.TabIndex = 50;
			this.btntoate.Text = "toate";
			this.btntoate.UseVisualStyleBackColor = true;
			this.btntoate.Click += new System.EventHandler(this.BtntoateClick);
			// 
			// frmCheltuieli
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1257, 719);
			this.Controls.Add(this.btntoate);
			this.Controls.Add(this.btninactive);
			this.Controls.Add(this.btnactive);
			this.Controls.Add(this.textcautadenumiri);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.gridactive);
			this.Controls.Add(this.listDenumiri);
			this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			
			//this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			//this.Icon = myicon; 

			this.Name = "frmCheltuieli";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "cheltuieli";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCheltuieli_UnLoad);
			this.Load += new System.EventHandler(this.frmCheltuieli_Load);
			this.Resize += new System.EventHandler(this.frmCheltuieli_Resize);
			((System.ComponentModel.ISupportInitialize)(this.gridactive)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
    }
}