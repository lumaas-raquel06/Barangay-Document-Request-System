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
            loaddata("Pending for Approval", dgvPending, dudYear.Text);
        }
        public async void loaddata(string status, DataGridView dgv, string year, string search = "")
        {
            try
            {
                HttpClient client = new HttpClient();
                // Gi-add ang &search= sa URL
                string url = $"http://localhost/Barangay-Document-Request-System/web/api/fetchRequests.php?status={Uri.EscapeDataString(status)}&year={year}&search={Uri.EscapeDataString(search)}";

                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<List<RequestData>>(response);

                dgv.Rows.Clear();
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        dgv.Rows.Add(item.id, item.Fullname, item.Documents, item.Purposes, item.DateofRequest, "View");
                    }
                }
            }
            catch (Exception ex)
            {
                // Ayaw lang i-show ang error kada type para dili samok ang UX
                Console.WriteLine("Search error: " + ex.Message);
            }
        }

        // Class para sa JSON Mapping
        public class RequestData
        {
            public string id { get; set; }
            public string Fullname { get; set; }
            public string Documents { get; set; }
            public string Purposes { get; set; }
            public string DateofRequest { get; set; }
            public string Status { get; set; }
        }

        private void searchtxt_OnValueChanged(object sender, EventArgs e)
        {
            string currentStatus = tabControl1.SelectedTab.Text;
            DataGridView targetDgv = dgvPending;

            // 2. I-map ang Tab Text ngadto sa Database Status
            // Siguroha nga mo-match ni sa imong Tab Names
            switch (currentStatus)
            {
                case "Request":
                    currentStatus = "Pending for Approval";
                    targetDgv = dgvPending;
                    break;
                case "Approved":
                    targetDgv = dgvApproved;
                    break;
                case "Disapproved":
                    targetDgv = dgvDisapproved;
                    break;
                case "Completed":
                    targetDgv = dgvCompleted;
                    break;
            }

            // 3. Tawgon ang loaddata function gamit ang text gikan sa searchtxt
            // Gi-apil nato ang dudYear.Text para ang i-search ra nija kay ang sulod sa maong tuig
            loaddata(currentStatus, targetDgv, dudYear.Text, searchtxt.Text);
        }
    }
}
