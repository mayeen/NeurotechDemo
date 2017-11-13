namespace NeurotechDemo
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
            this.btnIdentifyFromImage.Location = new System.Drawing.Point(49, 196);
            this.btnIdentifyFromImage.Name = "btnIdentifyFromImage";
            this.btnIdentifyFromImage.Size = new System.Drawing.Size(147, 47);
            this.btnIdentifyFromImage.TabIndex = 8;
            this.btnIdentifyFromImage.Text = "Open Image";
            this.btnIdentifyFromImage.UseVisualStyleBackColor = true;
            this.btnIdentifyFromImage.Click += new System.EventHandler(this.btnIdentifyFromImage_Click);
            // 
            // btnIdentifyFromScanner
            // 
            this.btnIdentifyFromScanner.Location = new System.Drawing.Point(49, 115);
            this.btnIdentifyFromScanner.Name = "btnIdentifyFromScanner";
            this.btnIdentifyFromScanner.Size = new System.Drawing.Size(147, 47);
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
            // IdentificationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 503);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnIdentifyFromImage);
            this.Controls.Add(this.btnIdentifyFromScanner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSubjectID);
            this.Name = "IdentificationView";
            this.Text = "IdentificationView";
            this.Load += new System.EventHandler(this.IdentificationView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnIdentifyFromImage;
        private System.Windows.Forms.Button btnIdentifyFromScanner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubjectID;
    }
}