using ApiMto.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
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
            if (response == null) return NotFound("No se estableció conexión");
                       
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(cred.Name, cred.Password));
                client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                response = await client.GetAsync(uri);
                if (response.ReasonPhrase.Equals("Unauthorized")) return new ContentResult { Content = "User / Password Incorrect", StatusCode = 401 };
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
        
        [HttpPost("hik/image")]
        public async Task<IActionResult> ImageHik(DataCamera cred)
        {
            var uri="";
            var auth = "";
           if (cred.brand == "Vivotek") {
                uri = "http://" + cred.IpAddress + "/cgi-bin/viewer/video.jpg";
                auth = "Basic";
            }
            if (cred.brand == "Hikvision") {
                uri = "http://" + cred.IpAddress + "/ISAPI/Streaming/channels/1/picture";
                auth = "Digest";
            }
            if (cred.brand == "Axis")
            {
                uri = "http://" + cred.IpAddress + "/axis-cgi/jpg/image.cgi";
                auth = "Digest";
            }
            if (cred.brand == "Hikvision" && cred.NicInterno=="NIC Interno")
            {
                uri = "rtsp://" + cred.IpAddress + ":554/streaming/channels/0102";
                auth = "Digest";
            }
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), auth, new NetworkCredential(cred.Name, cred.Password));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(cred.Name, cred.Password));
                client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                response = await client.GetAsync(uri);
            }
            byte[] content = await response.Content.ReadAsByteArrayAsync();
            return File(content, "image/jpeg");
            
            


            
            
           /* return new ContentResult
            {
                ContentType = "image/jpeg",
                Content =  response.ToString(),
                StatusCode = 200

            };*/



        }
    }
}
