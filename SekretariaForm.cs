using FinalProject_Eva_Bardhoku.userControls;
using FinalProject_Eva_Bardhoku.userControlsAdmin;
using FinalProject_Eva_Bardhoku.userControlsSekretaria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProject_Eva_Bardhoku.Program;

namespace FinalProject_Eva_Bardhoku
{
    public partial class SekretariaForm : Form
    {
        public string conn = GlobalData.globalConnString;


        private ShtoSallatControl shtoSallatControl;
        private PedagogLendetControl pedagogLendetControl;

        private GrupetMesimoreControl grupetMesimoreControl;
        private ShtoStudentControl shtoStudentControl;
        private StudentCardControl studentCardControl;
        private ShtoOrarControl shtoOrarControl;
        private gjeneroRaportetSekretaria gjeneroRaportetSekretaria;
        private GrupeStudentControl grupeStudentControl;

        public SekretariaForm(string fullName, string role)
        {
            InitializeComponent();

            timer1.Start();

            lblEmer.Text = fullName;
           

            shtoOrarControl = new ShtoOrarControl();
            shtoOrarControl.Visible = false;
            this.Controls.Add(shtoOrarControl);

            shtoSallatControl = new ShtoSallatControl();
            shtoSallatControl.Visible = false;
            this.Controls.Add(shtoSallatControl);

            shtoStudentControl = new ShtoStudentControl();
            shtoStudentControl.Visible = false;
            this.Controls.Add(shtoStudentControl);

            studentCardControl = new StudentCardControl();
            studentCardControl.Visible = false;
            this.Controls.Add(studentCardControl);

            pedagogLendetControl = new PedagogLendetControl();
            pedagogLendetControl.Visible = false;
            this.Controls.Add(pedagogLendetControl);


            grupetMesimoreControl = new GrupetMesimoreControl();
            grupetMesimoreControl.Visible = false;
            this.Controls.Add(grupetMesimoreControl);

            gjeneroRaportetSekretaria = new gjeneroRaportetSekretaria();
            gjeneroRaportetSekretaria.Visible = false;
            this.Controls.Add(gjeneroRaportetSekretaria);

            grupeStudentControl = new GrupeStudentControl();
            grupeStudentControl.Visible = false;
            this.Controls.Add(grupeStudentControl);

        }


        private void button15_Click(object sender, EventArgs e)
        {
            shtoOrarControl.Visible = false;
            shtoSallatControl.Visible = false;
            shtoStudentControl.Visible = true;
            studentCardControl.Visible = false;
            pedagogLendetControl.Visible = false;

            grupetMesimoreControl.Visible = false;
            gjeneroRaportetSekretaria.Visible = false;
            grupeStudentControl.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            shtoOrarControl.Visible = false;
            shtoSallatControl.Visible = true;
            shtoStudentControl.Visible = false;
            studentCardControl.Visible = false;
            pedagogLendetControl.Visible = false;

            grupetMesimoreControl.Visible = false;
            gjeneroRaportetSekretaria.Visible = false;
            grupeStudentControl.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            shtoOrarControl.Visible = false;
            shtoSallatControl.Visible = false;
            shtoStudentControl.Visible = false;
            studentCardControl.Visible = true;
            pedagogLendetControl.Visible = false;
            grupeStudentControl.Refresh();
            grupetMesimoreControl.Refresh();
            grupeStudentControl.Update();
            grupetMesimoreControl.Update();
            studentCardControl.Refresh();
            studentCardControl.Update();
            grupetMesimoreControl.Visible = false;
            gjeneroRaportetSekretaria.Visible = false;
            grupeStudentControl.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            shtoOrarControl.Visible = false;
            shtoSallatControl.Visible = false;
            shtoStudentControl.Visible = false;
            studentCardControl.Visible = false;
            pedagogLendetControl.Visible = false;
            grupeStudentControl.Refresh();
            grupetMesimoreControl.Refresh();
            grupeStudentControl.Update();
            grupetMesimoreControl.Update();
            studentCardControl.Refresh();
            studentCardControl.Update();
            grupetMesimoreControl.Visible = true;
            gjeneroRaportetSekretaria.Visible = false;
            grupeStudentControl.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            shtoOrarControl.Visible = true;
            shtoSallatControl.Visible = false;
            shtoStudentControl.Visible = false;
            studentCardControl.Visible = false;
            pedagogLendetControl.Visible = false;

            grupetMesimoreControl.Visible = false;
            gjeneroRaportetSekretaria.Visible = false;
            grupeStudentControl.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            shtoOrarControl.Visible = false;
            shtoSallatControl.Visible = false;
            shtoStudentControl.Visible = false;
            studentCardControl.Visible = false;
            pedagogLendetControl.Visible = true;

            grupetMesimoreControl.Visible = false;
            gjeneroRaportetSekretaria.Visible = false;
            grupeStudentControl.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            shtoOrarControl.Visible = false;
            shtoSallatControl.Visible = false;
            shtoStudentControl.Visible = false;
            studentCardControl.Visible = false;
            pedagogLendetControl.Visible = false;

            grupetMesimoreControl.Visible = false;
            gjeneroRaportetSekretaria.Visible = false;
            grupeStudentControl.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            shtoOrarControl.Visible = false;
            shtoSallatControl.Visible = false;
            shtoStudentControl.Visible = false;
            studentCardControl.Visible = false;
            pedagogLendetControl.Visible = false;

            grupetMesimoreControl.Visible = false;
            gjeneroRaportetSekretaria.Visible = true;
            grupeStudentControl.Visible = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblOra.Text = dt.ToString("F");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shtoOrarControl.Visible = false;
            shtoSallatControl.Visible = false;
            shtoStudentControl.Visible = false;
            studentCardControl.Visible = false;
            pedagogLendetControl.Visible = false;
           
            grupetMesimoreControl.Visible = false;
            gjeneroRaportetSekretaria.Visible = false;
            grupeStudentControl.Visible = true;
            grupeStudentControl.Refresh();
            grupetMesimoreControl.Refresh();
            grupeStudentControl.Update();
            grupetMesimoreControl.Update();
            studentCardControl.Refresh();
            studentCardControl.Update();

        }
    }
}