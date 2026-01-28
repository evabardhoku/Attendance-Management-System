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

namespace FinalProject_Eva_Bardhoku.userControlsAdmin
{
    public partial class ShtoGrupControl : UserControl
    {
        public int ID;
        public string conn = GlobalData.globalConnString;

        public ShtoGrupControl()
        {
            InitializeComponent();
            LoadGrupMesimor();
            LoadViti();
        }
        private void LoadGrupMesimor()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    string query = @"SELECT LearningGroupID, GroupName, YearName FROM LearningGroups g join AcademicYear v on g.AcademicYearID=v.AcademicYearID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["LearningGroupID"], reader["GroupName"], reader["YearName"]);
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

        private void LoadViti()
        {
            string query = "SELECT AcademicYearID, YearName FROM AcademicYear";
            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbViti.DisplayMember = "YearName";
                cmbViti.ValueMember = "AcademicYearID";
                cmbViti.DataSource = dt;
            }
        }

        private void InsertOrUpdateGrupi()
        {
            int AcademicYearID = (int)cmbViti.SelectedValue;
            string GroupName = txtEmriGrupit.Text;

            string query = "ShtoGrupControl";

            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AcademicYearID", AcademicYearID);
                    cmd.Parameters.AddWithValue("@GroupName", GroupName);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Grupi u shtua/modifikua me sukses.");
                        LoadGrupMesimor();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
           
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem selektoni nje rresht per ta fshire.");
                return;
            }

            DialogResult result = MessageBox.Show("Jeni te sigurt qe doni te fshini Grupin Akademik?", "Fshi Grupin Akademik", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            int LearningGroupID = Convert.ToInt32(row.Cells[0].Value);  

                            string query = "DELETE FROM LearningGroups WHERE LearningGroupID = @LearningGroupID";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@LearningGroupID", LearningGroupID);

                            int rowsAffected = cmd.ExecuteNonQuery(); 

                            if (rowsAffected == 0)
                            {
                                Console.WriteLine($"Nuk u gjet asnje Grupi me ID = {LearningGroupID} per tu fshire.");
                            }
                        }

                        MessageBox.Show("Grupi Akademik u fshi me sukses.");
                        LoadGrupMesimor(); 
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
            cmbViti.SelectedIndex = -1;
            txtEmriGrupit.Clear();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                    using (SqlConnection sqlConnection = new SqlConnection(conn))
                    {
                        sqlConnection.Open();
                    
                        string query = @"SELECT * FROM LearningGroups Where LearningGroupID = @ID ";
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@ID", ID);

                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    txtEmriGrupit.Text= dataReader["GroupName"].ToString();
                                    cmbViti.SelectedValue = dataReader["AcademicYearID"].ToString();
                                  
                                }
                                else
                                {
                                    MessageBox.Show("Nuk u gjet asnje e dhene per Grupin e selektuar.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Rreshti i gabuar.");
            }
        }
   
        private void btnPastro_Click(object sender, EventArgs e)
        {
            Pastro();
        }

      
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string kerkoTxt = textBox2.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(kerkoTxt))
            {
                LoadGrupMesimor();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        string query = "SELECT LearningGroupID, GroupName, YearName " +
                            "FROM LearningGroups g join AcademicYear v on g.AcademicYearID=v.AcademicYearID" +
                            " WHERE GroupName LIKE  @kerkoTxt OR YearName LIKE  @kerkoTxt";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@kerkoTxt", "%" + kerkoTxt + "%");

                        SqlDataReader reader = cmd.ExecuteReader();
                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["LearningGroupID"], reader["GroupName"], reader["YearName"]);
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

        private void button1_Click(object sender, EventArgs e)
        {
            string GroupName = txtEmriGrupit.Text;

            int ID = 0;

            if (string.IsNullOrWhiteSpace(GroupName)|| cmbViti.SelectedItem == null)
            {
                MessageBox.Show("Ju lutem plotesoni te gjitha fushat.");
                return;
            }

            InsertOrUpdateGrupi();
            Pastro();
        }
    }
}