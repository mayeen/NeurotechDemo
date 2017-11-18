using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neurotec.Gui;
using Neurotec.Devices;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Biometrics.Gui;
using System.Windows.Forms;

namespace NeurotechDemo.View
{
    class ViewUtils
    {

        public void FingerViewController(NFingerView fingerView)
        {
            using (var biometricClient = new NBiometricClient { UseDeviceManager = true })
            using (var deviceManager = biometricClient.DeviceManager)
            {
                deviceManager.DeviceTypes = NDeviceType.FingerScanner;
                deviceManager.Initialize();
                biometricClient.FingerScanner = (NFScanner)deviceManager.Devices[0];
                while (biometricClient.FingerScanner != null)
                {
                    NFinger subjectFinger = new NFinger();
                    MessageBox.Show("Place your finger on the scanner");
                    subjectFinger.CaptureOptions = NBiometricCaptureOptions.Stream;
                    var subject = new NSubject();
                    subject.Fingers.Add(subjectFinger);


                }
            }

        }

    }
}
