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
        }
        public async void loaddata(string status, DataGridView dgv, string year, string search = "")
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url =
                        baseApiUrl +
                        "requests?status=" + Uri.EscapeDataString(status) +
                        "&year=" + Uri.EscapeDataString(year) +
                        "&search=" + Uri.EscapeDataString(search);

                    string responseBody = await client.GetStringAsync(url);

                    if (string.IsNullOrWhiteSpace(responseBody))
                    {
                        dgv.Rows.Clear();

                        MessageBox.Show(
                            "The API returned an empty response.",
                            "No Response",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

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
                    {
                        return;
                    }

                    foreach (var item in apiResponse.data)
                    {
                        dgv.Rows.Add(
                            item.id,
                            item.Fullname,
                            item.Documents,
                            item.Purposes,
                            item.DateofRequest,
                            "View"
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
            string currentStatus = "";
            DataGridView targetDgv = null;

            switch (tabControl1.SelectedTab.Text)
            {
                case "Request":
                    currentStatus = "Pending for Approval";
                    targetDgv = dgvPending;
                    break;

                case "Approved":
                    currentStatus = "Approved";
                    targetDgv = dgvApproved;
                    break;

                case "Disapproved":
                    currentStatus = "Disapproved";
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void requestUserControl_Load(object sender, EventArgs e)
        {
            if (dudYear.Text == "domainUpDown1" || string.IsNullOrEmpty(dudYear.Text))
            {
                dudYear.Text = DateTime.Now.Year.ToString();
            }

            loaddata("Pending for Approval", dgvPending, dudYear.Text);
        }

        private void dudYear_SelectedItemChanged(object sender, EventArgs e)
        {
            searchtxt_OnValueChanged(sender, e);
        }
    }
}
