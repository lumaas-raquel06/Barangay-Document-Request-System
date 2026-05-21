using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace BrgyMis2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private bool isPasswordVisible = false;


        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;

            picShowPassword.Image =
                Properties.Resources.eye_closed;
        }

        private void picShowPassword_Click_1(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            txtPassword.UseSystemPasswordChar = !isPasswordVisible;

            picShowPassword.Image = isPasswordVisible
                ? Properties.Resources.eye_open
                : Properties.Resources.eye_closed;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var loginData = new
            {
                username = txtUsername.Text.Trim(),
                password = txtPassword.Text.Trim()
            };

            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(loginData);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(
                    "http://127.0.0.1:8000/api/login",
                    content
                );

                string result = await response.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(result);

                if (data.success == true)
                {
                    MessageBox.Show("Login successful!");

                    string fullname = data.user.fullname;
                    string role = data.user.role;

                    Form1 dashboard = new Form1(fullname, role);
                    dashboard.FormClosed += (s, args) => this.Close();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show((string)data.message);
                }
            }
        }
    }
}
