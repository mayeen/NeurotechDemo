namespace NeurotechDemo
{
    partial class EnrollView
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
            this.btnEnrollFromScanner = new System.Windows.Forms.Button();
            this.btnEnrollFromImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSubjectID
            // 
            this.txtSubjectID.Location = new System.Drawing.Point(183, 49);
            this.txtSubjectID.Name = "txtSubjectID";
            this.txtSubjectID.Size = new System.Drawing.Size(100, 20);
            this.txtSubjectID.TabIndex = 0;
            this.txtSubjectID.TextChanged += new System.EventHandler(this.txtSubjectID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subject ID Number";
            // 
            // btnEnrollFromScanner
            // 
            this.btnEnrollFromScanner.Location = new System.Drawing.Point(183, 190);
            this.btnEnrollFromScanner.Name = "btnEnrollFromScanner";
            this.btnEnrollFromScanner.Size = new System.Drawing.Size(147, 47);
            this.btnEnrollFromScanner.TabIndex = 2;
            this.btnEnrollFromScanner.Text = "Open Scanner";
            this.btnEnrollFromScanner.UseVisualStyleBackColor = true;
            this.btnEnrollFromScanner.Click += new System.EventHandler(this.btnEnrollFromScanner_Click);
            // 
            // btnEnrollFromImage
            // 
            this.btnEnrollFromImage.Location = new System.Drawing.Point(422, 190);
            this.btnEnrollFromImage.Name = "btnEnrollFromImage";
            this.btnEnrollFromImage.Size = new System.Drawing.Size(147, 47);
            this.btnEnrollFromImage.TabIndex = 3;
            this.btnEnrollFromImage.Text = "Open Image";
            this.btnEnrollFromImage.UseVisualStyleBackColor = true;
            this.btnEnrollFromImage.Click += new System.EventHandler(this.btnEnrollFromImage_Click);
            // 
            // EnrollView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 459);
            this.Controls.Add(this.btnEnrollFromImage);
            this.Controls.Add(this.btnEnrollFromScanner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSubjectID);
            this.Name = "EnrollView";
            this.Text = "EnrollView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubjectID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnrollFromScanner;
        private System.Windows.Forms.Button btnEnrollFromImage;
    }
}