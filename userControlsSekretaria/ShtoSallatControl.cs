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
    public partial class ShtoSallatControl : UserControl
    {
        public int ID;
        public string conn = GlobalData.globalConnString;
        public ShtoSallatControl()
        {
            InitializeComponent();
            LoadSalla();
        }

      

        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                    using (SqlConnection sqlConnection = new SqlConnection(conn))
                    {
                        sqlConnection.Open();

                        string query = "SELECT * FROM Room WHERE RoomID = @RoomID";
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@RoomID", ID);

                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    txtSalla.Text = dataReader["RoomName"].ToString();
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

        public void LoadSalla()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();
                    string query = "SELECT RoomID,RoomName FROM Room";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["RoomID"], reader["RoomName"]);
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


        public void pastro()
        {
            txtSalla.Clear();
            ID = 0;

        }

        private void btn_Shto_Click(object sender, EventArgs e)
        {
            string RoomName = txtSalla.Text;

            if (string.IsNullOrWhiteSpace(RoomName))
            {
                MessageBox.Show("Ju lutem plotesoni emrin e klases.");
                return;
            }

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ShtoSallaContol", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoomID", ID); 
                    cmd.Parameters.AddWithValue("@RoomName", RoomName);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Room u shtua/modifikua me sukses.");
                    LoadSalla(); 

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            LoadSalla();
        }

        
        public void Search(string kerkoText)
        {
            string kerkoTxt = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(kerkoTxt))
            {
                LoadSalla();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();
                        string query = "SELECT RoomID, RoomName FROM Room WHERE RoomName LIKE  @kerkoTxt ";


                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@kerkoTxt", "%" + kerkoTxt + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["RoomID"], reader["RoomName"]);
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

        private void btn_Fshi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem selektoni nje rresht qe doni te fshini.");
                return;
            }

            DialogResult result = MessageBox.Show("Jeni te sigurt qe doni te fshini Sallen?", "Fshi Sallen", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                int RoomID = Convert.ToInt32(row.Cells[0].Value);

                                string query = "DELETE FROM Room WHERE RoomID = @RoomID";
                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@RoomID", RoomID);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show("Nuk u gjet asnje Salle me ID = " + RoomID + " per tu fshire.");
                                }
                            }
                        }

                        MessageBox.Show("Sallat u fshine me sukses.");
                        LoadSalla();
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

        private void btnPastro_Click_1(object sender, EventArgs e)
        {
            pastro();
        }
    }
 }