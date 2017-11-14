using Neurotec.Images;
using NeurotechDemo.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeurotechDemo
{
    public partial class IdentificationView : Form
    {
        public IdentificationView(string subjectID)
        {
            InitializeComponent();
           // openFileDialog.Filter = NImages.GetOpenFileFilterString(true, true);
        }
        private static string subjectID;
        public static string SubjectID
        {
            get { return subjectID; }
            set { subjectID = value; }
        }

        string a = subjectID;
        private void btnIdentifyFromScanner_Click(object sender, EventArgs e)
        {
            IdentificationFromScanner identificationByScanner = new IdentificationFromScanner(subjectID);
        }

        private void btnIdentifyFromImage_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = openFileDialog.FileName;

                    IdentificationFromImage identificationFromImage = new IdentificationFromImage(subjectID, path);
                    MessageBox.Show("Identification Done from Image");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " in IdentificationView");
                }
            }

           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void IdentificationView_Load(object sender, EventArgs e)
        {
            txtSubjectID.Text = subjectID;

        }

        private void txtSubjectID_TextChanged(object sender, EventArgs e)
        {
            txtSubjectID.Text = subjectID;
        }
    }
}
