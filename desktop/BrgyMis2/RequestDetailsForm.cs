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
using System.IO;

namespace BrgyMis2
{
    public partial class RequestDetailsForm : Form
    {
        private string requestId;
        private string selectedRequestId;
        private readonly string baseApiUrl = "http://127.0.0.1:8000/api/";
        public bool StatusChanged { get; private set; } = false;

        public RequestDetailsForm(string id)
        {
            InitializeComponent();
            requestId = id;
            selectedRequestId = requestId;
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private async Task LoadRequestDetails()
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
                        MessageBox.Show("Unable to load request details.");
                        return;
                    }

                    var data = response.data;

                    lblRequestId.Text = "ID: " + (string)data.id;
                    lblResidentName.Text = (string)data.Fullname;
                    lblAddress.Text = (string)data.HomeAddress;
                    lblContact.Text = (string)data.Contact;
                    lblEmail.Text = (string)data.email;
                    lblDocumentType.Text = (string)data.Documents;
                    lblPurpose.Text = (string)data.Purposes;
                    lblDateRequested.Text = (string)data.DateofRequest;
                    lblStatus.Text = (string)data.Status;
                    lblPayment.Text = (string)data.Payment;
                    lblService.Text = (string)data.Service;
                    lblFee.Text = "₱ " + (string)data.Fee;
                    lblValidId.Text = (string)data.ValidID;

                    string frontFile = (string)data.FrontID;
                    string backFile = (string)data.BackID;

                    string uploadBasePath = @"C:\xampp\htdocs\Barangay-Document-Request-System\web\uploads\";

                    if (!string.IsNullOrEmpty(frontFile))
                    {
                        string frontPath = Path.Combine(uploadBasePath, frontFile);

                        if (File.Exists(frontPath))
                        {
                            picFrontId.Image = Image.FromFile(frontPath);
                            picFrontId.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }

                    if (!string.IsNullOrEmpty(backFile))
                    {
                        string backPath = Path.Combine(uploadBasePath, backFile);

                        if (File.Exists(backPath))
                        {
                            picBackId.Image = Image.FromFile(backPath);
                            picBackId.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading request details: " + ex.Message);
            }
        }

        private async Task<bool> UpdateRequestStatus(
    string status)
        {
            try
            {
                using (HttpClient client =
                    new HttpClient())
                {
                    var data = new
                    {
                        Status = status
                    };

                    var content =
                        new StringContent(
                            JsonConvert.SerializeObject(
                                data),
                            Encoding.UTF8,
                            "application/json"
                        );

                    HttpRequestMessage request =
                        new HttpRequestMessage(
                            new HttpMethod("PATCH"),
                            baseApiUrl +
                            "requests/" +
                            requestId +
                            "/status"
                        );

                    request.Content =
                        content;

                    var response =
                        await client.SendAsync(
                            request);

                    return
                        response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);

                return false;
            }
        }
        private async void RequestDetailsForm_Load(object sender, EventArgs e)
        {
            await LoadRequestDetails();
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            bool updated =
        await UpdateRequestStatus(
            "Approved");

            if (updated)
            {
                StatusChanged = true;

                MessageBox.Show(
                    "Request approved successfully.");

                this.DialogResult =
                    DialogResult.OK;

                this.Close();
            }
        }

        private async void btnDecline_Click(object sender, EventArgs e)
        {
            bool updated = await UpdateRequestStatus("Rejected");

            if (updated)
            {
                StatusChanged =
                    true;

                MessageBox.Show(
                    "Request declined.");

                this.DialogResult =
                    DialogResult.OK;

                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
