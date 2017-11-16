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
using NeurotechDemo.Controller;

namespace NeurotechDemo
{
    class IdentificationFromImage
    {
        public IdentificationFromImage(string subjectID,string templateFile)
        {
            string components = "Biometrics.FingerMatching";
            //obtain license 

            ControllerUtils.ObtainLicense(components);
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
