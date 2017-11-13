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
using Neurotec.Images;
namespace NeurotechDemo
{
    public partial class EnrollView : Form
    {
        public EnrollView(string subjectId)
        {
            InitializeComponent();
            openFileDialog.Filter = NImages.GetOpenFileFilterString(true, true);
        }
       // public NImage _image;
        //getting value from mainform txtSubjectID textbox. 
        private static string subjectID;
        public static string SubjectID
        {
            get { return subjectID; }
            set { subjectID = value; }
        }
 
        private void btnEnrollFromImage_Click(object sender, EventArgs e)
        {
            //starting with openFile Dialog box with null
            openFileDialog.FileName = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = openFileDialog.FileName;
                  
                    EnrollmentFromImage enrollmentFromImage = new EnrollmentFromImage(subjectID, path);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+" in EnrollView");
                }
            }
                
                  MessageBox.Show("Enrollment done from Image");
        }

        private void txtSubjectID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEnrollFromScanner_Click(object sender, EventArgs e)
        {
            EnrollmentFromScanner enrollmentFromScanner = new EnrollmentFromScanner(subjectID);
            MessageBox.Show("Enrollment done by scanner");
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void EnrollView_Load(object sender, EventArgs e)
        {
            txtSubjectID.Text = subjectID;
           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //disposal of this page.
            Dispose();
        
        }
    } 
}
