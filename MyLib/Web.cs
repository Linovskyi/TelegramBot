using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Web
    {
        public static string GetWebContent(string UriString)
        {
            string webResponseString;

            // Create a request for the URL.
            WebRequest request = WebRequest.Create(UriString);
            request.Method = WebRequestMethods.Http.Get;
            //request.Credentials = CredentialCache.DefaultCredentials;

            using (WebResponse response = request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader streamRdr = new StreamReader(dataStream);
                    webResponseString = streamRdr.ReadToEnd();
                }
            };

            return webResponseString;
        }
    }
}
