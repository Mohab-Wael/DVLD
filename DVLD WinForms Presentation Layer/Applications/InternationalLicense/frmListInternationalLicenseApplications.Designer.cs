namespace DVLD.Applications.InternationalLicense
{
    partial class frmListInternationalLicenseApplications
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInternationalLicenseApplications = new System.Windows.Forms.DataGridView();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowPersonDetailstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLicenseDetailstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPersonLicenseHistorytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCountRecords = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbIsReleased = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseApplications)).BeginInit();
            this.cmsApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(501, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.International_32;
            this.pictureBox2.Location = new System.Drawing.Point(669, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(342, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "International License Applications";
            // 
            // dgvInternationalLicenseApplications
            // 
            this.dgvInternationalLicenseApplications.AllowUserToAddRows = false;
            this.dgvInternationalLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenseApplications.AllowUserToResizeRows = false;
            this.dgvInternationalLicenseApplications.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenseApplications.ContextMenuStrip = this.cmsApplications;
            this.dgvInternationalLicenseApplications.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInternationalLicenseApplications.Location = new System.Drawing.Point(16, 330);
            this.dgvInternationalLicenseApplications.MultiSelect = false;
            this.dgvInternationalLicenseApplications.Name = "dgvInternationalLicenseApplications";
            this.dgvInternationalLicenseApplications.ReadOnly = true;
            this.dgvInternationalLicenseApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicenseApplications.Size = new System.Drawing.Size(1116, 350);
            this.dgvInternationalLicenseApplications.TabIndex = 3;
            this.dgvInternationalLicenseApplications.TabStop = false;
            // 
            // cmsApplications
            // 
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPersonDetailstoolStripMenuItem,
            this.ShowLicenseDetailstoolStripMenuItem,
            this.ShowPersonLicenseHistorytoolStripMenuItem});
            this.cmsApplications.Name = "cmsApplications";
            this.cmsApplications.Size = new System.Drawing.Size(242, 140);
            // 
            // ShowPersonDetailstoolStripMenuItem
            // 
            this.ShowPersonDetailstoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.PersonDetails_32;
            this.ShowPersonDetailstoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowPersonDetailstoolStripMenuItem.Name = "ShowPersonDetailstoolStripMenuItem";
            this.ShowPersonDetailstoolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.ShowPersonDetailstoolStripMenuItem.Text = "Show Person Details";
            this.ShowPersonDetailstoolStripMenuItem.Click += new System.EventHandler(this.ShowPersonDetailstoolStripMenuItem_Click);
            // 
            // ShowLicenseDetailstoolStripMenuItem
            // 
            this.ShowLicenseDetailstoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.License_View_32;
            this.ShowLicenseDetailstoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowLicenseDetailstoolStripMenuItem.Name = "ShowLicenseDetailstoolStripMenuItem";
            this.ShowLicenseDetailstoolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.ShowLicenseDetailstoolStripMenuItem.Text = "Show License Details";
            this.ShowLicenseDetailstoolStripMenuItem.Click += new System.EventHandler(this.ShowLicenseDetailstoolStripMenuItem_Click);
            // 
            // ShowPersonLicenseHistorytoolStripMenuItem
            // 
            this.ShowPersonLicenseHistorytoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.PersonLicenseHistory_32;
            this.ShowPersonLicenseHistorytoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowPersonLicenseHistorytoolStripMenuItem.Name = "ShowPersonLicenseHistorytoolStripMenuItem";
            this.ShowPersonLicenseHistorytoolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.ShowPersonLicenseHistorytoolStripMenuItem.Text = "Show Person License History";
            this.ShowPersonLicenseHistorytoolStripMenuItem.Click += new System.EventHandler(this.ShowPersonLicenseHistorytoolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "International License ID",
            "Application ID",
            "Driver ID",
            "Local License ID",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(105, 293);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(210, 28);
            this.cbFilterBy.TabIndex = 5;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddNewApplication.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewApplication.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.New_Application_64;
            this.btnAddNewApplication.Location = new System.Drawing.Point(1052, 250);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(80, 74);
            this.btnAddNewApplication.TabIndex = 6;
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 691);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "# Records:";
            // 
            // lblCountRecords
            // 
            this.lblCountRecords.AutoSize = true;
            this.lblCountRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecords.Location = new System.Drawing.Point(115, 691);
            this.lblCountRecords.Name = "lblCountRecords";
            this.lblCountRecords.Size = new System.Drawing.Size(29, 20);
            this.lblCountRecords.TabIndex = 8;
            this.lblCountRecords.Text = "??";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(992, 687);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 36);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbIsReleased
            // 
            this.cbIsReleased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsReleased.FormattingEnabled = true;
            this.cbIsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsReleased.Location = new System.Drawing.Point(324, 293);
            this.cbIsReleased.Name = "cbIsReleased";
            this.cbIsReleased.Size = new System.Drawing.Size(139, 28);
            this.cbIsReleased.TabIndex = 10;
            this.cbIsReleased.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(322, 295);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(256, 26);
            this.txtFilterValue.TabIndex = 162;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // frmListInternationalLicenseApplications
            // 
            this.AcceptButton = this.btnAddNewApplication;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1146, 739);
            this.Controls.Add(this.cbIsReleased);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCountRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvInternationalLicenseApplications);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtFilterValue);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListInternationalLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List International License Applications";
            this.Load += new System.EventHandler(this.frmListInternationalLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseApplications)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInternationalLicenseApplications;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCountRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbIsReleased;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonDetailstoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseDetailstoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonLicenseHistorytoolStripMenuItem;
    }
}