using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProject_Eva_Bardhoku.Program;


namespace FinalProject_Eva_Bardhoku.userControlsSekretaria
{
    public partial class ShtoStudentControl : UserControl
    {
        public int ID;
        public string conn = GlobalData.globalConnString;
        public ShtoStudentControl()
        {
            InitializeComponent();
            LoadUsers();
        }
        private void btn_Shto_Click(object sender, EventArgs e)
        {
            string FirstName = txtEmri.Text;
            string LastName = txtMbiemri.Text;
            string email = txtEmail.Text;
            string Password = txtPassword.Text;
            string BirthDate = txtDitelindja.Text;
            string tel = txtNrTel.Text;
            string Gender = rBtnF.Checked ? "F" : (rBtnM.Checked ? "M" : "");
            string adrese = txtAdresa.Text;
            string Role = "student"; 

            int ID = this.ID;

            if (Role != "student")
            {
                MessageBox.Show("Role duhet te jete 'student'.");
                return;
            }

            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName)  ||
                string.IsNullOrWhiteSpace(tel) || string.IsNullOrWhiteSpace(BirthDate) || string.IsNullOrEmpty(Gender) ||
                string.IsNullOrWhiteSpace(adrese) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(Role))
            {
                MessageBox.Show("Ju lutem plotesoni te gjitha fushat.");
                return;
            }

            string hashedPassword = HashPasswordSHA256(Password);


            string query = "ShtoStudentControl"; 

            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", ID);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                    cmd.Parameters.AddWithValue("@PhoneNumber", tel);
                    cmd.Parameters.AddWithValue("@BirthDate", BirthDate);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@Address", adrese);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Role", Role);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(ID == 0 ? "Studenti u shtua me sukses." : "Studenti u modifikua me sukses.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            LoadUsers();
        }

        public void LoadUsers()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    // string query = "SELECT UserID,FirstName ,LastName,Role,PhoneNumber, BirthDate ,Gender ,Address ,Email,HashedPassword FROM Users WHERE Role = 'student'";
                    string query = "SELECT UserID,FirstName ,LastName,Role,PhoneNumber, BirthDate ,Gender ,Address ,Email FROM Users WHERE Role = 'student'";


                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Role"], reader["PhoneNumber"],
   reader["BirthDate"], reader["Gender"], reader["Address"], reader["Email"]);

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


        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem selektoni nje rresht per ta fshire.");
                return;
            }

            DialogResult result = MessageBox.Show("Jeni te sigurt qe doni te fshini studentet e selektuar?", "Fshi Student", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            int UserID = Convert.ToInt32(row.Cells["UserID"].Value); 

                            string query = "DELETE FROM Users WHERE UserID = @UserID";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@UserID", UserID);

                            int rowsAffected = cmd.ExecuteNonQuery(); 

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"Studenti me ID: {UserID} u fshi me sukses.");
                            }
                            else
                            {
                                MessageBox.Show($"Nuk u gjet asnje student me kete ID: {UserID}.");
                            }
                        }
                        MessageBox.Show("Studenti u fshi me sukses");
                        LoadUsers();
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
                        ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value); 

                        using (SqlConnection sqlConnection = new SqlConnection(conn))
                        {
                            sqlConnection.Open();

                            string query = "SELECT * FROM Users WHERE UserID = @ID";
                            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@ID", ID);

                                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                                {
                                    if (dataReader.Read())
                                    {
                                        txtEmri.Text = dataReader["FirstName"].ToString();
                                        txtMbiemri.Text = dataReader["LastName"].ToString();
                                        txtEmail.Text = dataReader["Email"].ToString();
                                        txtNrTel.Text = dataReader["PhoneNumber"].ToString();
                                        txtDitelindja.Text = dataReader["BirthDate"].ToString();
                                        txtAdresa.Text = dataReader["Address"].ToString();

                                        string gender = dataReader["Gender"].ToString();
                                        if (gender == "F")
                                            rBtnF.Checked = true;
                                        else if (gender == "M")
                                            rBtnM.Checked = true;

                                        comboBox1.SelectedItem = dataReader["Role"].ToString();
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
                    MessageBox.Show("Nuk keni shtypur rreshtin e duhur.");
                }
            }
        public void Search(string kerkoText)
        {
            string kerkoTxt = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(kerkoTxt))
            {
                LoadUsers();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();
                        string query = "SELECT UserID, FirstName, LastName, Role, PhoneNumber, BirthDate, Gender, Address, Email,  " +
                               "FROM Users " +
                               "WHERE Role = 'student' AND (FirstName LIKE  @kerkoTxt OR LastName LIKE  @kerkoTxt ) " +
                               "ORDER BY FirstName ASC";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@kerkoTxt", "%" + kerkoTxt + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Role"], reader["PhoneNumber"],
                           reader["BirthDate"], reader["Gender"], reader["Address"], reader["Email"]);
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
        public void pastro()
        {
            txtEmri.Clear();
            txtMbiemri.Clear();
            txtEmail.Clear();
            txtAdresa.Clear();
            ID = 0;
            txtDitelindja.Clear();
            txtNrTel.Clear();
            txtPassword.Clear();
            comboBox1.SelectedIndex =-1;
            rBtnM.Checked = false;
            rBtnF.Checked = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        private void btnPastro_Click_1(object sender, EventArgs e)
        {
            pastro();
        }

        private string HashPasswordSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2")); // hex format
                }
                return builder.ToString();
            }
        }

    }
}
