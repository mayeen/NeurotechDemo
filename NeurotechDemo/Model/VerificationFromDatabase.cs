using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neurotec.Biometrics.Client;
using Neurotec.Biometrics;
using System.Windows.Forms;

namespace NeurotechDemo.Model
{
    class VerificationFromDatabase
    {
        public VerificationFromDatabase(NSubject subject)
        {
            var biometricClient = new NBiometricClient { UseDeviceManager = true };
            //database connection through constructor
            Connection con = new Connection(biometricClient);

            NBiometricTask identifyTask = biometricClient.CreateTask(NBiometricOperations.Verify, subject);
            biometricClient.PerformTask(identifyTask);
            NBiometricStatus status = identifyTask.Status;

            if (status != NBiometricStatus.Ok)
            {
                MessageBox.Show("Identification was unsuccessful."+ status);
               // Console.ReadLine();
                if (identifyTask.Error != null) throw identifyTask.Error;
                //return -1;

            }

            foreach (var matchingResult in subject.MatchingResults)
            {
                Console.WriteLine("Matched with ID: '{0}' with score {1}", matchingResult.Id, matchingResult.Score);
                MessageBox.Show("Matched with ID: " + matchingResult.Id + " with score: " + matchingResult.Score);
               // Console.ReadLine();
            }
        }
    }
}
