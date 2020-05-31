﻿// ReadForm.Designer.cs
//
// Greaseweazle GUI Wrapper
//
// Copyright (c) 2019 Don Mankin <don.mankin@yahoo.com>
//
// MIT License
//
// See the file LICENSE for more details, or visit <https://opensource.org/licenses/MIT>.

namespace Greaseweazle
{
    partial class ReadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadForm));
            this.gbReadFromDisk = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDriveRpmRFD = new System.Windows.Forms.TextBox();
            this.chkDriveRpmRFD = new System.Windows.Forms.CheckBox();
            this.txtDriveRateRFD = new System.Windows.Forms.TextBox();
            this.chkDriveRateRFD = new System.Windows.Forms.CheckBox();
            this.chkDoubleStep = new System.Windows.Forms.CheckBox();
            this.chkRevsPerTrack = new System.Windows.Forms.CheckBox();
            this.txtRevsPerTrack = new System.Windows.Forms.TextBox();
            this.chkReadFirstCyl = new System.Windows.Forms.CheckBox();
            this.txtReadFirstCyl = new System.Windows.Forms.TextBox();
            this.chkReadLastCyl = new System.Windows.Forms.CheckBox();
            this.txtDriveSelectRFD = new System.Windows.Forms.TextBox();
            this.txtReadLastCyl = new System.Windows.Forms.TextBox();
            this.chkDriveSelectRFD = new System.Windows.Forms.CheckBox();
            this.rbReadSingleSided = new System.Windows.Forms.RadioButton();
            this.rbReadDoubleSided = new System.Windows.Forms.RadioButton();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtRFDCommandLine = new System.Windows.Forms.TextBox();
            this.lblStaticCL = new System.Windows.Forms.Label();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.btnRFDSelectFile = new System.Windows.Forms.Button();
            this.btnRFDSelectFolder = new System.Windows.Forms.Button();
            this.toolTipRFD = new System.Windows.Forms.ToolTip(this.components);
            this.gbReadFromDisk.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReadFromDisk
            // 
            this.gbReadFromDisk.Controls.Add(this.groupBox1);
            this.gbReadFromDisk.Controls.Add(this.btnBack);
            this.gbReadFromDisk.Controls.Add(this.txtRFDCommandLine);
            this.gbReadFromDisk.Controls.Add(this.lblStaticCL);
            this.gbReadFromDisk.Controls.Add(this.btnLaunch);
            this.gbReadFromDisk.Controls.Add(this.btnRFDSelectFile);
            this.gbReadFromDisk.Controls.Add(this.btnRFDSelectFolder);
            this.gbReadFromDisk.Location = new System.Drawing.Point(21, 19);
            this.gbReadFromDisk.Name = "gbReadFromDisk";
            this.gbReadFromDisk.Size = new System.Drawing.Size(555, 464);
            this.gbReadFromDisk.TabIndex = 0;
            this.gbReadFromDisk.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDriveRpmRFD);
            this.groupBox1.Controls.Add(this.chkDriveRpmRFD);
            this.groupBox1.Controls.Add(this.txtDriveRateRFD);
            this.groupBox1.Controls.Add(this.chkDriveRateRFD);
            this.groupBox1.Controls.Add(this.chkDoubleStep);
            this.groupBox1.Controls.Add(this.chkRevsPerTrack);
            this.groupBox1.Controls.Add(this.txtRevsPerTrack);
            this.groupBox1.Controls.Add(this.chkReadFirstCyl);
            this.groupBox1.Controls.Add(this.txtReadFirstCyl);
            this.groupBox1.Controls.Add(this.chkReadLastCyl);
            this.groupBox1.Controls.Add(this.txtDriveSelectRFD);
            this.groupBox1.Controls.Add(this.txtReadLastCyl);
            this.groupBox1.Controls.Add(this.chkDriveSelectRFD);
            this.groupBox1.Controls.Add(this.rbReadSingleSided);
            this.groupBox1.Controls.Add(this.rbReadDoubleSided);
            this.groupBox1.Location = new System.Drawing.Point(23, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 264);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtDriveRpmRFD
            // 
            this.txtDriveRpmRFD.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtDriveRpmRFD.Location = new System.Drawing.Point(352, 193);
            this.txtDriveRpmRFD.MaxLength = 3;
            this.txtDriveRpmRFD.Name = "txtDriveRpmRFD";
            this.txtDriveRpmRFD.Size = new System.Drawing.Size(54, 22);
            this.txtDriveRpmRFD.TabIndex = 14;
            this.txtDriveRpmRFD.Text = "300";
            this.toolTipRFD.SetToolTip(this.txtDriveRpmRFD, "Host Tools v0.18 or Later");
            this.txtDriveRpmRFD.TextChanged += new System.EventHandler(this.txtDriveRpmRFD_TextChanged);
            // 
            // chkDriveRpmRFD
            // 
            this.chkDriveRpmRFD.AutoSize = true;
            this.chkDriveRpmRFD.Location = new System.Drawing.Point(107, 195);
            this.chkDriveRpmRFD.Name = "chkDriveRpmRFD";
            this.chkDriveRpmRFD.Size = new System.Drawing.Size(60, 21);
            this.chkDriveRpmRFD.TabIndex = 13;
            this.chkDriveRpmRFD.Text = "RPM";
            this.toolTipRFD.SetToolTip(this.chkDriveRpmRFD, "Host Tools v0.18 or Later");
            this.chkDriveRpmRFD.UseVisualStyleBackColor = true;
            this.chkDriveRpmRFD.CheckedChanged += new System.EventHandler(this.chkDriveRpmRFD_CheckedChanged);
            // 
            // txtDriveRateRFD
            // 
            this.txtDriveRateRFD.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtDriveRateRFD.Location = new System.Drawing.Point(352, 163);
            this.txtDriveRateRFD.MaxLength = 3;
            this.txtDriveRateRFD.Name = "txtDriveRateRFD";
            this.txtDriveRateRFD.Size = new System.Drawing.Size(54, 22);
            this.txtDriveRateRFD.TabIndex = 12;
            this.txtDriveRateRFD.Text = "250";
            this.toolTipRFD.SetToolTip(this.txtDriveRateRFD, "Host Tools v0.18 or Later");
            this.txtDriveRateRFD.TextChanged += new System.EventHandler(this.txtDriveRateRFD_TextChanged);
            // 
            // chkDriveRateRFD
            // 
            this.chkDriveRateRFD.AutoSize = true;
            this.chkDriveRateRFD.Location = new System.Drawing.Point(107, 165);
            this.chkDriveRateRFD.Name = "chkDriveRateRFD";
            this.chkDriveRateRFD.Size = new System.Drawing.Size(107, 21);
            this.chkDriveRateRFD.TabIndex = 11;
            this.chkDriveRateRFD.Text = "Rate (kbit/s)";
            this.toolTipRFD.SetToolTip(this.chkDriveRateRFD, "Host Tools v0.18 or Later");
            this.chkDriveRateRFD.UseVisualStyleBackColor = true;
            this.chkDriveRateRFD.CheckedChanged += new System.EventHandler(this.chkDriveRateRFD_CheckedChanged);
            // 
            // chkDoubleStep
            // 
            this.chkDoubleStep.AutoSize = true;
            this.chkDoubleStep.Location = new System.Drawing.Point(107, 23);
            this.chkDoubleStep.Name = "chkDoubleStep";
            this.chkDoubleStep.Size = new System.Drawing.Size(109, 21);
            this.chkDoubleStep.TabIndex = 2;
            this.chkDoubleStep.Text = "Double-Step";
            this.toolTipRFD.SetToolTip(this.chkDoubleStep, "Host Tools v0.12 or Later");
            this.chkDoubleStep.UseVisualStyleBackColor = true;
            this.chkDoubleStep.CheckedChanged += new System.EventHandler(this.chkDoubleStep_CheckedChanged);
            // 
            // chkRevsPerTrack
            // 
            this.chkRevsPerTrack.AutoSize = true;
            this.chkRevsPerTrack.Location = new System.Drawing.Point(107, 50);
            this.chkRevsPerTrack.Name = "chkRevsPerTrack";
            this.chkRevsPerTrack.Size = new System.Drawing.Size(171, 21);
            this.chkRevsPerTrack.TabIndex = 3;
            this.chkRevsPerTrack.Text = "Revs to read per track";
            this.chkRevsPerTrack.UseVisualStyleBackColor = true;
            this.chkRevsPerTrack.CheckedChanged += new System.EventHandler(this.chkRevsPerTrack_CheckedChanged);
            // 
            // txtRevsPerTrack
            // 
            this.txtRevsPerTrack.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtRevsPerTrack.Location = new System.Drawing.Point(352, 48);
            this.txtRevsPerTrack.Name = "txtRevsPerTrack";
            this.txtRevsPerTrack.Size = new System.Drawing.Size(54, 22);
            this.txtRevsPerTrack.TabIndex = 4;
            this.txtRevsPerTrack.Text = "3";
            this.txtRevsPerTrack.TextChanged += new System.EventHandler(this.txtRevsPerTrack_TextChanged);
            // 
            // chkReadFirstCyl
            // 
            this.chkReadFirstCyl.AutoSize = true;
            this.chkReadFirstCyl.Location = new System.Drawing.Point(107, 78);
            this.chkReadFirstCyl.Name = "chkReadFirstCyl";
            this.chkReadFirstCyl.Size = new System.Drawing.Size(159, 21);
            this.chkReadFirstCyl.TabIndex = 5;
            this.chkReadFirstCyl.Text = "First cylinder to read";
            this.chkReadFirstCyl.UseVisualStyleBackColor = true;
            this.chkReadFirstCyl.CheckedChanged += new System.EventHandler(this.chkReadFirstCyl_CheckedChanged);
            // 
            // txtReadFirstCyl
            // 
            this.txtReadFirstCyl.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtReadFirstCyl.Location = new System.Drawing.Point(352, 77);
            this.txtReadFirstCyl.Name = "txtReadFirstCyl";
            this.txtReadFirstCyl.Size = new System.Drawing.Size(54, 22);
            this.txtReadFirstCyl.TabIndex = 6;
            this.txtReadFirstCyl.Text = "0";
            this.txtReadFirstCyl.TextChanged += new System.EventHandler(this.txtReadFirstCyl_TextChanged);
            // 
            // chkReadLastCyl
            // 
            this.chkReadLastCyl.AutoSize = true;
            this.chkReadLastCyl.Location = new System.Drawing.Point(107, 108);
            this.chkReadLastCyl.Name = "chkReadLastCyl";
            this.chkReadLastCyl.Size = new System.Drawing.Size(159, 21);
            this.chkReadLastCyl.TabIndex = 7;
            this.chkReadLastCyl.Text = "Last cylinder to read";
            this.chkReadLastCyl.UseVisualStyleBackColor = true;
            this.chkReadLastCyl.CheckedChanged += new System.EventHandler(this.chkReadLastCyl_CheckedChanged);
            // 
            // txtDriveSelectRFD
            // 
            this.txtDriveSelectRFD.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtDriveSelectRFD.Location = new System.Drawing.Point(352, 134);
            this.txtDriveSelectRFD.MaxLength = 1;
            this.txtDriveSelectRFD.Name = "txtDriveSelectRFD";
            this.txtDriveSelectRFD.Size = new System.Drawing.Size(54, 22);
            this.txtDriveSelectRFD.TabIndex = 10;
            this.txtDriveSelectRFD.Text = "A";
            this.txtDriveSelectRFD.TextChanged += new System.EventHandler(this.txtDriveSelectRFD_TextChanged);
            // 
            // txtReadLastCyl
            // 
            this.txtReadLastCyl.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtReadLastCyl.Location = new System.Drawing.Point(352, 106);
            this.txtReadLastCyl.Name = "txtReadLastCyl";
            this.txtReadLastCyl.Size = new System.Drawing.Size(54, 22);
            this.txtReadLastCyl.TabIndex = 8;
            this.txtReadLastCyl.Text = "79";
            this.txtReadLastCyl.TextChanged += new System.EventHandler(this.txtReadLastCyl_TextChanged);
            // 
            // chkDriveSelectRFD
            // 
            this.chkDriveSelectRFD.AutoSize = true;
            this.chkDriveSelectRFD.Enabled = false;
            this.chkDriveSelectRFD.Location = new System.Drawing.Point(107, 136);
            this.chkDriveSelectRFD.Name = "chkDriveSelectRFD";
            this.chkDriveSelectRFD.Size = new System.Drawing.Size(162, 21);
            this.chkDriveSelectRFD.TabIndex = 9;
            this.chkDriveSelectRFD.Text = "Drive Select (AB012)";
            this.toolTipRFD.SetToolTip(this.chkDriveSelectRFD, "Host Tools v0.10 or Later");
            this.chkDriveSelectRFD.UseVisualStyleBackColor = true;
            this.chkDriveSelectRFD.CheckedChanged += new System.EventHandler(this.chkDriveSelectRFD_CheckedChanged);
            // 
            // rbReadSingleSided
            // 
            this.rbReadSingleSided.AutoSize = true;
            this.rbReadSingleSided.Location = new System.Drawing.Point(107, 224);
            this.rbReadSingleSided.Name = "rbReadSingleSided";
            this.rbReadSingleSided.Size = new System.Drawing.Size(108, 21);
            this.rbReadSingleSided.TabIndex = 15;
            this.rbReadSingleSided.TabStop = true;
            this.rbReadSingleSided.Text = "Single Sided";
            this.rbReadSingleSided.UseVisualStyleBackColor = true;
            this.rbReadSingleSided.CheckedChanged += new System.EventHandler(this.rbReadSingleSided_CheckedChanged);
            // 
            // rbReadDoubleSided
            // 
            this.rbReadDoubleSided.AutoSize = true;
            this.rbReadDoubleSided.Checked = true;
            this.rbReadDoubleSided.Location = new System.Drawing.Point(221, 224);
            this.rbReadDoubleSided.Name = "rbReadDoubleSided";
            this.rbReadDoubleSided.Size = new System.Drawing.Size(114, 21);
            this.rbReadDoubleSided.TabIndex = 16;
            this.rbReadDoubleSided.TabStop = true;
            this.rbReadDoubleSided.Text = "Double Sided";
            this.rbReadDoubleSided.UseVisualStyleBackColor = true;
            this.rbReadDoubleSided.CheckedChanged += new System.EventHandler(this.rbReadDoubleSided_CheckedChanged);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(394, 414);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(108, 29);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtRFDCommandLine
            // 
            this.txtRFDCommandLine.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtRFDCommandLine.Location = new System.Drawing.Point(23, 326);
            this.txtRFDCommandLine.Multiline = true;
            this.txtRFDCommandLine.Name = "txtRFDCommandLine";
            this.txtRFDCommandLine.Size = new System.Drawing.Size(512, 74);
            this.txtRFDCommandLine.TabIndex = 18;
            // 
            // lblStaticCL
            // 
            this.lblStaticCL.AutoSize = true;
            this.lblStaticCL.Location = new System.Drawing.Point(229, 298);
            this.lblStaticCL.Name = "lblStaticCL";
            this.lblStaticCL.Size = new System.Drawing.Size(102, 17);
            this.lblStaticCL.TabIndex = 17;
            this.lblStaticCL.Text = "Command Line";
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(280, 414);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(108, 29);
            this.btnLaunch.TabIndex = 21;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // btnRFDSelectFile
            // 
            this.btnRFDSelectFile.Location = new System.Drawing.Point(166, 414);
            this.btnRFDSelectFile.Name = "btnRFDSelectFile";
            this.btnRFDSelectFile.Size = new System.Drawing.Size(108, 29);
            this.btnRFDSelectFile.TabIndex = 20;
            this.btnRFDSelectFile.Text = "Select File";
            this.toolTipRFD.SetToolTip(this.btnRFDSelectFile, "HFE & IPF require Host Tools v0.13 or later");
            this.btnRFDSelectFile.UseVisualStyleBackColor = true;
            this.btnRFDSelectFile.Click += new System.EventHandler(this.btnRFDSelectFile_Click);
            // 
            // btnRFDSelectFolder
            // 
            this.btnRFDSelectFolder.Location = new System.Drawing.Point(52, 414);
            this.btnRFDSelectFolder.Name = "btnRFDSelectFolder";
            this.btnRFDSelectFolder.Size = new System.Drawing.Size(108, 29);
            this.btnRFDSelectFolder.TabIndex = 19;
            this.btnRFDSelectFolder.Text = "Select Folder";
            this.btnRFDSelectFolder.UseVisualStyleBackColor = true;
            this.btnRFDSelectFolder.Click += new System.EventHandler(this.btnRFDSelectFolder_Click);
            // 
            // ReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(597, 503);
            this.Controls.Add(this.gbReadFromDisk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Read From Disk";
            this.Load += new System.EventHandler(this.ReadForm_Load);
            this.gbReadFromDisk.ResumeLayout(false);
            this.gbReadFromDisk.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReadFromDisk;
        private System.Windows.Forms.TextBox txtDriveSelectRFD;
        private System.Windows.Forms.CheckBox chkDriveSelectRFD;
        private System.Windows.Forms.Button btnRFDSelectFile;
        private System.Windows.Forms.Button btnRFDSelectFolder;
        private System.Windows.Forms.RadioButton rbReadDoubleSided;
        private System.Windows.Forms.RadioButton rbReadSingleSided;
        private System.Windows.Forms.TextBox txtReadLastCyl;
        private System.Windows.Forms.CheckBox chkReadLastCyl;
        private System.Windows.Forms.TextBox txtReadFirstCyl;
        private System.Windows.Forms.CheckBox chkReadFirstCyl;
        private System.Windows.Forms.TextBox txtRevsPerTrack;
        private System.Windows.Forms.CheckBox chkRevsPerTrack;
        private System.Windows.Forms.TextBox txtRFDCommandLine;
        private System.Windows.Forms.Label lblStaticCL;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkDoubleStep;
        private System.Windows.Forms.ToolTip toolTipRFD;
        private System.Windows.Forms.TextBox txtDriveRpmRFD;
        private System.Windows.Forms.CheckBox chkDriveRpmRFD;
        private System.Windows.Forms.TextBox txtDriveRateRFD;
        private System.Windows.Forms.CheckBox chkDriveRateRFD;
    }
}