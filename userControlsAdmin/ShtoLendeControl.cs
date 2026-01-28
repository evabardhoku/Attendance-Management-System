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
    public partial class ShtoLendeControl : UserControl
    {
        public int ID;
        public string conn = GlobalData.globalConnString;
        public ShtoLendeControl()
        {
            InitializeComponent();
            LoadLende();
        }

        private void btn_Shto_Click(object sender, EventArgs e)
        {
            string SubjectName = txtEmri.Text; 

            if (string.IsNullOrWhiteSpace(SubjectName))
            {
                MessageBox.Show("Ju lutem selektoni nje Lende.");
                return;
            }

            shtoTeDhena(ID, SubjectName);
            LoadLende(); 
        }


        private void btn_Fshi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem selektoni nje rresht per ta fshire.");
                return;
            }

            DialogResult result = MessageBox.Show("Jeni te sigurt qe doni ta fshini Lenden?", "Fshi Lendet", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            int SubjectID = Convert.ToInt32(row.Cells[0].Value);

                            string query = "DELETE FROM Subject WHERE SubjectID = @SubjectID";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                               Console.WriteLine("Nuk u gjet asnje Lende me ID = " + SubjectID + " per tu fshire.");
                            }
                        }

                        MessageBox.Show("Subject u fshi me sukses.");
                        LoadLende();  
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




        public void LoadLende()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();
                    string query = "SELECT SubjectID,SubjectName FROM Subject";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["SubjectID"], reader["SubjectName"]);
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
        public void shtoTeDhena(int ID, string SubjectName)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("ShtoLendeControl", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SubjectID", ID);
                    cmd.Parameters.AddWithValue("@SubjectName", SubjectName);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Subject u shtua/modifikua me sukses.");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

             

         public void pastro()
         {
           txtEmri.Clear();
           ID = 0;
         }

        private void btnPastro_Click_1(object sender, EventArgs e)
        {
            pastro();
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

                        string query = "SELECT * FROM Subject WHERE SubjectID = @SubjectID";
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@SubjectID", ID);

                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    txtEmri.Text = dataReader["SubjectName"].ToString();

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
                MessageBox.Show("Keni selektuar rreshtin e gabuar.");
            }
        }
        public void Search(string kerkoText)
        {
            string kerkoTxt = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(kerkoTxt))
            {
                LoadLende();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        string query = @"SELECT SubjectID,SubjectName FROM Subject WHERE SubjectName LIKE @kerkoTxt";

                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@kerkoTxt", "%" + kerkoTxt + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["SubjectID"], reader["SubjectName"], reader["SubjectName"]);
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
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }
    }
}