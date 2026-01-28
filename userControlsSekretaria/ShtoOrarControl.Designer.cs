namespace FinalProject_Eva_Bardhoku.userControlsSekretaria
{
    partial class ShtoOrarControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnPastro = new System.Windows.Forms.Button();
            this.btn_Fshi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORaFillimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OraMarimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pedagog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Shto = new System.Windows.Forms.Button();
            this.cmbGrupet = new System.Windows.Forms.ComboBox();
            this.cmbDitaJaves = new System.Windows.Forms.ComboBox();
            this.cmbSalla = new System.Windows.Forms.ComboBox();
            this.cmbLenda = new System.Windows.Forms.ComboBox();
            this.cmbPedagog = new System.Windows.Forms.ComboBox();
            this.txtMbarim = new System.Windows.Forms.TextBox();
            this.txtFillim = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(815, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 62;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(881, 177);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(231, 22);
            this.txtSearch.TabIndex = 61;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnPastro
            // 
            this.btnPastro.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPastro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPastro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPastro.Location = new System.Drawing.Point(977, 528);
            this.btnPastro.Margin = new System.Windows.Forms.Padding(4);
            this.btnPastro.Name = "btnPastro";
            this.btnPastro.Size = new System.Drawing.Size(161, 36);
            this.btnPastro.TabIndex = 60;
            this.btnPastro.Text = "Pasto";
            this.btnPastro.UseVisualStyleBackColor = false;
            this.btnPastro.Click += new System.EventHandler(this.btnPastro_Click);
            // 
            // btn_Fshi
            // 
            this.btn_Fshi.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_Fshi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Fshi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Fshi.Location = new System.Drawing.Point(977, 627);
            this.btn_Fshi.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Fshi.Name = "btn_Fshi";
            this.btn_Fshi.Size = new System.Drawing.Size(161, 37);
            this.btn_Fshi.TabIndex = 59;
            this.btn_Fshi.Text = "Fshi";
            this.btn_Fshi.UseVisualStyleBackColor = false;
            this.btn_Fshi.Click += new System.EventHandler(this.btn_Fshi_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScheduleID,
            this.Subject,
            this.Room,
            this.Dita,
            this.Grupet,
            this.ORaFillimit,
            this.OraMarimit,
            this.Pedagog});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridView1.Location = new System.Drawing.Point(265, 218);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(873, 292);
            this.dataGridView1.TabIndex = 58;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick_1);
            // 
            // ScheduleID
            // 
            this.ScheduleID.HeaderText = "ID";
            this.ScheduleID.MinimumWidth = 6;
            this.ScheduleID.Name = "ScheduleID";
            this.ScheduleID.Width = 125;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Subject";
            this.Subject.MinimumWidth = 6;
            this.Subject.Name = "Subject";
            this.Subject.Width = 125;
            // 
            // Room
            // 
            this.Room.HeaderText = "Room";
            this.Room.MinimumWidth = 6;
            this.Room.Name = "Room";
            this.Room.Width = 125;
            // 
            // Dita
            // 
            this.Dita.HeaderText = "Dita e Javes";
            this.Dita.MinimumWidth = 6;
            this.Dita.Name = "Dita";
            this.Dita.Width = 125;
            // 
            // Grupet
            // 
            this.Grupet.HeaderText = "Grupet Mesimore";
            this.Grupet.MinimumWidth = 6;
            this.Grupet.Name = "Grupet";
            this.Grupet.Width = 125;
            // 
            // ORaFillimit
            // 
            this.ORaFillimit.HeaderText = "Ora e Fillimit";
            this.ORaFillimit.MinimumWidth = 6;
            this.ORaFillimit.Name = "ORaFillimit";
            this.ORaFillimit.Width = 125;
            // 
            // OraMarimit
            // 
            this.OraMarimit.HeaderText = "Ora e Mbarimit";
            this.OraMarimit.MinimumWidth = 6;
            this.OraMarimit.Name = "OraMarimit";
            this.OraMarimit.Width = 125;
            // 
            // Pedagog
            // 
            this.Pedagog.HeaderText = "Pedagog";
            this.Pedagog.MinimumWidth = 6;
            this.Pedagog.Name = "Pedagog";
            this.Pedagog.Width = 125;
            // 
            // btn_Shto
            // 
            this.btn_Shto.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_Shto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Shto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Shto.Location = new System.Drawing.Point(977, 576);
            this.btn_Shto.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Shto.Name = "btn_Shto";
            this.btn_Shto.Size = new System.Drawing.Size(161, 38);
            this.btn_Shto.TabIndex = 56;
            this.btn_Shto.Text = "Shto/Modifiko";
            this.btn_Shto.UseVisualStyleBackColor = false;
            this.btn_Shto.Click += new System.EventHandler(this.btn_Shto_Click);
            // 
            // cmbGrupet
            // 
            this.cmbGrupet.FormattingEnabled = true;
            this.cmbGrupet.Location = new System.Drawing.Point(751, 539);
            this.cmbGrupet.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGrupet.Name = "cmbGrupet";
            this.cmbGrupet.Size = new System.Drawing.Size(189, 24);
            this.cmbGrupet.TabIndex = 77;
            // 
            // cmbDitaJaves
            // 
            this.cmbDitaJaves.FormattingEnabled = true;
            this.cmbDitaJaves.Items.AddRange(new object[] {
            "E Hene",
            "E Marte",
            "E Merkure",
            "E Enjte",
            "E Premte"});
            this.cmbDitaJaves.Location = new System.Drawing.Point(389, 634);
            this.cmbDitaJaves.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDitaJaves.Name = "cmbDitaJaves";
            this.cmbDitaJaves.Size = new System.Drawing.Size(189, 24);
            this.cmbDitaJaves.TabIndex = 76;
            // 
            // cmbSalla
            // 
            this.cmbSalla.FormattingEnabled = true;
            this.cmbSalla.Location = new System.Drawing.Point(389, 601);
            this.cmbSalla.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSalla.Name = "cmbSalla";
            this.cmbSalla.Size = new System.Drawing.Size(189, 24);
            this.cmbSalla.TabIndex = 75;
            // 
            // cmbLenda
            // 
            this.cmbLenda.FormattingEnabled = true;
            this.cmbLenda.Location = new System.Drawing.Point(389, 568);
            this.cmbLenda.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLenda.Name = "cmbLenda";
            this.cmbLenda.Size = new System.Drawing.Size(189, 24);
            this.cmbLenda.TabIndex = 74;
            // 
            // cmbPedagog
            // 
            this.cmbPedagog.FormattingEnabled = true;
            this.cmbPedagog.Location = new System.Drawing.Point(389, 535);
            this.cmbPedagog.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPedagog.Name = "cmbPedagog";
            this.cmbPedagog.Size = new System.Drawing.Size(189, 24);
            this.cmbPedagog.TabIndex = 73;
            // 
            // txtMbarim
            // 
            this.txtMbarim.Location = new System.Drawing.Point(751, 605);
            this.txtMbarim.Margin = new System.Windows.Forms.Padding(4);
            this.txtMbarim.Name = "txtMbarim";
            this.txtMbarim.Size = new System.Drawing.Size(189, 22);
            this.txtMbarim.TabIndex = 72;
            // 
            // txtFillim
            // 
            this.txtFillim.Location = new System.Drawing.Point(751, 573);
            this.txtFillim.Margin = new System.Windows.Forms.Padding(4);
            this.txtFillim.Name = "txtFillim";
            this.txtFillim.Size = new System.Drawing.Size(189, 22);
            this.txtFillim.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(519, 88);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(285, 46);
            this.label6.TabIndex = 78;
            this.label6.Text = "Orari Mesimor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(633, 608);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 85;
            this.label8.Text = "Ora e Mbarimit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(644, 576);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 84;
            this.label7.Text = "Ora e Fillimit";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(628, 543);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 16);
            this.label10.TabIndex = 83;
            this.label10.Text = "Grupet Mesimore";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(310, 605);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 82;
            this.label11.Text = "Room";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(292, 634);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 16);
            this.label12.TabIndex = 81;
            this.label12.Text = "Dita e Javes";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(306, 571);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 16);
            this.label13.TabIndex = 80;
            this.label13.Text = "Subject";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(299, 538);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 16);
            this.label14.TabIndex = 79;
            this.label14.Text = "Pedagog";
            // 
            // ShtoOrarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbGrupet);
            this.Controls.Add(this.cmbDitaJaves);
            this.Controls.Add(this.cmbSalla);
            this.Controls.Add(this.cmbLenda);
            this.Controls.Add(this.cmbPedagog);
            this.Controls.Add(this.txtMbarim);
            this.Controls.Add(this.txtFillim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnPastro);
            this.Controls.Add(this.btn_Fshi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Shto);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShtoOrarControl";
            this.Size = new System.Drawing.Size(1142, 720);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnPastro;
        private System.Windows.Forms.Button btn_Fshi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Shto;
        private System.Windows.Forms.ComboBox cmbGrupet;
        private System.Windows.Forms.ComboBox cmbDitaJaves;
        private System.Windows.Forms.ComboBox cmbSalla;
        private System.Windows.Forms.ComboBox cmbLenda;
        private System.Windows.Forms.ComboBox cmbPedagog;
        private System.Windows.Forms.TextBox txtMbarim;
        private System.Windows.Forms.TextBox txtFillim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dita;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORaFillimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn OraMarimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pedagog;
    }
}
