using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using static FinalProject_Eva_Bardhoku.Program;

namespace FinalProject_Eva_Bardhoku.userControlsStudent
{
    public partial class FrekuentimiControl : UserControl
    {
        int ID;
        public string conn = GlobalData.globalConnString;

        public FrekuentimiControl(int loggedInStudentID)
        {
            InitializeComponent();
            ID = loggedInStudentID;

            LoadSubjects(ID);          // Load ComboBox subjects first
            LoadStudentAttendance(ID); // Load full attendance
        }

        // Simple subject model
        public class SubjectItem
        {
            public int SubjectID { get; set; }
            public string SubjectName { get; set; }

            public override string ToString()
            {
                return SubjectName; // What gets displayed in ComboBox
            }
        }

        private void LoadSubjects(int studentID)
        {
            comboSubjects.Items.Clear();

            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();
                    string query = @"
                        SELECT DISTINCT s.SubjectID, s.SubjectName
                        FROM Subject s
                        JOIN Attendance a ON s.SubjectID = a.SubjectID
                        WHERE a.StudentID = @StudentID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboSubjects.Items.Add(new SubjectItem
                        {
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            SubjectName = reader["SubjectName"].ToString()
                        });
                    }

                    if (comboSubjects.Items.Count > 0)
                        comboSubjects.SelectedIndex = 0;
                    else
                        comboSubjects.Text = "No subjects found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading subjects: " + ex.Message);
                }
            }
        }

        private void LoadStudentAttendance(int studentID, int? subjectID = null)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    con.Open();

                    string query = @"
                        SELECT u.FirstName, u.LastName, u.Email, 
                               p.AttendanceDate, p.Status, 
                               l.SubjectName, g.GroupName
                        FROM Attendance p
                        JOIN Subject l ON p.SubjectID = l.SubjectID
                        JOIN GroupStudents gs ON p.StudentID = gs.StudentID
                        JOIN LearningGroups g ON gs.LearningGroupID = g.LearningGroupID
                        JOIN Users u ON p.StudentID = u.UserID
                        WHERE p.StudentID = @StudentID";

                    if (subjectID.HasValue)
                        query += " AND p.SubjectID = @SubjectID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    if (subjectID.HasValue)
                        cmd.Parameters.AddWithValue("@SubjectID", subjectID.Value);

                    SqlDataReader reader = cmd.ExecuteReader();

                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    // Define columns
                    dataGridView1.Columns.Add("FirstName", "First Name");
                    dataGridView1.Columns.Add("LastName", "Last Name");
                    dataGridView1.Columns.Add("Email", "Email");
                    dataGridView1.Columns.Add("AttendanceDate", "Date");
                    dataGridView1.Columns.Add("Status", "Status");
                    dataGridView1.Columns.Add("SubjectName", "Subject");
                    dataGridView1.Columns.Add("GroupName", "Group");

                    if (!reader.HasRows)
                    {
                        MessageBox.Show("No attendance data found.");
                        return;
                    }

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["FirstName"],
                            reader["LastName"],
                            reader["Email"],
                            Convert.ToDateTime(reader["AttendanceDate"]).ToString("yyyy-MM-dd"),
                            reader["Status"],
                            reader["SubjectName"],
                            reader["GroupName"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Example: a button to filter attendance by selected subject
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (comboSubjects.SelectedItem is SubjectItem selectedSubject)
            {
                LoadStudentAttendance(ID, selectedSubject.SubjectID);
            }
            else
            {
                MessageBox.Show("Please select a subject.");
            }
        }
    }
}
