using ApiMto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;

namespace ApiMto.Application
{
    public class DeviceApplication : IDeviceApplication
    {
        public DeviceApplication()
        {

        }
        public async Task<IActionResult> GetDevice(string uri, string user, string pass)
        {
           
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(user, pass));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(user, pass));
                client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                response = await client.GetAsync(uri);
            }
            if (response.ReasonPhrase.Equals("Unauthorized")) return new ContentResult { Content = "User / Password Incorrect", StatusCode = 401 };
            return new ContentResult
            {
                ContentType = "application/xml",
                Content = await response.Content.ReadAsStringAsync(),
                StatusCode = 200

            };
        }
        public async Task<ObjectResult> Get(string IP, string user, string pass)
        {
            var uri = "http://" +IP + "/ISAPI/System/time";
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(user, pass));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            return new ObjectResult(response) { StatusCode =200};
        }
        public async Task<IActionResult> Put(string IP, string user, string pass, HttpContent content)
        {
            var uri = "http://" + IP + "/ISAPI/System/time";
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(user, pass));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.PutAsync(uri,content);
            return new ContentResult
            {
                ContentType = "application/xml",
                Content = await response.Content.ReadAsStringAsync(),
                StatusCode = 200

            };
        }
        public async Task<IActionResult> PutMic(string IP, string user, string pass, HttpContent content)
        {
            var uri = "http://" + IP + "/ISAPI/Streaming/channels/101";
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(user, pass));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.PutAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(user, pass));
                client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                response = await client.GetAsync(uri);
            }
            return new ContentResult
            {
                ContentType = "application/xml",
                Content = await response.Content.ReadAsStringAsync(),
                StatusCode = 200

            };
        }
        public async Task<IActionResult> Update(string uri, string user, string pass, HttpContent content)
        {
           
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(user, pass));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.PutAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(user, pass));
                client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                response = await client.GetAsync(uri);
            }
            return new ContentResult
            {
                ContentType = "application/xml",
                Content = await response.Content.ReadAsStringAsync(),
                StatusCode = 200

            };
        }
    }
}
