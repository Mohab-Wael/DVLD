namespace DVLD.Tests
{
    partial class frmListTestAppoointments
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLicenseTestAppointments = new System.Windows.Forms.DataGridView();
            this.cmsTestAppointment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.edittoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TakeTesttoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnCLose = new System.Windows.Forms.Button();
            this.pbTestImage = new System.Windows.Forms.PictureBox();
            this.ctrlLocalDrivingLicenseInfo1 = new DVLD.Controls.ApplicationControls.ctrlLocalDrivingLicenseInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseTestAppointments)).BeginInit();
            this.cmsTestAppointment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(4, 124);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 49);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Vision Test Appointments";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 557);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Appointments:";
            // 
            // dgvLicenseTestAppointments
            // 
            this.dgvLicenseTestAppointments.AllowUserToAddRows = false;
            this.dgvLicenseTestAppointments.AllowUserToDeleteRows = false;
            this.dgvLicenseTestAppointments.AllowUserToResizeRows = false;
            this.dgvLicenseTestAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvLicenseTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicenseTestAppointments.ContextMenuStrip = this.cmsTestAppointment;
            this.dgvLicenseTestAppointments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLicenseTestAppointments.Location = new System.Drawing.Point(12, 595);
            this.dgvLicenseTestAppointments.MultiSelect = false;
            this.dgvLicenseTestAppointments.Name = "dgvLicenseTestAppointments";
            this.dgvLicenseTestAppointments.ReadOnly = true;
            this.dgvLicenseTestAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLicenseTestAppointments.Size = new System.Drawing.Size(879, 165);
            this.dgvLicenseTestAppointments.TabIndex = 5;
            // 
            // cmsTestAppointment
            // 
            this.cmsTestAppointment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsTestAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edittoolStripMenuItem,
            this.TakeTesttoolStripMenuItem});
            this.cmsTestAppointment.Name = "cmsTestAppointment";
            this.cmsTestAppointment.Size = new System.Drawing.Size(157, 80);
            // 
            // edittoolStripMenuItem
            // 
            this.edittoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.edit_32;
            this.edittoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.edittoolStripMenuItem.Name = "edittoolStripMenuItem";
            this.edittoolStripMenuItem.Size = new System.Drawing.Size(156, 38);
            this.edittoolStripMenuItem.Text = "Edit";
            this.edittoolStripMenuItem.Click += new System.EventHandler(this.edittoolStripMenuItem_Click);
            // 
            // TakeTesttoolStripMenuItem
            // 
            this.TakeTesttoolStripMenuItem.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Test_32;
            this.TakeTesttoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TakeTesttoolStripMenuItem.Name = "TakeTesttoolStripMenuItem";
            this.TakeTesttoolStripMenuItem.Size = new System.Drawing.Size(156, 38);
            this.TakeTesttoolStripMenuItem.Text = "Take Test";
            this.TakeTesttoolStripMenuItem.Click += new System.EventHandler(this.TakeTesttoolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 775);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "# Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(114, 776);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(27, 20);
            this.lblRecordsCount.TabIndex = 8;
            this.lblRecordsCount.Text = "??";
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddAppointment.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.AddAppointment_32;
            this.btnAddAppointment.Location = new System.Drawing.Point(844, 552);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(47, 37);
            this.btnAddAppointment.TabIndex = 4;
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // btnCLose
            // 
            this.btnCLose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCLose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCLose.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Close_32;
            this.btnCLose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCLose.Location = new System.Drawing.Point(741, 770);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(150, 35);
            this.btnCLose.TabIndex = 6;
            this.btnCLose.Text = "Close";
            this.btnCLose.UseVisualStyleBackColor = true;
            // 
            // pbTestImage
            // 
            this.pbTestImage.Image = global::DVLD_WinForms_Presentation_Layer.Properties.Resources.Vision_512;
            this.pbTestImage.Location = new System.Drawing.Point(388, 20);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(156, 97);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestImage.TabIndex = 0;
            this.pbTestImage.TabStop = false;
            // 
            // ctrlLocalDrivingLicenseInfo1
            // 
            this.ctrlLocalDrivingLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlLocalDrivingLicenseInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLocalDrivingLicenseInfo1.Location = new System.Drawing.Point(9, 171);
            this.ctrlLocalDrivingLicenseInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlLocalDrivingLicenseInfo1.Name = "ctrlLocalDrivingLicenseInfo1";
            this.ctrlLocalDrivingLicenseInfo1.Size = new System.Drawing.Size(889, 386);
            this.ctrlLocalDrivingLicenseInfo1.TabIndex = 2;
            // 
            // frmListTestAppoointments
            // 
            this.AcceptButton = this.btnAddAppointment;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCLose;
            this.ClientSize = new System.Drawing.Size(902, 817);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.dgvLicenseTestAppointments);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbTestImage);
            this.Controls.Add(this.ctrlLocalDrivingLicenseInfo1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListTestAppoointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Test Appoointments";
            this.Load += new System.EventHandler(this.ListTestAppoointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseTestAppointments)).EndInit();
            this.cmsTestAppointment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTestImage;
        private System.Windows.Forms.Label lblTitle;
        private DVLD.Controls.ApplicationControls.ctrlLocalDrivingLicenseInfo ctrlLocalDrivingLicenseInfo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.DataGridView dgvLicenseTestAppointments;
        private System.Windows.Forms.Button btnCLose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ContextMenuStrip cmsTestAppointment;
        private System.Windows.Forms.ToolStripMenuItem edittoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TakeTesttoolStripMenuItem;
    }
}