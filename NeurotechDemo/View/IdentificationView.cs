using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Biometrics.Gui;
using Neurotec.Devices;
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
            string component = "Biometrics.FingerExtraction,Biometrics.FingerMatching,Devices.FingerScanners,Images.WSQ,Biometrics.FingerSegmentation,Biometrics.FingerQualityAssessmentBase";
            ControllerUtils.ObtainLicense(component);
        }
        public void FingerViewController(NSubject subject, NBiometricClient biometricClient)
        {
            using (biometricClient = new NBiometricClient { UseDeviceManager = true })
            using (var deviceManager = biometricClient.DeviceManager)
            {
                deviceManager.DeviceTypes = NDeviceType.FingerScanner;
                deviceManager.Initialize();
                biometricClient.FingerScanner = (NFScanner)deviceManager.Devices[0];
                if (biometricClient.FingerScanner == null)
                {
                    MessageBox.Show("Please connect your fingerprint scanner");
                }
                else {
                    NFinger subjectFinger = new NFinger();
                    MessageBox.Show("Place your finger on the scanner");
                    subjectFinger.CaptureOptions = NBiometricCaptureOptions.Stream;
                    subject = new NSubject();
                    subject.Fingers.Add(subjectFinger);
                }

            }
        }
        private NBiometricClient biometricClient = new NBiometricClient { UseDeviceManager = true, BiometricTypes = NBiometricType.Finger };
        private NSubject subject=new NSubject();
        public NFinger subjectFinger=new NFinger();
        private ControllerUtils controller=new ControllerUtils();

        private static string subjectID;
        public static string SubjectID
        {
            get { return subjectID; }
            set { subjectID = value; }
        }

        string a = subjectID;
        private async void btnIdentifyFromScanner_Click(object sender, EventArgs e)
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
                    FingerViewIdentification.Finger = subjectFinger;

                    FingerViewIdentification.ShownImage = ShownImage.Original;
                    FingerViewIdentification.Show();
                    biometricClient.FingersReturnBinarizedImage = true;

                    NBiometricTask task = biometricClient.CreateTask(NBiometricOperations.Capture/* | NBiometricOperations.CreateTemplate*/, subject);
                    //NBiometricStatus status = biometricClient.Capture(subject);
                    //status = biometricClient.CreateTemplate(subject);
                    var performTask = await biometricClient.PerformTaskAsync(task);

                    // EnrollmentFromScanner enrollmentFromScanner = new EnrollmentFromScanner(subjectID, subject);
                    IdentificationFromScanner identificationByScanner = new IdentificationFromScanner(subjectID, subject);
                }
                }
        }
        private void OnAttributesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Status")
            {
                BeginInvoke(new Action<NBiometricStatus>(status => lblQualityIdentification.Text = status.ToString()), subjectFinger.Status);
            }
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
            MainForm mainform = new MainForm();
            mainform.Show();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
         //   FingerViewIdentification.c 
        }
    }
}
