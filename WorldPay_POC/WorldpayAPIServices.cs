using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GP.WorldpayGateway
{
    public static class WorldpayAPIServices
    {
        public static PaymentService SubmitOrderRequest()
        {
            
            string testUrl = ConfigurationManager.AppSettings["TestUrl"];
            PaymentService response = new PaymentService();

            string xmlData = string.Empty;
            
            try
            {

                var httpWebRequest = CreateHttpWebRequest(testUrl, "POST");
             
               // TODO: Use objects and fill with values instead of xml file
                using (StreamReader r = new StreamReader("OrderRequest.xml"))
                {
                    xmlData = r.ReadToEnd();
                }

                //  Call API using POST
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(xmlData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //  Output response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = XMLHelper.Deserialize<PaymentService>(result);
                }
            }
            catch (WebException e)
            {
                LogException(e);
            }
            return response;
        }
        public static PaymentService SubmitTokenRequest()
        {
            string testUrl = ConfigurationManager.AppSettings["TestUrl"];
            PaymentService response = new PaymentService();
            string xmlData = string.Empty;

            try
            {

                var httpWebRequest = CreateHttpWebRequest(testUrl, "POST");
                // For POS devices : Get encrypted card details from POS devices and decrypt at BE
                // use CSE to encrypt ( javascript integration) at BE and send as part of token request ( use merchant token )
                //https://developer.worldpay.com/docs/wpg/tokenisation/createmerchanttokens

                // For website : Get encrypted card details from FE ( CSE will be handled at FE only)
                // Send this encrypted details as a part of token request ( use shopper token)
                //https://developer.worldpay.com/docs/wpg/tokenisation/createshoppertokens

                // TODO: Use CSE and objects and fill with values instead of xml file
                //https://developer.worldpay.com/docs/wpg/clientsideencryption/javascript-integration


                using (StreamReader r = new StreamReader("TokenRequest.xml"))
                {
                    xmlData = r.ReadToEnd();
                }

                //  Call API using POST
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(xmlData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                //  Output response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = XMLHelper.Deserialize<PaymentService>(result);
                }
            }
            catch (WebException e)
            {
                LogException(e);
            }
            return response;
        }
        private static HttpWebRequest CreateHttpWebRequest(string url, string method)
        {
            string username = ConfigurationManager.AppSettings["Username"];
            string password = ConfigurationManager.AppSettings["Password"];
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/xml";
            httpWebRequest.Accept = "application/xml";
            httpWebRequest.Method = method;
            httpWebRequest.Headers.Add("Authorization", "Basic " + svcCredentials);

            return httpWebRequest;
        }
        private static void LogException(WebException e)
        {
            if (!string.IsNullOrEmpty(e.Message))
            {
                // Print general errors 
                Console.WriteLine("Exception - ");
                Console.WriteLine(e.Message);
            }
            if (e.Response != null)
            {
                // Print Output response exception
                Stream receiveStream = e.Response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                // print the error received from Server 
                Console.WriteLine("Response error received - ");
                Console.WriteLine(readStream.ReadToEnd());
            }
        }
    }
}
