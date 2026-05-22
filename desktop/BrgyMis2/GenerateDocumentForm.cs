using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Drawing.Printing;

namespace BrgyMis2
{
    public partial class GenerateDocumentForm : Form
    {
        private Bitmap certificateImage;
        private PrintDocument printDocument = new PrintDocument();
        private string requestId;
        private readonly string baseApiUrl = "http://127.0.0.1:8000/api/";

        public GenerateDocumentForm(string selectedRequestId)
        {
            InitializeComponent();
            requestId = selectedRequestId;
            printDocument.PrintPage += printDocument_PrintPage;
        }

        private void CaptureCertificate()
        {
            certificateImage =
                new Bitmap(
                    panelCertificate.Width * 3,
                    panelCertificate.Height * 3);

            panelCertificate.DrawToBitmap(
                certificateImage,
                new Rectangle(
                    0,
                    0,
                    certificateImage.Width,
                    certificateImage.Height));
        }


        private async void GenerateDocumentForm_Load(object sender, EventArgs e)
        {
            await LoadDocumentData();
            LoadDocumentFooter();
        }

        private void GenerateORNumber()
        {
            string orNumber = "OR-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // left panel textbox
            txtORNumber.Text =
                orNumber;

            // certificate preview
            lblCertORNumber.Text =
                orNumber;
        }

        private void LoadDocumentFooter()
        {
            GenerateORNumber();

            // Date Issued sa certificate
            lblCertDateIssued.Text =
                dtpDateIssued.Value.ToString(
                    "MMMM dd, yyyy");

            // Doc stamp automatic
            lblCertDocStamp.Text = "Paid";
        }
        private async Task LoadDocumentData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string responseBody = await client.GetStringAsync(baseApiUrl + "requests/" + requestId);
                    dynamic response = JsonConvert.DeserializeObject(responseBody);

                    if (response == null || response.success != true)
                    {
                        MessageBox.Show("Unable to load document information.");
                        return;
                    }

                    var data = response.data;

                    lblRequestId.Text = "Request ID: " + (string)data.id;

                    txtDocumentType.Text = (string)data.Documents;
                    txtPurpose.Text = (string)data.Purposes;
                    txtServiceOption.Text = (string)data.Service;
                    txtPaymentOption.Text = (string)data.Payment;
                    txtFee.Text = "₱ " + (string)data.Fee;
                    txtDateRequested.Text = (string)data.DateofRequest;
                    txtStatus.Text = (string)data.Status;

                    txtResidentName.Text = (string)data.Fullname;
                    txtAddress.Text = (string)data.HomeAddress;
                    txtContactNumber.Text = (string)data.Contact;
                    txtEmail.Text = (string)data.email;
                    txtValidIDType.Text = (string)data.ValidID;

                    lblCertResidentName.Text = (string)data.Fullname;
                    lblCertAge.Text = (string)data.Age;
                    lblCertAddress.Text = (string)data.HomeAddress;

                    DateTime issueDate = dtpDateIssued.Value;
                    lblCertDay.Text = issueDate.Day.ToString();
                    lblCertMonth.Text = issueDate.ToString("MMMM");
                    lblCertYear.Text = issueDate.Year.ToString();

                    lblCertORNumber.Text = txtORNumber.Text;
                    lblCertDateIssued.Text = issueDate.ToString("MMMM dd, yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading document data: " + ex.Message);
            }
        }

        private void dtpDateIssued_ValueChanged(object sender, EventArgs e)
        {
            lblCertDateIssued.Text = dtpDateIssued.Value.ToString("MMMM dd, yyyy");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                CaptureCertificate();

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDocument;
                previewDialog.WindowState = FormWindowState.Maximized;
                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print error: " + ex.Message);
            }
        }

        private void printDocument_PrintPage(
    object sender,
    PrintPageEventArgs e)
        {
            e.PageSettings.PaperSize =
                new PaperSize(
                    "A4",
                    827,
                    1169);

            e.PageSettings.Landscape = false;

            int margin = 40;

            Rectangle printableArea =
                new Rectangle(
                    margin,
                    margin,
                    e.PageBounds.Width - (margin * 2),
                    e.PageBounds.Height - (margin * 2));

            e.Graphics.InterpolationMode =
                System.Drawing.Drawing2D
                .InterpolationMode.HighQualityBicubic;

            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D
                .SmoothingMode.HighQuality;

            e.Graphics.PixelOffsetMode =
                System.Drawing.Drawing2D
                .PixelOffsetMode.HighQuality;

            e.Graphics.CompositingQuality =
                System.Drawing.Drawing2D
                .CompositingQuality.HighQuality;

            float ratioX =
                (float)printableArea.Width /
                certificateImage.Width;

            float ratioY =
                (float)printableArea.Height /
                certificateImage.Height;

            float ratio =
                Math.Min(ratioX, ratioY);

            int width =
                (int)(certificateImage.Width * ratio);

            int height =
                (int)(certificateImage.Height * ratio);

            int x =
                (e.PageBounds.Width - width) / 2;

            int y =
                (e.PageBounds.Height - height) / 2;

            e.Graphics.DrawImage(
                certificateImage,
                x,
                y,
                width,
                height);
        }
    }
}
