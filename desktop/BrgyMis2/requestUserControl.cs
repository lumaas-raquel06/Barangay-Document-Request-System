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
    public partial class requestUserControl : UserControl
    {
        private static requestUserControl _instance;
        private readonly string baseApiUrl = "http://127.0.0.1:8000/api/";
        private Timer refreshTimer = new Timer();
        private bool isLoading = false;

        public static requestUserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new requestUserControl();

                return _instance;
            }
        }

        public requestUserControl()
        {
            InitializeComponent();
            SetupDataGridViews();

            refreshTimer.Interval = 2000;
            refreshTimer.Tick += refreshTimer_Tick;
            refreshTimer.Start();

            dgvPending.CellContentClick += RequestGrid_CellContentClick;
            dgvApproved.CellContentClick += RequestGrid_CellContentClick;
            dgvDisapproved.CellContentClick += RequestGrid_CellContentClick;
            dgvCompleted.CellContentClick += RequestGrid_CellContentClick;
        }

        private void RequestGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridView dgv = sender as DataGridView;

            if (dgv == null)
                return;

            if (dgv.Columns[e.ColumnIndex].HeaderText != "Action")
                return;

            try
            {
                string requestId = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                string documentType = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                string actionText = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();

                refreshTimer.Stop();

                if (actionText == "View")
                {
                    using (RequestDetailsForm detailsForm = new RequestDetailsForm(requestId))
                    {
                        if (detailsForm.ShowDialog() == DialogResult.OK)
                        {
                            RefreshAllRequestTabs();
                        }
                    }
                }
                else if (actionText == "Generate / Done")
                {
                    DialogResult choice = MessageBox.Show(
                        "Choose YES to generate the document.\nChoose NO to mark this request as completed.",
                        "Approved Request Action",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                    );

                    if (choice == DialogResult.Yes)
                    {
                        OpenGenerateDocumentForm(requestId, documentType);
                    }
                    else if (choice == DialogResult.No)
                    {
                        MarkRequestAsCompleted(requestId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to process request action.\n\nDetails: " + ex.Message,
                    "Request Action Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                refreshTimer.Start();
            }
        }

        private async void MarkRequestAsCompleted(string requestId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var data = new
                    {
                        Status = "Completed"
                    };

                    var content = new StringContent(
                        JsonConvert.SerializeObject(data),
                        Encoding.UTF8,
                        "application/json"
                    );

                    var request = new HttpRequestMessage(
                        new HttpMethod("PATCH"),
                        baseApiUrl + "requests/" + requestId + "/status"
                    );

                    request.Content = content;

                    var response = await client.SendAsync(request);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(
                            "Request marked as completed successfully.",
                            "Completed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        RefreshAllRequestTabs();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Unable to mark request as completed.\n\n" + responseBody,
                            "Update Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error marking request as completed:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void OpenGenerateDocumentForm(string requestId, string documentType)
        {
            if (documentType == "Barangay Clearance")
            {
                using (GenerateDocumentForm form = new GenerateDocumentForm(requestId))
                {
                    form.ShowDialog();
                }
            }
            else if (documentType == "Certificate of Indigency")
            {
                using (GenerateIndigency form = new GenerateIndigency(requestId))
                {
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(
                    "Document generation is only available for Barangay Clearance and Certificate of Indigency.",
                    "Unavailable Document Type",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            LoadCurrentTabData();
        }

        private void LoadCurrentTabData()
        {
            string currentStatus = "";
            DataGridView targetDgv = null;

            switch (tabControl1.SelectedTab.Text)
            {
                case "Pending":
                    currentStatus = "Pending for Approval";
                    targetDgv = dgvPending;
                    break;

                case "Approved":
                    currentStatus = "Approved";
                    targetDgv = dgvApproved;
                    break;

                case "Disapproved":
                    currentStatus = "Rejected";
                    targetDgv = dgvDisapproved;
                    break;

                case "Completed":
                    currentStatus = "Completed";
                    targetDgv = dgvCompleted;
                    break;
            }

            if (targetDgv != null)
            {
                loaddata(currentStatus, targetDgv, dudYear.Text, searchtxt.Text);
            }
        }

        private void SetupDataGridViews()
        {
            dgvPending.AutoGenerateColumns = false;
            dgvApproved.AutoGenerateColumns = false;
            dgvDisapproved.AutoGenerateColumns = false;
            dgvCompleted.AutoGenerateColumns = false;

            dgvPending.AllowUserToAddRows = false;
            dgvApproved.AllowUserToAddRows = false;
            dgvDisapproved.AllowUserToAddRows = false;
            dgvCompleted.AllowUserToAddRows = false;
        }

        public async void loaddata(string status, DataGridView dgv, string year, string search = "")
        {
            if (isLoading)
                return;

            isLoading = true;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url =
                        baseApiUrl +
                        "requests?status=" + Uri.EscapeDataString(status.Trim()) +
                        "&year=" + Uri.EscapeDataString(year.Trim()) +
                        "&search=" + Uri.EscapeDataString(search.Trim());

                    string responseBody = await client.GetStringAsync(url);

                    ApiResponse apiResponse =
                        JsonConvert.DeserializeObject<ApiResponse>(responseBody);

                    dgv.Rows.Clear();

                    if (apiResponse == null || apiResponse.success == false)
                    {
                        MessageBox.Show(
                            apiResponse?.message ?? "Unable to load request records.",
                            "API Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }

                    if (apiResponse.data == null || apiResponse.data.Count == 0)
                        return;

                    foreach (var item in apiResponse.data)
                    {
                        string actionText = status == "Approved" ? "Generate / Done" : "View";

                        dgv.Rows.Add(
                            item.id,
                            item.Fullname,
                            item.Documents,
                            item.Purposes,
                            item.DateofRequest,
                            actionText
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                dgv.Rows.Clear();

                MessageBox.Show(
                    "Unable to load document requests.\n\nDetails: " + ex.Message,
                    "Request Loading Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                isLoading = false;
            }
        }

        private void RefreshAllRequestTabs()
        {
            loaddata("Pending for Approval", dgvPending, dudYear.Text, searchtxt.Text);
            loaddata("Approved", dgvApproved, dudYear.Text, searchtxt.Text);
            loaddata("Rejected", dgvDisapproved, dudYear.Text, searchtxt.Text);
            loaddata("Completed", dgvCompleted, dudYear.Text, searchtxt.Text);
        }

        public class ApiResponse
        {
            public bool success { get; set; }
            public string message { get; set; }
            public List<RequestData> data { get; set; }
        }

        // Class para sa JSON Mapping
        public class RequestData
        {
            public string id { get; set; }
            public string residentId { get; set; }
            public string Fullname { get; set; }
            public string Birthdate { get; set; }
            public string Age { get; set; }
            public string Gender { get; set; }
            public string HomeAddress { get; set; }
            public string Contact { get; set; }
            public string DateofRequest { get; set; }
            public string Purposes { get; set; }
            public string Documents { get; set; }
            public string Fee { get; set; }
            public string ValidID { get; set; }
            public string FrontID { get; set; }
            public string BackID { get; set; }
            public string Payment { get; set; }
            public string Service { get; set; }
            public string Status { get; set; }
        }

        private void searchtxt_OnValueChanged(object sender, EventArgs e)
        {
            LoadCurrentTabData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void requestUserControl_Load(object sender, EventArgs e)
        {
            if (dudYear.Text == "domainUpDown1" || string.IsNullOrEmpty(dudYear.Text))
            {
                dudYear.Text = DateTime.Now.Year.ToString();
            }

            RefreshAllRequestTabs();
        }

        private void dudYear_SelectedItemChanged(object sender, EventArgs e)
        {
            RefreshAllRequestTabs();

        }
    }
}
