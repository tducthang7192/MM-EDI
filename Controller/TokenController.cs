using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Project
{
    class TokenController
    {
        public async Task<string> Gettoken()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "token" + ".txt";
            string token = await ClientHttpController.GetToken();
            return token;
        }
    }
}
