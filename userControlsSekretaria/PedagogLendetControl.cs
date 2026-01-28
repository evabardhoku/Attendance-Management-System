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
    public partial class PedagogLendetControl : UserControl
    {
        public string conn = GlobalData.globalConnString;
        public PedagogLendetControl()
        {
            InitializeComponent();
            LoadPedagog();
            LoadLende();
            LoadGrupet();
            LoadDepartmentet();
            LoadPedagogLende();
        }
        private void LoadPedagogLende()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();
                    string query = @"SELECT u.UserID, u.FirstName,u.LastName, u.Email,l.SubjectName, g.GroupName, d.DepartmentName
                            FROM Users u
                            JOIN InstructorInfo pi ON u.UserID = pi.InstructorID
                            JOIN Subject l ON pi.SubjectID = l.SubjectID
                            JOIN LearningGroups g ON pi.LearningGroupID = g.LearningGroupID
                            JOIN Department d ON pi.DepartmentID = d.DepartmentID
                            WHERE u.Role = 'Pedagog'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView2.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView2.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Email"],
                            reader["SubjectName"], reader["GroupName"], reader["DepartmentName"]);
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

        private void LoadPedagog()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    string query = @"SELECT UserID, FirstName, LastName, Email
                            FROM Users 
                            WHERE Role = 'Pedagog'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Email"]);
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
        private void LoadLende()
        {
            string query = "SELECT SubjectID, SubjectName FROM Subject";

            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbSubjects.DisplayMember = "SubjectName";
                cmbSubjects.ValueMember = "SubjectID";
                cmbSubjects.DataSource = dt;
            }
        }

        private void LoadGrupet()
        {
            string query = "SELECT LearningGroupID, GroupName FROM LearningGroups";

            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbGroups.DisplayMember = "GroupName";
                cmbGroups.ValueMember = "LearningGroupID";
                cmbGroups.DataSource = dt;
            }
        }

        private void LoadDepartmentet()
        {
            string query = "SELECT DepartmentID, DepartmentName FROM Department";

            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbDepartments.DisplayMember = "DepartmentName";
                cmbDepartments.ValueMember = "DepartmentID";
                cmbDepartments.DataSource = dt;
            }
        }

        private void InsertPedagogLende()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                if (selectedRow.Cells[0].Value != null)
                {
                    string query = @" INSERT INTO InstructorInfo (InstructorID, SubjectID, LearningGroupID, DepartmentID) 
                VALUES (@InstructorID, @SubjectID, @LearningGroupID, @DepartmentID)";

                    using (SqlConnection con = new SqlConnection(conn))
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@InstructorID", Convert.ToInt32(selectedRow.Cells[0].Value));
                        cmd.Parameters.AddWithValue("@SubjectID", cmbSubjects.SelectedValue);
                        cmd.Parameters.AddWithValue("@LearningGroupID", cmbGroups.SelectedValue);
                        cmd.Parameters.AddWithValue("@DepartmentID", cmbDepartments.SelectedValue);

                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Subject u shtua me sukses te lendet e Pedagogut.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ju lutem selektoni nje rresht si fillim.");
            }
        }

        private void UpdatePedagogLende()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                if (selectedRow.Cells[0].Value != null)
                {
                    string query = @"UPDATE InstructorInfo 
                             SET SubjectID = @SubjectID, LearningGroupID = @LearningGroupID, DepartmentID = @DepartmentID
                             WHERE InstructorID = @InstructorID";

                    using (SqlConnection con = new SqlConnection(conn))
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@InstructorID", Convert.ToInt32(selectedRow.Cells["UserID"].Value));
                        cmd.Parameters.AddWithValue("@SubjectID", cmbSubjects.SelectedValue);
                        cmd.Parameters.AddWithValue("@LearningGroupID", cmbGroups.SelectedValue);
                        cmd.Parameters.AddWithValue("@DepartmentID", cmbDepartments.SelectedValue);

                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Pedagogu u modifikua me sukses.");
                            LoadPedagogLende(); 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                } 
            }
            else
            {
                MessageBox.Show("Ju lutem perzgjidhni nje rresht ne DatagridView.");
            }
            LoadPedagogLende ();    
        }


        private void DeletePedagogLende()
        {
            DataGridView selectedGridView = dataGridView2.SelectedRows.Count > 0 ? dataGridView2 : dataGridView1;

            if (selectedGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem perzgjidhni nje ose me shume rreshta per te fshire.");
                return;
            }

            // Confirm delete operation for multiple rows
            DialogResult result = MessageBox.Show($"Jeni te sigurt qe doni te fshini {selectedGridView.SelectedRows.Count} pedagoget nga grupet?", "Fshi Pedagoget", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        foreach (DataGridViewRow row in selectedGridView.SelectedRows)
                        {
                            int InstructorID = Convert.ToInt32(row.Cells[0].Value);  
                            int groupID = Convert.ToInt32(cmbGroups.SelectedValue); 

                            string query = @"DELETE FROM InstructorInfo 
                                     WHERE InstructorID = @InstructorID 
                                     AND LearningGroupID = @LearningGroupID";

                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@InstructorID", InstructorID);
                            cmd.Parameters.AddWithValue("@LearningGroupID", groupID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                             Console.WriteLine($"Pedagogu me ID: {InstructorID} u fshi nga grupi me sukses.");
                            }
                            else
                            {
                                MessageBox.Show($"Nuk u gjet asnje pedagog me kete ID: {InstructorID} ne grupin e selektuar.");
                            }
                        }

                        LoadPedagogLende();
                        MessageBox.Show("Grupi u fshi nga pedagogu me sukses.");
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

        private void Pastro()
        {
            txtName.Clear();
            txtLastname.Clear();
            txtEmail.Clear();
            cmbSubjects.SelectedIndex = -1;
            cmbGroups.SelectedIndex = -1;
            cmbDepartments.SelectedIndex = -1;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLastname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertPedagogLende();
            LoadPedagogLende();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdatePedagogLende();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePedagogLende();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            Pastro();
        }
        public void Search1(string kerkoText)
        {
            string kerkoTxt = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(kerkoTxt))
            {
                LoadPedagog();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        string query = @"SELECT UserID, FirstName, LastName, Email FROM Users 
                            WHERE Role = 'Pedagog' 
                            AND (FirstName LIKE @kerkoTxt OR LastName LIKE @kerkoTxt)
                            ORDER BY FirstName ASC";

                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@kerkoTxt", "%" + kerkoTxt + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Email"]);
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
            Search1(txtSearch.Text);
        }

        public void Search2(string kerkoText)
        {
            string kerkoTxt = txtSearch2.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(kerkoTxt))
            {
                LoadPedagogLende();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        string query = @"SELECT u.UserID, u.FirstName,u.LastName, u.Email,l.SubjectName, g.GroupName, d.DepartmentName
                            FROM Users u
                            JOIN InstructorInfo pi ON u.UserID = pi.InstructorID
                            JOIN Subject l ON pi.SubjectID = l.SubjectID
                            JOIN LearningGroups g ON pi.LearningGroupID = g.LearningGroupID
                            JOIN Department d ON pi.DepartmentID = d.DepartmentID
                            WHERE u.Role = 'Pedagog' AND (u.FirstName LIKE @kerkoTxt OR 
                                                              u.LastName LIKE @kerkoTxt OR
                                                              d.DepartmentName LIKE @kerkoTxt OR
                                                              g.GroupName LIKE @kerkoTxt)";

                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@kerkoTxt", "%" + kerkoTxt + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        dataGridView2.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView2.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Email"],
                             reader["SubjectName"], reader["GroupName"], reader["DepartmentName"]);
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


        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            Search2(txtSearch2.Text);
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblLastname_Click(object sender, EventArgs e)
        {

        }
    }
}