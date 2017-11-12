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
        public String subjectID;
        public string SetSubjectID()
        {
            subjectID = txtSubjectID.Text;
            EnrollView.MainForm = txtSubjectID.Text;
            return subjectID;
        }
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            string id = SetSubjectID();
            EnrollView enrollView = new EnrollView(id);
            enrollView.Show();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            Verification verification = new Verification(subjectID);
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {

            Identification identification = new Identification(subjectID);
        }

        public void txtSubjectID_TextChanged(object sender, EventArgs e)
        {
            
            subjectID = txtSubjectID.Text;
            //MessageBox.Show();
           
        }

        private void btnIdentifyByScanner_Click(object sender, EventArgs e)
        {
            IdentificationByScanner identificationByScanner = new IdentificationByScanner(subjectID);
        }
    }
}
