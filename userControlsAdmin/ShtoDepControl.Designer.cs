namespace FinalProject_Eva_Bardhoku.userControls
{
    partial class ShtoDepControl
    {
        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

      
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DepartmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmriDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkBAktiv = new System.Windows.Forms.CheckBox();
            this.txtEmriDep = new System.Windows.Forms.TextBox();
            this.txtSearchDep = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_Pastro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DepartmentID,
            this.EmriDep,
            this.Status});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridView1.Location = new System.Drawing.Point(474, 230);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(578, 361);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // DepartmentID
            // 
            this.DepartmentID.HeaderText = "ID";
            this.DepartmentID.MinimumWidth = 6;
            this.DepartmentID.Name = "DepartmentID";
            this.DepartmentID.Width = 125;
            // 
            // EmriDep
            // 
            this.EmriDep.HeaderText = "Department";
            this.EmriDep.MinimumWidth = 6;
            this.EmriDep.Name = "EmriDep";
            this.EmriDep.Width = 125;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.Width = 125;
            // 
            // chkBAktiv
            // 
            this.chkBAktiv.AutoSize = true;
            this.chkBAktiv.Location = new System.Drawing.Point(651, 140);
            this.chkBAktiv.Name = "chkBAktiv";
            this.chkBAktiv.Size = new System.Drawing.Size(58, 20);
            this.chkBAktiv.TabIndex = 1;
            this.chkBAktiv.Text = "Aktiv";
            this.chkBAktiv.UseVisualStyleBackColor = true;
            // 
            // txtEmriDep
            // 
            this.txtEmriDep.Location = new System.Drawing.Point(651, 102);
            this.txtEmriDep.Name = "txtEmriDep";
            this.txtEmriDep.Size = new System.Drawing.Size(178, 22);
            this.txtEmriDep.TabIndex = 2;
            // 
            // txtSearchDep
            // 
            this.txtSearchDep.Location = new System.Drawing.Point(876, 187);
            this.txtSearchDep.Name = "txtSearchDep";
            this.txtSearchDep.Size = new System.Drawing.Size(174, 22);
            this.txtSearchDep.TabIndex = 3;
            this.txtSearchDep.TextChanged += new System.EventHandler(this.txtSearchDep_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(253, 335);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 75);
            this.button2.TabIndex = 5;
            this.button2.Text = "Shto/Modifiko";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(253, 416);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(176, 67);
            this.button3.TabIndex = 6;
            this.button3.Text = "Fshi";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_Pastro
            // 
            this.btn_Pastro.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_Pastro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Pastro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Pastro.Location = new System.Drawing.Point(253, 263);
            this.btn_Pastro.Name = "btn_Pastro";
            this.btn_Pastro.Size = new System.Drawing.Size(176, 68);
            this.btn_Pastro.TabIndex = 7;
            this.btn_Pastro.Text = "Refrsh";
            this.btn_Pastro.UseVisualStyleBackColor = false;
            this.btn_Pastro.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(332, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 46);
            this.label1.TabIndex = 10;
            this.label1.Text = "Departamentet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(818, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Search:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(500, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Emri i Departamentit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Statusi i Departamentit";
            // 
            // ShtoDepControl
            // 
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Pastro);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSearchDep);
            this.Controls.Add(this.txtEmriDep);
            this.Controls.Add(this.chkBAktiv);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ShtoDepControl";
            this.Size = new System.Drawing.Size(1162, 677);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chkBAktiv;
        private System.Windows.Forms.TextBox txtEmriDep;
        private System.Windows.Forms.TextBox txtSearchDep;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_Pastro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmriDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}
