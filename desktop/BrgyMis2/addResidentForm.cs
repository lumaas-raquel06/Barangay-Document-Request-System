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
namespace BrgyMis2
{
    public partial class addResidentForm : Form
    {
        public addResidentForm()
        {
            InitializeComponent();
            
            
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
                                      "age", "gender", "bday", "isVoter", "civilStatus",
                                      "nationality", "contact"
                                  };
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
                emailtxt.Text = inforesult["email"];

                string[] address = {
                                          "houseNumber","block","lot","streetName","areaType","area"
                                      };

                Dictionary<string, dynamic> addressresult = db.fetchRecordWithCondition("tbl_address", address, "residentId", id);
                housenotxt.Text = addressresult["houseNumber"];
                blktxt.Text = addressresult["block"];
                lottxt.Text = addressresult["lot"];
                streettxt.Text = addressresult["streetName"];
                fc.SetSelectedValue(areatypedrp, addressresult["areaType"]);
            
                //bwisittttttttttttttttttt
                area = addressresult["area"];

                savebtn.Text = "Save Changes";
                label2.Text = "Update Resident";
            }
        }

        


        private void select()
        {
            areadrp.Clear();
            foreach (string item in fc.purokAndOthers(areatypedrp.selectedIndex))
            {
                areadrp.AddItem(item);
            }
        }
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void areatypedrp_onItemSelected(object sender, EventArgs e)
        {
            select();
        }

        private void contxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            fc.KeyPressNumOnly(e, contxt.Text, 10);
        }

        private void fnametxt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void savedata()
        {
            // Email validation
            string email = emailtxt.Text.Trim();
            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show(
                    "Please enter a valid Email Address!",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string residentId = fc.generateId(7);

            // Auto-generate username — firstname.lastname (lowercase)
            string autoUsername = (fnametxt.Text.Trim() + "." + lnametxt.Text.Trim())
                                  .ToLower()
                                  .Replace(" ", "");

            // Auto-generate password — MMddyyyy
            string autoPassword = dobdrp.Value.ToString("MMddyyyy");

            Dictionary<string, dynamic> fields = new Dictionary<string, dynamic>(){
                {"residentId", residentId},
                {"fname", fnametxt.Text},
                {"mname", mnametxt.Text},
                {"lname", lnametxt.Text},
                {"ext", exttxt.Text},
                {"placeOfBirth", pobtxt.Text},
                {"age", fc.CalculateAge(dobdrp.Value.ToString())},
                {"gender", genderdrp.selectedValue},
                {"bday", dobdrp.Value.ToShortDateString()},
                {"isVoter", isvoterdrp.selectedValue},
                {"civilStatus", csdrp.selectedValue},
                {"nationality", natdrp.selectedValue},
                {"contact", (contxt.Text.Length == 10) ? "+63" + contxt.Text : ""},
                {"username", autoUsername},
                {"password", autoPassword},
                {"email", email},  // ← email address
                {"status", "Active"}
            };

            if (db.insertRecord("tbl_residentinfo", fields))
            {
                Dictionary<string, dynamic> address = new Dictionary<string, dynamic>(){
                    {"residentId", residentId},
                    {"houseNumber", housenotxt.Text},
                    {"block", blktxt.Text},
                    {"lot", lottxt.Text},
                    {"streetName", streettxt.Text},
                    {"areaType", areatypedrp.selectedValue},
                    {"area", areadrp.selectedValue},
                };
                db.insertRecord("tbl_address", address);

                // Show credentials to admin
                MessageBox.Show(
                    "Resident saved successfully!\n\n" +
                    "Login Credentials:\n" +
                    "Username: " + autoUsername + "\n" +
                    "Password: " + autoPassword + "\n\n" +
                    "Please inform the resident of their credentials.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                residentUserControl.Instance.loaddata();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error saving resident!");
            }
        }


        private void updatedata()
        {
            // Email validation
            string email = emailtxt.Text.Trim();
            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show(
                    "Please enter a valid Email Address!",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            // fc.SetSelectedValue(areadrp, area);

            Dictionary<string, dynamic> info = new Dictionary<string, dynamic>()
            {
                {"fname", fnametxt.Text},
                {"lname", lnametxt.Text},
                {"ext", exttxt.Text},
                {"placeOfBirth", pobtxt.Text},
                {"age", fc.CalculateAge(dobdrp.Value.ToString())},
                {"gender", genderdrp.selectedValue},
                {"bday", dobdrp.Value.ToShortDateString()},
                {"isVoter", isvoterdrp.selectedValue},
                {"civilStatus", csdrp.selectedValue},
                {"nationality", natdrp.selectedValue},
                {"contact", (contxt.Text.Length == 10) ? "+63" + contxt.Text : ""}
            };
            Dictionary<string, dynamic> winfo = new Dictionary<string, dynamic>()
            {
                {"residentId", id}
            };
            bool result = db.updateRecord("tbl_residentinfo", winfo, info);
            if (result)
            {

                //adress
                Dictionary<string, dynamic> address = new Dictionary<string, dynamic>(){
                         {"houseNumber", housenotxt.Text},
                         {"block", blktxt.Text},
                         {"lot", lottxt.Text},
                         {"streetName", streettxt.Text},
                         {"areaType", areatypedrp.selectedValue}
                        // {"area", areadrp.selectedValue}
                     };
                Dictionary<string, dynamic> waddress = new Dictionary<string, dynamic>()
            {
                {"residentId", id}
            };
                db.updateRecord("tbl_address", waddress, address);





                MessageBox.Show("Updated");
                residentUserControl.Instance.loaddata();
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                savedata();
            }
            else
            {
                updatedata();
            }
        }

        private void dobdrp_onValueChanged(object sender, EventArgs e)
        {

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
    }
}
