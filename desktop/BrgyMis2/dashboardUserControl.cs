using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace BrgyMis2
{
    public partial class dashboardUserControl : UserControl
    {
        private readonly string baseApiUrl = "http://127.0.0.1:8000/api/";

        public dashboardUserControl()
        {
            InitializeComponent();
        }
        private static dashboardUserControl instance;
        public static dashboardUserControl Instance
        {
            get
            {
                if (instance == null)
                    instance = new dashboardUserControl();
                return instance;
            }
        }

        private async void dashboardUserControl_Load(object sender, EventArgs e)
        {
            await LoadDashboardCounts();
        }

        private async Task LoadDashboardCounts()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string response =
                        await client.GetStringAsync(
                            baseApiUrl + "dashboard-counts");

                    dynamic data =
                        JsonConvert.DeserializeObject(response);

                    lblTotalResidents.Text =
                        data.totalResidents.ToString();

                    lblPendingRequests.Text =
                        data.pendingRequests.ToString();

                    lblApprovedRequests.Text =
                        data.approvedRequests.ToString();

                    lblCompletedRequests.Text =
                        data.completedRequests.ToString();

                    lblRejectedRequests.Text =
                        data.rejectedRequests.ToString();

                    lblTotalRequests.Text =
                        data.totalRequests.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Dashboard Error: " + ex.Message);
            }
        }
    }
}
