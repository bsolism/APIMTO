using ApiMto.Application.UnitOfWork;
using ApiMto.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace ApiMto.Controllers
{
    public class HikvisionController : BaseController
    {
        private readonly IUnitOfWork uow;

        public HikvisionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpPost("capabilities")]
        [Produces("application/xml")]
        public async Task<IActionResult> HikvisionCapabilities(Credentials credential)
        {
            var uri = "http://" + credential.IpAddress + "/ISAPI/Streaming/channels/101";
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(credential.Name, credential.Password));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            if (response == null) return NotFound("No se estableció conexión");

            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(credential.Name, credential.Password));
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
        [HttpPost("time")]
        [Produces("application/xml")]
        public async Task<IActionResult> HikvisionInfo(Credentials credential)
        {
            var uri = "http://" + credential.IpAddress + "/ISAPI/System/time";
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(credential.Name, credential.Password));
            HttpClient client = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var response = await client.GetAsync(uri);
            if (response == null) return NotFound("No se estableció conexión");
            if (response.ReasonPhrase.Equals("Unauthorized")) return new ContentResult { Content = "User / Password Incorrect", StatusCode = 401 };
            if (!response.IsSuccessStatusCode)
            {
                credCache.Add(new Uri(uri), "Basic", new NetworkCredential(credential.Name, credential.Password));
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
        [HttpPut("time")]
        [Produces("application/xml")]
        public async Task<IActionResult> updateTime(updateTime time)
        {
            string xml= "<?xml version='1.0' encoding='UTF - 8' ?>" +
                "<Time version='1.0' xmlns='http://www.isapi.org/ver20/XMLSchema'>" +
                "<timeMode>manual</timeMode>" +
                "<localTime>"+time.dateTime+"</localTime>" +
                " <timeZone>CST+6:00:00</timeZone>" +
                "</Time>";
            XDocument xd = XDocument.Parse(xml);
            HttpContent content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml");
            return await  uow.DeviceApplication.Put(time.IpAddress, time.Name, time.Password, content);       
          
            
        }
        [HttpPut("mic")]
        [Produces("application/xml")]
        public async Task<IActionResult> updateMic(Mic mic)
        {
            string xml = "<?xml version='1.0' encoding='UTF - 8' ?>" +
                "<StreamingChannel version='2.0' xmlns='http://www.isapi.org/ver20/XMLSchema'>" +
            "<Audio>" +
                "<enabled>" + mic.mic + "</enabled>" +
                " <audioInputChannelID>1</audioInputChannelID>" +
                "<audioCompressionType>G.711ulaw</audioCompressionType>"+
                "</Audio>"+
                "</StreamingChannel>";
            XDocument xd = XDocument.Parse(xml);
            HttpContent content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml");
            return await uow.DeviceApplication.PutMic(mic.IpAddress, mic.Name, mic.Password, content);


        }
    }
}
