namespace BrgyMis2
{
    partial class RequestDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestDetailsForm));
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblRequestId = new System.Windows.Forms.Label();
            this.lblResidentSection = new System.Windows.Forms.Label();
            this.lblResidentName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.lblRequestSection = new System.Windows.Forms.Label();
            this.lblDocumentType = new System.Windows.Forms.Label();
            this.lblPurpose = new System.Windows.Forms.Label();
            this.lblDateRequested = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.lblFee = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblValidId = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picFrontId = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picBackId = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnDecline = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnViewFront = new System.Windows.Forms.Button();
            this.btnDownloadFront = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnViewback = new System.Windows.Forms.Button();
            this.btnDownloadBack = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFrontId)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackId)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panel5);
            this.panelMain.Controls.Add(this.panel3);
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.txtNotes);
            this.panelMain.Controls.Add(this.btnAccept);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.btnDecline);
            this.panelMain.Controls.Add(this.groupBox2);
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Controls.Add(this.lblValidId);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.lblFee);
            this.panelMain.Controls.Add(this.lblService);
            this.panelMain.Controls.Add(this.lblPayment);
            this.panelMain.Controls.Add(this.lblStatus);
            this.panelMain.Controls.Add(this.lblDateRequested);
            this.panelMain.Controls.Add(this.lblPurpose);
            this.panelMain.Controls.Add(this.lblDocumentType);
            this.panelMain.Controls.Add(this.lblRequestSection);
            this.panelMain.Controls.Add(this.lblEmail);
            this.panelMain.Controls.Add(this.lblContact);
            this.panelMain.Controls.Add(this.lblAddress);
            this.panelMain.Controls.Add(this.lblResidentName);
            this.panelMain.Controls.Add(this.lblResidentSection);
            this.panelMain.Location = new System.Drawing.Point(20, 93);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1128, 637);
            this.panelMain.TabIndex = 0;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(99, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(389, 41);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Document Request Details";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblSubtitle.Location = new System.Drawing.Point(104, 53);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(303, 23);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "View and manage request information";
            // 
            // lblRequestId
            // 
            this.lblRequestId.AutoSize = true;
            this.lblRequestId.BackColor = System.Drawing.Color.Lavender;
            this.lblRequestId.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestId.ForeColor = System.Drawing.Color.Purple;
            this.lblRequestId.Location = new System.Drawing.Point(905, 39);
            this.lblRequestId.Name = "lblRequestId";
            this.lblRequestId.Size = new System.Drawing.Size(61, 25);
            this.lblRequestId.TabIndex = 0;
            this.lblRequestId.Text = "ID: 10";
            this.lblRequestId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResidentSection
            // 
            this.lblResidentSection.AutoSize = true;
            this.lblResidentSection.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResidentSection.ForeColor = System.Drawing.Color.MediumPurple;
            this.lblResidentSection.Image = ((System.Drawing.Image)(resources.GetObject("lblResidentSection.Image")));
            this.lblResidentSection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblResidentSection.Location = new System.Drawing.Point(30, 17);
            this.lblResidentSection.Name = "lblResidentSection";
            this.lblResidentSection.Size = new System.Drawing.Size(210, 23);
            this.lblResidentSection.TabIndex = 0;
            this.lblResidentSection.Text = "      Resident Information";
            // 
            // lblResidentName
            // 
            this.lblResidentName.AutoSize = true;
            this.lblResidentName.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResidentName.Location = new System.Drawing.Point(40, 59);
            this.lblResidentName.Name = "lblResidentName";
            this.lblResidentName.Size = new System.Drawing.Size(105, 17);
            this.lblResidentName.TabIndex = 1;
            this.lblResidentName.Text = "Resident Name:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(40, 93);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(61, 17);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address:";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(40, 124);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(85, 17);
            this.lblContact.TabIndex = 3;
            this.lblContact.Text = "Contact No.:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(40, 156);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 17);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // picHeader
            // 
            this.picHeader.Image = ((System.Drawing.Image)(resources.GetObject("picHeader.Image")));
            this.picHeader.Location = new System.Drawing.Point(20, 25);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(56, 51);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHeader.TabIndex = 3;
            this.picHeader.TabStop = false;
            // 
            // lblRequestSection
            // 
            this.lblRequestSection.AutoSize = true;
            this.lblRequestSection.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestSection.ForeColor = System.Drawing.Color.MediumPurple;
            this.lblRequestSection.Image = ((System.Drawing.Image)(resources.GetObject("lblRequestSection.Image")));
            this.lblRequestSection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRequestSection.Location = new System.Drawing.Point(584, 21);
            this.lblRequestSection.Name = "lblRequestSection";
            this.lblRequestSection.Size = new System.Drawing.Size(205, 23);
            this.lblRequestSection.TabIndex = 5;
            this.lblRequestSection.Text = "      Request Information";
            // 
            // lblDocumentType
            // 
            this.lblDocumentType.AutoSize = true;
            this.lblDocumentType.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentType.Location = new System.Drawing.Point(586, 60);
            this.lblDocumentType.Name = "lblDocumentType";
            this.lblDocumentType.Size = new System.Drawing.Size(109, 17);
            this.lblDocumentType.TabIndex = 6;
            this.lblDocumentType.Text = "Document Type:";
            // 
            // lblPurpose
            // 
            this.lblPurpose.AutoSize = true;
            this.lblPurpose.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurpose.Location = new System.Drawing.Point(586, 94);
            this.lblPurpose.Name = "lblPurpose";
            this.lblPurpose.Size = new System.Drawing.Size(62, 17);
            this.lblPurpose.TabIndex = 7;
            this.lblPurpose.Text = "Purpose:";
            // 
            // lblDateRequested
            // 
            this.lblDateRequested.AutoSize = true;
            this.lblDateRequested.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRequested.Location = new System.Drawing.Point(586, 126);
            this.lblDateRequested.Name = "lblDateRequested";
            this.lblDateRequested.Size = new System.Drawing.Size(109, 17);
            this.lblDateRequested.TabIndex = 8;
            this.lblDateRequested.Text = "Date Requested:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.LightYellow;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblStatus.Location = new System.Drawing.Point(586, 158);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 19);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.Location = new System.Drawing.Point(586, 186);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(113, 17);
            this.lblPayment.TabIndex = 10;
            this.lblPayment.Text = "Payment Option:";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.Location = new System.Drawing.Point(586, 222);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(103, 17);
            this.lblService.TabIndex = 11;
            this.lblService.Text = "Service Option:";
            // 
            // lblFee
            // 
            this.lblFee.AutoSize = true;
            this.lblFee.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFee.Location = new System.Drawing.Point(586, 259);
            this.lblFee.Name = "lblFee";
            this.lblFee.Size = new System.Drawing.Size(33, 17);
            this.lblFee.TabIndex = 12;
            this.lblFee.Text = "Fee:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumPurple;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(30, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "     Valid ID Type:";
            // 
            // lblValidId
            // 
            this.lblValidId.AutoSize = true;
            this.lblValidId.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidId.Location = new System.Drawing.Point(31, 319);
            this.lblValidId.Name = "lblValidId";
            this.lblValidId.Size = new System.Drawing.Size(59, 17);
            this.lblValidId.TabIndex = 14;
            this.lblValidId.Text = "ID Type:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.btnDownloadFront);
            this.groupBox1.Controls.Add(this.btnViewFront);
            this.groupBox1.Controls.Add(this.picFrontId);
            this.groupBox1.ForeColor = System.Drawing.Color.MediumPurple;
            this.groupBox1.Location = new System.Drawing.Point(40, 360);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 261);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Front Photo of ID";
            // 
            // picFrontId
            // 
            this.picFrontId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFrontId.Location = new System.Drawing.Point(20, 30);
            this.picFrontId.Name = "picFrontId";
            this.picFrontId.Size = new System.Drawing.Size(300, 164);
            this.picFrontId.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFrontId.TabIndex = 0;
            this.picFrontId.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDownloadBack);
            this.groupBox2.Controls.Add(this.btnViewback);
            this.groupBox2.Controls.Add(this.picBackId);
            this.groupBox2.ForeColor = System.Drawing.Color.MediumPurple;
            this.groupBox2.Location = new System.Drawing.Point(430, 360);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 261);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Back Photo of ID";
            // 
            // picBackId
            // 
            this.picBackId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBackId.Location = new System.Drawing.Point(20, 30);
            this.picBackId.Name = "picBackId";
            this.picBackId.Size = new System.Drawing.Size(300, 164);
            this.picBackId.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBackId.TabIndex = 0;
            this.picBackId.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumPurple;
            this.label2.Location = new System.Drawing.Point(807, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Additional Notes (if any)";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(816, 310);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(293, 250);
            this.txtNotes.TabIndex = 18;
            // 
            // btnDecline
            // 
            this.btnDecline.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDecline.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecline.ForeColor = System.Drawing.Color.Red;
            this.btnDecline.Image = ((System.Drawing.Image)(resources.GetObject("btnDecline.Image")));
            this.btnDecline.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDecline.Location = new System.Drawing.Point(823, 572);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(143, 49);
            this.btnDecline.TabIndex = 4;
            this.btnDecline.Text = "     Decline Request";
            this.btnDecline.UseVisualStyleBackColor = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAccept.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.Green;
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(972, 572);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(137, 49);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "      Accept Request";
            this.btnAccept.UseVisualStyleBackColor = false;
            // 
            // btnViewFront
            // 
            this.btnViewFront.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnViewFront.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewFront.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnViewFront.Image = ((System.Drawing.Image)(resources.GetObject("btnViewFront.Image")));
            this.btnViewFront.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewFront.Location = new System.Drawing.Point(30, 210);
            this.btnViewFront.Name = "btnViewFront";
            this.btnViewFront.Size = new System.Drawing.Size(128, 33);
            this.btnViewFront.TabIndex = 1;
            this.btnViewFront.Text = "     View Full Size";
            this.btnViewFront.UseVisualStyleBackColor = false;
            // 
            // btnDownloadFront
            // 
            this.btnDownloadFront.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDownloadFront.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadFront.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnDownloadFront.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadFront.Image")));
            this.btnDownloadFront.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownloadFront.Location = new System.Drawing.Point(184, 210);
            this.btnDownloadFront.Name = "btnDownloadFront";
            this.btnDownloadFront.Size = new System.Drawing.Size(104, 33);
            this.btnDownloadFront.TabIndex = 2;
            this.btnDownloadFront.Text = "      Download";
            this.btnDownloadFront.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1091, 736);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Location = new System.Drawing.Point(37, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 2);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Thistle;
            this.panel2.Location = new System.Drawing.Point(589, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 2);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Thistle;
            this.panel3.Location = new System.Drawing.Point(34, 301);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 2);
            this.panel3.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Thistle;
            this.panel4.Location = new System.Drawing.Point(2, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(400, 2);
            this.panel4.TabIndex = 22;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Thistle;
            this.panel5.Location = new System.Drawing.Point(430, 376);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(350, 2);
            this.panel5.TabIndex = 23;
            // 
            // btnViewback
            // 
            this.btnViewback.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnViewback.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewback.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnViewback.Image = ((System.Drawing.Image)(resources.GetObject("btnViewback.Image")));
            this.btnViewback.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewback.Location = new System.Drawing.Point(38, 212);
            this.btnViewback.Name = "btnViewback";
            this.btnViewback.Size = new System.Drawing.Size(128, 33);
            this.btnViewback.TabIndex = 5;
            this.btnViewback.Text = "     View Full Size";
            this.btnViewback.UseVisualStyleBackColor = false;
            // 
            // btnDownloadBack
            // 
            this.btnDownloadBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDownloadBack.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadBack.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnDownloadBack.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadBack.Image")));
            this.btnDownloadBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownloadBack.Location = new System.Drawing.Point(181, 210);
            this.btnDownloadBack.Name = "btnDownloadBack";
            this.btnDownloadBack.Size = new System.Drawing.Size(104, 33);
            this.btnDownloadBack.TabIndex = 6;
            this.btnDownloadBack.Text = "      Download";
            this.btnDownloadBack.UseVisualStyleBackColor = false;
            // 
            // RequestDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 778);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblRequestId);
            this.Controls.Add(this.picHeader);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "RequestDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Request Details";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFrontId)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblRequestId;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblResidentName;
        private System.Windows.Forms.Label lblResidentSection;
        private System.Windows.Forms.Label lblFee;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDateRequested;
        private System.Windows.Forms.Label lblPurpose;
        private System.Windows.Forms.Label lblDocumentType;
        private System.Windows.Forms.Label lblRequestSection;
        private System.Windows.Forms.Label lblValidId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picBackId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picFrontId;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnDownloadFront;
        private System.Windows.Forms.Button btnViewFront;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnViewback;
        private System.Windows.Forms.Button btnDownloadBack;
    }
}