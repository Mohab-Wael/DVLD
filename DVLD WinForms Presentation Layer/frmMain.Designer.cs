namespace DVLD_WinForms_Presentation_Layer
{
    partial class frmMain
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
            this.msMainMenue = new System.Windows.Forms.MenuStrip();
            this.tsmiApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.ServicestoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.replacementForALostDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.releaseDetainedDrivingLicsenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ManageApplicationstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InternationalLicenseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.DetainStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainedLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ManageApplicationTypestoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.ManageTestTypestoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.CurrentUserInfotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePasswordtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SignOuttoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.msMainMenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msMainMenue
            // 
            this.msMainMenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMainMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiApplications,
            this.tsmiPeople,
            this.tsmDrivers,
            this.tsmUsers,
            this.tsmAccountSettings});
            this.msMainMenue.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.msMainMenue.Location = new System.Drawing.Point(0, 0);
            this.msMainMenue.Name = "msMainMenue";
            this.msMainMenue.Size = new System.Drawing.Size(1024, 72);
            this.msMainMenue.TabIndex = 1;
            this.msMainMenue.Text = "Applications";
            // 
            // tsmiApplications
            // 
            this.tsmiApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServicestoolStripMenuItem,
            this.toolStripMenuItem1,
            this.ManageApplicationstoolStripMenuItem,
            this.toolStripMenuItem3,
            this.DetainStripMenuItem,
            this.toolStripMenuItem2,
            this.ManageApplicationTypestoolStripMenuItem,
            this.toolStripMenuItem,
            this.ManageTestTypestoolStripMenuItem});
            this.tsmiApplications.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Applications_64;
            this.tsmiApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiApplications.Name = "tsmiApplications";
            this.tsmiApplications.Size = new System.Drawing.Size(182, 68);
            this.tsmiApplications.Text = "&Applications";
            // 
            // ServicestoolStripMenuItem
            // 
            this.ServicestoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.toolStripMenuItem4,
            this.renewDrivingLicenseToolStripMenuItem,
            this.toolStripMenuItem5,
            this.replacementForALostDrivingLicenseToolStripMenuItem,
            this.toolStripMenuItem6,
            this.releaseDetainedDrivingLicsenseToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.ServicestoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Driver_License_48;
            this.ServicestoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ServicestoolStripMenuItem.Name = "ServicestoolStripMenuItem";
            this.ServicestoolStripMenuItem.Size = new System.Drawing.Size(331, 70);
            this.ServicestoolStripMenuItem.Text = "Driving License Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            this.newDrivingLicenseToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.New_Driving_License_32;
            this.newDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(428, 38);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            this.newDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.newDrivingLicenseToolStripMenuItem_Click);
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Local_32;
            this.localLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem
            // 
            this.internationalLicenseToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.International_32;
            this.internationalLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.internationalLicenseToolStripMenuItem.Text = "International License";
            this.internationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(425, 6);
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            this.renewDrivingLicenseToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Renew_Driving_License_32;
            this.renewDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(428, 38);
            this.renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            this.renewDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(425, 6);
            // 
            // replacementForALostDrivingLicenseToolStripMenuItem
            // 
            this.replacementForALostDrivingLicenseToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Damaged_Driving_License_321;
            this.replacementForALostDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.replacementForALostDrivingLicenseToolStripMenuItem.Name = "replacementForALostDrivingLicenseToolStripMenuItem";
            this.replacementForALostDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(428, 38);
            this.replacementForALostDrivingLicenseToolStripMenuItem.Text = "Replacement for a Lost or Damaged License";
            this.replacementForALostDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.replacementForALostDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(425, 6);
            // 
            // releaseDetainedDrivingLicsenseToolStripMenuItem
            // 
            this.releaseDetainedDrivingLicsenseToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Detained_Driving_License_32;
            this.releaseDetainedDrivingLicsenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainedDrivingLicsenseToolStripMenuItem.Name = "releaseDetainedDrivingLicsenseToolStripMenuItem";
            this.releaseDetainedDrivingLicsenseToolStripMenuItem.Size = new System.Drawing.Size(428, 38);
            this.releaseDetainedDrivingLicsenseToolStripMenuItem.Text = "Release Detained Driving Licsense";
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Retake_Test_32;
            this.retakeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(428, 38);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            this.retakeTestToolStripMenuItem.Click += new System.EventHandler(this.retakeTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(328, 6);
            // 
            // ManageApplicationstoolStripMenuItem
            // 
            this.ManageApplicationstoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseApplicationsToolStripMenuItem,
            this.InternationalLicenseApplicationToolStripMenuItem});
            this.ManageApplicationstoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Manage_Applications_64;
            this.ManageApplicationstoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ManageApplicationstoolStripMenuItem.Name = "ManageApplicationstoolStripMenuItem";
            this.ManageApplicationstoolStripMenuItem.Size = new System.Drawing.Size(331, 70);
            this.ManageApplicationstoolStripMenuItem.Text = "Manage Applications";
            this.ManageApplicationstoolStripMenuItem.Click += new System.EventHandler(this.ManageApplicationstoolStripMenuItem_Click);
            // 
            // localDrivingLicenseApplicationsToolStripMenuItem
            // 
            this.localDrivingLicenseApplicationsToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.LocalDriving_License;
            this.localDrivingLicenseApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.localDrivingLicenseApplicationsToolStripMenuItem.Name = "localDrivingLicenseApplicationsToolStripMenuItem";
            this.localDrivingLicenseApplicationsToolStripMenuItem.Size = new System.Drawing.Size(357, 38);
            this.localDrivingLicenseApplicationsToolStripMenuItem.Text = "Local Driving License Applications";
            this.localDrivingLicenseApplicationsToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenseApplicationsToolStripMenuItem_Click);
            // 
            // InternationalLicenseApplicationToolStripMenuItem
            // 
            this.InternationalLicenseApplicationToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.International_321;
            this.InternationalLicenseApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InternationalLicenseApplicationToolStripMenuItem.Name = "InternationalLicenseApplicationToolStripMenuItem";
            this.InternationalLicenseApplicationToolStripMenuItem.Size = new System.Drawing.Size(357, 38);
            this.InternationalLicenseApplicationToolStripMenuItem.Text = "International License Application";
            this.InternationalLicenseApplicationToolStripMenuItem.Click += new System.EventHandler(this.InternationalLicenseApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(328, 6);
            // 
            // DetainStripMenuItem
            // 
            this.DetainStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainedLicensesToolStripMenuItem,
            this.detainLicenseToolStripMenuItem,
            this.releaseToolStripMenuItem});
            this.DetainStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Detain_641;
            this.DetainStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DetainStripMenuItem.Name = "DetainStripMenuItem";
            this.DetainStripMenuItem.Size = new System.Drawing.Size(331, 70);
            this.DetainStripMenuItem.Text = "Detain Licenses";
            // 
            // manageDetainedLicensesToolStripMenuItem
            // 
            this.manageDetainedLicensesToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Detain_64;
            this.manageDetainedLicensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageDetainedLicensesToolStripMenuItem.Name = "manageDetainedLicensesToolStripMenuItem";
            this.manageDetainedLicensesToolStripMenuItem.Size = new System.Drawing.Size(332, 70);
            this.manageDetainedLicensesToolStripMenuItem.Text = "Manage Detained Licenses";
            this.manageDetainedLicensesToolStripMenuItem.Click += new System.EventHandler(this.manageDetainedLicensesToolStripMenuItem_Click);
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Detain_64;
            this.detainLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(332, 70);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            this.detainLicenseToolStripMenuItem.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem_Click);
            // 
            // releaseToolStripMenuItem
            // 
            this.releaseToolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Release_Detained_License_64;
            this.releaseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseToolStripMenuItem.Name = "releaseToolStripMenuItem";
            this.releaseToolStripMenuItem.Size = new System.Drawing.Size(332, 70);
            this.releaseToolStripMenuItem.Text = "Release Detained License";
            this.releaseToolStripMenuItem.Click += new System.EventHandler(this.releaseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(328, 6);
            // 
            // ManageApplicationTypestoolStripMenuItem
            // 
            this.ManageApplicationTypestoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Application_Types_64;
            this.ManageApplicationTypestoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ManageApplicationTypestoolStripMenuItem.Name = "ManageApplicationTypestoolStripMenuItem";
            this.ManageApplicationTypestoolStripMenuItem.Size = new System.Drawing.Size(331, 70);
            this.ManageApplicationTypestoolStripMenuItem.Text = "Manage Application Types";
            this.ManageApplicationTypestoolStripMenuItem.Click += new System.EventHandler(this.ManageApplicationTypestoolStripMenuItem_Click);
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(328, 6);
            // 
            // ManageTestTypestoolStripMenuItem
            // 
            this.ManageTestTypestoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Test_Type_64;
            this.ManageTestTypestoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ManageTestTypestoolStripMenuItem.Name = "ManageTestTypestoolStripMenuItem";
            this.ManageTestTypestoolStripMenuItem.Size = new System.Drawing.Size(331, 70);
            this.ManageTestTypestoolStripMenuItem.Text = "Manage Test Types";
            this.ManageTestTypestoolStripMenuItem.Click += new System.EventHandler(this.ManageTestTypestoolStripMenuItem_Click);
            // 
            // tsmiPeople
            // 
            this.tsmiPeople.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.People_64;
            this.tsmiPeople.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiPeople.Name = "tsmiPeople";
            this.tsmiPeople.Size = new System.Drawing.Size(139, 68);
            this.tsmiPeople.Text = "People";
            this.tsmiPeople.Click += new System.EventHandler(this.tsmiPeople_Click);
            // 
            // tsmDrivers
            // 
            this.tsmDrivers.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Drivers_64;
            this.tsmDrivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDrivers.Name = "tsmDrivers";
            this.tsmDrivers.Size = new System.Drawing.Size(140, 68);
            this.tsmDrivers.Text = "Drivers";
            this.tsmDrivers.Click += new System.EventHandler(this.tsmDrivers_Click);
            // 
            // tsmUsers
            // 
            this.tsmUsers.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Users_2_64;
            this.tsmUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmUsers.Name = "tsmUsers";
            this.tsmUsers.Size = new System.Drawing.Size(127, 68);
            this.tsmUsers.Text = "Users";
            this.tsmUsers.Click += new System.EventHandler(this.tsmUsers_Click);
            // 
            // tsmAccountSettings
            // 
            this.tsmAccountSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentUserInfotoolStripMenuItem,
            this.ChangePasswordtoolStripMenuItem,
            this.SignOuttoolStripMenuItem});
            this.tsmAccountSettings.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.account_settings_64;
            this.tsmAccountSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmAccountSettings.Name = "tsmAccountSettings";
            this.tsmAccountSettings.Size = new System.Drawing.Size(215, 68);
            this.tsmAccountSettings.Text = "Account Settings";
            // 
            // CurrentUserInfotoolStripMenuItem
            // 
            this.CurrentUserInfotoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.PersonDetails_32;
            this.CurrentUserInfotoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CurrentUserInfotoolStripMenuItem.Name = "CurrentUserInfotoolStripMenuItem";
            this.CurrentUserInfotoolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.CurrentUserInfotoolStripMenuItem.Text = "Current User Info";
            this.CurrentUserInfotoolStripMenuItem.Click += new System.EventHandler(this.CurrentUserInfotoolStripMenuItem_Click);
            // 
            // ChangePasswordtoolStripMenuItem
            // 
            this.ChangePasswordtoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Password_32;
            this.ChangePasswordtoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ChangePasswordtoolStripMenuItem.Name = "ChangePasswordtoolStripMenuItem";
            this.ChangePasswordtoolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.ChangePasswordtoolStripMenuItem.Text = "Change Password";
            this.ChangePasswordtoolStripMenuItem.Click += new System.EventHandler(this.ChangePasswordtoolStripMenuItem_Click);
            // 
            // SignOuttoolStripMenuItem
            // 
            this.SignOuttoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.sign_out_32__2;
            this.SignOuttoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SignOuttoolStripMenuItem.Name = "SignOuttoolStripMenuItem";
            this.SignOuttoolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.SignOuttoolStripMenuItem.Text = "Sign Out";
            this.SignOuttoolStripMenuItem.Click += new System.EventHandler(this.SignOuttoolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.DVLD_Logo__2_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 573);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 645);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.msMainMenue);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMainMenue;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msMainMenue.ResumeLayout(false);
            this.msMainMenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenue;
        private System.Windows.Forms.ToolStripMenuItem tsmiApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmiPeople;
        private System.Windows.Forms.ToolStripMenuItem tsmDrivers;
        private System.Windows.Forms.ToolStripMenuItem tsmUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmAccountSettings;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem CurrentUserInfotoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangePasswordtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SignOuttoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ManageApplicationstoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem DetainStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ManageApplicationTypestoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageTestTypestoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServicestoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem replacementForALostDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedDrivingLicsenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InternationalLicenseApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainedLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseToolStripMenuItem;
    }
}