using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace trabalho1
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    class RestClient
    {
        public string _endpoint;
        public httpVerb httpMethod;

        public RestClient()
        {
            _endpoint = String.Empty;
            httpMethod = httpVerb.GET;
        }

        public string MakeRequest(string endpoint)
        {
            string response = string.Empty;

            _endpoint = endpoint;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_endpoint);

            httpWebRequest.Method = httpMethod.ToString();

            using(HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if(webResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("endpoint error: " + webResponse.StatusCode.ToString());
                }

                using(Stream responseStream = webResponse.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using(StreamReader reader = new StreamReader(responseStream))
                        {
                            response = reader.ReadToEnd();
                        }
                    }
                }
            }
            
            
            return response;
        }
    }
}
