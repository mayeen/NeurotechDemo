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
using Neurotec.Devices;
using System.Windows.Forms;
using NeurotechDemo.Model;
using NeurotechDemo.Controller;
using Neurotec.Images;
using Neurotec.Biometrics.Gui;
namespace NeurotechDemo
{
    class EnrollmentFromScanner
    {
      
        
        public EnrollmentFromScanner(string subjectID,NSubject subject)
        {
            
            const string components = "Biometrics.FingerExtraction,Devices.FingerScanners";
            //obtain license 
            ControllerUtils.ObtainLicense(components);

                using (var biometricClient = new NBiometricClient { UseDeviceManager = true })
                using (var deviceManager = biometricClient.DeviceManager)
               // using (var subject = new NSubject())
                //using (var finger = new NFinger())
                {
                    
                    ////set type of the device used
                    //deviceManager.DeviceTypes = NDeviceType.FingerScanner;
                    ////initialize the NDeviceManager
                    //deviceManager.Initialize();

                    //int i;
                    ////get count of connected devices
                    //int count = deviceManager.Devices.Count;

                    //if (count > 0)
                    //    MessageBox.Show("found " + count + "finger scanners");
                    //else
                    //{
                    //    MessageBox.Show("no finger scanners found, exiting ...\n");
                    //    // return -1;
                    //}
                    ////list detected scanners
                    //if (count > 1)
                    //    MessageBox.Show("Please select finger scanner from the list: ");
                    //for (i = 0; i < count; i++)
                    //{
                    //    NDevice device = deviceManager.Devices[i];
                    //    MessageBox.Show(i + 1 + " " + device.DisplayName);
                    //}
                    ////finger scanner selection by user
                    //if (count > 1)
                    //{
                    //    MessageBox.Show("Please enter finger scanner index: ");
                    //    string line = Console.ReadLine();
                    //    if (line == null) throw new ApplicationException("Nothing read from standard input");
                    //    i = int.Parse(line);
                    //    if (i > count || i < 1)
                    //    {
                    //        MessageBox.Show("Incorrect index provided, exiting ...");
                    //        //return -1;
                    //    }
                    //}
                    //i--;

                    ////set the selected finger scanner as NBiometricClient Finger Scanner
                    //biometricClient.FingerScanner = (NFScanner)deviceManager.Devices[i];

                    //add NFinger to NSubject
                    //subject.Fingers.Add(finger);
                //    MessageBox.Show("Place your finger on the scanner");
                //    //start capturing
                //    NBiometricStatus status = biometricClient.Capture(subject);
                //if (status != NBiometricStatus.Ok)
                //{
                //    MessageBox.Show("Failed to capture: " + status);
                //    // return -1;
                //}
                
                //    MessageBox.Show("Captured ");
                    //Set finger template size (recommended, for enroll to database, is large) (optional)
                    biometricClient.FingersTemplateSize = NTemplateSize.Large;
                    subject.Id = subjectID;
                    //Create template from added finger image
                    NBiometricStatus status = biometricClient.CreateTemplate(subject);
                
                    if (status == NBiometricStatus.Ok)

                    {
                    //save template
                    ControllerUtils.SaveTemplate(subject);
                    EnrollToDatabase enrollToDatabase = new EnrollToDatabase(status, subject);
                    MessageBox.Show("Enrollment done");
                }

                    else
                    {
                        MessageBox.Show("Extraction failed! Status: "+ status);
                    }



                }
               
            }
    }
}
