using ApiMto.Application.UnitOfWork;
using ApiMto.Dto;
using ApiMto.Helper;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

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
            var PassDecod = EncodingPass.DecryptPass(cred.Password).Split("|");
            credCache.Add(new Uri(uri), "digest", new NetworkCredential(cred.User, PassDecod[1]));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(cred.User, PassDecod[1]));
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
            //var credCache = new CredentialCache();
            var PassDecod = EncodingPass.DecryptPass(cred.Password).Split("|");
            var response = await uow.DeviceApplication.GetDevice(uri, cred.Name, PassDecod[1]);
            if (response == null) return NotFound("No se estableció conexión");
            //var result = JsonSerializer.Serialize(new { response.Content });
            //return Ok(result);
            return response;

            //credCache.Add(new Uri(uri), "Digest", new NetworkCredential(cred.Name, PassDecod[1]));
            //HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            //var response = await client.GetAsync(uri);
            //if (!response.IsSuccessStatusCode)
            //{
            //    credCache.Add(new Uri(uri), "Basic", new NetworkCredential(cred.Name, PassDecod[1]));
            //    client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            //    response = await client.GetAsync(uri);
            //}
            //if (!response.IsSuccessStatusCode) return new ContentResult { Content = "Unauthorized", StatusCode = 401 };

        }
        [HttpPost("setName")]
        public async Task<IActionResult> VivotekSetName(Camera cam)
        {
            var nameCamera = cam.Name.Replace(' ', '+');
            var uri = "http://" + cam.IpAddress + "/cgi-bin/admin/setparam.cgi?system_hostname="+nameCamera;
            var credCache = new CredentialCache();
            var PassDecod = EncodingPass.DecryptPass(cam.Password).Split("|");
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(cam.User, PassDecod[1]));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(cam.User, PassDecod[1]));
                client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                response = await client.GetAsync(uri);
            }
            if (!response.IsSuccessStatusCode) return new ContentResult { Content = "Unauthorized", StatusCode = 401 };
            return new ContentResult
            {
                Content = "Success",
                StatusCode = 200
            };
        }
        [HttpPost("setNameOSD")]
        public async Task<IActionResult> VivotekSetNameOSD(Camera cam)
        {
            var uri = "http://" + cam.IpAddress + "/cgi-bin/admin/setparam.cgi";
            var param = new Dictionary<string, string>();
            param.Add("videoin_c0_text", cam.Name);
            param.Add("videoin_c0_imprinttimestamp", "1");

            HttpContent content = new FormUrlEncodedContent(param);
            var PassDecod = EncodingPass.DecryptPass(cam.Password).Split("|");
            return await uow.DeviceApplication.PostDevice(uri, cam.User, PassDecod[1], content);
            
        }
    }
}
