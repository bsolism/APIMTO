using ApiMto.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiMto.Controllers
{
    public class DeviceInfoController : BaseController
    {
        public DeviceInfoController()
        {

        }
        [HttpPost("hikvision")]
        [Produces("application/xml")]
        public async Task<IActionResult> HikvisionInfo(connected cred)
        {
            var uri = "http://" + cred.IpAddress + "/ISAPI/System/deviceInfo";
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(cred.Name, cred.Password));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(cred.Name, cred.Password));
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
        [HttpPost("vivotek")]
        [Produces("application/text")]
        public async Task<IActionResult> VivotekInfo(connected cred)
        {
            var uri = "http://" + cred.IpAddress + "/cgi-bin/viewer/getparam.cgi?system_hostname&system_info";
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Basic", new NetworkCredential(cred.Name, cred.Password));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            return new ContentResult
            {
                ContentType = "application/text",
                Content = await response.Content.ReadAsStringAsync(),
                StatusCode = 200

            };
        }
    }
}
