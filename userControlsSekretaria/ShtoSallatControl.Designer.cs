namespace FinalProject_Eva_Bardhoku.userControlsAdmin
{
    partial class ShtoSallatControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnPastro = new System.Windows.Forms.Button();
            this.btn_Fshi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSalla = new System.Windows.Forms.TextBox();
            this.btn_Shto = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 378);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 53;
            this.label2.Text = "Emri i Salles:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(819, 188);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 52;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(890, 185);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(201, 22);
            this.txtSearch.TabIndex = 51;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnPastro
            // 
            this.btnPastro.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPastro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPastro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPastro.Location = new System.Drawing.Point(605, 335);
            this.btnPastro.Margin = new System.Windows.Forms.Padding(4);
            this.btnPastro.Name = "btnPastro";
            this.btnPastro.Size = new System.Drawing.Size(83, 31);
            this.btnPastro.TabIndex = 50;
            this.btnPastro.Text = "Pasto";
            this.btnPastro.UseVisualStyleBackColor = false;
            this.btnPastro.Click += new System.EventHandler(this.btnPastro_Click_1);
            // 
            // btn_Fshi
            // 
            this.btn_Fshi.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_Fshi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Fshi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Fshi.Location = new System.Drawing.Point(563, 489);
            this.btn_Fshi.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Fshi.Name = "btn_Fshi";
            this.btn_Fshi.Size = new System.Drawing.Size(125, 46);
            this.btn_Fshi.TabIndex = 49;
            this.btn_Fshi.Text = "Fshi";
            this.btn_Fshi.UseVisualStyleBackColor = false;
            this.btn_Fshi.Click += new System.EventHandler(this.btn_Fshi_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.UserName});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridView1.Location = new System.Drawing.Point(772, 231);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(319, 353);
            this.dataGridView1.TabIndex = 48;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick_1);
            // 
            // UserID
            // 
            this.UserID.HeaderText = "ID";
            this.UserID.MinimumWidth = 6;
            this.UserID.Name = "UserID";
            this.UserID.Width = 125;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "Name";
            this.UserName.HeaderText = "Room";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.Width = 125;
            // 
            // txtSalla
            // 
            this.txtSalla.Location = new System.Drawing.Point(401, 413);
            this.txtSalla.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalla.Name = "txtSalla";
            this.txtSalla.Size = new System.Drawing.Size(285, 22);
            this.txtSalla.TabIndex = 47;
            // 
            // btn_Shto
            // 
            this.btn_Shto.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_Shto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Shto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Shto.Location = new System.Drawing.Point(401, 489);
            this.btn_Shto.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Shto.Name = "btn_Shto";
            this.btn_Shto.Size = new System.Drawing.Size(124, 46);
            this.btn_Shto.TabIndex = 46;
            this.btn_Shto.Text = "Shto/Modifiko";
            this.btn_Shto.UseVisualStyleBackColor = false;
            this.btn_Shto.Click += new System.EventHandler(this.btn_Shto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(625, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 46);
            this.label3.TabIndex = 54;
            this.label3.Text = "Sallat";
            // 
            // ShtoSallatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnPastro);
            this.Controls.Add(this.btn_Fshi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSalla);
            this.Controls.Add(this.btn_Shto);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShtoSallatControl";
            this.Size = new System.Drawing.Size(1161, 715);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnPastro;
        private System.Windows.Forms.Button btn_Fshi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSalla;
        private System.Windows.Forms.Button btn_Shto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
    }
}
