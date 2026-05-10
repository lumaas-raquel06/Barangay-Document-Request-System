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
    public partial class residentUserControl : UserControl
    {
        public residentUserControl()
        {
            InitializeComponent();

        }
        private static residentUserControl instance;
        database db = new database();
        function fc = new function();
        public static residentUserControl Instance
        {
            get
            {
                if (instance == null)
                    instance = new residentUserControl();
                return instance;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            addResidentForm f = new addResidentForm();
            // Kinahanglan ShowDialog() para "mo-pause" ang code dinhi hangtod ma-close ang form
            if (f.ShowDialog() == DialogResult.OK)
            {
                loaddata(); // Mo-refresh ang DataGrid human nimo i-click ang OK sa save
            }
        }

        private void residentUserControl_Paint(object sender, PaintEventArgs e)
        {
           
           
        }


        public async void loaddata(string viewStatus = "Active")
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string apiUrl = "http://localhost/Barangay-Document-Request-System/web/api/residents.php?status=" + viewStatus;
                    var response = await client.GetAsync(apiUrl);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // FIX: I-check kon ang responseBody nagsugod ba og '{'
                    // Kon nagsugod og '<', pasabot HTML error to gikan sa PHP
                    if (!responseBody.Trim().StartsWith("{"))
                    {
                        MessageBox.Show("Ang API nag-return og HTML imbis nga JSON. Palihug i-check ang residents.php.\n\nServer Response: " + responseBody);
                        return;
                    }

                    dynamic jsonData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("Firstname");
                    dt.Columns.Add("Middlename");
                    dt.Columns.Add("Lastname");
                    dt.Columns.Add("Gender");
                    dt.Columns.Add("Birthdate");
                    dt.Columns.Add("Age");
                    dt.Columns.Add("Contact");
                    dt.Columns.Add("Email");
                    dt.Columns.Add("Status");

                    if (jsonData != null && jsonData.data != null)
                    {
                        foreach (var item in jsonData.data)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = (string)item.residentId ?? "";
                            row["Firstname"] = (string)item.fname ?? "";
                            row["Middlename"] = (string)item.mname ?? "";
                            row["Lastname"] = (string)item.lname ?? "";
                            row["Gender"] = (string)item.gender ?? "";
                            row["Birthdate"] = (string)item.bday ?? "";
                            row["Age"] = (string)item.age ?? "";
                            row["Contact"] = (string)item.contact ?? "";
                            row["Email"] = (string)item.email ?? "";
                            row["Status"] = (string)item.status ?? "";
                            dt.Rows.Add(row);
                        }
                    }
                    mytable.DataSource = dt;
                    searchtxt.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading residents: " + ex.Message);
            }
        }

        // Helper method para mag-extract og value gikan sa JSON string
        private string getJsonValue(string json, string key)
        {
            try
            {
                string search = "\"" + key + "\":\"";
                int start = json.IndexOf(search) + search.Length;
                int end = json.IndexOf("\"", start);
                return json.Substring(start, end - start);
            }
            catch
            {
                return "";
            }
        }

        private void residentUserControl_Load(object sender, EventArgs e)
        {
            // I-set ang dropdown sa "Active" (index 0) inig start
            if (filterdrp.Items.Length > 0)
            {
                filterdrp.selectedIndex = 0;
            }
            loaddata();
        }


        private void searchtxt_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Siguroha nga ang DataSource dili null ug usa ka DataTable
                if (mytable.DataSource is DataTable dt)
                {
                    // Kini mo-search sa Firstname, Lastname, o ID (Real-time)
                    // Pwede nimo pun-an ang columns depende sa imong gusto
                    dt.DefaultView.RowFilter = string.Format(
                        "Firstname LIKE '%{0}%' OR Lastname LIKE '%{0}%' OR ID LIKE '%{0}%'",
                        searchtxt.Text.Replace("'", "''") // Proteksyon sa single quotes
                    );
                }
            }
            catch (Exception ex)
            {
                // Hilom lang kon naay error sa filter para dili samok sa user
                Console.WriteLine("Search Error: " + ex.Message);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            // 1. Siguroha nga naay napili nga row sa imong DataGrid (mytable)
            if (mytable.SelectedRows.Count > 0)
            {
                // 2. Kuhaa ang Resident ID gikan sa "ID" column sa napili nga row
                string selectedId = mytable.SelectedRows[0].Cells["ID"].Value.ToString();

                // 3. I-initialize ang form
                addResidentForm f = new addResidentForm();

                // 4. IMPORTANTE: I-pasa ang ID ngadto sa property sa addResidentForm
                f.id = selectedId;

                // 5. I-show ang form
                if (f.ShowDialog() == DialogResult.OK)
                {
                    loaddata(); // Refresh ang table inig human og edit
                }
            }
            else
            {
                // Kon walay gi-click sa table, pahibalo-on ang user
                MessageBox.Show("Please select a resident from the table first before clicking Edit.",
                                "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

            if (mytable.SelectedRows.Count > 0)
            {
                string resId = mytable.SelectedRows[0].Cells["ID"].Value.ToString();
                string currentStatus = mytable.SelectedRows[0].Cells["Status"].Value.ToString();

                string newStatus = (currentStatus == "Active") ? "Archived" : "Active";
                string actionText = (currentStatus == "Active") ? "archive" : "restore";

                DialogResult result = MessageBox.Show($"Are you sure you want to {actionText} this resident?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 1. Update sa Database (Siguroha nga 'connect.php' ang naa sa updateStatus.php)
                    await updateResidentStatus(resId, newStatus);

                    // 2. Refresh ang table base sa unsay gi-filter karon
                    // Gamita ang .Text kon dili mo-gana ang .selectedValue
                    string currentFilter = filterdrp.Text;

                    if (currentFilter == "Archived")
                    {
                        loaddata("Archived");
                    }
                    else
                    {
                        loaddata("Active");
                    }

                    MessageBox.Show($"Resident successfully {newStatus.ToLower()}d!");
                }
            }
            else
            {
                MessageBox.Show("Please select a resident from the table first.");
            }
        }

        private async Task updateResidentStatus(string id, string status)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = "http://localhost/Barangay-Document-Request-System/web/api/updateStatus.php";
                    var data = new { residentId = id, status = status };
                    var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, content);
                    string resBody = await response.Content.ReadAsStringAsync();

                    // I-check kon tinuod ba nga success
                    if (resBody.ToLower().Contains("true"))
                    {
                        // Ayaw na pag MessageBox dinhi para diretso refresh
                    }
                    else
                    {
                        MessageBox.Show("Server Error: " + resBody);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("C# Error: " + ex.Message);
            }
        }

        private void filterdrp_onItemSelected(object sender, EventArgs e)
        {
            // 1. Pag-check kon naay napili (selectedIndex -1 means walay napili)
            if (filterdrp.selectedIndex != -1)
            {
                string selectedFilter = filterdrp.selectedValue.ToString();

                // 2. Siguroha nga kon "Active" ang napili, "Active" gyud ang i-load
                // Kon "Filter By" ang napili (pananglitan wala nimo nadelete), i-load gihapon ang Active
                if (selectedFilter == "Archived")
                {
                    loaddata("Archived");
                }
                else
                {
                    loaddata("Active");
                }
            }
            else
            {
                // Default load kon walay na-select
                loaddata("Active");
            }
        }

        private void mytable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
