using ApiMto.Application.UnitOfWork;
using ApiMto.Dto;
using ApiMto.Helper;
using ApiMto.Models;
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
        //[HttpGet("server/pdf/{id}")]
        //public async Task<IActionResult> GetPdfSrvId(string id)
        //{
        //    var data = await uow.DataSheetApplication.FindById(id);
        //    if (data.StatusCode == 500)
        //    {
        //        return BadRequest(data.Value);
        //    }
        //    return Ok(data.Value);
        //}
        //[HttpGet("camera/pdf/{id}")]
        //public async Task<IActionResult> GetPdfCamId(string id)
        //{
        //    var data = await uow.DataSheetApplication.FindByCameraId(id);
        //    if (data.StatusCode == 500)
        //    {
        //        return BadRequest(data.Value);
        //    }
        //    return Ok(data.Value);
        //}
        [HttpPost("info")]
        [Produces("application/xml")]
        public async Task<IActionResult> HikvisionInfo(Credentials credential)
        {
            var uri = "http://" + credential.IpAddress + "/ISAPI/System/deviceInfo";
            var PassDecod = EncodingPass.DecryptPass(credential.Password).Split("|");
            var response = await uow.DeviceApplication.GetDevice(uri, credential.Name, PassDecod[1]);
            if (response == null) return NotFound("No se estableció conexión");
            return response;
           
        }
        [HttpPost("capabilities")]
        [Produces("application/xml")]
        public async Task<IActionResult> HikvisionCapabilities(Camera camera)
        {
            var uri = "http://" + camera.IpAddress + "/ISAPI/Streaming/channels/101";
            var PassDecod = EncodingPass.DecryptPass(camera.Password).Split("|");
            var response = await uow.DeviceApplication.GetDevice(uri, camera.User, PassDecod[1]);
            if (response == null) return NotFound("No se estableció conexión");
            return response;
        }
        [HttpPost("playback")]
        public async Task<IActionResult> HikvisionPlayback(Credentials credential)
        {
            
            var response = await uow.DeviceApplication.GetPlayBack(credential.IpAddress, credential.Name, credential.Password);
            if (response == null) return NotFound("No se estableció conexión");
            return Ok(response);
        }
        [HttpPost("time")]
        [Produces("application/xml")]
        public async Task<IActionResult> HikvisionTime(Credentials credential)
        {
            Console.WriteLine(credential.Password);
            var uri = "http://" + credential.IpAddress + "/ISAPI/System/time";
            var PassDecod = EncodingPass.DecryptPass(credential.Password).Split("|");
            Console.WriteLine(credential.Name);
            Console.WriteLine(PassDecod[1]);
            Console.WriteLine(uri);
            var response = await uow.DeviceApplication.GetDevice(uri, credential.Name, PassDecod[1]);
            if (response == null) return NotFound("No se estableció conexión");
            return response;

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
            var PassDecod = EncodingPass.DecryptPass(time.Password).Split("|");
            return await  uow.DeviceApplication.Put(time.IpAddress, time.Name, PassDecod[1], content);       
          
            
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
            var PassDecod = EncodingPass.DecryptPass(mic.Password).Split("|");
            return await uow.DeviceApplication.PutMic(mic.IpAddress, mic.Name, PassDecod[1], content);


        }
        [HttpPut("info")]
        [Produces("application/xml")]
        public async Task<IActionResult> updateInfo(InfoNameDto info)
        {
            string xml = "<?xml version='1.0' encoding='UTF - 8' ?>" +
                "<DeviceInfo version='1.0' xmlns='http://www.isapi.org/ver20/XMLSchema'>" +
            "<deviceName>"+info.NameDevice+"</deviceName> " +
                "</DeviceInfo>" ;
            var uri = "http://" + info.IpAddress + "/ISAPI/System/deviceInfo";
            XDocument xd = XDocument.Parse(xml);
            HttpContent content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml");
            var PassDecod = EncodingPass.DecryptPass(info.Password).Split("|");
            return await uow.DeviceApplication.Update(uri, info.Name, PassDecod[1], content);


        }
        [HttpPut("infoOsd")]
        [Produces("application/xml")]
        public async Task<IActionResult> updateInfoOSD(Camera cam)
        {
            var channel = (cam.Type == "Analoga") ? cam.PortChannel : 1;
            string xml = "<?xml version='1.0' encoding='UTF-8' ?>" +
                "<VideoInputChannel version='2.0' xmlns='http://www.hikvision.com/ver20/XMLSchema'>" +
                "<id>"+channel+"</id> " +
                "<inputPort>"+channel+"</inputPort>" +
                "<videoInputEnabled>true</videoInputEnabled>"+
                "<name>" +cam.Name+"</name>"+
                "</VideoInputChannel>";
            var uri = "http://" + cam.IpAddress + "/ISAPI/System/Video/inputs/channels/"+channel;
            //XDocument xd = XDocument.Parse(xml);
            HttpContent content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml");
            var PassDecod = EncodingPass.DecryptPass(cam.Password).Split("|");
            return await uow.DeviceApplication.Update(uri, cam.User, PassDecod[1], content);


        }
        [HttpPost("channels")]
        [Produces("application/xml")]
        public async Task<IActionResult> HikvisionStatusChannel(Credentials credential)
        {
            var uri = "http://" + credential.IpAddress + "/ISAPI/ContentMgmt/InputProxy/channels/status";
            var PassDecod = EncodingPass.DecryptPass(credential.Password).Split("|");
            var response = await uow.DeviceApplication.GetDevice(uri, credential.Name, PassDecod[1]);
            if (response == null) return NotFound("No se estableció conexión");           
            return  response;
        }
        [HttpPost("channels/dvr")]
        [Produces("application/xml")]
        public async Task<IActionResult> HikvisionStatusChannelDvr(Credentials credential)
        {
            var uri = "http://" + credential.IpAddress + "/ISAPI/System/Video/inputs/channels";
            var PassDecod = EncodingPass.DecryptPass(credential.Password).Split("|");
            var response = await uow.DeviceApplication.GetDevice(uri, credential.Name, PassDecod[1]);
            if (response == null) return NotFound("No se estableció conexión");
            return response;
        }
        [HttpPost("image")]
        public async Task<IActionResult> ImageHik(Camera camera)
        {
            var uri = "";
            var user="";
            var pass="";
            if (camera.Server != null)
            {
                uri = "http://" + camera.Server.IpAddress + "/ISAPI/Streaming/channels/" + camera.PortChannel + "01/picture";
                user = camera.Server.User;
                pass = camera.Server.Password;
            }
            else
            {
                uri = "http://" + camera.IpAddress + "/ISAPI/Streaming/channels/101/picture";
                user= camera.User;
                pass = camera.Password;

            }
            var credCache = new CredentialCache();
            var PassDecod = EncodingPass.DecryptPass(pass).Split("|");
            Console.WriteLine(uri+" "+user+" "+ PassDecod[1]);
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
                return BadRequest(response.ReasonPhrase);
            }
            byte[] content = await response.Content.ReadAsByteArrayAsync();
            return File(content, "image/jpeg");
        }
    }
}
