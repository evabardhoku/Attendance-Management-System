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

namespace FinalProject_Eva_Bardhoku.userControlsSekretaria
{
    public partial class GrupeStudentControl : UserControl
    {
        private string conn = GlobalData.globalConnString;
        public GrupeStudentControl()
        {
            InitializeComponent();
            LoadGrupet();
            LoadStudentGrup();
        }

        private void LoadGrupet()
        {
            string query = "SELECT LearningGroupID, GroupName FROM LearningGroups";

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable groupData = new DataTable();
                    da.Fill(groupData);

                    comboBoxGroups.DataSource = groupData;
                    comboBoxGroups.DisplayMember = "GroupName"; 
                    comboBoxGroups.ValueMember = "LearningGroupID";  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void LoadStudentGrup()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    string query = @"SELECT u.UserID, u.FirstName, u.LastName, u.Email, g.GroupName
                                    FROM Users u
                                    INNER JOIN GroupStudents gs ON u.UserID = gs.StudentID
                                    INNER JOIN LearningGroups g ON gs.LearningGroupID = g.LearningGroupID
                                    WHERE u.Role = 'Student'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Email"],reader["GroupName"]);
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
        private void btnUpdateStudentGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text) || comboBoxGroups.SelectedItem == null)
            {
                MessageBox.Show("Ju lutem selektoni nje student dhe nje grup.");
                return;
            }

            int StudentID = Convert.ToInt32(txtStudentID.Text);
            int groupID = Convert.ToInt32(comboBoxGroups.SelectedValue);

            string query = "UPDATE GroupStudents SET LearningGroupID = @GroupID WHERE StudentID = @StudentID";

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@GroupID", groupID);
                    cmd.Parameters.AddWithValue("@StudentID", StudentID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Studenti u shtua te grupi me sukses.");
                        LoadStudentGrup();
                    }
                    else
                    {
                        MessageBox.Show("Nuk ka te dhena studenti me ID e dhene.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void btnDeleteStudentGroup_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem selektoni nje ose me shume studente per ti fshire.");
                return;
            }

            DialogResult result = MessageBox.Show("Jeni te sigurt qe doni te fshini studentet e selektuar?", "Fshi Studentet", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            int StudentID = Convert.ToInt32(row.Cells["UserID"].Value);

                            string query = "DELETE FROM GroupStudents WHERE StudentID = @StudentID";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@StudentID", StudentID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                            Console.WriteLine($"Studenti me ID: {StudentID} u fshi me sukses.");
                            }
                            else
                            {
                                MessageBox.Show($"Nuk u gjet asnje student me kete ID: {StudentID}.");
                            }
                        }

                        LoadStudentGrup();
                        MessageBox.Show("Studentet u fshine me sukses.");
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

        //private void btnDeleteStudentGroup_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtStudentID.Text))
        //    {
        //        MessageBox.Show("Ju lutem selektoni nje student.");
        //        return;
        //    }

        //    int StudentID = Convert.ToInt32(txtStudentID.Text);

        //    string query = "DELETE FROM GroupStudents WHERE StudentID = @StudentID";

        //    using (SqlConnection con = new SqlConnection(conn))
        //    {
        //        try
        //        {
        //            con.Open();

        //            SqlCommand cmd = new SqlCommand(query, con);
        //            cmd.Parameters.AddWithValue("@StudentID", StudentID);

        //            int rowsAffected = cmd.ExecuteNonQuery();

        //            if (rowsAffected > 0)
        //            {
        //                MessageBox.Show("Studenti u fshi me sukses.");
        //                LoadStudentGrup();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Nuk ka te dhena studenti me ID e dhene.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error: " + ex.Message);
        //        }
        //    }
        //    LoadStudentGrup();
        //}
        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)  
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                int StudentID = Convert.ToInt32(row.Cells[0].Value);
                string firstName = row.Cells[1].Value.ToString();
                string lastName = row.Cells[2].Value.ToString();
                string email = row.Cells[3].Value.ToString();
                string groupName = row.Cells[4].Value.ToString();
               
                txtStudentID.Text = StudentID.ToString();
                txtFirstName.Text = firstName;
                txtLastName.Text = lastName;
                txtEmail.Text = email;

                comboBoxGroups.SelectedItem = groupName;  
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadStudentGrup();
        }
    }
}