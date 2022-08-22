using ApiMto.Context;
using ApiMto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ApiMto.Domain.Domain
{
    public class DeviceDomain : IDeviceDomain
    {
        private readonly DataContext dc;

        public DeviceDomain(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<HttpResponseMessage> conDevice(string uri, string user, string pass)
        {
            var response = new HttpResponseMessage();
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(user, pass));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            try
            {
                response = await client.GetAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    credCache.Add(new Uri(uri), "Basic", new NetworkCredential(user, pass));
                    client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                    response = await client.GetAsync(uri);
                }
            }
            catch (Exception ex)
            {
                response = null;
            }
            return response;
        }
        public async Task<HttpResponseMessage> PostDevice(string uri, string user, string pass, HttpContent content)
        {
            var response = new HttpResponseMessage();
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(user, pass));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            try
            {
                response = await client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    credCache.Add(new Uri(uri), "Basic", new NetworkCredential(user, pass));
                    client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                    response = await client.PostAsync(uri, content);
                }
            }
            catch (Exception ex)
            {
                response = null;
            }
            return response;
        }
        public async Task<int> DayPlayback(string uri, string user, string pass)
        {
            var moment = DateTime.Now;
            int month = (moment.Month - 2);
            int currenMonth = (moment.Month);
            int year = moment.Year;
            int dayPlayback = 0;
            for (int i = 0; i < 3; i++)
            {
                monthYear(currenMonth, year, month, i);
                string xml = xmlData(year, month);
                XDocument xd = XDocument.Parse(xml);
                HttpContent content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml");
                var response = await PostDevice(uri, user, pass, content);
                if (response == null) return 0;
                var contentResult = new ContentResult
                {
                    ContentType = "application/xml",
                    Content = await response.Content.ReadAsStringAsync(),
                    StatusCode = 200
                };
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(contentResult.Content);
                XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("day");
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    foreach (XmlNode item in xmlNode)
                    {

                        if (item.Name.Equals("record") && item.InnerText.Equals("true"))
                        {
                            dayPlayback++;
                        }
                    }

                }
                month++;
            }

            return dayPlayback;
        }
        private void monthYear(int currenMonth, int year, int month, int i)
        {
            if (currenMonth == 1 && i < 2)
            {
                year = year - 1;
                month = 11 + i;

            }
            else
               if (currenMonth == 1 && i == 2)
            {
                year = year + 1;
                month = currenMonth;

            }
            else
               if (currenMonth == 2 && i == 0)
            {
                year = year - 1;
                month = 12;

            }
            else
               if (currenMonth == 2 && i > 0)
            {
                year = year + 1;
                month = i;

            }

        }
        private string xmlData(int year, int month)
        {
            return "<?xml version='1.0' encoding='UTF - 8' ?>" +
                "<trackDailyParam>" +
                "<year>" + year + "</year>" +
                "<monthOfYear>" + month + "</monthOfYear>" +
                "</trackDailyParam>";
        }
    }
}
