using FinalProject_Eva_Bardhoku.userControlsPedagog;
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
    public partial class PedagogForm : Form
    {
       
        private OraMesimore oraMesimore;

        private gjeneroRaport gjeneroRaport;
        private OrariReadOnly orariReadOnly;
       
        private GrMesimore_PEdagog grMesimore_PEdagog;
      
        public PedagogForm(string fullName, string role,int InstructorID)
        {
            InitializeComponent();
            timer1.Start();

            lblEmri.Text = fullName;
            
            oraMesimore = new OraMesimore(InstructorID);
            oraMesimore.Visible = false;
            this.Controls.Add(oraMesimore);

            gjeneroRaport = new gjeneroRaport ();
            gjeneroRaport.Visible=false;
            this.Controls.Add(gjeneroRaport);
           
            orariReadOnly = new OrariReadOnly();    
            orariReadOnly.Visible=false;
            this.Controls.Add(orariReadOnly);


           
        grMesimore_PEdagog=new GrMesimore_PEdagog(InstructorID);
            grMesimore_PEdagog.Visible=false;
            this.Controls.Add((grMesimore_PEdagog));
        
        
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

        private void button23_Click(object sender, EventArgs e)
        {
            oraMesimore.Visible = true;
            gjeneroRaport.Visible = false ;
            orariReadOnly.Visible = false;
           
            grMesimore_PEdagog.Visible = false;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            oraMesimore.Visible = false;
            gjeneroRaport.Visible = true;
            orariReadOnly.Visible = false;
            
            grMesimore_PEdagog.Visible = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            oraMesimore.Visible = false;
            gjeneroRaport.Visible = false;
            orariReadOnly.Visible = true;
           
            grMesimore_PEdagog.Visible = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            oraMesimore.Visible = false;
            gjeneroRaport.Visible = false;
            orariReadOnly.Visible = false;
          
            grMesimore_PEdagog.Visible = true;

        }

        private void button19_Click(object sender, EventArgs e)
        {
            oraMesimore.Visible = false;
            gjeneroRaport.Visible = false;
            orariReadOnly.Visible = false;
          
            grMesimore_PEdagog.Visible = false;
        }
    }
}
