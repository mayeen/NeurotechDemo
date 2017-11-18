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
using Neurotec.Biometrics.Gui;
using NeurotechDemo.Controller;
namespace NeurotechDemo
{
    public partial class EnrollView : Form
    {
        public EnrollView(string subjectId)
        {
            InitializeComponent();
            openFileDialog.Filter = NImages.GetOpenFileFilterString(true, true);
            string component = "Biometrics.FingerExtraction,Biometrics.FingerMatching,Devices.FingerScanners,Images.WSQ,Biometrics.FingerSegmentation,Biometrics.FingerQualityAssessmentBase";
            ControllerUtils.ObtainLicense(component);
        }

        private NBiometricClient biometricClient = new NBiometricClient { UseDeviceManager = true,BiometricTypes=NBiometricType.Finger };
        private NSubject subject;
        private NFinger subjectFinger;



        // public NImage _image;
        //getting value from mainform txtSubjectID textbox. 
        private static string subjectID;
        public static string SubjectID
        {
           // get { return subjectID; }
            set { subjectID = value; }
        }

        private void EnableControls(bool capturing)
        {

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
        //public void 

        private async void btnEnrollFromScanner_Click(object sender, EventArgs e)
        {
            using (var biometricClient = new NBiometricClient { UseDeviceManager = true })
            using (var deviceManager = biometricClient.DeviceManager)
            {
                deviceManager.DeviceTypes = NDeviceType.FingerScanner;
                deviceManager.Initialize();
                biometricClient.FingerScanner = (NFScanner)deviceManager.Devices[0];
                if (biometricClient.FingerScanner == null)
                {
                    MessageBox.Show(@"Please connect a fingerprint scanner");
                }
                else {
                    subjectFinger = new NFinger();
                    MessageBox.Show("Place your finger on the scanner");

                    subjectFinger.CaptureOptions = NBiometricCaptureOptions.Stream;

                    subject = new NSubject();
                    subject.Fingers.Add(subjectFinger);

                    subjectFinger.PropertyChanged += OnAttributesPropertyChanged;
                    fingerView.Finger = subjectFinger;

                    fingerView.ShownImage = ShownImage.Original;
                    fingerView.Show();
                    biometricClient.FingersReturnBinarizedImage = true;

                    NBiometricTask task = biometricClient.CreateTask(NBiometricOperations.Capture/* | NBiometricOperations.CreateTemplate*/, subject);
                    var performTask = await biometricClient.PerformTaskAsync(task);
                    EnrollmentFromScanner enrollmentFromScanner = new EnrollmentFromScanner(subjectID, subject);
                    fingerView.ClearSelectedArea();
                }
                //MessageBox.Show("Enrollment done by scanner");
                
            }
        }

        private void OnAttributesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Status")
            {
                BeginInvoke(new Action<NBiometricStatus>(status => lblQuality.Text = status.ToString()), subjectFinger.Status);
            }
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
            MainForm mainform = new MainForm();
            mainform.Show();
            Dispose();
            
        
        }
    } 
}
