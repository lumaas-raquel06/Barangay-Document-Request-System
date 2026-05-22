using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace BrgyMis2
{
    public partial class Report : UserControl
    {
        private Bitmap reportBitmap;
        private static Report _instance;

        public Report()
        {
            InitializeComponent();
        }

        public static Report Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Report();

                return _instance;
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // =========================
            // RESIDENT REPORT
            // =========================

            if (cmbReportType.Text == "Resident Records")
            {
                dataGridView1.Columns.Add(
                    "colResidentId",
                    "Resident ID");

                dataGridView1.Columns.Add(
                    "colFullName",
                    "Full Name");

                dataGridView1.Columns.Add(
                    "colGender",
                    "Gender");

                dataGridView1.Columns.Add(
                    "colBirthdate",
                    "Birthdate");

                dataGridView1.Columns.Add(
                    "colAge",
                    "Age");

                dataGridView1.Columns.Add(
                    "colContact",
                    "Contact No");

                dataGridView1.Columns.Add(
                    "colAddress",
                    "Address");

                dataGridView1.Columns.Add(
                    "colStatus",
                    "Status");

                // SAMPLE DATA
                dataGridView1.Rows.Add(
                    "RES-2026-0001",
                    "Juan Dela Cruz",
                    "Male",
                    "2004-05-12",
                    "22",
                    "09123456789",
                    "Ayahag Saint Bernard",
                    "Active");

                dataGridView1.Rows.Add(
                    "RES-2026-0002",
                    "Maria Santos",
                    "Female",
                    "2003-10-20",
                    "23",
                    "09171234567",
                    "Ayahag Saint Bernard",
                    "Active");
            }

            // =========================
            // COMPLETED REQUEST REPORT
            // =========================

            else if (cmbReportType.Text ==
                     "Completed Requests")
            {
                dataGridView1.Columns.Add(
                    "colRequestId",
                    "Request ID");

                dataGridView1.Columns.Add(
                    "colResidentName",
                    "Resident Name");

                dataGridView1.Columns.Add(
                    "colDocumentType",
                    "Document Type");

                dataGridView1.Columns.Add(
                    "colPurpose",
                    "Purpose");

                dataGridView1.Columns.Add(
                    "colDateRequested",
                    "Date Requested");

                dataGridView1.Columns.Add(
                    "colStatus",
                    "Status");

                // SAMPLE DATA
                dataGridView1.Rows.Add(
                    "15",
                    "Jowella Mae",
                    "Barangay Clearance",
                    "Scholarship",
                    "2026-05-20",
                    "Completed");

                dataGridView1.Rows.Add(
                    "16",
                    "Raquel Changka",
                    "Certificate of Indigency",
                    "Financial Assistance",
                    "2026-05-22",
                    "Completed");
            }
        }

        private void Report_Load(object sender, EventArgs e)
        {
            cmbReportType.Items.Add(
        "Resident Records");

            cmbReportType.Items.Add(
                "Completed Requests");

            cmbYear.Items.Add("2024");
            cmbYear.Items.Add("2025");
            cmbYear.Items.Add("2026");

            cmbYear.SelectedItem = "2026";
        }

        private void CaptureReport()
        {
            reportBitmap = new Bitmap(
                panelReportPreview.Width,
                panelReportPreview.Height
            );

            panelReportPreview.DrawToBitmap(
                reportBitmap,
                new Rectangle(
                    0,
                    0,
                    panelReportPreview.Width,
                    panelReportPreview.Height
                )
            );
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                CaptureReport();

                printPreviewDialog1.Document =
                    printDocument1;

                printPreviewDialog1.WindowState =
                    FormWindowState.Maximized;

                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Print Error: " + ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle marginBounds =
        e.MarginBounds;

            float scale =
                Math.Min(
                    (float)marginBounds.Width /
                    reportBitmap.Width,

                    (float)marginBounds.Height /
                    reportBitmap.Height);

            int width =
                (int)(reportBitmap.Width * scale);

            int height =
                (int)(reportBitmap.Height * scale);

            e.Graphics.DrawImage(
                reportBitmap,
                marginBounds.Left,
                marginBounds.Top,
                width,
                height);
        }
    }
}
