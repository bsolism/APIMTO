using ApiMto.Application.Interfaces;
using ApiMto.Helper;
using ApiMto.Models;
using System.Net;

namespace ApiMto.Application
{
    public class VivotekApplication: IVivotekApplication
    {
        public VivotekApplication()
        {

        }
        public async Task<byte[]> GetImage(Camera camera)
        {
            var uri = "http://" + camera.IpAddress + "/cgi-bin/viewer/video.jpg";
            var credCache = new CredentialCache();
            var PassDecod = EncodingPass.DecryptPass(camera.Password).Split("|");
            credCache.Add(new Uri(uri), "digest", new NetworkCredential(camera.User, PassDecod[1]));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = new HttpResponseMessage();
            try
            {
                response = await client.GetAsync(uri);
                Console.WriteLine(response.StatusCode);
                //if (!response.IsSuccessStatusCode)
                //{
                //    credCache.Add(new Uri(uri), "Basic", new NetworkCredential(user, pass));
                //    client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                //    response = await client.GetAsync(uri);
                //}
            }
            catch 
            {
                return null!;
            }

            //var response = await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "basic", new NetworkCredential(camera.User, PassDecod[1]));
                client = new HttpClient(new HttpClientHandler { Credentials = credCache });
                response = await client.GetAsync(uri);
            }
            //if (!response.IsSuccessStatusCode)
            //{
            //    uri = "http://" + camera.IpAddress + "/ISAPI/Streaming/channels/101/picture";
            //    credCache.Add(new Uri(uri), "digest", new NetworkCredential(user, PassDecod[1]));
            //    client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            //    response = await client.GetAsync(uri);
            //}
            //if (!response.IsSuccessStatusCode)
            //{
            //    credCache.Add(new Uri(uri), "basic", new NetworkCredential(user, PassDecod[1]));
            //    client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            //    response = await client.GetAsync(uri);
            //}
            if (!response.IsSuccessStatusCode)
            {
                return null!;
            }
            byte[] content = await response.Content.ReadAsByteArrayAsync();
            return content;
        }
    }
}
