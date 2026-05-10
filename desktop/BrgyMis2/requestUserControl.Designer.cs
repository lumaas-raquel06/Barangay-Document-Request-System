namespace BrgyMis2
{
    partial class requestUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(requestUserControl));
            this.label2 = new System.Windows.Forms.Label();
            this.searchtxt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvPending = new System.Windows.Forms.DataGridView();
            this.req_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_purpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_view = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvApproved = new System.Windows.Forms.DataGridView();
            this.app_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.app_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.app_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.app_purpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.app_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.app_view = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvDisapproved = new System.Windows.Forms.DataGridView();
            this.dis_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dis_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dis_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dis_reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dis_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dis_view = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvCompleted = new System.Windows.Forms.DataGridView();
            this.com_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_print = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dudYear = new System.Windows.Forms.DomainUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisapproved)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompleted)).BeginInit();
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
            this.label2.Size = new System.Drawing.Size(1347, 62);
            this.label2.TabIndex = 13;
            this.label2.Text = "Request";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchtxt
            // 
            this.searchtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchtxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchtxt.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.searchtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(62)))), ((int)(((byte)(74)))));
            this.searchtxt.HintForeColor = System.Drawing.Color.DimGray;
            this.searchtxt.HintText = "Search here ...";
            this.searchtxt.isPassword = false;
            this.searchtxt.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(68)))), ((int)(((byte)(200)))));
            this.searchtxt.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(210)))), ((int)(((byte)(236)))));
            this.searchtxt.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(68)))), ((int)(((byte)(200)))));
            this.searchtxt.LineThickness = 3;
            this.searchtxt.Location = new System.Drawing.Point(1053, 107);
            this.searchtxt.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.Size = new System.Drawing.Size(245, 38);
            this.searchtxt.TabIndex = 27;
            this.searchtxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.searchtxt.OnValueChanged += new System.EventHandler(this.searchtxt_OnValueChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::BrgyMis2.Properties.Resources.icons8_Search_32px;
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(1259, 110);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(26, 162);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(25, 10);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1273, 479);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvPending);
            this.tabPage1.Location = new System.Drawing.Point(4, 41);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1265, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Request";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvPending
            // 
            this.dgvPending.AllowUserToAddRows = false;
            this.dgvPending.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPending.BackgroundColor = System.Drawing.Color.White;
            this.dgvPending.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.req_id,
            this.req_name,
            this.req_type,
            this.req_purpose,
            this.req_date,
            this.req_view});
            this.dgvPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPending.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(210)))), ((int)(((byte)(236)))));
            this.dgvPending.Location = new System.Drawing.Point(3, 3);
            this.dgvPending.Name = "dgvPending";
            this.dgvPending.RowHeadersVisible = false;
            this.dgvPending.RowHeadersWidth = 51;
            this.dgvPending.RowTemplate.Height = 24;
            this.dgvPending.Size = new System.Drawing.Size(1259, 428);
            this.dgvPending.TabIndex = 0;
            // 
            // req_id
            // 
            this.req_id.HeaderText = "ID";
            this.req_id.MinimumWidth = 6;
            this.req_id.Name = "req_id";
            // 
            // req_name
            // 
            this.req_name.HeaderText = "Resident Name";
            this.req_name.MinimumWidth = 6;
            this.req_name.Name = "req_name";
            // 
            // req_type
            // 
            this.req_type.HeaderText = "Document Type";
            this.req_type.MinimumWidth = 6;
            this.req_type.Name = "req_type";
            // 
            // req_purpose
            // 
            this.req_purpose.HeaderText = "Purpose";
            this.req_purpose.MinimumWidth = 6;
            this.req_purpose.Name = "req_purpose";
            // 
            // req_date
            // 
            this.req_date.HeaderText = "Date Requested";
            this.req_date.MinimumWidth = 6;
            this.req_date.Name = "req_date";
            // 
            // req_view
            // 
            this.req_view.HeaderText = "Action";
            this.req_view.MinimumWidth = 6;
            this.req_view.Name = "req_view";
            this.req_view.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.req_view.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvApproved);
            this.tabPage2.Location = new System.Drawing.Point(4, 41);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1265, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Approved";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvApproved
            // 
            this.dgvApproved.AllowUserToAddRows = false;
            this.dgvApproved.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApproved.BackgroundColor = System.Drawing.Color.White;
            this.dgvApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApproved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.app_id,
            this.app_name,
            this.app_type,
            this.app_purpose,
            this.app_date,
            this.app_view});
            this.dgvApproved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApproved.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(210)))), ((int)(((byte)(236)))));
            this.dgvApproved.Location = new System.Drawing.Point(3, 3);
            this.dgvApproved.Name = "dgvApproved";
            this.dgvApproved.RowHeadersVisible = false;
            this.dgvApproved.RowHeadersWidth = 51;
            this.dgvApproved.RowTemplate.Height = 24;
            this.dgvApproved.Size = new System.Drawing.Size(1259, 507);
            this.dgvApproved.TabIndex = 0;
            // 
            // app_id
            // 
            this.app_id.HeaderText = "ID";
            this.app_id.MinimumWidth = 6;
            this.app_id.Name = "app_id";
            // 
            // app_name
            // 
            this.app_name.HeaderText = "Resident Name";
            this.app_name.MinimumWidth = 6;
            this.app_name.Name = "app_name";
            // 
            // app_type
            // 
            this.app_type.HeaderText = "Document Type";
            this.app_type.MinimumWidth = 6;
            this.app_type.Name = "app_type";
            // 
            // app_purpose
            // 
            this.app_purpose.HeaderText = "Purposes";
            this.app_purpose.MinimumWidth = 6;
            this.app_purpose.Name = "app_purpose";
            // 
            // app_date
            // 
            this.app_date.HeaderText = "Date Approved";
            this.app_date.MinimumWidth = 6;
            this.app_date.Name = "app_date";
            // 
            // app_view
            // 
            this.app_view.HeaderText = "Action";
            this.app_view.MinimumWidth = 6;
            this.app_view.Name = "app_view";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvDisapproved);
            this.tabPage3.Location = new System.Drawing.Point(4, 41);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1265, 513);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Disapproved";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvDisapproved
            // 
            this.dgvDisapproved.AllowUserToAddRows = false;
            this.dgvDisapproved.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisapproved.BackgroundColor = System.Drawing.Color.White;
            this.dgvDisapproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisapproved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dis_id,
            this.dis_name,
            this.dis_type,
            this.dis_reason,
            this.dis_date,
            this.dis_view});
            this.dgvDisapproved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDisapproved.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(210)))), ((int)(((byte)(236)))));
            this.dgvDisapproved.Location = new System.Drawing.Point(0, 0);
            this.dgvDisapproved.Name = "dgvDisapproved";
            this.dgvDisapproved.RowHeadersVisible = false;
            this.dgvDisapproved.RowHeadersWidth = 51;
            this.dgvDisapproved.RowTemplate.Height = 24;
            this.dgvDisapproved.Size = new System.Drawing.Size(1265, 513);
            this.dgvDisapproved.TabIndex = 0;
            // 
            // dis_id
            // 
            this.dis_id.HeaderText = "ID";
            this.dis_id.MinimumWidth = 6;
            this.dis_id.Name = "dis_id";
            // 
            // dis_name
            // 
            this.dis_name.HeaderText = "Resident Name";
            this.dis_name.MinimumWidth = 6;
            this.dis_name.Name = "dis_name";
            // 
            // dis_type
            // 
            this.dis_type.HeaderText = "Document Type";
            this.dis_type.MinimumWidth = 6;
            this.dis_type.Name = "dis_type";
            // 
            // dis_reason
            // 
            this.dis_reason.HeaderText = "Reason";
            this.dis_reason.MinimumWidth = 6;
            this.dis_reason.Name = "dis_reason";
            // 
            // dis_date
            // 
            this.dis_date.HeaderText = "Date Denied";
            this.dis_date.MinimumWidth = 6;
            this.dis_date.Name = "dis_date";
            // 
            // dis_view
            // 
            this.dis_view.HeaderText = "Action";
            this.dis_view.MinimumWidth = 6;
            this.dis_view.Name = "dis_view";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvCompleted);
            this.tabPage4.Location = new System.Drawing.Point(4, 41);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1265, 513);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Completed";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvCompleted
            // 
            this.dgvCompleted.AllowUserToAddRows = false;
            this.dgvCompleted.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompleted.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompleted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompleted.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.com_id,
            this.com_name,
            this.com_type,
            this.com_date,
            this.com_print});
            this.dgvCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompleted.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(210)))), ((int)(((byte)(236)))));
            this.dgvCompleted.Location = new System.Drawing.Point(0, 0);
            this.dgvCompleted.Name = "dgvCompleted";
            this.dgvCompleted.RowHeadersVisible = false;
            this.dgvCompleted.RowHeadersWidth = 51;
            this.dgvCompleted.RowTemplate.Height = 24;
            this.dgvCompleted.Size = new System.Drawing.Size(1265, 513);
            this.dgvCompleted.TabIndex = 0;
            // 
            // com_id
            // 
            this.com_id.HeaderText = "ID";
            this.com_id.MinimumWidth = 6;
            this.com_id.Name = "com_id";
            // 
            // com_name
            // 
            this.com_name.HeaderText = "Resident Name";
            this.com_name.MinimumWidth = 6;
            this.com_name.Name = "com_name";
            // 
            // com_type
            // 
            this.com_type.HeaderText = "Document Type";
            this.com_type.MinimumWidth = 6;
            this.com_type.Name = "com_type";
            // 
            // com_date
            // 
            this.com_date.HeaderText = "Date Completed";
            this.com_date.MinimumWidth = 6;
            this.com_date.Name = "com_date";
            // 
            // com_print
            // 
            this.com_print.HeaderText = "Print";
            this.com_print.MinimumWidth = 6;
            this.com_print.Name = "com_print";
            // 
            // dudYear
            // 
            this.dudYear.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dudYear.Location = new System.Drawing.Point(722, 116);
            this.dudYear.Name = "dudYear";
            this.dudYear.Size = new System.Drawing.Size(99, 23);
            this.dudYear.TabIndex = 32;
            this.dudYear.Text = "domainUpDown1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(669, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "Year";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(844, 107);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(199, 38);
            this.button1.TabIndex = 34;
            this.button1.Text = "Generate List";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // requestUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dudYear);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.searchtxt);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(0, 20);
            this.Name = "requestUserControl";
            this.Size = new System.Drawing.Size(1347, 738);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisapproved)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompleted)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox searchtxt;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvPending;
        private System.Windows.Forms.DataGridView dgvApproved;
        private System.Windows.Forms.DataGridView dgvDisapproved;
        private System.Windows.Forms.DataGridView dgvCompleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_purpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_date;
        private System.Windows.Forms.DataGridViewButtonColumn req_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn app_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn app_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn app_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn app_purpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn app_date;
        private System.Windows.Forms.DataGridViewButtonColumn app_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn dis_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dis_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dis_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn dis_reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn dis_date;
        private System.Windows.Forms.DataGridViewButtonColumn dis_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_date;
        private System.Windows.Forms.DataGridViewButtonColumn com_print;
        private System.Windows.Forms.DomainUpDown dudYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
