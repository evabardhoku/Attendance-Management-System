using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static FinalProject_Eva_Bardhoku.Program;

namespace FinalProject_Eva_Bardhoku.userControlsSekretaria
{
    public partial class StudentCardControl : UserControl
    {
        int ID = 0;
        public string conn = GlobalData.globalConnString;

        public StudentCardControl()
        {
            InitializeComponent();
            LoadStudentet();
            LoadGrup();
            LoadViti();
            LoadKartaInfo();
        }

        private void LoadStudentet()
        {
            string query = @"SELECT UserID, FirstName, LastName FROM Users WHERE Role = 'student'";

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbStudenti.DisplayMember = "FirstName";
                    cmbStudenti.ValueMember = "UserID";
                    cmbStudenti.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadGrup()
        {
            string query = @" SELECT LearningGroupID, GroupName FROM LearningGroups";

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbGrupet.DisplayMember = "GroupName";
                    cmbGrupet.ValueMember = "LearningGroupID";
                    cmbGrupet.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadViti()
        {
            string query = @"SELECT AcademicYearID, YearName FROM AcademicYear";

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbViti.DisplayMember = "YearName";
                    cmbViti.ValueMember = "AcademicYearID";
                    cmbViti.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadKartaInfo()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("LoadStudentCard", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Email"], reader["PhoneNumber"],
                                               reader["CardNumber"], reader["GroupName"], reader["YearName"]);
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

        private string GjeneroKarteStudenti()
        {
            Random rand = new Random();
            return rand.Next(100000, 1000000).ToString();
        }

        private bool KaGrupStudenti(int StudentID)
        {
            string query = @"SELECT COUNT(*) FROM GroupStudents WHERE StudentID = @StudentID";

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentID", StudentID);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
        private void btnGjeneroKarte_Click(object sender, EventArgs e)
        {
            int StudentID = (int)cmbStudenti.SelectedValue;

            if (KaGrupStudenti(StudentID))
            {
                string cardNumber = GjeneroKarteStudenti();
                txtKartaStudentit.Text = cardNumber;
            }
            else
            {
                MessageBox.Show("Ky student nuk eshte futur ne nje grup. Dhe nuk mund te gjenerohet nje Karte, Ju lutem vendoseni ne nje grup dhe provojeni perseri nga ComboBox.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem perzgjidhni nje rresht per ta fshire.");
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
                            int StudentID = Convert.ToInt32(row.Cells["UserID"].Value); 

                            string query = "DELETE FROM StudentCard WHERE StudentID = @StudentID";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@StudentID", StudentID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                             Console.WriteLine($"Studenti me ID: {StudentID} u fshi me sukses.");
                            }
                            else
                            {
                                MessageBox.Show($"Nuk u gjet asnje student me kete ID: {StudentID}.");
                            }
                        }

                        LoadKartaInfo();
                        MessageBox.Show("Studentet u fshine me sukses.");
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



        private void btnInsert_Click(object sender, EventArgs e)
        {
            int StudentID = (int)cmbStudenti.SelectedValue;
            int grupID = (int)cmbGrupet.SelectedValue;
            int vitiID = (int)cmbViti.SelectedValue;
            string numriKartes = txtKartaStudentit.Text;

            InsertOseUpdateKartaStudent(StudentID, vitiID, numriKartes, grupID);
            LoadKartaInfo();
        }

        private void InsertOseUpdateKartaStudent(int StudentID, int vitiID, string numriKartes, int grupID)
        {
            if (string.IsNullOrEmpty(numriKartes))
            {
                MessageBox.Show("Ju lutem plotesoni numrin e kartes.");
                return;
            }

            if (StudentID <= 0 || grupID <= 0 || vitiID <= 0)
            {
                MessageBox.Show("Ju lutem plotesoni te gjitha informacionet.");
                return;
            }

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ShtoStudentCardControl", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StudentID", StudentID);
                    cmd.Parameters.AddWithValue("@CardNumber", numriKartes);
                    cmd.Parameters.AddWithValue("@AcademicYearID", vitiID);
                    cmd.Parameters.AddWithValue("@LearningGroupID", grupID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Karta e Studentit u shtua/modifikua me sukses.");

                    LoadKartaInfo();
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
            LoadKartaInfo();
        }

        private void Pastro()
        {
            cmbStudenti.SelectedIndex = -1;
            cmbGrupet.SelectedIndex = -1;
            cmbViti.SelectedIndex = -1;
            txtKartaStudentit.Clear();
        }

        private void cmbStudenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudenti.SelectedValue != null)
            {
                int StudentID = (int)cmbStudenti.SelectedValue;

                btnGjeneroKarte.Enabled = KaGrupStudenti(StudentID);

                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        string query = @"SELECT gs.LearningGroupID, g.AcademicYearID 
                                         FROM GroupStudents gs
                                         JOIN LearningGroups g ON gs.LearningGroupID = g.LearningGroupID
                                         WHERE gs.StudentID = @StudentID";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@StudentID", StudentID);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            cmbGrupet.SelectedValue = reader["LearningGroupID"];
                            cmbViti.SelectedValue = reader["AcademicYearID"];
                        }
                        else
                        {
                            MessageBox.Show("Ky student nuk ka nje grup ose vit akademik te lidhur.");
                            cmbGrupet.SelectedIndex = -1;
                            cmbViti.SelectedIndex = -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int StudentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                    using (SqlConnection sqlConnection = new SqlConnection(conn))
                    {
                        sqlConnection.Open();

                        string query = "SELECT * FROM StudentCard WHERE StudentID = @StudentID";

                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@StudentID", StudentID);

                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    cmbStudenti.SelectedValue = dataReader["StudentID"].ToString();
                                    txtKartaStudentit.Text = dataReader["CardNumber"].ToString();
                                    cmbViti.SelectedValue = dataReader["AcademicYearID"].ToString();
                                    cmbGrupet.SelectedValue = dataReader["LearningGroupID"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Studenti nuk ka nje Karte aktive.");
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

        public void Search(string kerkoText)
        {
            string kerkoTxt = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(kerkoTxt))
            {
                LoadKartaInfo();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        string query = @"SELECT u.UserID,  u.FirstName, u.LastName, u.Email, u.PhoneNumber, sa.CardNumber,g.GroupName, v.YearName
                            FROM Users u
                            JOIN GroupStudents gs ON u.UserID = gs.StudentID
                            JOIN LearningGroups g ON gs.LearningGroupID = g.LearningGroupID
                            JOIN AcademicYear v ON g.AcademicYearID = v.AcademicYearID
                            LEFT JOIN StudentCard sa ON u.UserID = sa.StudentID
                            WHERE u.Role = 'student' AND (u.FirstName LIKE @kerkoTxt OR 
                                                              u.LastName LIKE @kerkoTxt  OR 
                                                               sa.CardNumber LIKE @kerkoTxt)
                                                               ORDER BY FirstName ASC";

                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@kerkoTxt", "%" + kerkoTxt + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Email"], reader["PhoneNumber"]
                           , reader["CardNumber"], reader["GroupName"], reader["YearName"]);
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
            string searchText = txtSearch.Text;
            Search(searchText);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pastro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadKartaInfo();
            LoadStudentet();
        }
    }
}