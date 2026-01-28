using FinalProject_Eva_Bardhoku.userControlsSekretaria;
using FinalProject_Eva_Bardhoku.userControlsStudent;
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
    public partial class StudentForm : Form
    {       private CheckIn checkIn;
        private FrekuentimiControl frekuentimiControl;
        public StudentForm(string fullName, string role,int ID)
        {
            InitializeComponent();
            timer1.Start();

            lblEmri.Text = fullName;
           
            checkIn = new CheckIn();
            checkIn.Visible = false;
            this.Controls.Add(checkIn);

            frekuentimiControl = new FrekuentimiControl(ID);
            frekuentimiControl.Visible = false;
            this.Controls.Add(frekuentimiControl);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblData.Text = dt.ToString("F");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            checkIn.Visible = true;
            frekuentimiControl.Visible = false;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            checkIn.Visible = false;
            frekuentimiControl.Visible = true;
        }
    }
}
