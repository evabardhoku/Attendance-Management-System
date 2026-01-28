namespace FinalProject_Eva_Bardhoku.userControlsPedagog
{
            partial class OraMesimore
        {
            private System.ComponentModel.IContainer components = null;
            private System.Windows.Forms.RichTextBox richTextBox1;
            private System.Windows.Forms.Button btnOpenClassroom;
            private System.Windows.Forms.DataGridView dataGridView1;
            private System.Windows.Forms.Button btnInsert;

            private void InitializeComponent()
            {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnOpenClassroom = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mbiemri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KArtaStudentit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInsert = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxGrupi = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(218, 453);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(688, 117);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnOpenClassroom
            // 
            this.btnOpenClassroom.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnOpenClassroom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenClassroom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOpenClassroom.Location = new System.Drawing.Point(745, 91);
            this.btnOpenClassroom.Name = "btnOpenClassroom";
            this.btnOpenClassroom.Size = new System.Drawing.Size(161, 52);
            this.btnOpenClassroom.TabIndex = 1;
            this.btnOpenClassroom.Text = "Hap Oren";
            this.btnOpenClassroom.UseVisualStyleBackColor = false;
            this.btnOpenClassroom.Click += new System.EventHandler(this.btnHapKlasen_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userID,
            this.Emri,
            this.Mbiemri,
            this.Email,
            this.KArtaStudentit});
            this.dataGridView1.GridColor = System.Drawing.Color.OliveDrab;
            this.dataGridView1.Location = new System.Drawing.Point(218, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(688, 202);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // userID
            // 
            this.userID.HeaderText = "ID";
            this.userID.MinimumWidth = 6;
            this.userID.Name = "userID";
            this.userID.Width = 125;
            // 
            // Emri
            // 
            this.Emri.HeaderText = "Emri";
            this.Emri.MinimumWidth = 6;
            this.Emri.Name = "Emri";
            this.Emri.Width = 125;
            // 
            // Mbiemri
            // 
            this.Mbiemri.HeaderText = "Mbiemri";
            this.Mbiemri.MinimumWidth = 6;
            this.Mbiemri.Name = "Mbiemri";
            this.Mbiemri.Width = 125;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // KArtaStudentit
            // 
            this.KArtaStudentit.HeaderText = "Karta eStudentit";
            this.KArtaStudentit.MinimumWidth = 6;
            this.KArtaStudentit.Name = "KArtaStudentit";
            this.KArtaStudentit.Width = 125;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInsert.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInsert.Location = new System.Drawing.Point(745, 371);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(161, 63);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "Ruaj Prezencen";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(578, 106);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(131, 24);
            this.comboBox1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Lenda";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(501, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 46);
            this.label6.TabIndex = 63;
            this.label6.Text = "Klasa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 65;
            this.label2.Text = "Grupi";
            // 
            // comboBoxGrupi
            // 
            this.comboBoxGrupi.FormattingEnabled = true;
            this.comboBoxGrupi.Location = new System.Drawing.Point(336, 109);
            this.comboBoxGrupi.Name = "comboBoxGrupi";
            this.comboBoxGrupi.Size = new System.Drawing.Size(131, 24);
            this.comboBoxGrupi.TabIndex = 64;
            // 
            // OraMesimore
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxGrupi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOpenClassroom);
            this.Controls.Add(this.richTextBox1);
            this.Name = "OraMesimore";
            this.Size = new System.Drawing.Size(1313, 641);
            this.Load += new System.EventHandler(this.OraMesimore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            private System.Windows.Forms.ComboBox comboBox1;
            private System.Windows.Forms.DataGridViewTextBoxColumn userID;
            private System.Windows.Forms.DataGridViewTextBoxColumn Emri;
            private System.Windows.Forms.DataGridViewTextBoxColumn Mbiemri;
            private System.Windows.Forms.DataGridViewTextBoxColumn Email;
            private System.Windows.Forms.DataGridViewTextBoxColumn KArtaStudentit;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxGrupi;
    }
    }
