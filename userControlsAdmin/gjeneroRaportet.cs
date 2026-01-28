using FinalProject_Eva_Bardhoku.NewReports;
//using Microsoft.Reporting.WebForms;

//using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WinForms;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace FinalProject_Eva_Bardhoku.userControlsAdmin
{
    public partial class gjeneroRaportet : UserControl
    {
        public gjeneroRaportet()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportViewer1.Show();
            reportViewer2.Hide();
            reportViewer3.Hide();
            reportViewer4.Hide();

            try
            {
                // Initialize and fill the dataset
                NewReports.FinalProjectDataSet ds = new NewReports.FinalProjectDataSet();
                NewReports.FinalProjectDataSetTableAdapters.StudentGrupTableAdapter adapter =
                    new NewReports.FinalProjectDataSetTableAdapters.StudentGrupTableAdapter();
                adapter.Fill(ds.StudentGrup);

                // Clear existing data sources
                reportViewer1.LocalReport.DataSources.Clear();

                // Define and add the new data source — name must match the dataset name in the RDLC
                ReportDataSource rds = new ReportDataSource("DataSet1", (System.Data.DataTable)ds.Tables["StudentGrup"]);
                reportViewer1.LocalReport.DataSources.Add(rds);

                // Set the path to the RDLC report — make sure it's marked as "Embedded Resource"
                reportViewer1.LocalReport.ReportEmbeddedResource =
                    "FinalProject_Eva_Bardhoku.NewReports.RaportGrupetMesimore.rdlc";

                // Refresh the report viewer
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the report:\n" + ex.Message,
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reportViewer2.Show();
            reportViewer1.Hide();
            reportViewer3.Hide();
            reportViewer4.Hide();

            try
            {
                // Initialize and fill the dataset
                NewReports.FinalProjectDataSet1 ds = new NewReports.FinalProjectDataSet1();
                NewReports.FinalProjectDataSet1TableAdapters.PedagogTableAdapter adapter =
                    new NewReports.FinalProjectDataSet1TableAdapters.PedagogTableAdapter();
                adapter.Fill(ds.Pedagog);

                // Clear existing data sources
                reportViewer2.LocalReport.DataSources.Clear();

                // Define and add the new data source — name must match the dataset name in the RDLC
                ReportDataSource rds = new ReportDataSource("DataSetRaportPedagog", (System.Data.DataTable)ds.Tables["Pedagog"]);
                reportViewer2.LocalReport.DataSources.Add(rds);

                // Set the path to the RDLC report — make sure it's marked as "Embedded Resource"
                reportViewer2.LocalReport.ReportEmbeddedResource =
                    "FinalProject_Eva_Bardhoku.NewReports.RaportPedagog.rdlc";

                // Refresh the report viewer
                reportViewer2.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the report:\n" + ex.Message,
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            reportViewer3.Show();
            reportViewer1.Hide();
            reportViewer2.Hide();
            reportViewer4.Hide();

            try
            {
                // Initialize and fill the dataset
                NewReports.FinalProjectDataSet2 ds = new NewReports.FinalProjectDataSet2();
                NewReports.FinalProjectDataSet2TableAdapters.OrariTableAdapter adapter =
                    new NewReports.FinalProjectDataSet2TableAdapters.OrariTableAdapter();
                adapter.Fill(ds.Orari);

                // Clear existing data sources
                reportViewer3.LocalReport.DataSources.Clear();

                // Correct the data source table here
                ReportDataSource rds = new ReportDataSource("DataSet1", (System.Data.DataTable)ds.Tables["Orari"]);
                reportViewer3.LocalReport.DataSources.Add(rds);

                // Set the path to the RDLC report
                reportViewer3.LocalReport.ReportEmbeddedResource =
                    "FinalProject_Eva_Bardhoku.NewReports.RaportOrari.rdlc";

                // Refresh the report viewer
                reportViewer3.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the report:\n" + ex.Message,
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            reportViewer4.Show();
            reportViewer1.Hide();
            reportViewer2.Hide();
            reportViewer3.Hide();

            try
            {
                // Initialize and fill the dataset
                NewReports.FinalProjectDataSet3 ds = new NewReports.FinalProjectDataSet3();
                NewReports.FinalProjectDataSet3TableAdapters.FrekuentimiTableAdapter adapter =
                    new NewReports.FinalProjectDataSet3TableAdapters.FrekuentimiTableAdapter();
                adapter.Fill(ds.Frekuentimi);

                // Clear existing data sources
                reportViewer4.LocalReport.DataSources.Clear();

                // Define and add the new data source — name must match the dataset name in the RDLC
                ReportDataSource rds = new ReportDataSource("DataSet1", (System.Data.DataTable)ds.Tables["Frekuentimi"]);
                reportViewer4.LocalReport.DataSources.Add(rds);

                // Set the path to the RDLC report — make sure it's marked as "Embedded Resource"
                reportViewer4.LocalReport.ReportEmbeddedResource =
                    "FinalProject_Eva_Bardhoku.NewReports.RaportFrekuentimi.rdlc";

                // Refresh the report viewer
                reportViewer4.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the report:\n" + ex.Message,
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportViewer3_Load(object sender, EventArgs e)
        {

        }
    }
    }




