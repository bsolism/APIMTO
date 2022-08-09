using ApiMto.Application.UnitOfWork;
using ApiMto.Dto;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiMto.Controllers
{
    public class VivotekController : BaseController
    {
        private readonly IUnitOfWork uow;

        public VivotekController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpPost("checkvideo")]
        [Produces("application/text")]
        public async Task<IActionResult> VivotekCheckVideo(Credentials cred)
        {
            var uri = "http://" + cred.IpAddress + "/cgi-bin/viewer/getparam.cgi?capability_videoin_resolution";
            var response = await uow.DeviceApplication.GetDevice(uri, cred.Name, cred.Password);
            if (response == null) return NotFound("No se estableció conexión");
            return response;
        }
        [HttpPost("image")]
        public async Task<IActionResult> Image(Camera cred)
        {
            var uri = "http://" + cred.IpAddress + "/cgi-bin/viewer/video.jpg";
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "digest", new NetworkCredential(cred.User, cred.Password));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(cred.User, cred.Password));
                client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                response = await client.GetAsync(uri);
            }
            byte[] content = await response.Content.ReadAsByteArrayAsync();
            return File(content, "image/jpeg");
        }
        [HttpPost("info")]
        [Produces("application/text")]
        public async Task<IActionResult> VivotekInfo(connected cred)
        {
            var uri = "http://" + cred.IpAddress + "/cgi-bin/viewer/getparam.cgi?system_hostname&system_info";
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
            if (!response.IsSuccessStatusCode) return new ContentResult { Content = "Unauthorized", StatusCode = 401 };
            return new ContentResult
            {
                ContentType = "application/text",
                Content = await response.Content.ReadAsStringAsync(),
                StatusCode = 200

            };
        }
    }
}
