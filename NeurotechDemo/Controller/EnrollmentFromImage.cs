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
using System.Windows.Forms;
using NeurotechDemo.Controller;


namespace NeurotechDemo
{
    class EnrollmentFromImage

    {
        public EnrollmentFromImage(string subjectID, string imageFile)
        {
            string components = "Biometrics.FingerExtraction";
           
            //call Obtain License to obtain license
            ControllerUtils.ObtainLicense(components);
         
            try {
                using (var biometricClient = new NBiometricClient { UseDeviceManager = true })
                 // using (var deviceManager = biometricClient.DeviceManager)
                using (var subject = new NSubject())
                using (var finger = new NFinger())
                {
                    finger.FileName = imageFile;
                    subject.Fingers.Add(finger);
                    subject.Id = subjectID; //ID number in the database

                    //Set finger template size (recommended, for enroll to database, is large)
                    biometricClient.FingersTemplateSize = NTemplateSize.Large;

                    NBiometricStatus status = NBiometricStatus.InternalError;

                    //creates template using the image
                    status = biometricClient.CreateTemplate(subject);
                    if (status == NBiometricStatus.Ok)
                    {
                        ControllerUtils.SaveTemplate(subject);
                        
                        //enroll into database using EnrollToDatabase Constructor
                        EnrollToDatabase enrollToDatabase = new EnrollToDatabase(status, subject);
                    }
                    else
                    {
                        Console.WriteLine("Extraction failed! Status: {0}", status);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           // return 0;

        }
    }
}