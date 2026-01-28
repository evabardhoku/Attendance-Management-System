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
    public partial class ShtoDepControl : UserControl
    {
        public int ID;
        public string conn = GlobalData.globalConnString;
        public ShtoDepControl()
        {
            InitializeComponent();
            LoadDep();
        }
        public void LoadDep()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();
                    string query = "SELECT DepartmentID,DepartmentName,Status FROM Department";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["DepartmentID"], reader["DepartmentName"], reader["Status"]);
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
  
        private void button2_Click(object sender, EventArgs e)
        {
            string emriDep = txtEmriDep.Text;
            string departmentStatus = chkBAktiv.Checked ? "Aktiv" : "Joaktiv";

            if (string.IsNullOrWhiteSpace(emriDep) || string.IsNullOrEmpty(departmentStatus))
            {
                MessageBox.Show("Ju lutem mos e lini bosh emrin e Departamentit.");
                return;
            }

            string query = "ShtoDepartamentControl";

            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DepartmentID", ID); 
                    cmd.Parameters.AddWithValue("@DepartmentName", emriDep);
                    cmd.Parameters.AddWithValue("@Status", departmentStatus);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Department u shtua me sukses.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            LoadDep(); 
        }

    
    private void button4_Click(object sender, EventArgs e)
        {
            pastro();
        }

        public void kerko(string kerkoText)
        {
            kerkoText = txtSearchDep.Text.Trim().ToLower();
            string statusFilter = chkBAktiv.Checked ? "Aktiv" : "Joaktiv";

            if (string.IsNullOrWhiteSpace(kerkoText) && string.IsNullOrWhiteSpace(statusFilter))
            {
                LoadDep();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        string query = "SELECT DepartmentID, DepartmentName, Status FROM Department WHERE DepartmentName LIKE @kerkoText  OR Status = @statusFilter";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@kerkoText", "%" + kerkoText + "%");
                        cmd.Parameters.AddWithValue("@statusFilter", kerkoText);

                        SqlDataReader reader = cmd.ExecuteReader();

                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["DepartmentID"], reader["DepartmentName"], reader["Status"]);
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
        private void txtSearchDep_TextChanged(object sender, EventArgs e)
        {
          kerko(txtSearchDep.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem selektoni nje rresht para se ta fshini.");
                return;
            }

            DialogResult result = MessageBox.Show("Jeni te sigurt qe doni te fshini Departamentet?", "Fshi Departamentet", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            int DepartmentID = Convert.ToInt32(row.Cells[0].Value);

                            string query = "DELETE FROM Department WHERE DepartmentID = @DepartmentID";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Department me ID: " + DepartmentID + " u fshi me sukses.");
                            }
                            else
                            {
                                MessageBox.Show("Nuk u gjet asnje departament me ID e specifikuar.");
                            }
                        }

                        MessageBox.Show("Departamentet u fshine me sukses.");
                        LoadDep();
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


        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Ju lutem selektoni nje Departament para se te fshini.");
        //        return;
        //    }

        //    int UserID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

        //    DialogResult result = MessageBox.Show("Jeni te sigurt qe doni ta fshini Departamentin?", "Fshi Departament", MessageBoxButtons.YesNo);
        //    if (result == DialogResult.Yes)
        //    {
        //        using (SqlConnection con = new SqlConnection(conn))
        //        {
        //            try
        //            {
        //                con.Open();

        //                string query = "DELETE FROM Department WHERE DepartmentID = @DepartmentID";
        //                SqlCommand cmd = new SqlCommand(query, con);
        //                cmd.Parameters.AddWithValue("@DepartmentID", UserID);

        //                int rowsAffected = cmd.ExecuteNonQuery(); 

        //                if (rowsAffected > 0)
        //                {
        //                    MessageBox.Show("Department u fshi me sukses.");
        //                    LoadDep(); 
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Nuk u gjet asnje departament me ID e specifikuar.");
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Error: " + ex.Message);
        //            }
        //            finally
        //            {
        //                con.Close();
        //            }
        //        }
        //    }
        //}

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

                        string query = "SELECT * FROM Department WHERE DepartmentID = @DepartmentID";
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@DepartmentID", ID);

                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    txtEmriDep.Text = dataReader["DepartmentName"].ToString();
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
        public void pastro()
        {
            txtEmriDep.Clear();
            ID = 0;
            chkBAktiv.Checked = false;
        }

      
    }
}
