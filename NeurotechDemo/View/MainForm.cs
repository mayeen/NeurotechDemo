using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeurotechDemo.Controller;

namespace NeurotechDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //setting subject ID to Enrollview's subjectID
        public String subjectID;
        public string SetSubjectID()
        {
            subjectID = txtSubjectID.Text;
            EnrollView.SubjectID = txtSubjectID.Text;
            IdentificationView.SubjectID = txtSubjectID.Text;
            return subjectID;
        }


        private void btnEnroll_Click(object sender, EventArgs e)
        {
            //getting id from SetSubjectID
            string id = SetSubjectID();

            //sending it to enrollview constructor
            EnrollView enrollView = new EnrollView(id);

            enrollView.Show();
            this.Hide();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            Verification verification = new Verification(subjectID);
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            string id = SetSubjectID();
            IdentificationView identificationView = new IdentificationView(id);
            identificationView.Show();
            this.Hide();
            //IdentificationFromImage identification = new IdentificationFromImage(subjectID);

        }

        public void txtSubjectID_TextChanged(object sender, EventArgs e)
        {
            
            subjectID = txtSubjectID.Text;
            //MessageBox.Show();
           
        }

       
        private void btxExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
