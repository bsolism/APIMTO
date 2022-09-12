using ApiMto.Helper;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiMto.Controllers
{
    public class GeovisionController : BaseController
    {
        public GeovisionController()
        {

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
    }
}
