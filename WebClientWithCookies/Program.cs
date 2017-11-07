using System;
using System.Net;

namespace WebClientWithCookies
{
    class Program
    {
        // Cookie-Merker:
        //private static string _cookies = string.Empty;

        static void Main(string[] args)
        {
            string url = "https://www.bestattungwien.at/eportal2/fhw/cal/submitCalender.do?&searchfield={datum}&progId=83491&datum=03.11.2017";

            // Web-Client
            using (WebClientWithCookies client = new WebClientWithCookies())
            {
                // 3x Aufruf der Post-Methode (client.DownloadString()):
                for (var i = 0; i < 3; i++)
                    Post(url, client);
            }

            Console.WriteLine("Hit <ENTER> to exit");
            Console.ReadLine();
        }

        private static void Post(string url, WebClientWithCookies client)
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            //client.Headers.Add("Cookie", _cookies);
            Console.WriteLine(client.DownloadString(uri));
        }

    }

    // Die Hilfsklasse für WebClientWithCookies.
    public class WebClientWithCookies : WebClient
    {
        private CookieContainer _container = new CookieContainer();

        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;

            if (request != null)
            {
                request.Method = "Post";
                request.CookieContainer = _container;
                request.ContentType = "application/x-www-form-urlencoded";
            }

            return request;
        }
    }
}
