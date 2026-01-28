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

namespace FinalProject_Eva_Bardhoku.userControls
{
    public partial class ShtoVitAkademikControl : UserControl
    {
        public int ID;
        public string conn = GlobalData.globalConnString;
        public ShtoVitAkademikControl()
        {
            InitializeComponent();
            LoadVit();
        }
        public void LoadVit()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();
                    string query = "SELECT AcademicYearID,YearName FROM AcademicYear";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["AcademicYearID"], reader["YearName"]);
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

        public void shtoTeDhena(int ID, string AcademicYear)
        {
            string checkQuery = "SELECT COUNT(*) FROM AcademicYear WHERE YearName = @YearName";

            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmdCheck = new SqlCommand(checkQuery, con))
                {
                    cmdCheck.Parameters.AddWithValue("@YearName", AcademicYear);

                    try
                    {
                        con.Open();
                        int count = (int)cmdCheck.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Egziston nje Vit Akademik me kete emertim.");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
            }

            string query = @"IF EXISTS (SELECT * FROM AcademicYear WHERE AcademicYearID = @AcademicYearID)
            BEGIN
                UPDATE AcademicYear SET YearName = @YearName WHERE AcademicYearID = @AcademicYearID
            END
            ELSE
            BEGIN
                INSERT INTO AcademicYear (YearName)
                VALUES (@YearName)
            END";

            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AcademicYearID", ID);
                    cmd.Parameters.AddWithValue("@YearName", AcademicYear);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Viti u shtua/modifikua me sukses.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btn_Shto_Click(object sender, EventArgs e)
        {
            string vitiAkadem = txtEmri.Text;  

            if (string.IsNullOrWhiteSpace(vitiAkadem))
            {
                MessageBox.Show("Ju lutem mos e lini vitin bosh.");
                return;
            }

            shtoTeDhena(ID, vitiAkadem);
            LoadVit();
        }

        public void pastro()
        {
            txtEmri.Clear();
            ID = 0;
        }

        private void btnPastro_Click(object sender, EventArgs e)
        {
            pastro();
        }

        private void btn_Fshi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem selektoni nje vit akademik per ta fshire.");
                return;
            }

            DialogResult result = MessageBox.Show("Jeni te sigurt qe doni ta fshini vitin akademik?", "Fshi Vitin Akademik", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            int AcademicYearID = Convert.ToInt32(row.Cells[0].Value); 
                            string query = "DELETE FROM AcademicYear WHERE AcademicYearID = @AcademicYearID";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@AcademicYearID", AcademicYearID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                Console.WriteLine($"Nuk u gjet asnje Vit Akademik me ID = {AcademicYearID} per tu fshire.");
                            }
                        }

                        MessageBox.Show("Vitet Akademik u fshine me sukses.");
                        LoadVit(); 
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
            string searchText = txtSearch.Text.Trim().ToLower(); 

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadVit();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();
                        string query = "SELECT AcademicYearID, YearName FROM AcademicYear WHERE YearName LIKE  @searchText ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["AcademicYearID"], reader["YearName"]);
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

                        string query = "SELECT * FROM AcademicYear WHERE AcademicYearID = @AcademicYearID";
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@AcademicYearID", ID);

                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    txtEmri.Text = dataReader["YearName"].ToString();

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
                MessageBox.Show("Keni perzgjedhur rreshtin e gabuar.");
            }
        }
    }
}