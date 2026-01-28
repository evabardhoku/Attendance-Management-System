using FinalProject_Eva_Bardhoku.userControls;
using FinalProject_Eva_Bardhoku.userControlsAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Eva_Bardhoku
{
    public partial class AdminForm : Form
    {
        private ShtoDepControl shtoDepControl;
        private ShtoUserControl ShtoUserControl;
        private ShtoPlanControl shtoPlanControl;
        private ShtoLendeControl shtoLendeControl;
        private gjeneroRaportet gjeneroRaportet;
        private ShtoVitAkademikControl shtoVitAkademikControl;
        private ShtoGrupControl shtoGrupControl;

        public string emriUser, roliUser;
        public AdminForm(string fullName, string role)
        {
            InitializeComponent();
            timer1.Start();
           
            lblEmri.Text = fullName;
          
            shtoDepControl = new ShtoDepControl();
            shtoDepControl.Visible = false;
            ShtoUserControl = new ShtoUserControl();
            ShtoUserControl.Visible = false;
            shtoPlanControl =new ShtoPlanControl();
            shtoPlanControl.Visible = false;
            shtoLendeControl=new ShtoLendeControl();
            shtoLendeControl.Visible = false;
            gjeneroRaportet = new gjeneroRaportet();
            gjeneroRaportet.Visible = false;
            shtoVitAkademikControl=new ShtoVitAkademikControl();
            shtoVitAkademikControl.Visible = false;
            shtoGrupControl=new ShtoGrupControl();
            shtoGrupControl.Visible = false;
            this.Controls.Add(shtoDepControl);
            this.Controls.Add(ShtoUserControl);
            this.Controls.Add(shtoPlanControl);
            this.Controls.Add(shtoLendeControl);
            this.Controls.Add(gjeneroRaportet);
            this.Controls.Add(shtoVitAkademikControl);
            this.Controls.Add(shtoGrupControl);
        }
       
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Close();
            FormLogin fl = new FormLogin();
            fl.Show();
            timer1.Stop();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShtoUserControl.Visible = false;
            shtoDepControl.Visible = false;
            shtoPlanControl.Visible = false;
            shtoLendeControl.Visible = false;
            gjeneroRaportet.Visible = true;
            shtoVitAkademikControl.Visible = false;
            shtoGrupControl.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShtoUserControl.Visible = false;
            shtoDepControl.Visible = false;
            shtoPlanControl.Visible = true;
            shtoLendeControl.Visible = false;
            gjeneroRaportet.Visible = false;
            shtoVitAkademikControl.Visible = false;
            shtoGrupControl.Visible = false;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ShtoUserControl.Visible=true;
            shtoDepControl.Visible = false;
            shtoPlanControl.Visible = false;
            shtoLendeControl.Visible = false;
            gjeneroRaportet.Visible = false;
            shtoVitAkademikControl.Visible = false;
            shtoGrupControl.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            shtoDepControl.Visible=true;
            ShtoUserControl.Visible = false;
            shtoPlanControl.Visible = false;
            shtoLendeControl.Visible = false;
            gjeneroRaportet.Visible = false;
            shtoVitAkademikControl.Visible = false;
            shtoGrupControl.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shtoDepControl.Visible = false;
            ShtoUserControl.Visible = false;
            shtoPlanControl.Visible = false;
            gjeneroRaportet.Visible = false;
            shtoVitAkademikControl.Visible = false;
            shtoLendeControl.Visible = true;
            shtoGrupControl.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            shtoDepControl.Visible = false;
            ShtoUserControl.Visible = false;
            shtoPlanControl.Visible = false;
            shtoLendeControl.Visible = false;
            gjeneroRaportet.Visible = false;
            shtoVitAkademikControl.Visible = true;
            shtoGrupControl.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            shtoDepControl.Visible = false;
            ShtoUserControl.Visible = false;
            shtoPlanControl.Visible = false;
            shtoLendeControl.Visible = false;
            gjeneroRaportet.Visible = false;
            shtoVitAkademikControl.Visible = false;
            shtoGrupControl.Visible = true;

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lbl_data.Text = dt.ToString("F");
        }

       
    }
}
