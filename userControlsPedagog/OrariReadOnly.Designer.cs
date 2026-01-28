namespace FinalProject_Eva_Bardhoku.userControlsPedagog
{
    partial class OrariReadOnly
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.orarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GRMesimore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OraFillim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OraMbarim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pedagog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orarID,
            this.SubjectName,
            this.Room,
            this.Dita,
            this.GRMesimore,
            this.OraFillim,
            this.OraMbarim,
            this.Pedagog});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridView1.Location = new System.Drawing.Point(317, 280);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(858, 348);
            this.dataGridView1.TabIndex = 41;
            // 
            // orarID
            // 
            this.orarID.HeaderText = "ID";
            this.orarID.MinimumWidth = 6;
            this.orarID.Name = "orarID";
            this.orarID.Width = 125;
            // 
            // SubjectName
            // 
            this.SubjectName.HeaderText = "Subject";
            this.SubjectName.MinimumWidth = 6;
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.Width = 125;
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
            // GRMesimore
            // 
            this.GRMesimore.HeaderText = "Grupet Mesimore";
            this.GRMesimore.MinimumWidth = 6;
            this.GRMesimore.Name = "GRMesimore";
            this.GRMesimore.Width = 125;
            // 
            // OraFillim
            // 
            this.OraFillim.HeaderText = "Ora e Fillimit";
            this.OraFillim.MinimumWidth = 6;
            this.OraFillim.Name = "OraFillim";
            this.OraFillim.Width = 125;
            // 
            // OraMbarim
            // 
            this.OraMbarim.HeaderText = "Ora e Mbarimit";
            this.OraMbarim.MinimumWidth = 6;
            this.OraMbarim.Name = "OraMbarim";
            this.OraMbarim.Width = 125;
            // 
            // Pedagog
            // 
            this.Pedagog.HeaderText = "Pedagog";
            this.Pedagog.MinimumWidth = 6;
            this.Pedagog.Name = "Pedagog";
            this.Pedagog.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(826, 206);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(891, 202);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(231, 22);
            this.txtSearch.TabIndex = 45;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(446, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(285, 46);
            this.label6.TabIndex = 62;
            this.label6.Text = "Orari Mesimor";
            // 
            // OrariReadOnly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrariReadOnly";
            this.Size = new System.Drawing.Size(1765, 825);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orarID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dita;
        private System.Windows.Forms.DataGridViewTextBoxColumn GRMesimore;
        private System.Windows.Forms.DataGridViewTextBoxColumn OraFillim;
        private System.Windows.Forms.DataGridViewTextBoxColumn OraMbarim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pedagog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label6;
    }
}
