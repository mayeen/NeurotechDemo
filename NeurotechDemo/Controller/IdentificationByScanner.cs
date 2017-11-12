using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neurotec.Licensing;
using Neurotec.Biometrics.Client;
using Neurotec.Biometrics;
using System.IO;
using Neurotec.Biometrics.Standards;
using Neurotec.IO;
using System.Windows.Forms;
using NeurotechDemo.Model;
using Neurotec.Devices;

namespace NeurotechDemo.Controller
{
    class IdentificationByScanner
    {
        public IdentificationByScanner(string subjectID)
        {
            BdifStandard standard = BdifStandard.Unspecified;
            const string Components = "Biometrics.FingerExtraction,Biometrics.FingerMatching";
            try
            {
                if (!NLicense.ObtainComponents("/local", 5000, Components))
                {
                    throw new ApplicationException(string.Format("Could not obtain licenses for components: {0}", Components));
                }
                using (var biometricClient = new NBiometricClient { UseDeviceManager = true })
                using (var deviceManager = biometricClient.DeviceManager)
                using (var subject = new NSubject())
                using (var finger = new NFinger())
                {
                    // conenction to database
                    biometricClient.SetDatabaseConnectionToOdbc("Dsn=mssql_dsn;UID=sa;PWD=ddm@TT", "subjects");

                    //set type of the device used
                    deviceManager.DeviceTypes = NDeviceType.FingerScanner;
                    //initialize the NDeviceManager
                    deviceManager.Initialize();

                    int i;
                    //get count of connected devices
                    int count = deviceManager.Devices.Count;

                    if (count > 0)
                        MessageBox.Show("found " + count + "finger scanners");
                    else
                    {
                        MessageBox.Show("no finger scanners found, exiting ...\n");
                        // return -1;
                    }
                    //list detected scanners
                    if (count > 1)
                        MessageBox.Show("Please select finger scanner from the list: ");
                    for (i = 0; i < count; i++)
                    {
                        NDevice device = deviceManager.Devices[i];
                        MessageBox.Show(i + 1 + " " + device.DisplayName);
                    }
                    //finger scanner selection by user
                    if (count > 1)
                    {
                        MessageBox.Show("Please enter finger scanner index: ");
                        string line = Console.ReadLine();
                        if (line == null) throw new ApplicationException("Nothing read from standard input");
                        i = int.Parse(line);
                        if (i > count || i < 1)
                        {
                            MessageBox.Show("Incorrect index provided, exiting ...");
                            //return -1;
                        }
                    }
                    i--;

                    //set the selected finger scanner as NBiometricClient Finger Scanner
                    biometricClient.FingerScanner = (NFScanner)deviceManager.Devices[i];

                    //add NFinger to NSubject
                    subject.Fingers.Add(finger);
                    MessageBox.Show("Place your finger on the scanner");
                    //start capturing
                    NBiometricStatus status = biometricClient.Capture(subject);
                    if (status != NBiometricStatus.Ok)
                    {
                        MessageBox.Show("Failed to capture: " + status);
                        // return -1;
                    }
                    MessageBox.Show("Captured ");
                    //Set finger template size (recommended, for enroll to database, is large) (optional)
                    biometricClient.FingersTemplateSize = NTemplateSize.Large;
                    subject.Id = subjectID;
                    //Create template from added finger image
                    status = biometricClient.CreateTemplate(subject);
                    //identification from IdentificationFromDatabase from model class
                    IdentificationFromDatabase idm = new IdentificationFromDatabase(subject);

                }
            } catch (Exception ex)
            {
                Console.WriteLine("didn't work");
            }
                }
            }
}
