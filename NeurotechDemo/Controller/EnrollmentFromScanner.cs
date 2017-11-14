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

namespace NeurotechDemo
{
    class EnrollmentFromScanner
    {
        public EnrollmentFromScanner(string subjectID)
        {
            BdifStandard standard = BdifStandard.Unspecified;
            const string Components = "Biometrics.FingerExtraction,Devices.FingerScanners";
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

                    if (status == NBiometricStatus.Ok)

                    {
                        Console.WriteLine("{0} template extracted.", standard == BdifStandard.Iso ?
                   "ISO" : standard == BdifStandard.Ansi ? "ANSI" : "Proprietary");
                        MessageBox.Show("Template extracted");

                        // save image to file
                        using (var image = subject.Fingers[0].Image)
                        {
                            image.Save(Config.saveImage() +"Scanned Sample.jpg");
                            MessageBox.Show("image saved successfully");
                        }
                        if (standard == BdifStandard.Iso)
                        {   //create BDifStandard.ISO template
                            File.WriteAllBytes(Config.FileDirectory() + "Scanned Sample ISO", subject.GetTemplateBuffer(CbeffBiometricOrganizations.IsoIecJtc1SC37Biometrics,
                                CbeffBdbFormatIdentifiers.IsoIecJtc1SC37BiometricsFingerMinutiaeRecordFormat,
                                FMRecord.VersionIsoCurrent).ToArray());
                        }
                        else if (standard == BdifStandard.Ansi)
                        {
                            //create BDifStandard.ANSI template
                            File.WriteAllBytes(Config.FileDirectory() + "Scanned Sample Template ANSI", subject.GetTemplateBuffer(CbeffBiometricOrganizations.IncitsTCM1Biometrics,
                                CbeffBdbFormatIdentifiers.IncitsTCM1BiometricsFingerMinutiaeU,
                                FMRecord.VersionAnsiCurrent).ToArray());
                        }
                        else
                        {
                            //create general template  
                            File.WriteAllBytes(Config.FileDirectory() + "Scanned Sample Template", subject.GetTemplateBuffer().ToArray());
                        }
                        //enroll into database using EnrollToDatabase Constructor
                        EnrollToDatabase enrollToDatabase = new EnrollToDatabase(status, subject);   
                    }
                
                    else
                    {
                        MessageBox.Show("Extraction failed! Status: "+ status);
                        //return -1;
                    }



                }
                }catch(Exception ex)
            {
                MessageBox.Show("didn't work");

            }
            }
    }
}
