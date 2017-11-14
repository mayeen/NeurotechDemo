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


namespace NeurotechDemo
{
    class IdentificationFromImage
    {
        public IdentificationFromImage(string subjectID,string templateFile)
        {
            //string fileName = "E:\\Fingerprint sample\\Fingerprint Scanned By Scanner\\Scanned Sample Template";
            //  string subjectID = subjectID;   //it is requierd for veryfication 
            string components = "Biometrics.FingerMatching";
            try
            {
                if (!NLicense.ObtainComponents("/local", 5000, components))
                {
            
                    throw new ApplicationException(string.Format("Could not obtain licenses for components: { 0 }", components));
                    // Console.WriteLine("obtained");
                }

            }
            catch
            {
                Console.WriteLine(components);
                //Console.ReadLine();
            }
            using (var biometricClient = new NBiometricClient())
            // Read template


            using (NSubject subject = CreateSubject(templateFile, subjectID))
            {
                //Identification done from IdentificationFromDatabase constructor 
                IdentificationFromDatabase identify = new IdentificationFromDatabase(subject);
                
            }
        }
        private static NSubject CreateSubject(string templateFile, string subjectId)
        {
            var subject = new NSubject();
            subject.SetTemplateBuffer(new NBuffer(File.ReadAllBytes(templateFile)));
            subject.Id = subjectId;

            return subject;


        }
    }
}
