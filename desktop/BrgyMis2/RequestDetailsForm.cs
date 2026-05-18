using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrgyMis2
{
    public partial class RequestDetailsForm : Form
    {
        public RequestDetailsForm(
            string requestId,
            string residentName,
            string documentType,
            string purpose,
            string dateRequested)
        {
            InitializeComponent();

            lblRequestId.Text = "ID: " + requestId;
            lblResidentName.Text = residentName;
            lblDocumentType.Text = documentType;
            lblPurpose.Text = purpose;
            lblDateRequested.Text = dateRequested;
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
