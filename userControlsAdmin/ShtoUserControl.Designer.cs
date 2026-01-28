using System.Windows.Forms;

namespace FinalProject_Eva_Bardhoku.userControls
{
    partial class ShtoUserControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnPastro;
        private System.Windows.Forms.Button btn_Fshi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtEmri;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_Shto;
        private System.Windows.Forms.TextBox txtMbiemri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDitelindja;
        private System.Windows.Forms.TextBox txtNrTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rBtnF;
        private System.Windows.Forms.RadioButton rBtnM;

        // Dispose method to clean up resources
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Designer generated code
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnPastro = new System.Windows.Forms.Button();
            this.btn_Fshi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passwordi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmri = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_Shto = new System.Windows.Forms.Button();
            this.txtMbiemri = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDitelindja = new System.Windows.Forms.TextBox();
            this.txtNrTel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rBtnF = new System.Windows.Forms.RadioButton();
            this.rBtnM = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Mbiemri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Emri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(718, 312);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(784, 309);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(231, 22);
            this.txtSearch.TabIndex = 16;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnPastro
            // 
            this.btnPastro.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPastro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPastro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPastro.Location = new System.Drawing.Point(274, 295);
            this.btnPastro.Margin = new System.Windows.Forms.Padding(4);
            this.btnPastro.Name = "btnPastro";
            this.btnPastro.Size = new System.Drawing.Size(117, 36);
            this.btnPastro.TabIndex = 15;
            this.btnPastro.Text = "Refresh";
            this.btnPastro.UseVisualStyleBackColor = false;
            this.btnPastro.Click += new System.EventHandler(this.btnPastro_Click_1);
            // 
            // btn_Fshi
            // 
            this.btn_Fshi.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_Fshi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Fshi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Fshi.Location = new System.Drawing.Point(412, 294);
            this.btn_Fshi.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Fshi.Name = "btn_Fshi";
            this.btn_Fshi.Size = new System.Drawing.Size(126, 37);
            this.btn_Fshi.TabIndex = 14;
            this.btn_Fshi.Text = "Fshi";
            this.btn_Fshi.UseVisualStyleBackColor = false;
            this.btn_Fshi.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.UserName,
            this.LastName,
            this.Role,
            this.PhoneNumber,
            this.BirthDate,
            this.Gender,
            this.Address,
            this.Email,
            this.Passwordi});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridView1.Location = new System.Drawing.Point(276, 381);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(745, 304);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // UserID
            // 
            this.UserID.HeaderText = "UserID";
            this.UserID.MinimumWidth = 6;
            this.UserID.Name = "UserID";
            this.UserID.Width = 125;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "Name";
            this.UserName.HeaderText = "Name";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.Width = 125;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "LastName";
            this.LastName.MinimumWidth = 6;
            this.LastName.Name = "LastName";
            this.LastName.Width = 125;
            // 
            // Role
            // 
            this.Role.HeaderText = "Role";
            this.Role.MinimumWidth = 6;
            this.Role.Name = "Role";
            this.Role.Width = 125;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.HeaderText = "PhoneNumber";
            this.PhoneNumber.MinimumWidth = 6;
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Width = 125;
            // 
            // BirthDate
            // 
            this.BirthDate.HeaderText = "BirthDate";
            this.BirthDate.MinimumWidth = 6;
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.Width = 125;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Gender";
            this.Gender.MinimumWidth = 6;
            this.Gender.Name = "Gender";
            this.Gender.Width = 125;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.Width = 125;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // Passwordi
            // 
            this.Passwordi.HeaderText = "Passwordi";
            this.Passwordi.MinimumWidth = 6;
            this.Passwordi.Name = "Passwordi";
            this.Passwordi.Width = 125;
            // 
            // txtEmri
            // 
            this.txtEmri.Location = new System.Drawing.Point(368, 117);
            this.txtEmri.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmri.Name = "txtEmri";
            this.txtEmri.Size = new System.Drawing.Size(160, 22);
            this.txtEmri.TabIndex = 12;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "admin",
            "pedagog",
            "sekretaria"});
            this.comboBox1.Location = new System.Drawing.Point(657, 144);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 11;
            // 
            // btn_Shto
            // 
            this.btn_Shto.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_Shto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Shto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Shto.Location = new System.Drawing.Point(557, 294);
            this.btn_Shto.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Shto.Name = "btn_Shto";
            this.btn_Shto.Size = new System.Drawing.Size(117, 37);
            this.btn_Shto.TabIndex = 10;
            this.btn_Shto.Text = "Shto/Modifiko";
            this.btn_Shto.UseVisualStyleBackColor = false;
            this.btn_Shto.Click += new System.EventHandler(this.btn_Shto_Click);
            // 
            // txtMbiemri
            // 
            this.txtMbiemri.Location = new System.Drawing.Point(368, 149);
            this.txtMbiemri.Margin = new System.Windows.Forms.Padding(4);
            this.txtMbiemri.Name = "txtMbiemri";
            this.txtMbiemri.Size = new System.Drawing.Size(160, 22);
            this.txtMbiemri.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 218);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Ditelindja";
            // 
            // txtDitelindja
            // 
            this.txtDitelindja.Location = new System.Drawing.Point(368, 214);
            this.txtDitelindja.Margin = new System.Windows.Forms.Padding(4);
            this.txtDitelindja.Name = "txtDitelindja";
            this.txtDitelindja.Size = new System.Drawing.Size(160, 22);
            this.txtDitelindja.TabIndex = 23;
            // 
            // txtNrTel
            // 
            this.txtNrTel.Location = new System.Drawing.Point(368, 181);
            this.txtNrTel.Margin = new System.Windows.Forms.Padding(4);
            this.txtNrTel.Name = "txtNrTel";
            this.txtNrTel.Size = new System.Drawing.Size(160, 22);
            this.txtNrTel.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 185);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Nr. Telefonit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(580, 147);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Role";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(580, 187);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(577, 218);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 33;
            this.label8.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(657, 218);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(160, 22);
            this.txtPassword.TabIndex = 32;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(657, 181);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(160, 22);
            this.txtEmail.TabIndex = 31;
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(657, 112);
            this.txtAdresa.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(160, 22);
            this.txtAdresa.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(577, 112);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "Adresa";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(295, 259);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Gjinia";
            // 
            // rBtnF
            // 
            this.rBtnF.AutoSize = true;
            this.rBtnF.Location = new System.Drawing.Point(380, 259);
            this.rBtnF.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnF.Name = "rBtnF";
            this.rBtnF.Size = new System.Drawing.Size(36, 20);
            this.rBtnF.TabIndex = 35;
            this.rBtnF.TabStop = true;
            this.rBtnF.Text = "F";
            this.rBtnF.UseVisualStyleBackColor = true;
            // 
            // rBtnM
            // 
            this.rBtnM.AutoSize = true;
            this.rBtnM.Location = new System.Drawing.Point(449, 259);
            this.rBtnM.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnM.Name = "rBtnM";
            this.rBtnM.Size = new System.Drawing.Size(39, 20);
            this.rBtnM.TabIndex = 36;
            this.rBtnM.TabStop = true;
            this.rBtnM.Text = "M";
            this.rBtnM.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(506, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(247, 46);
            this.label11.TabIndex = 38;
            this.label11.Text = " Perdoruesit";
            // 
            // ShtoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.rBtnM);
            this.Controls.Add(this.rBtnF);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAdresa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDitelindja);
            this.Controls.Add(this.txtNrTel);
            this.Controls.Add(this.txtMbiemri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnPastro);
            this.Controls.Add(this.btn_Fshi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtEmri);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_Shto);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShtoUserControl";
            this.Size = new System.Drawing.Size(1161, 739);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Label label11;
        private DataGridViewTextBoxColumn UserID;
        private DataGridViewTextBoxColumn UserName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Role;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn BirthDate;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Passwordi;
    }
}
