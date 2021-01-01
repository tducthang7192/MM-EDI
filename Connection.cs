using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MM_Project
{
    class Connection
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["connectionstr"].ConnectionString;
    }
}
