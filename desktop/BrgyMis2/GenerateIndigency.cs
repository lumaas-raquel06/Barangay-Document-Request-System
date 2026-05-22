using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BrgyMis2
{
    public partial class GenerateIndigency : Form
    {
        private string requestId;
        private readonly string baseApiUrl = "http://127.0.0.1:8000/api/";

        public GenerateIndigency(string selectedRequestId)
        {
            InitializeComponent();
            requestId = selectedRequestId;
        }

        private void panelCertificate_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void GenerateIndigency_Load(object sender, EventArgs e)
        {
            GenerateORNumber();
            await LoadDocumentData();
            UpdateCertificateFooter();
        }

        private async Task LoadDocumentData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = baseApiUrl + "requests/" + requestId;
                    string responseBody = await client.GetStringAsync(url);

                    dynamic response = JsonConvert.DeserializeObject(responseBody);

                    if (response == null || response.success != true)
                    {
                        MessageBox.Show("Unable to load indigency document details.");
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
                    lblCertAddress.Text = (string)data.HomeAddress;

                    string civilStatus = "";

                    try
                    {
                        civilStatus = (string)data.civilStatus;
                    }
                    catch
                    {
                        civilStatus = "of legal age";
                    }

                    lblCertCivilStatus.Text = civilStatus;

                    DateTime issueDate = dtpDateIssued.Value;
                    lblCertDay.Text = issueDate.Day.ToString();
                    lblCertMonth.Text = issueDate.ToString("MMMM");
                    lblCertYear.Text = issueDate.Year.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading indigency document data:\n\n" + ex.Message,
                    "Loading Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void GenerateORNumber()
        {
            string orNumber = "OR-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            txtORNumber.Text = orNumber;
            lblCertORNumber.Text = orNumber;

            txtORNumber.ReadOnly = true;
        }

        private void UpdateCertificateFooter()
        {
            lblCertDateIssued.Text = dtpDateIssued.Value.ToString("MMMM dd, yyyy");
            lblCertDocStamp.Text = "Paid";
        }

        private void dtpDateIssued_ValueChanged(object sender, EventArgs e)
        {
            DateTime issueDate = dtpDateIssued.Value;

            lblCertDay.Text = issueDate.Day.ToString();
            lblCertMonth.Text = issueDate.ToString("MMMM");
            lblCertYear.Text = issueDate.Year.ToString();

            UpdateCertificateFooter();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
