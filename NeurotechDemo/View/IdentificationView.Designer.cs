﻿namespace NeurotechDemo
{
    partial class IdentificationView
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnIdentifyFromImage = new System.Windows.Forms.Button();
            this.btnIdentifyFromScanner = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubjectID = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FingerViewIdentification = new Neurotec.Biometrics.Gui.NFingerView();
            this.lblQualityIdentification = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(656, 404);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(93, 37);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnIdentifyFromImage
            // 
            this.btnIdentifyFromImage.Location = new System.Drawing.Point(6, 107);
            this.btnIdentifyFromImage.Name = "btnIdentifyFromImage";
            this.btnIdentifyFromImage.Size = new System.Drawing.Size(147, 47);
            this.btnIdentifyFromImage.TabIndex = 8;
            this.btnIdentifyFromImage.Text = "Open Image";
            this.btnIdentifyFromImage.UseVisualStyleBackColor = true;
            this.btnIdentifyFromImage.Click += new System.EventHandler(this.btnIdentifyFromImage_Click);
            // 
            // btnIdentifyFromScanner
            // 
            this.btnIdentifyFromScanner.Location = new System.Drawing.Point(6, 29);
            this.btnIdentifyFromScanner.Name = "btnIdentifyFromScanner";
            this.btnIdentifyFromScanner.Size = new System.Drawing.Size(147, 45);
            this.btnIdentifyFromScanner.TabIndex = 7;
            this.btnIdentifyFromScanner.Text = "Open Scanner";
            this.btnIdentifyFromScanner.UseVisualStyleBackColor = true;
            this.btnIdentifyFromScanner.Click += new System.EventHandler(this.btnIdentifyFromScanner_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Subject ID Number";
            // 
            // txtSubjectID
            // 
            this.txtSubjectID.AcceptsReturn = true;
            this.txtSubjectID.Location = new System.Drawing.Point(166, 61);
            this.txtSubjectID.Name = "txtSubjectID";
            this.txtSubjectID.Size = new System.Drawing.Size(100, 20);
            this.txtSubjectID.TabIndex = 5;
            this.txtSubjectID.TextChanged += new System.EventHandler(this.txtSubjectID_TextChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // FingerViewIdentification
            // 
            this.FingerViewIdentification.BackColor = System.Drawing.SystemColors.Control;
            this.FingerViewIdentification.BoundingRectColor = System.Drawing.Color.Red;
            this.FingerViewIdentification.Location = new System.Drawing.Point(307, 64);
            this.FingerViewIdentification.MinutiaColor = System.Drawing.Color.Red;
            this.FingerViewIdentification.Name = "FingerViewIdentification";
            this.FingerViewIdentification.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.FingerViewIdentification.ResultImageColor = System.Drawing.Color.Green;
            this.FingerViewIdentification.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.FingerViewIdentification.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.FingerViewIdentification.SingularPointColor = System.Drawing.Color.Red;
            this.FingerViewIdentification.Size = new System.Drawing.Size(316, 330);
            this.FingerViewIdentification.TabIndex = 10;
            this.FingerViewIdentification.TreeColor = System.Drawing.Color.Crimson;
            this.FingerViewIdentification.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.FingerViewIdentification.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.FingerViewIdentification.TreeWidth = 2D;
            // 
            // lblQualityIdentification
            // 
            this.lblQualityIdentification.AutoSize = true;
            this.lblQualityIdentification.Location = new System.Drawing.Point(38, 427);
            this.lblQualityIdentification.Name = "lblQualityIdentification";
            this.lblQualityIdentification.Size = new System.Drawing.Size(35, 13);
            this.lblQualityIdentification.TabIndex = 11;
            this.lblQualityIdentification.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIdentifyFromScanner);
            this.groupBox1.Controls.Add(this.btnIdentifyFromImage);
            this.groupBox1.Location = new System.Drawing.Point(49, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 192);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Option";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(307, 404);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 36);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // IdentificationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 453);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblQualityIdentification);
            this.Controls.Add(this.FingerViewIdentification);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSubjectID);
            this.Name = "IdentificationView";
            this.Text = "IdentificationView";
            this.Load += new System.EventHandler(this.IdentificationView_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnIdentifyFromImage;
        private System.Windows.Forms.Button btnIdentifyFromScanner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubjectID;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Neurotec.Biometrics.Gui.NFingerView FingerViewIdentification;
        private System.Windows.Forms.Label lblQualityIdentification;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefresh;
    }
}