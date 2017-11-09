using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neurotec.Licensing;
using Neurotec.Devices;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using NeurotechDemo;


namespace NeurotechDemo
{
    public partial class EnrollView : Form
    {
        public EnrollView()
        {
            InitializeComponent();
        }

        string subjectID="0";

        //private string SubjectID(string id)
        //{
        //    string subjectID = id;
        //    return subjectID;
        //}
          

        private void btnEnrollFromImage_Click(object sender, EventArgs e)
        {
           
            EnrollmentFromImage enrollmentFromImage = new EnrollmentFromImage(subjectID);
            MessageBox.Show("Enrollment done from Image");
        }

        private void txtSubjectID_TextChanged(object sender, EventArgs e)
        {
            subjectID = txtSubjectID.Text;

        }

        private void btnEnrollFromScanner_Click(object sender, EventArgs e)
        {
             EnrollmentFromScanner enrollmentFromScanner = new EnrollmentFromScanner(subjectID);
            MessageBox.Show("Enrollment done by scanner");
        }
    }
}
