using Microsoft.Reporting.WinForms;
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

namespace FinalProject_Eva_Bardhoku.userControlsPedagog
{
    public partial class gjeneroRaport : UserControl
    {
        public gjeneroRaport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Make sure the reportViewer is visible
            reportViewer1.Show();

            try
            {
                // Get the selected date from the date picker
                DateTime selectedDate = dateTimePicker1.Value.Date;

                // Define your SQL query
                string query = @"
            SELECT
                FirstName,
                LastName,
                Email,
                GroupName,
                Status,
                InstructorFirstName,
                InstructorLastName
            FROM
                DailyStudentAttendanceReport
            WHERE
                AttendanceDate = @SelectedDate
            ORDER BY
                GroupName, LastName, FirstName;";

                // Create a DataTable to hold the query results
                DataTable dt = new DataTable();

                // Use your actual connection string here
                string connectionString = "Data Source=DESKTOP-6N42GG2\\SQLEXPRESS;Initial Catalog=FinalProject;Integrated Security=True;Encrypt=False";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameter value to prevent SQL injection
                        cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);

                        // Use SqlDataAdapter to fill the DataTable
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                // Clear existing data sources in the report viewer
                reportViewer1.LocalReport.DataSources.Clear();

                // Set the new data source; "DataSet1" must match the RDLC's dataset name
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rds);

                // Set the path to the RDLC report
                reportViewer1.LocalReport.ReportEmbeddedResource =
                    "FinalProject_Eva_Bardhoku.NewReports.RaportAttendance.rdlc";

                // Refresh the report viewer to show updated data
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                // Show any error that occurred
                MessageBox.Show("An error occurred while generating the report:\n" + ex.Message,
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
