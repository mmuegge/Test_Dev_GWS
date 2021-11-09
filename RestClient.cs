using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace GWS_MVC
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    #region RestClient
    public class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb HttpMethod { get; set; }

        public const string EndpointAussenTemp = "http://192.168.178.23/dev/sps/io/Aussentemperatur/state";
        public const string EndpointInnenTemp = "http://192.168.178.23/dev/sps/io/WZ-Temperatur/state";

        public RestClient()
        {
            EndPoint = string.Empty;
            HttpMethod = HttpVerb.GET;
        }
        public string MakeRequest()
        {
            string strResponseValue = string.Empty;

            if ((EndPoint != string.Empty) && (EndPoint!=null))
            {

                Uri myUri = new Uri(EndPoint);   //neu

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);  // neu
                                                                                    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

                request.Method = HttpMethod.ToString();

                NetworkCredential myNetworkCredential = new NetworkCredential("muegge", "loxone_MMwiK27243Ew18");   // user und password
                CredentialCache myCredentialCache = new CredentialCache
            {
                {myUri, "Basic", myNetworkCredential }
            };
                //myCredentialCache.Add(myUri, "Basic", myNetworkCredential);
                request.PreAuthenticate = true;
                request.Credentials = myCredentialCache;

                request.Timeout = 2000; // Timeout after 2000ms

                HttpWebResponse responce = null;

                try
                {
                    try
                    {
                        responce = (HttpWebResponse)request.GetResponse();
                        // Process the responce stream...(could be JSON, XML, HTML...)
                    }
                    catch
                    {
                        strResponseValue = "errorMessages";
                        return strResponseValue;
                    }

                    using (Stream responceStream = responce.GetResponseStream())
                    {
                        if (responceStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responceStream))
                            {
                                strResponseValue = reader.ReadToEnd();

                            } // end of Streamreader

                        }
                    } // end of using ResponceStream
                }
                catch (WebException ex)         // vorher Exception
                {
                     strResponseValue = "{\" errorMessages\":[\"" + ex.Message.ToString() + "\"], \"error\":{}}";         // alt
                    //console.  Log(ex.Message);
                    //JSONObject jsonError = new JSONObject();
                    //var valueError = new KeyValuePair<string, JSONValue>("status", "error");
                    //jsonError.Add(valueError);
                    //return jsonError;
                }
                finally
                {
                    if (responce != null)
                    {
                        ((IDisposable)responce).Dispose();
                    }
                }
            }
            return strResponseValue;
        }
    }
    #endregion
}
