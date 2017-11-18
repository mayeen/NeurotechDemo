using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.IO;
using Neurotec.Licensing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeurotechDemo.Model;

namespace NeurotechDemo.Controller
{
    class Verification
    {
        public Verification(string subjectID)
        {

            {
                string fileName = "E:\\Fingerprint sample\\Latest Sample\\Second Template Generated";
                 
                string components = "Biometrics.FingerMatching";
                ControllerUtils.ObtainLicense(components);
                using (var biometricClient = new NBiometricClient())
                // Read template


                using (NSubject subject = CreateSubject(fileName, subjectID))
                {
                    //Identification done from IdentificationFromDatabase constructor 
                    VerificationFromDatabase verify = new VerificationFromDatabase(subject);
                    

                }
            }
        }
             private static NSubject CreateSubject(string fileName, string subjectId)
        {
            var subject = new NSubject();
            subject.SetTemplateBuffer(new NBuffer(File.ReadAllBytes(fileName)));
            subject.Id = subjectId;

            return subject;


        }
    }
    }

