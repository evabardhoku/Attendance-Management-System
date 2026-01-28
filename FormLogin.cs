using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography; 
using static FinalProject_Eva_Bardhoku.Program;

namespace FinalProject_Eva_Bardhoku
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public string conn = GlobalData.globalConnString;

        private void btn_login_Click(object sender, EventArgs e)
        {
            string Email = textBox1.Text;
            string Password = textBox2.Text;

            string queryString = "SELECT * FROM Users WHERE Email = @Email";

            using (var connection = new SqlConnection(conn))
            {
                connection.Open();
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Email", Email);

                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    if (reader.Read())
                    {
                        string storedHashedPassword = reader["HashedPassword"].ToString();
                        string fullName = reader["FirstName"].ToString();
                        string userRole = reader["Role"]?.ToString();
                        int UserID = Convert.ToInt32(reader["UserID"]);

                        using (SHA256 sha256Hash = SHA256.Create())
                        {
                            bool validPass = VerifyHash(sha256Hash, Password, storedHashedPassword);

                            if (validPass)
                            {
                                Form nextForm = null;

                                if (userRole == "admin")
                                    nextForm = new AdminForm(fullName, userRole);
                                else if (userRole == "pedagog")
                                    nextForm = new PedagogForm(fullName, userRole, UserID);
                                else if (userRole == "sekretaria")
                                    nextForm = new SekretariaForm(fullName, userRole);
                                else if (userRole == "student")
                                    nextForm = new StudentForm(fullName, userRole, UserID);

                                if (nextForm != null)
                                {
                                    nextForm.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email ose Password i gabuar.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Emaili nuk u gjet.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }

        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            string hashOfInput = GetHash(hashAlgorithm, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
