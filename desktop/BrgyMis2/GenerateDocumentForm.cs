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


namespace BrgyMis2
{
    public partial class GenerateDocumentForm : Form
    {
        private string requestId;
        private readonly string baseApiUrl = "http://127.0.0.1:8000/api/";

        public GenerateDocumentForm(string selectedRequestId)
        {
            InitializeComponent();
            requestId = selectedRequestId;
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
    }
}
