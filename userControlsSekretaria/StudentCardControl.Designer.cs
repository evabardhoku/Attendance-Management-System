using System.Windows.Forms;

namespace FinalProject_Eva_Bardhoku.userControlsSekretaria
{
    partial class StudentCardControl
    {
        private System.ComponentModel.IContainer components = null;

        // Controls declaration
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbStudenti;
        private System.Windows.Forms.ComboBox cmbGrupet;
        private System.Windows.Forms.ComboBox cmbViti;
        private System.Windows.Forms.Button btnGjeneroKarte;
        private System.Windows.Forms.Button btnShtoModifiko;
        private System.Windows.Forms.Button btnFshi;
        private System.Windows.Forms.TextBox txtKartaStudentit;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.Label lblSearch;

        // Designer method to initialize components
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Karta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcademicYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbStudenti = new System.Windows.Forms.ComboBox();
            this.cmbGrupet = new System.Windows.Forms.ComboBox();
            this.cmbViti = new System.Windows.Forms.ComboBox();
            this.btnGjeneroKarte = new System.Windows.Forms.Button();
            this.btnShtoModifiko = new System.Windows.Forms.Button();
            this.btnFshi = new System.Windows.Forms.Button();
            this.txtKartaStudentit = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.FirstName,
            this.LastName,
            this.Email,
            this.PhoneNumber,
            this.Karta,
            this.Grupi,
            this.AcademicYear});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridView1.Location = new System.Drawing.Point(238, 179);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(814, 250);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick_1);
            // 
            // UserID
            // 
            this.UserID.HeaderText = "ID";
            this.UserID.MinimumWidth = 6;
            this.UserID.Name = "UserID";
            this.UserID.Width = 125;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "FirstName";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 125;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "LastName";
            this.LastName.MinimumWidth = 6;
            this.LastName.Name = "LastName";
            this.LastName.Width = 125;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.HeaderText = "Numri Telefonit";
            this.PhoneNumber.MinimumWidth = 6;
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Width = 125;
            // 
            // Karta
            // 
            this.Karta.HeaderText = "Numri i Kartes";
            this.Karta.MinimumWidth = 6;
            this.Karta.Name = "Karta";
            this.Karta.Width = 125;
            // 
            // Grupi
            // 
            this.Grupi.HeaderText = "Grupi Mesimor";
            this.Grupi.MinimumWidth = 6;
            this.Grupi.Name = "Grupi";
            this.Grupi.Width = 125;
            // 
            // AcademicYear
            // 
            this.AcademicYear.HeaderText = "Viti Akademik";
            this.AcademicYear.MinimumWidth = 6;
            this.AcademicYear.Name = "AcademicYear";
            this.AcademicYear.Width = 125;
            // 
            // cmbStudenti
            // 
            this.cmbStudenti.FormattingEnabled = true;
            this.cmbStudenti.Location = new System.Drawing.Point(368, 574);
            this.cmbStudenti.Name = "cmbStudenti";
            this.cmbStudenti.Size = new System.Drawing.Size(200, 24);
            this.cmbStudenti.TabIndex = 1;
            this.cmbStudenti.SelectedIndexChanged += new System.EventHandler(this.cmbStudenti_SelectedIndexChanged);
            // 
            // cmbGrupet
            // 
            this.cmbGrupet.FormattingEnabled = true;
            this.cmbGrupet.Location = new System.Drawing.Point(368, 526);
            this.cmbGrupet.Name = "cmbGrupet";
            this.cmbGrupet.Size = new System.Drawing.Size(200, 24);
            this.cmbGrupet.TabIndex = 2;
            // 
            // cmbViti
            // 
            this.cmbViti.FormattingEnabled = true;
            this.cmbViti.Location = new System.Drawing.Point(729, 526);
            this.cmbViti.Name = "cmbViti";
            this.cmbViti.Size = new System.Drawing.Size(200, 24);
            this.cmbViti.TabIndex = 3;
            // 
            // btnGjeneroKarte
            // 
            this.btnGjeneroKarte.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnGjeneroKarte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGjeneroKarte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGjeneroKarte.Location = new System.Drawing.Point(768, 602);
            this.btnGjeneroKarte.Name = "btnGjeneroKarte";
            this.btnGjeneroKarte.Size = new System.Drawing.Size(132, 40);
            this.btnGjeneroKarte.TabIndex = 4;
            this.btnGjeneroKarte.Text = "Gjenero Karte";
            this.btnGjeneroKarte.UseVisualStyleBackColor = false;
            this.btnGjeneroKarte.Click += new System.EventHandler(this.btnGjeneroKarte_Click);
            // 
            // btnShtoModifiko
            // 
            this.btnShtoModifiko.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnShtoModifiko.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShtoModifiko.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShtoModifiko.Location = new System.Drawing.Point(820, 450);
            this.btnShtoModifiko.Name = "btnShtoModifiko";
            this.btnShtoModifiko.Size = new System.Drawing.Size(104, 46);
            this.btnShtoModifiko.TabIndex = 5;
            this.btnShtoModifiko.Text = "Shto/Modifiko";
            this.btnShtoModifiko.UseVisualStyleBackColor = false;
            this.btnShtoModifiko.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnFshi
            // 
            this.btnFshi.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnFshi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFshi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFshi.Location = new System.Drawing.Point(950, 450);
            this.btnFshi.Name = "btnFshi";
            this.btnFshi.Size = new System.Drawing.Size(102, 46);
            this.btnFshi.TabIndex = 6;
            this.btnFshi.Text = "Fshi";
            this.btnFshi.UseVisualStyleBackColor = false;
            this.btnFshi.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtKartaStudentit
            // 
            this.txtKartaStudentit.Location = new System.Drawing.Point(729, 574);
            this.txtKartaStudentit.Name = "txtKartaStudentit";
            this.txtKartaStudentit.ReadOnly = true;
            this.txtKartaStudentit.Size = new System.Drawing.Size(200, 22);
            this.txtKartaStudentit.TabIndex = 7;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(860, 151);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(192, 22);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new System.Drawing.Point(304, 577);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(58, 16);
            this.lblStudent.TabIndex = 9;
            this.lblStudent.Text = "Studenti:";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(312, 534);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(42, 16);
            this.lblGroup.TabIndex = 10;
            this.lblGroup.Text = "Grupi:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(639, 534);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(84, 16);
            this.lblYear.TabIndex = 11;
            this.lblYear.Text = "Viti i Studimit:";
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(637, 577);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(92, 16);
            this.lblCardNumber.TabIndex = 12;
            this.lblCardNumber.Text = "Numri i Kartes:";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(804, 154);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 16);
            this.lblSearch.TabIndex = 13;
            this.lblSearch.Text = "Search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 46);
            this.label1.TabIndex = 14;
            this.label1.Text = "Karta e Studentit";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(707, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 46);
            this.button1.TabIndex = 15;
            this.button1.Text = "Pastro";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.Location = new System.Drawing.Point(307, 442);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 54);
            this.button2.TabIndex = 16;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // StudentCardControl
            // 
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblCardNumber);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtKartaStudentit);
            this.Controls.Add(this.btnFshi);
            this.Controls.Add(this.btnShtoModifiko);
            this.Controls.Add(this.btnGjeneroKarte);
            this.Controls.Add(this.cmbViti);
            this.Controls.Add(this.cmbGrupet);
            this.Controls.Add(this.cmbStudenti);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StudentCardControl";
            this.Size = new System.Drawing.Size(1157, 711);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Karta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupi;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcademicYear;
        private System.Windows.Forms.Button button2;
    }
}