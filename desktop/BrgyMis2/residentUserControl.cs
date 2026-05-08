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
            f.Show();
        }

        private void residentUserControl_Paint(object sender, PaintEventArgs e)
        {
           
           
        }


        public async void loaddata()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string apiUrl = "http://localhost/Barangay-Documents-Online-Request-System/api/residents.php";
                    var response = await client.GetAsync(apiUrl);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Simple JSON parsing
                    // Kuhaon ang "data" array
                    int dataStart = responseBody.IndexOf("\"data\":[") + 8;
                    int dataEnd = responseBody.LastIndexOf("]");
                    string dataArray = responseBody.Substring(dataStart, dataEnd - dataStart);

                    // Load sa DataTable
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

                    // I-parse ang JSON objects
                    string[] residents = dataArray.Split(new string[] { "},{" }, StringSplitOptions.None);
                    foreach (string resident in residents)
                    {
                        string r = resident.Replace("{", "").Replace("}", "");
                        DataRow row = dt.NewRow();
                        row["ID"] = getJsonValue(r, "residentId");
                        row["Firstname"] = getJsonValue(r, "fname");
                        row["Middlename"] = getJsonValue(r, "mname");
                        row["Lastname"] = getJsonValue(r, "lname");
                        row["Gender"] = getJsonValue(r, "gender");
                        row["Birthdate"] = getJsonValue(r, "bday");
                        row["Age"] = getJsonValue(r, "age");
                        row["Contact"] = getJsonValue(r, "contact");
                        row["Email"] = getJsonValue(r, "email");
                        row["Status"] = getJsonValue(r, "status");
                        dt.Rows.Add(row);
                    }

                    mytable.DataSource = dt;
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

        private async void residentUserControl_Load(object sender, EventArgs e)
        {
            try
            {
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void searchtxt_OnValueChanged(object sender, EventArgs e)
        {
            if (!(filterdrp.selectedIndex <= -1))
            {
                try
                {
                    DataView dv = new DataView(db.table);
                    dv.RowFilter = string.Format("CONVERT({0}, System.String) Like '%{1}%'", filterdrp.selectedValue, searchtxt.Text);
                    mytable.DataSource = dv;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            addResidentForm f = new addResidentForm();
            f.id = mytable.SelectedCells[0].Value.ToString();
            f.Show();
        }

    }
}
