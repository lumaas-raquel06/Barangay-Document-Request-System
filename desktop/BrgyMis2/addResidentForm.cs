using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using System.Threading;
using System.Net.Http;                   
using System.Net.Http.Headers;            
using Newtonsoft.Json;
namespace BrgyMis2
{
    public partial class addResidentForm : Form
    {
        public addResidentForm()
        {
            InitializeComponent();
            agetxt.Enabled = false; // para dili ma-edit
        }
        function fc = new function();
        //Timer t = new Timer();
        database db = new database();
        public string id { get; set; }
        string area = "";

        public void update()
        {
            if (id != null)
            {
                string[] info = {
            "fname","mname","lname","ext","placeOfBirth",
            "age","gender","bday","isVoter","civilStatus",
            "nationality","contact",
            "houseNumber","block","lot","streetName","areaType"
        };
                // removed "email" here

                Dictionary<string, dynamic> inforesult = db.fetchRecordWithCondition("tbl_residentinfo", info, "residentId", id);

                fnametxt.Text = inforesult["fname"];
                mnametxt.Text = inforesult["mname"];
                lnametxt.Text = inforesult["lname"];
                exttxt.Text = inforesult["ext"];
                pobtxt.Text = inforesult["placeOfBirth"];
                dobdrp.Value = Convert.ToDateTime(inforesult["bday"]);
                fc.SetSelectedValue(genderdrp, inforesult["gender"]);
                fc.SetSelectedValue(csdrp, inforesult["civilStatus"]);
                fc.SetSelectedValue(natdrp, inforesult["nationality"]);
                fc.SetSelectedValue(isvoterdrp, inforesult["isVoter"]);
                contxt.Text = (inforesult["contact"].Length >= 10) ? inforesult["contact"].Substring(3, 10) : "";
                agetxt.Text = inforesult["age"];

                housenotxt.Text = inforesult.ContainsKey("houseNumber") ? inforesult["houseNumber"] : "";
                blktxt.Text = inforesult.ContainsKey("block") ? inforesult["block"] : "";
                lottxt.Text = inforesult.ContainsKey("lot") ? inforesult["lot"] : "";
                streettxt.Text = inforesult.ContainsKey("streetName") ? inforesult["streetName"] : "";
                if (inforesult.ContainsKey("areaType"))
                    fc.SetSelectedValue(areatypedrp, inforesult["areaType"]);

                // fetch email separately from user_resident
                string[] authInfo = { "email" };
                Dictionary<string, dynamic> authResult = db.fetchRecordWithCondition("user_resident", authInfo, "residentId", id);
                if (authResult.ContainsKey("email"))
                    emailtxt.Text = authResult["email"];

                savebtn.Text = "Save Changes";
                label2.Text = "Update Resident";
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void contxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            fc.KeyPressNumOnly(e, contxt.Text, 10);
        }

        private void fnametxt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private async Task savedata()
        {
            string email = emailtxt.Text.Trim();
            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid Email Address!", "Invalid Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string residentId = GenerateResidentId();
            string autoUsername = (fnametxt.Text.Trim() + "." + lnametxt.Text.Trim())
                                  .ToLower().Replace(" ", "");
            string autoPassword = dobdrp.Value.ToString("MMddyyyy");

            string json = "{" +
                "\"residentId\":\"" + residentId + "\"," +
                "\"fname\":\"" + fnametxt.Text + "\"," +
                "\"mname\":\"" + mnametxt.Text + "\"," +
                "\"lname\":\"" + lnametxt.Text + "\"," +
                "\"ext\":\"" + exttxt.Text + "\"," +
                "\"placeOfBirth\":\"" + pobtxt.Text + "\"," +
                "\"age\":\"" + fc.CalculateAge(dobdrp.Value.ToString()) + "\"," +
                "\"gender\":\"" + genderdrp.selectedValue + "\"," +
                "\"bday\":\"" + dobdrp.Value.ToString("yyyy-MM-dd") + "\"," +
                "\"isVoter\":\"" + isvoterdrp.selectedValue + "\"," +
                "\"civilStatus\":\"" + csdrp.selectedValue + "\"," +
                "\"nationality\":\"" + natdrp.selectedValue + "\"," +
                "\"contact\":\"" + ((contxt.Text.Length == 10) ? "+63" + contxt.Text : "") + "\"," +
                "\"houseNumber\":\"" + housenotxt.Text + "\"," +
                "\"block\":\"" + blktxt.Text + "\"," +
                "\"lot\":\"" + lottxt.Text + "\"," +
                "\"streetName\":\"" + streettxt.Text + "\"," +
                "\"areaType\":\"" + areatypedrp.selectedValue + "\"," +
                "\"username\":\"" + autoUsername + "\"," +
                "\"password\":\"" + autoPassword + "\"," +
                "\"email\":\"" + email + "\"," +
                "\"status\":\"Active\"" +
            "}";

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    string apiUrl = "http://localhost/Barangay-Documents-Online-Request-System/api/residents.php";
                    var response = await client.PostAsync(apiUrl, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (responseBody.Contains("\"success\":true"))
                    {

                        MessageBox.Show(
                            "Resident saved successfully!\n\n" +
                            "Login Credentials:\n" +
                            "Username: " + autoUsername + "\n" +
                            "Password: " + autoPassword + "\n\n" +
                            "Please inform the resident of their credentials.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information
                        );

                        residentUserControl.Instance.loaddata();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error saving resident!\n" + responseBody, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string GenerateResidentId()
        {
            string yearPrefix = "2026"; // fixed year prefix
            int lastNumber = db.GetLastResidentNumber(yearPrefix); // custom method to query DB
            int newNumber = lastNumber + 1;
            string formattedNumber = newNumber.ToString("D4"); // 0001, 0002, etc.
            return yearPrefix + "-" + formattedNumber;
        }



        private async Task updatedata()
        {
            using (var client = new HttpClient())
            {
                // Update resident personal info
                var values = new Dictionary<string, string>
                {
                    { "residentId", id },
                    { "fname", fnametxt.Text },
                    { "mname", mnametxt.Text },
                    { "lname", lnametxt.Text },
                    { "gender", genderdrp.selectedValue },
                    { "bday", dobdrp.Value.ToString("yyyy-MM-dd") },
                    { "age", agetxt.Text },
                    { "contact", (contxt.Text.Length == 10) ? "+63" + contxt.Text : "" },
                    { "status", "Active" }
                };

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://localhost/Barangay-Documents-Online-Request-System/api/updateResident.php", content);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (responseBody.Contains("\"success\":true"))
                {
                    // Update email separately
                    var emailValues = new Dictionary<string, string>
                    {
                        { "residentId", id },
                        { "email", emailtxt.Text }
                    };
                    var emailContent = new FormUrlEncodedContent(emailValues);
                    await client.PostAsync("http://localhost/Barangay-Documents-Online-Request-System/api/updateUserResident.php", emailContent);

                    MessageBox.Show("Resident updated successfully!");
                    residentUserControl.Instance.loaddata();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error updating resident!\n" + responseBody);
                }
            }
        }



        private void dobdrp_onValueChanged(object sender, EventArgs e)
        {
            agetxt.Text = fc.CalculateAge(dobdrp.Value.ToString()).ToString();
        }

        private void addResidentForm_Shown(object sender, EventArgs e)
        {
            update();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                await savedata();
            }
            else
            {
                updatedata();
            }
        }
    }
}
