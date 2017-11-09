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
        String subjectID = "0";
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            EnrollView enrollView = new EnrollView();
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

        private void txtSubjectID_TextChanged(object sender, EventArgs e)
        {
            subjectID = txtSubjectID.Text;
            //MessageBox.Show();
        }
    }
}
