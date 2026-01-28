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
    public partial class ShtoOrarControl : UserControl
    {

        public int ID;
        public string conn = GlobalData.globalConnString;

        public ShtoOrarControl()
        {
            InitializeComponent();
            LoadOrari();
            LoadGrupet();
            LoadKlasa();
            LoadLende();
            LoadPedagog();
        }
        private void LoadOrari()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    string query = @"SELECT om.ScheduleID, l.SubjectName, s.RoomName , om.Weekday , om.StartTime ,om.EndTime,g.GroupName,u.FirstName 
                                FROM  Schedule om
                                JOIN Subject l ON om.SubjectID = l.SubjectID
                                JOIN Room s ON om.RoomID = s.RoomID
                                JOIN LearningGroups g ON om.LearningGroupID = g.LearningGroupID
                                JOIN Users u ON om.InstructorID = u.UserID
                                WHERE u.Role = 'pedagog'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["ScheduleID"], reader["SubjectName"], reader["RoomName"], reader["Weekday"], reader["GroupName"],
                            reader["StartTime"], reader["EndTime"], reader["FirstName"]);
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

        private void LoadPedagog()
        {
            string query = "SELECT UserID, FirstName FROM Users WHERE Role = 'pedagog'";
            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbPedagog.DisplayMember = "FirstName";
                cmbPedagog.ValueMember = "UserID";
                cmbPedagog.DataSource = dt;
            }
        }
        private void LoadLende()
        {
            string query = "SELECT SubjectID, SubjectName FROM Subject";
            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbLenda.DisplayMember = "SubjectName";
                cmbLenda.ValueMember = "SubjectID";
                cmbLenda.DataSource = dt;
            }
        }
        private void LoadKlasa()
        {
            string query = "SELECT RoomID, RoomName FROM Room";
            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbSalla.DisplayMember = "RoomName";
                cmbSalla.ValueMember = "RoomID";
                cmbSalla.DataSource = dt;
            }
        }

        private void LoadGrupet()
        {
            string query = "SELECT LearningGroupID, GroupName FROM LearningGroups";
            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbGrupet.DisplayMember = "GroupName";
                cmbGrupet.ValueMember = "LearningGroupID";
                cmbGrupet.DataSource = dt;
            }
        }
       private void InsertOseUpdateOrari()
        {
            if (cmbLenda.SelectedIndex == -1 || cmbSalla.SelectedIndex == -1 || cmbDitaJaves.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtFillim.Text) || string.IsNullOrWhiteSpace(txtMbarim.Text) ||
                cmbPedagog.SelectedIndex == -1 || cmbGrupet.SelectedIndex == -1)
            {
                MessageBox.Show("Ju lutem plotesoni te gjitha fushat.");
                return;
            }

            string storedProcedure = "ShtoOrarControl";

            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ScheduleID", ID);
                    cmd.Parameters.AddWithValue("@SubjectID", cmbLenda.SelectedValue);
                    cmd.Parameters.AddWithValue("@RoomID", cmbSalla.SelectedValue);
                    cmd.Parameters.AddWithValue("@Weekday", cmbDitaJaves.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@StartTime", txtFillim.Text);
                    cmd.Parameters.AddWithValue("@EndTime", txtMbarim.Text);
                    cmd.Parameters.AddWithValue("@LearningGroupID", cmbGrupet.SelectedValue);
                    cmd.Parameters.AddWithValue("@InstructorID", cmbPedagog.SelectedValue);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Schedule u shtua/modifikua me sukses.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            LoadOrari();
            Pastro();
        }

        public void Search(string kerkoText)
        {
            string kerkoTxt = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(kerkoTxt))
            {
                LoadOrari();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        string query = @"SELECT om.ScheduleID, l.SubjectName, s.RoomName, om.Weekday, 
                           om.StartTime, om.EndTime, g.GroupName, u.FirstName
                            FROM Schedule om
                            JOIN Subject l ON om.SubjectID = l.SubjectID
                            JOIN Room s ON om.RoomID = s.RoomID
                            JOIN LearningGroups g ON om.LearningGroupID = g.LearningGroupID
                            JOIN Users u ON om.InstructorID = u.UserID
                            WHERE (l.SubjectName LIKE @kerkoTxt OR 
                           om.Weekday LIKE @kerkoTxt OR 
                           g.GroupName LIKE @kerkoTxt OR
                           s.RoomName LIKE @kerkoTxt )";

                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@kerkoTxt", "%" + kerkoTxt + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["ScheduleID"], reader["SubjectName"], reader["RoomName"], reader["Weekday"], reader["GroupName"],
                                reader["StartTime"], reader["EndTime"], reader["FirstName"]);
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

        private void Pastro()
        {
            cmbLenda.SelectedIndex = -1;
            cmbSalla.SelectedIndex = -1;
            cmbDitaJaves.SelectedIndex = -1;
            txtFillim.Clear();
            txtMbarim.Clear();
            cmbPedagog.SelectedIndex = -1;
            cmbGrupet.SelectedIndex = -1;
        }

        private void btn_Shto_Click(object sender, EventArgs e)
        {
            InsertOseUpdateOrari();
            LoadOrari();
            Pastro();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        private void btnPastro_Click(object sender, EventArgs e)
        {
            Pastro();
        }


        private void btn_Fshi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem selektoni rresht para se te fshini.");
                return;
            }

            DialogResult result = MessageBox.Show("Jeni te sigurt qe doni ta fshini orarin?", "Fshi Orar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        con.Open();

                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                                int ScheduleID = Convert.ToInt32(row.Cells[0].Value);

                                string query = "DELETE FROM Schedule WHERE ScheduleID = @ScheduleID";
                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@ScheduleID", ScheduleID);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                Console.WriteLine($"Schedule me ID: {ScheduleID} u fshi me sukses.");
                            }
                                else
                                {
                                    MessageBox.Show("Nuk u gjet asnje orar me ID e specifikuar.");
                                }
                            }
                        
                        MessageBox.Show("Schedule u fshi me sukses.");
                        LoadOrari();
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

                        string query = "SELECT * FROM Schedule WHERE ScheduleID = @ScheduleID";
                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@ScheduleID", ID);

                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    cmbLenda.SelectedValue = dataReader["SubjectID"].ToString();
                                    cmbSalla.SelectedValue = dataReader["RoomID"].ToString();
                                    cmbDitaJaves.Text = dataReader["Weekday"].ToString();
                                    txtFillim.Text = dataReader["StartTime"].ToString();
                                    txtMbarim.Text = dataReader["EndTime"].ToString();
                                    cmbPedagog.SelectedValue = dataReader["InstructorID"].ToString();
                                    cmbGrupet.SelectedValue = dataReader["LearningGroupID"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Nuk u gjet asnje e dhene per orarin e selektuar.");
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
    }
}