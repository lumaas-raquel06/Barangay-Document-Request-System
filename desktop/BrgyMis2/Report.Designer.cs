namespace BrgyMis2
{
    partial class Report
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.panelReportPreview = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.picBarangayLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lineHeader = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panelReportPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarangayLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(88)))), ((int)(((byte)(220)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(1230, 62);
            this.label2.TabIndex = 13;
            this.label2.Text = "Reports";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Report Type:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.btnPrintReport);
            this.panel1.Controls.Add(this.btnGenerateReport);
            this.panel1.Controls.Add(this.cmbYear);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbReportType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(7, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 64);
            this.panel1.TabIndex = 15;
            // 
            // cmbReportType
            // 
            this.cmbReportType.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(115, 19);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(225, 25);
            this.cmbReportType.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(405, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Year:";
            // 
            // cmbYear
            // 
            this.cmbYear.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(450, 18);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(225, 25);
            this.cmbYear.TabIndex = 17;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(774, 10);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(160, 40);
            this.btnGenerateReport.TabIndex = 18;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.Location = new System.Drawing.Point(966, 11);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(158, 39);
            this.btnPrintReport.TabIndex = 19;
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // panelReportPreview
            // 
            this.panelReportPreview.BackColor = System.Drawing.Color.Transparent;
            this.panelReportPreview.Controls.Add(this.dataGridView1);
            this.panelReportPreview.Controls.Add(this.lineHeader);
            this.panelReportPreview.Controls.Add(this.pictureBox2);
            this.panelReportPreview.Controls.Add(this.label9);
            this.panelReportPreview.Controls.Add(this.label8);
            this.panelReportPreview.Controls.Add(this.label7);
            this.panelReportPreview.Controls.Add(this.label6);
            this.panelReportPreview.Controls.Add(this.label5);
            this.panelReportPreview.Controls.Add(this.picBarangayLogo);
            this.panelReportPreview.Location = new System.Drawing.Point(3, 134);
            this.panelReportPreview.Name = "panelReportPreview";
            this.panelReportPreview.Size = new System.Drawing.Size(1216, 601);
            this.panelReportPreview.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(499, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Office of the Barangay Council";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(537, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Barangay Ayahag";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(509, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Municipality of Saint Bernard\n";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(509, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Province of Southern Leyte";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(510, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Republic of the Philippines";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBarangayLogo
            // 
            this.picBarangayLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBarangayLogo.Image")));
            this.picBarangayLogo.Location = new System.Drawing.Point(220, 3);
            this.picBarangayLogo.Name = "picBarangayLogo";
            this.picBarangayLogo.Size = new System.Drawing.Size(242, 149);
            this.picBarangayLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBarangayLogo.TabIndex = 11;
            this.picBarangayLogo.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(789, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(149, 93);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 43;
            this.pictureBox2.TabStop = false;
            // 
            // lineHeader
            // 
            this.lineHeader.BackColor = System.Drawing.Color.Black;
            this.lineHeader.Location = new System.Drawing.Point(235, 143);
            this.lineHeader.Name = "lineHeader";
            this.lineHeader.Size = new System.Drawing.Size(800, 2);
            this.lineHeader.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(502, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "RESIDENTS RECORD REPORT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 218);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1194, 380);
            this.dataGridView1.TabIndex = 0;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelReportPreview);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Name = "Report";
            this.Size = new System.Drawing.Size(1230, 738);
            this.Load += new System.EventHandler(this.Report_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelReportPreview.ResumeLayout(false);
            this.panelReportPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarangayLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Panel panelReportPreview;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picBarangayLogo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel lineHeader;
        private System.Windows.Forms.Label label4;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
