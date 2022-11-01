using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_4
{
    internal interface BaseSensorController
    {
        public bool Connect();
        public void Disconnect();
        public bool SetConnectionString(string connectionString);

    }
}
