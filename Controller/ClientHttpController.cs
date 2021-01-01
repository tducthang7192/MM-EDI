using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.CSharp;
using System.Net.Http.Headers;
using System.Windows.Forms;
using RestSharp;
using System.Net;
using RestSharp.Serialization.Json;
using Newtonsoft.Json.Linq;

namespace MM_Project
{
    public class ClientHttpController
    {
        public static async Task<string> GetToken()
        {
            string token = "";
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var httpClient = new RestClient(Constant.ION_TOKEN_URL);
            var request = new RestRequest(Method.POST);
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", "infor#KAP-pYBSx-ULzlRw_tzVw95wAZUxdya7QumqMH9LsAhAnoKP1FC2j4RJpcQ_XJ9MV5U3RH-8VYTSHREPonKbBA");
            request.AddParameter("password", "V-cOWwVQLhnuF_zysowjlezj8eGUmqdOuj877L3QDfu-VN1VwCuRO4xCoRNBN5BU2eMyPpBZeBJwj-iUa--b9Q");
            request.AddParameter("scope", "infor-ionapi-all");
            request.AddParameter("client_id", "infor~Bjn1gapnzDmsiWwy_fLUPO_O0Jfg5scfbS7HmRM5c2c");
            request.AddParameter("client_secret", "AsxRjQOk84yyU72t2UAyu7nTHzms3OMz_j79qSxaUVg42J1EzC1VvfvRxAczdkrT320lTHaOLtvtDrbAlXgf7Q");
            IRestResponse response = httpClient.Execute(request);
            if (response.IsSuccessful)
            {
                var content = response.Content;
                var jObjectContent = JObject.Parse(content);
                token = jObjectContent.GetValue("access_token").ToString();

            }
            else
            {
                return "";
            }
            return token;
        }

        public static async Task<IonReponse> Post(JObject model, string url, String token)
        {
    
            IonReponse result = new IonReponse();
            var tempModel = JsonConvert.DeserializeObject(model.ToString());
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            string URI = string.Format(url, token);
            var httpClient = new RestClient(URI);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", tempModel, ParameterType.RequestBody);
            IRestResponse response = httpClient.Execute(request);
            if (response.IsSuccessful)
            {
                result.check = true;
                result.message = response.Content.ToString();
            }
            else
            {
                result.check = false;
                result.message = response.Content.ToString();
                result.errcode = response.StatusCode;
            }
            return result;
        }

    }
}
