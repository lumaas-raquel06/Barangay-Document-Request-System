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
        database db = new database();
        public string id { get; set; }

        //folder name sa htdocs
        string baseApiUrl = "http://localhost/Barangay-Document-Request-System/web/api/";

        public void update()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    string[] info = {
                        "fname","mname","lname","ext","placeOfBirth",
                        "age","gender","bday","isVoter","civilStatus",
                        "nationality","contact","houseNumber","block","lot","streetName","areaType"
                    };

                    Dictionary<string, dynamic> inforesult = db.fetchRecordWithCondition("tbl_residentinfo", info, "residentId", id);

                    if (inforesult != null && inforesult.Count > 0)
                    {
                        fnametxt.Text = GetVal(inforesult, "fname");
                        mnametxt.Text = GetVal(inforesult, "mname");
                        lnametxt.Text = GetVal(inforesult, "lname");
                        exttxt.Text = GetVal(inforesult, "ext");
                        pobtxt.Text = GetVal(inforesult, "placeOfBirth");
                        agetxt.Text = GetVal(inforesult, "age");

                        if (inforesult.ContainsKey("bday") && !string.IsNullOrEmpty(GetVal(inforesult, "bday")))
                            dobdrp.Value = Convert.ToDateTime(inforesult["bday"]);

                        fc.SetSelectedValue(genderdrp, GetVal(inforesult, "gender"));
                        fc.SetSelectedValue(csdrp, GetVal(inforesult, "civilStatus"));
                        fc.SetSelectedValue(natdrp, GetVal(inforesult, "nationality"));
                        fc.SetSelectedValue(isvoterdrp, GetVal(inforesult, "isVoter"));
                        fc.SetSelectedValue(areatypedrp, GetVal(inforesult, "areaType"));

                        housenotxt.Text = GetVal(inforesult, "houseNumber");
                        blktxt.Text = GetVal(inforesult, "block");
                        lottxt.Text = GetVal(inforesult, "lot");
                        streettxt.Text = GetVal(inforesult, "streetName");

                        string contactRaw = GetVal(inforesult, "contact");
                        if (contactRaw.StartsWith("+63") && contactRaw.Length >= 13)
                            contxt.Text = contactRaw.Substring(3);
                        else
                            contxt.Text = contactRaw;

                        string[] authInfo = { "email" };
                        Dictionary<string, dynamic> authResult = db.fetchRecordWithCondition("user_resident", authInfo, "residentId", id);
                        if (authResult != null && authResult.ContainsKey("email"))
                            emailtxt.Text = authResult["email"];

                        savebtn.Text = "Save Changes";
                        label2.Text = "Update Resident";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update UI Error: " + ex.Message);
                }
            }
        }

        // Helper function para dili mo-crash kon naay NULL sa database
        private string GetVal(Dictionary<string, dynamic> dict, string key)
        {
            return (dict.ContainsKey(key) && dict[key] != null) ? dict[key].ToString() : "";
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
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                MessageBox.Show("Please enter a valid Email Address!");
                return;
            }

            string residentId = GenerateResidentId();
            // Auto-generate credentials
            string autoUsername = (fnametxt.Text.Trim() + "." + lnametxt.Text.Trim()).ToLower().Replace(" ", "");
            string autoPassword = dobdrp.Value.ToString("MMddyyyy");

            // KINI NGA OBJECT DAPAT KUMPLETO PARA DILI MAG-NULL SA PHP
            var data = new
            {
                residentId = residentId,
                fname = fnametxt.Text,
                mname = mnametxt.Text,
                lname = lnametxt.Text,
                ext = exttxt.Text,
                placeOfBirth = pobtxt.Text,
                age = agetxt.Text,
                gender = genderdrp.selectedValue,
                bday = dobdrp.Value.ToString("yyyy-MM-dd"),
                isVoter = isvoterdrp.selectedValue,
                civilStatus = csdrp.selectedValue,
                nationality = natdrp.selectedValue,
                contact = (contxt.Text.Length == 10) ? "+63" + contxt.Text : contxt.Text,

                // --- ADDED ADDRESS FIELDS PARA DILI NA MAG-NULL ---
                houseNumber = housenotxt.Text,
                block = blktxt.Text,
                lot = lottxt.Text,
                streetName = streettxt.Text,
                areaType = areatypedrp.selectedValue, // Siguroha areatypedrp ang ngalan sa control

                username = autoUsername,
                password = autoPassword,
                email = email,
                status = "Active"
            };

            string json = JsonConvert.SerializeObject(data);

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(baseApiUrl + "residents.php", content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (responseBody.Contains("\"success\":true"))
                    {
                        // Gi-fix ang message box para ipakita ang auto-generated username
                        MessageBox.Show("Resident Saved Successfully!\n\nDefault Credentials:\nUsername: " + autoUsername + "\nPassword: " + autoPassword,
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK; // Importante para sa refresh sa table
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error from Server: " + responseBody);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("API Error: " + ex.Message); }
        }



        private string GenerateResidentId()
        {
            string yearPrefix = DateTime.Now.Year.ToString();
            int lastNumber = db.GetLastResidentNumber(yearPrefix);
            return yearPrefix + "-" + (lastNumber + 1).ToString("D4");
        }



        private async Task updatedata()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var residentData = new
                    {
                        residentId = id,
                        fname = fnametxt.Text,
                        mname = mnametxt.Text,
                        lname = lnametxt.Text,
                        ext = exttxt.Text,
                        placeOfBirth = pobtxt.Text,
                        gender = genderdrp.selectedValue,
                        bday = dobdrp.Value.ToString("yyyy-MM-dd"),
                        age = agetxt.Text,
                        isVoter = isvoterdrp.selectedValue,
                        civilStatus = csdrp.selectedValue,
                        nationality = natdrp.selectedValue,
                        contact = (contxt.Text.Length == 10) ? "+63" + contxt.Text : contxt.Text,

                        // I-apil ang address fields sa update
                        houseNumber = housenotxt.Text,
                        block = blktxt.Text,
                        lot = lottxt.Text,
                        streetName = streettxt.Text,
                        areaType = areatypedrp.selectedValue
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(residentData), Encoding.UTF8, "application/json");

                    // Siguroha nga ang updateResident.php andam pud modawat ani nga address fields
                    var response = await client.PostAsync(baseApiUrl + "updateResident.php", content);
                    string resBody = await response.Content.ReadAsStringAsync();

                    if (resBody.Contains("\"success\":true"))
                    {
                        // Update usab ang email sa pikas table
                        var emailData = new { residentId = id, email = emailtxt.Text };
                        var emailContent = new StringContent(JsonConvert.SerializeObject(emailData), Encoding.UTF8, "application/json");
                        await client.PostAsync(baseApiUrl + "updateUserResident.php", emailContent);

                        MessageBox.Show("Updated successfully!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
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
                await updatedata();
            }
        }
    }
}
