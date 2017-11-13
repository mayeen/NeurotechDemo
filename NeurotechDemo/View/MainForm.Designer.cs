namespace NeurotechDemo
{
    partial class MainForm
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
            this.txtSubjectID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnIdentifyByScanner = new System.Windows.Forms.Button();
            this.btxExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSubjectID
            // 
            this.txtSubjectID.Location = new System.Drawing.Point(163, 37);
            this.txtSubjectID.Name = "txtSubjectID";
            this.txtSubjectID.Size = new System.Drawing.Size(139, 20);
            this.txtSubjectID.TabIndex = 0;
            this.txtSubjectID.TextChanged += new System.EventHandler(this.txtSubjectID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subject ID number";
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(43, 169);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(123, 29);
            this.btnVerify.TabIndex = 2;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(43, 226);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(123, 32);
            this.btnIdentify.TabIndex = 3;
            this.btnIdentify.Text = "Identify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(43, 103);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(123, 31);
            this.btnEnroll.TabIndex = 4;
            this.btnEnroll.Text = "Enrollment";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnIdentifyByScanner
            // 
            this.btnIdentifyByScanner.Location = new System.Drawing.Point(43, 288);
            this.btnIdentifyByScanner.Name = "btnIdentifyByScanner";
            this.btnIdentifyByScanner.Size = new System.Drawing.Size(123, 30);
            this.btnIdentifyByScanner.TabIndex = 5;
            this.btnIdentifyByScanner.Text = "Identify By Scanner";
            this.btnIdentifyByScanner.UseVisualStyleBackColor = true;
            this.btnIdentifyByScanner.Click += new System.EventHandler(this.btnIdentifyByScanner_Click);
            // 
            // btxExit
            // 
            this.btxExit.Location = new System.Drawing.Point(575, 454);
            this.btxExit.Name = "btxExit";
            this.btxExit.Size = new System.Drawing.Size(84, 30);
            this.btxExit.TabIndex = 6;
            this.btxExit.Text = "Exit";
            this.btxExit.UseVisualStyleBackColor = true;
            this.btxExit.Click += new System.EventHandler(this.btxExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 500);
            this.Controls.Add(this.btxExit);
            this.Controls.Add(this.btnIdentifyByScanner);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.btnIdentify);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSubjectID);
            this.Name = "MainForm";
            this.Text = "Fingerprint Authentication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubjectID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Button btnIdentifyByScanner;
        private System.Windows.Forms.Button btxExit;
    }
}

