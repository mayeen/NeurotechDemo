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
using NeurotechDemo.Model;


namespace NeurotechDemo
{
    class EnrollmentFromImage

    {
      
        public EnrollmentFromImage(string subjectID, string imageFile)
        {
            BdifStandard standard = BdifStandard.Unspecified;


            //Licenses obtain for components

            string components = "Biometrics.FaceExtraction,Biometrics.FingerExtraction,Devices.Cameras";
            try
            {
                if (!NLicense.ObtainComponents("/local", 5000, components))
                {

                    throw new ApplicationException(string.Format("Could not obtain licenses for components: { 0 }", components));

                }

            }
            catch
            {
                Console.WriteLine(components);

            }
            using (var biometricClient = new NBiometricClient { UseDeviceManager = true })
            using (var deviceManager = biometricClient.DeviceManager)
            using (var subject = new NSubject())
            using (var finger = new NFinger())
            {
                //image location to create template 
                //string imageFile = "E:\\Fingerprint sample\\Latest Sample\\Fourth Finger.jpg";
              



                finger.FileName = imageFile;
                subject.Fingers.Add(finger);
                subject.Id = subjectID; //ID number in the database
                Console.WriteLine(finger.FileName);
                //Set finger template size (recommended, for enroll to database, is large)

                biometricClient.FingersTemplateSize = NTemplateSize.Large;

                NBiometricStatus status = NBiometricStatus.InternalError;

                //creates template using the image
                status = biometricClient.CreateTemplate(subject);
                if (status == NBiometricStatus.Ok)
                {
                    //ISO or ANSI template stadard can be set before extraction
                    Console.WriteLine("{0} template extracted.", standard == BdifStandard.Iso ?
                    "ISO" : standard == BdifStandard.Ansi ? "ANSI" : "Proprietary");
                    Console.WriteLine("Template extracted");
                    if (standard == BdifStandard.Iso)
                    {   //create BDifStandard.ISO template
                        File.WriteAllBytes(Config.FileDirectory() + "Fourth Template Generated ISO", subject.GetTemplateBuffer(CbeffBiometricOrganizations.IsoIecJtc1SC37Biometrics,
                            CbeffBdbFormatIdentifiers.IsoIecJtc1SC37BiometricsFingerMinutiaeRecordFormat,
                            FMRecord.VersionIsoCurrent).ToArray());
                    }
                    else if (standard == BdifStandard.Ansi)
                    {
                        //create BDifStandard.ANSI template
                        File.WriteAllBytes(Config.FileDirectory() + "Fourth Template Generated ANSI", subject.GetTemplateBuffer(CbeffBiometricOrganizations.IncitsTCM1Biometrics,
                            CbeffBdbFormatIdentifiers.IncitsTCM1BiometricsFingerMinutiaeU,
                            FMRecord.VersionAnsiCurrent).ToArray());
                    }
                    else
                    {
                        //create general template  
                        File.WriteAllBytes(Config.FileDirectory() + "Fourth Finger Template Generated", subject.GetTemplateBuffer().ToArray());
                    }

                    //enroll into database using EnrollToDatabase Constructor
                    EnrollToDatabase enrollToDatabase = new EnrollToDatabase(status, subject);
                   
                    Console.WriteLine("template saved successfully");
                }
                else
                {
                    Console.WriteLine("Extraction failed! Status: {0}", status);
                   // return -1;
                }

            }

           // return 0;

        }
    }
}