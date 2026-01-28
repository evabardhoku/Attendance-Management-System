using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProject_Eva_Bardhoku.Program;
//using BCrypt.Net;
using System.Security.Cryptography;

namespace FinalProject_Eva_Bardhoku.userControls
{
    public partial class ShtoUserControl : UserControl
    {
        public int ID;
        public string conn = GlobalData.globalConnString;

        public ShtoUserControl()
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
            string Role = comboBox1.SelectedItem.ToString();

            int ID = this.ID;

            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(tel) || string.IsNullOrWhiteSpace(BirthDate) || string.IsNullOrEmpty(Gender) ||
                string.IsNullOrWhiteSpace(adrese) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(Role))
            {
                MessageBox.Show("Ju lutem mos lini fusha bosh.");
                return;
            }

            string hashedPassword = HashPasswordSHA256(Password);

       


        string query = "ShtoUserControl"; 

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

                        MessageBox.Show(ID == 0 ? "Perdoruesi u shtua me sukses." : "Perdoruesi u modifikua me sukses.");
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
                    string query = "SELECT UserID,FirstName ,LastName,Role,PhoneNumber, BirthDate ,Gender ,Address ,Email,HashedPassword FROM Users " +
                        "WHERE Role != 'student'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Role"], reader["PhoneNumber"],
                           reader["BirthDate"], reader["Gender"], reader["Address"], reader["Email"], reader["HashedPassword"] );
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
                MessageBox.Show("Ju lutem perzgjidhni nje rresht per ta fshire!");
                return;
            }

            DialogResult result = MessageBox.Show("Jeni te sigurt qe doni te fshini kete perdorues?", "Fshi User", MessageBoxButtons.YesNo);
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
                               Console.WriteLine("Useri me ID: " + UserID + " u fshi me sukses.");
                            }
                            else
                            {
                                MessageBox.Show("Nuk u gjet asnje user me kete ID.");
                            }
                        }

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

                        string query = "SELECT * FROM Users WHERE UserID = @UserID";
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@UserID", ID);

                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    txtEmri.Text = dataReader["FirstName"].ToString();
                                    txtMbiemri.Text = dataReader["LastName"].ToString();
                                    comboBox1.SelectedItem = dataReader["Role"].ToString();
                                    txtNrTel.Text = dataReader["PhoneNumber"].ToString();
                                    txtDitelindja.Text = dataReader["BirthDate"].ToString();
                                  
                                    string gender = dataReader["Gender"].ToString();
                                    if (gender == "F")
                                        rBtnF.Checked = true;
                                    else if (gender == "M")
                                        rBtnM.Checked = true;

                                    txtAdresa.Text = dataReader["Address"].ToString();
                                    txtEmail.Text = dataReader["Email"].ToString();
                                    txtPassword.Text = dataReader["HashedPassword"].ToString();
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
                MessageBox.Show("Keni zgjedhur rreshtin e gabuar.");
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
                        string query = "SELECT UserID,FirstName ,LastName ,Role,PhoneNumber ,BirthDate ,Gender ,Address ,Email,HashedPassword FROM Users " +
                           "WHERE FirstName LIKE  @kerkoTxt  or LastName LIKE  @kerkoTxt";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@kerkoTxt", "%" + kerkoTxt + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Role"], reader["PhoneNumber"],
                           reader["BirthDate"], reader["Gender"], reader["Address"], reader["Email"], reader["HashedPassword"]);
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
            comboBox1.SelectedIndex = -1; 
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