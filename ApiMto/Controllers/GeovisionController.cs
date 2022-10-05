using ApiMto.Application.UnitOfWork;
using ApiMto.Dto;
using ApiMto.Helper;
using ApiMto.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace ApiMto.Controllers
{
    public class GeovisionController : BaseController
    {
        private readonly IUnitOfWork uow;

        public GeovisionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpPost("image")]
        public async Task<IActionResult> ImageHik(Camera camera)
        {
            var PassDecod = EncodingPass.DecryptPass(camera.Password).Split("|");
            var uri = "http://" + camera.IpAddress + "/PictureCatch.cgi?username="+camera.User+"&password="+PassDecod[1]+"&channel=1";
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "digest", new NetworkCredential(camera.User, PassDecod[1]));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(camera.User, PassDecod[1]));
                client = new HttpClient();
                response = await client.GetAsync(uri);
            }
            byte[] content = await response.Content.ReadAsByteArrayAsync();

            return File(content, "image/jpeg");
        }
        [HttpPost("infoName")]
        public async Task<IActionResult> infoName(connected cred)
        {
            var uri = "http://" + cred.IpAddress + "/ssi.cgi/VideoSetting.htm?cam=1";
            //var PassDecod = EncodingPass.DecryptPass(cred.Password).Split("|");
            var response = await uow.DeviceApplication.GetDevice(uri, cred.Name, cred.Password);
            if (response == null) return NotFound("No se estableció conexión");
            var pageContent = response.Content;
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(pageContent);
            var name = "";
            var firm = "";
            var nodes = html.DocumentNode.SelectSingleNode("//form");
            Console.WriteLine(nodes.OuterHtml);
            foreach (var node in nodes.SelectNodes(".//table/tbody/tr/td"))
            {
                var nod = node.SelectSingleNode(".//input");
                if (nod != null)
                {
                    if (nod.Attributes["name"].Value == "szCamName")
                    {
                        name = nod.Attributes["value"].Value;
                    }
                }
            }
            string result = JsonSerializer.Serialize(new { name = name });
            return Ok(result);

        }
    }
}
