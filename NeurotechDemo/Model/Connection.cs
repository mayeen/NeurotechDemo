using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neurotec.Biometrics.Client;
using Neurotec.Biometrics;

namespace NeurotechDemo
{
    class Connection
    {
        public Connection(NBiometricClient biometricClient)
        {
            // conenction to database
            biometricClient.SetDatabaseConnectionToOdbc("Dsn=mssql_dsn;UID=sa;PWD=ddm@TT", "subjects");
        }
    }
}
