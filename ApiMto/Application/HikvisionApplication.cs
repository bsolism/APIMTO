using ApiMto.Application.Interfaces;
using ApiMto.Helper;
using ApiMto.Models;
using System.Net;
using System.Web.Mvc;

namespace ApiMto.Application
{
    public class HikvisionApplication : IHikvisionApplication
    {
        public HikvisionApplication()
        {

        }
        public async Task<byte[]> GetImage(Camera camera)
        {
            var uri = "";
            var user = "";
            var pass = "";
            if (camera.Server != null)
            {
                uri = "http://" + camera.Server.IpAddress + "/ISAPI/Streaming/channels/" + camera.PortChannel + "01/picture";
                user = camera.Server.User;
                pass = camera.Server.Password;
            }
            else
            {
                uri = "http://" + camera.IpAddress + "/ISAPI/Streaming/channels/101/picture";
                user = camera.User;
                pass = camera.Password;

            }
            var credCache = new CredentialCache();
            var PassDecod = EncodingPass.DecryptPass(pass).Split("|");
            credCache.Add(new Uri(uri), "digest", new NetworkCredential(user, PassDecod[1]));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "basic", new NetworkCredential(user, PassDecod[1]));
                client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                response = await client.GetAsync(uri);
            }
            if (!response.IsSuccessStatusCode)
            {
                uri = "http://" + camera.IpAddress + "/ISAPI/Streaming/channels/101/picture";
                credCache.Add(new Uri(uri), "digest", new NetworkCredential(user, PassDecod[1]));
                client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                response = await client.GetAsync(uri);
            }
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "basic", new NetworkCredential(user, PassDecod[1]));
                client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                response = await client.GetAsync(uri);
            }
            if (!response.IsSuccessStatusCode)
            {
                return null!;
            }
            byte[] content = await response.Content.ReadAsByteArrayAsync();
            return content;
        }
    }
}
