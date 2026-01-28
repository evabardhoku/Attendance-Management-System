using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProject_Eva_Bardhoku.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProject_Eva_Bardhoku.userControlsPedagog
{
    public partial class OraMesimore : UserControl
    {
        private TcpListener tcpListener;
        private int port = 8888;
        private bool isServerRunning = false;
        private int InstructorID;
        private int selectedStudentCardID = 0;
        public string conn = GlobalData.globalConnString;
        


        public OraMesimore(int pedagogAktivID)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            InstructorID = pedagogAktivID;
        }

        private void comboBoxGrupi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudentet();
        }


        private void StartTCPServerAndOpenSession()
        {
            try
            {
                // Kontrollo nëse janë zgjedhur grupi dhe lënda
                if (comboBoxGrupi.SelectedValue == null || comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("Ju lutem zgjidhni grupin dhe lëndën.");
                    return;
                }

                int selectedGroupID = Convert.ToInt32(comboBoxGrupi.SelectedValue);
                int selectedSubjectID = Convert.ToInt32(comboBox1.SelectedValue);

                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();

                    // Fut në OpenSessions vetëm InstructorID, OpenTime dhe mund të ruash edhe grupin dhe lëndën nëse i ke shtuar në tabelë
                    string insertQuery = @"
                INSERT INTO OpenSessions (InstructorID, OpenTime)
                VALUES (@InstructorID, @OpenTime)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@InstructorID", InstructorID);
                        cmd.Parameters.AddWithValue("@OpenTime", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Nis TCP serverin
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                Task.Run(() => ListenForConnections());

                ShtoStudnetRichTextBox($"📢 Ora u hap për lëndën ID {selectedSubjectID}, grupin ID {selectedGroupID}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in StartTCPServerAndOpenSession:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapKlasen_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isServerRunning)
                {
                    // Kontrollo nëse është zgjedhur grupi dhe lënda
                    if (comboBoxGrupi.SelectedValue == null || comboBox1.SelectedValue == null)
                    {
                        MessageBox.Show("Ju lutem zgjidhni një lëndë dhe grup për të hapur sesionin.");
                        return;
                    }

                    // Nis sesionin dhe serverin TCP
                    isServerRunning = true;
                    btnOpenClassroom.Text = "Mbyll Oren";
                    btnOpenClassroom.BackColor = Color.DarkRed;
                    btnOpenClassroom.ForeColor = Color.White;

                    StartTCPServerAndOpenSession();
                }
                else
                {
                    // Ndal sesionin dhe serverin TCP
                    isServerRunning = false;
                    btnOpenClassroom.Text = "Hap Oren";
                    btnOpenClassroom.BackColor = Color.DarkSlateBlue;
                    btnOpenClassroom.ForeColor = Color.White;

                    if (tcpListener != null)
                    {
                        tcpListener.Stop();
                        tcpListener = null;
                    }

                    // Fshi sesionet e hapura të instruktorit
                    using (SqlConnection con = new SqlConnection(conn))
                    {
                        con.Open();

                        string deleteQuery = @"
                    DELETE FROM OpenSessions
                    WHERE InstructorID = @InstructorID";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@InstructorID", InstructorID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in btnHapKlasen_Click:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void ListenForConnections()
        {
            while (isServerRunning)
            {
                try
                {
                    var client = tcpListener.AcceptTcpClient();
                    var networkStream = client.GetStream();
                    var reader = new StreamReader(networkStream, Encoding.UTF8);
                    var writer = new StreamWriter(networkStream, Encoding.UTF8) { AutoFlush = true };

                    string studentInfo = reader.ReadLine();

                    if (!string.IsNullOrWhiteSpace(studentInfo))
                    {
                        // Supozojmë që studentInfo përmban vetëm numrin e kartës (ose mund ta ndash nëse përmban më shumë).
                        string cardNumber = studentInfo.Trim();

                        if (IsStudentInSelectedGroup(cardNumber))
                        {
                            ShtoStudnetRichTextBox("✔️ Lejohet: " + studentInfo);
                        }
                        else
                        {
                            ShtoStudnetRichTextBox("❌ Nuk lejohet: " + studentInfo);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private bool IsStudentInSelectedGroup(string cardNumber)
        {
            if (comboBoxGrupi.SelectedValue == null || comboBox1.SelectedValue == null)
                return false;

            int selectedGroupID = Convert.ToInt32(comboBoxGrupi.SelectedValue);
            int selectedSubjectID = Convert.ToInt32(comboBox1.SelectedValue);

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string query = @"
            SELECT COUNT(*) 
            FROM StudentCard sc
            INNER JOIN InstructorInfo ii ON sc.LearningGroupID = ii.LearningGroupID
            WHERE sc.CardNumber = @CardNumber
              AND sc.LearningGroupID = @GroupID
              AND ii.SubjectID = @SubjectID
              AND ii.InstructorID = @InstructorID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CardNumber", cardNumber);
                    cmd.Parameters.AddWithValue("@GroupID", selectedGroupID);
                    cmd.Parameters.AddWithValue("@SubjectID", selectedSubjectID);
                    cmd.Parameters.AddWithValue("@InstructorID", InstructorID);  // Use the field

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }






        private void ShtoStudnetRichTextBox(string studentInfo)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action(() => richTextBox1.AppendText(studentInfo + "\n")));
            }
            else
            {
                richTextBox1.AppendText(studentInfo + "\n");
            }
        }
        private void OraMesimore_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            LoadStudentet();
            LoadLenda();
            LoadGrupetMesimore();

            DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
            comboColumn.HeaderText = "Attendance";
            comboColumn.Name = "Attendance";
            comboColumn.Items.Add("Prezent");
            comboColumn.Items.Add("Mungon");
            comboColumn.Items.Add("Justifikuar");

            dataGridView1.Columns.Add(comboColumn);
        }

        private void LoadStudentet()
        {
            if (comboBoxGrupi.SelectedValue == null)
                return;

            int selectedGroupID = Convert.ToInt32(comboBoxGrupi.SelectedValue);

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    string query = @"SELECT Users.UserID, Users.FirstName, Users.LastName, Users.Email, StudentCard.CardNumber
                 FROM Users
                 JOIN StudentCard ON Users.UserID = StudentCard.StudentID
                 WHERE Users.Role = 'student' 
                 AND StudentCard.LearningGroupID = @GroupID";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@GroupID", selectedGroupID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["UserID"], reader["FirstName"], reader["LastName"], reader["Email"], reader["CardNumber"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void LoadLenda()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string subjectQuery = "SELECT SubjectID, SubjectName FROM Subject";
                DataTable subjectTable = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(subjectQuery, connection))
                {
                    connection.Open();
                    adapter.Fill(subjectTable);
                }

                comboBox1.DisplayMember = "SubjectName";
                comboBox1.ValueMember = "SubjectID";
                comboBox1.DataSource = subjectTable;
            }
        }

        private void LoadGrupetMesimore()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string groupQuery = "SELECT LearningGroupID, GroupName FROM LearningGroups";
                DataTable groupTable = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(groupQuery, connection))
                {
                    connection.Open();
                    adapter.Fill(groupTable);
                }

                comboBoxGrupi.DisplayMember = "GroupName";
                comboBoxGrupi.ValueMember = "LearningGroupID";
                comboBoxGrupi.DataSource = groupTable;
            }
        }



        private void RuajPrezencen(int StudentID, int SubjectID, string attendanceStatus)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE StudentID = @StudentID AND SubjectID = @SubjectID AND InstructorID = @InstructorID AND CONVERT(date, AttendanceDate) = CONVERT(date, @today)";

                connection.Open();
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@StudentID", StudentID);
                checkCmd.Parameters.AddWithValue("@SubjectID", SubjectID);
                checkCmd.Parameters.AddWithValue("@InstructorID", InstructorID);
                checkCmd.Parameters.AddWithValue("@today", DateTime.Now);

                int attendanceCount = (int)checkCmd.ExecuteScalar();

                if (attendanceCount > 0)
                {
                    MessageBox.Show("Ketij studenti i eshte vendosur Attendance per sot.", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string insertQuery = "INSERT INTO Attendance (StudentID, InstructorID, SubjectID, AttendanceDate, Status) " +
                                 "VALUES (@StudentID, @InstructorID, @SubjectID, @AttendanceDate, @Status)";

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, connection);

                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                cmd.Parameters.AddWithValue("@InstructorID", InstructorID);
                cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
                cmd.Parameters.AddWithValue("@AttendanceDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@Status", attendanceStatus);

                cmd.ExecuteNonQuery();
            }

            // Notify user
            MessageBox.Show("Attendance u shtua me sukses!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ju lutem selektoni nje student nga DataGridView.");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int StudentID = Convert.ToInt32(row.Cells["UserID"].Value);
                int SubjectID = Convert.ToInt32(comboBox1.SelectedValue);

                string attendanceStatus = row.Cells["Attendance"].Value?.ToString();

                if (string.IsNullOrEmpty(attendanceStatus))
                {
                    MessageBox.Show("Ju lutem vendosni statusin e Prezences per te gjithe studentet.");
                    return;
                }

                RuajPrezencen(StudentID, SubjectID, attendanceStatus);
            }

            MessageBox.Show("Attendance u shtua me sukses per te gjithe studentet!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Attendance"].Index)
            {
                string selectedAttendance = dataGridView1.Rows[e.RowIndex].Cells["Attendance"].Value?.ToString();
                if (!string.IsNullOrEmpty(selectedAttendance))
                {
                    int StudentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value);
                    int SubjectID = Convert.ToInt32(comboBox1.SelectedValue);

                    RuajPrezencen(StudentID, SubjectID, selectedAttendance);

                    string studentName = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                    string studentEmail = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                    string studentCardNumber = dataGridView1.Rows[e.RowIndex].Cells["CardNumber"].Value.ToString();
                    string studentInfo = $"Student Name: {studentName} Card Number: {studentCardNumber} Email: {studentEmail}";

                    ShtoStudnetRichTextBox(studentInfo);
                }
            }
        }


    }
}