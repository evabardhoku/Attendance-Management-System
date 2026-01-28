using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProject_Eva_Bardhoku.Program;

namespace FinalProject_Eva_Bardhoku.userControlsPedagog
{
  
    public partial class GrMesimore_PEdagog : UserControl
    {
        int ID; 
        public string conn = GlobalData.globalConnString;
        public GrMesimore_PEdagog(int loggedInPedagogID)
        {
            InitializeComponent();
            ID = loggedInPedagogID;
            LoadPedagogoGrup(ID); 
        }
        private void LoadPedagogoGrup(int InstructorID)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    string query = @"SELECT u.FirstName, u.LastName, g.GroupName
                                    FROM Users u
                                    JOIN InstructorInfo pi ON u.UserID = pi.InstructorID
                                    JOIN LearningGroups g ON pi.LearningGroupID = g.LearningGroupID
                                    WHERE u.Role = 'Pedagog' AND u.UserID = @InstructorID";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@InstructorID", InstructorID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add( reader["FirstName"], reader["LastName"], reader["GroupName"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

    }
}
