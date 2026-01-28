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
    public partial class GrupetMesimoreControl : UserControl
    {
        public int ID;
        public string conn = GlobalData.globalConnString;

        public GrupetMesimoreControl()
        {
            InitializeComponent();
            LoadStudentet();
            LoadGrupet();   
        }
        private void LoadStudentet()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    string query = @"SELECT u.UserID, u.FirstName, u.LastName, u.Email, u.PhoneNumber, u.BirthDate, u.Gender, u.Address
                            FROM Users u
                            LEFT JOIN GroupStudents gs ON u.UserID = gs.StudentID
                            WHERE u.Role = 'Student' AND gs.LearningGroupID IS NULL";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Email"],
                            reader["PhoneNumber"], reader["BirthDate"], reader["Gender"], reader["Address"]);
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

        private void LoadGrupet()
        {
            string query = "SELECT LearningGroupID, GroupName FROM LearningGroups";

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable groupsData = new DataTable();
                    da.Fill(groupsData);

                    comboBoxGrupet.DataSource = groupsData;
                    comboBoxGrupet.DisplayMember = "GroupName";  
                    comboBoxGrupet.ValueMember = "LearningGroupID";  
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

        private void btnAddStudentToGroup_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem selektoni nje student per ta shtuar te grupi.");
                return;
            }

            if (comboBoxGrupet.SelectedItem == null)
            {
                MessageBox.Show("Ju lutem selektoni nje grup.");
                return;
            }
            int StudentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            int groupID = Convert.ToInt32(comboBoxGrupet.SelectedValue);

            string query = "INSERT INTO GroupStudents (StudentID, LearningGroupID) VALUES (@StudentID, @GroupID)";

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentID", StudentID);
                    cmd.Parameters.AddWithValue("@GroupID", groupID);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Studenti u shtua me sukses te grupi.");
                    
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
            LoadStudentet();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  
            {
                int StudentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                string firstName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string lastName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string email = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                txtStudentID.Text = StudentID.ToString();
                txtEmri.Text = firstName;
                txtMbiemri.Text = lastName;
                txtEmail.Text = email;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadStudentet();
            
        }
        public void pastro()
        {
            txtEmri.Clear();
            txtMbiemri.Clear();
            txtEmail.Clear();
            ID = 0;
        }
        private void btnPastro_Click_1(object sender, EventArgs e)
        {
            pastro();
        }

        private void GrupetMesimoreControl_Load(object sender, EventArgs e)
        {

        }
    }
}