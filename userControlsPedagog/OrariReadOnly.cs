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
    public partial class OrariReadOnly : UserControl
    {
        public int ID;
        public string conn = GlobalData.globalConnString;
        public OrariReadOnly()
        {
            InitializeComponent();
            LoadOrari();
        }
        private void LoadOrari()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

               string query = @"SELECT om.ScheduleID, l.SubjectName, s.RoomName , om.Weekday , om.StartTime ,om.EndTime,g.GroupName,u.FirstName 
                                FROM  Schedule om
                                JOIN Subject l ON om.SubjectID = l.SubjectID
                                JOIN Room s ON om.RoomID = s.RoomID
                                JOIN LearningGroups g ON om.LearningGroupID = g.LearningGroupID
                                JOIN Users u ON om.InstructorID = u.UserID
                                WHERE u.Role = 'pedagog'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["ScheduleID"], reader["SubjectName"], reader["RoomName"], reader["Weekday"], reader["GroupName"],
                            reader["StartTime"], reader["EndTime"], reader["FirstName"]);
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
        public void Search(string kerkoText)
        {
            string kerkoTxt = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(kerkoTxt))
            {
                LoadOrari();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

             string query = @"SELECT om.ScheduleID, l.SubjectName, s.RoomName, om.Weekday, 
                           om.StartTime, om.EndTime, g.GroupName, u.FirstName
                            FROM Schedule om
                            JOIN Subject l ON om.SubjectID = l.SubjectID
                            JOIN Room s ON om.RoomID = s.RoomID
                            JOIN LearningGroups g ON om.LearningGroupID = g.LearningGroupID
                            JOIN Users u ON om.InstructorID = u.UserID
                            WHERE (l.SubjectName LIKE @kerkoTxt OR 
                           om.Weekday LIKE @kerkoTxt OR 
                           g.GroupName LIKE @kerkoTxt OR
                           s.RoomName LIKE @kerkoTxt )";

                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@kerkoTxt", "%" + kerkoTxt + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["ScheduleID"], reader["SubjectName"], reader["RoomName"], reader["Weekday"], reader["GroupName"],
                                reader["StartTime"], reader["EndTime"], reader["FirstName"]);
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
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }
    }
}
