using Neurotec.Biometrics.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeurotechDemo.Model
{
    class Config
    {
        public Config()
        {

        }


        public static string FileDirectory()
        {
            string path = @"E:\Fingerprint sample\Config Folder\";
            return path;
        }
        public static string saveImage()
        {
            string path = @"E:\Fingerprint sample\Config Folder\Scanned Image\";
            return path;
        }

        public void Connection(NBiometricClient biometricClient)
        {
            biometricClient.SetDatabaseConnectionToOdbc("Dsn=mssql_dsn;UID=sa;PWD=ddm@TT", "subjects");
        }
          
    }
}
