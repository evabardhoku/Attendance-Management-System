using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static FinalProject_Eva_Bardhoku.Program;

namespace FinalProject_Eva_Bardhoku.userControlsStudent
{
    public partial class CheckIn : UserControl
    {
        private string conn = GlobalData.globalConnString;
        private int studentID;
        private string studentCardNumber;

        public CheckIn()
        {
            InitializeComponent();
        }

        private void CheckIn_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            studentCardNumber = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(studentCardNumber))
                LoadStudentInfo(studentCardNumber);
            else
                SetLabelText("Ju lutem vendosni numrin tuaj të kartës.", Color.Red);
        }

        private void LoadStudentInfo(string cardNumber)
        {
            string query = @"SELECT u.UserID, u.FirstName, u.LastName, u.Email
                             FROM StudentCard sc
                             JOIN Users u ON sc.StudentID = u.UserID
                             WHERE sc.CardNumber = @cardNumber";

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@cardNumber", cardNumber);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    studentID = Convert.ToInt32(reader["UserID"]);
                    textBox2.Text = reader["FirstName"].ToString();
                    textBox3.Text = reader["LastName"].ToString();
                    textBox4.Text = reader["Email"].ToString();
                    textBox5.Text = cardNumber;

                    LoadOpenSessions(studentID);
                }
                else
                {
                    SetLabelText("Numri i kartës është i gabuar.", Color.Red);
                }
            }
        }

        private void LoadOpenSessions(int studentID)
        {
            comboBoxSessions.Items.Clear();
            comboBoxSessions.DisplayMember = "DisplayText";
            comboBoxSessions.ValueMember = "OpenSessionID";

            string query = @"
                SELECT os.OpenSessionID, s.SubjectName, u.FirstName + ' ' + u.LastName AS InstructorName, os.SessionStartTime, os.SessionEndTime
                FROM OpenSessions os
                JOIN Schedule sch ON os.ScheduleID = sch.ScheduleID
                JOIN InstructorInfo ii ON sch.InstructorID = ii.InstructorID AND sch.SubjectID = ii.SubjectID
                JOIN Subject s ON sch.SubjectID = s.SubjectID
                JOIN Users u ON sch.InstructorID = u.UserID
                JOIN GroupStudents gs ON sch.LearningGroupID = gs.LearningGroupID
                WHERE gs.StudentID = @studentID AND os.IsActive = 1";

            using (SqlConnection connDb = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(query, connDb))
            {
                cmd.Parameters.AddWithValue("@studentID", studentID);
                connDb.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                var sessions = new List<dynamic>();

                while (reader.Read())
                {
                    sessions.Add(new
                    {
                        OpenSessionID = reader["OpenSessionID"],
                        DisplayText = $"{reader["SubjectName"]} - {reader["InstructorName"]} ({reader["SessionStartTime"]} - {reader["SessionEndTime"]})"
                    });
                }

                comboBoxSessions.DataSource = sessions;

                if (sessions.Count == 0)
                {
                    SetLabelText("Nuk ka sesione të hapura për grupin tuaj.", Color.Red);
                }
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (comboBoxSessions.SelectedItem == null)
            {
                SetLabelText("Ju lutem zgjidhni një sesion të hapur.", Color.Red);
                return;
            }

            int selectedSessionId = (int)((dynamic)comboBoxSessions.SelectedItem).OpenSessionID;

            string insertQuery = @"
                INSERT INTO Attendance (StudentID, InstructorID, SubjectID, AttendanceDate, Status)
                SELECT @StudentID, sch.InstructorID, sch.SubjectID, GETDATE(), 'Present'
                FROM OpenSessions os
                JOIN Schedule sch ON os.ScheduleID = sch.ScheduleID
                WHERE os.OpenSessionID = @OpenSessionID";

            using (SqlConnection connDb = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand(insertQuery, connDb))
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@OpenSessionID", selectedSessionId);

                connDb.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    SetLabelText("Check-in i suksesshëm!", Color.Green);
                else
                    SetLabelText("Check-in dështoi.", Color.Red);
            }
        }

        private void SetLabelText(string text, Color color)
        {
            if (InvokeRequired)
                Invoke(new Action(() => SetLabelText(text, color)));
            else
            {
                label3.Text = text;
                label3.ForeColor = color;
            }
        }
    }
}
