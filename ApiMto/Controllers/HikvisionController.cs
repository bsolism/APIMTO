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
            var response = await uow.DeviceApplication.GetDevice(uri, credential.Name, credential.Password);
            if (response == null) return NotFound("No se estableció conexión");
            return response;
        }
        [HttpPost("time")]
        [Produces("application/xml")]
        public async Task<IActionResult> HikvisionInfo(Credentials credential)
        {
            var uri = "http://" + credential.IpAddress + "/ISAPI/System/time";
            var response = await uow.DeviceApplication.GetDevice(uri, credential.Name, credential.Password);
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
            return await uow.DeviceApplication.Update(uri, info.Name, info.Password, content);


        }
        [HttpPost("channels")]
        [Produces("application/xml")]
        public async Task<IActionResult> HikvisionStatusChannel(Credentials credential)
        {
            var uri = "http://" + credential.IpAddress + "/ISAPI/ContentMgmt/InputProxy/channels/status";

            var response = await uow.DeviceApplication.GetDevice(uri, credential.Name, credential.Password);
            if (response == null) return NotFound("No se estableció conexión");           
            return  response;
        }
        [HttpPost("channels/dvr")]
        [Produces("application/xml")]
        public async Task<IActionResult> HikvisionStatusChannelDvr(Credentials credential)
        {
            var uri = "http://" + credential.IpAddress + "/ISAPI/System/Video/inputs/channels";

            var response = await uow.DeviceApplication.GetDevice(uri, credential.Name, credential.Password);
            if (response == null) return NotFound("No se estableció conexión");
            return response;
        }
    }
}
