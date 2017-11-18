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
using System.Windows.Forms;

namespace NeurotechDemo
{
    class EnrollToDatabase
    {
        public EnrollToDatabase(NBiometricStatus status,NSubject subject)
            {
            var biometricClient = new NBiometricClient { UseDeviceManager = true };
            //database connection through constructor
            Connection con = new Connection(biometricClient);
            
            
            //add into database
            NBiometricTask enrollTask =
            biometricClient.CreateTask(NBiometricOperations.Enroll, subject);
            biometricClient.PerformTask(enrollTask);
            status = enrollTask.Status;
            if (status != NBiometricStatus.Ok)
            {
                MessageBox.Show("Enrollment was unsuccessful. status:"+ status);
                if (enrollTask.Error != null) throw enrollTask.Error;
                // return -1;
            }
            MessageBox.Show("Enrollment was successful.");
        }

    }
}
