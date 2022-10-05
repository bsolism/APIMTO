using ApiMto.Application.UnitOfWork;
using ApiMto.Domain.UnitOfWork;
using ApiMto.Dto;
using ApiMto.Helper;
using ApiMto.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ApiMto.Controllers
{
    public class PanasonicController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IUnitOfWorkDomain unitOf;

        public PanasonicController(IUnitOfWork uow, IUnitOfWorkDomain unitOf)
        {
            this.uow = uow;
            this.unitOf = unitOf;
        }
        [HttpPost("info")]
        public async Task<IActionResult> PanModel(connected cred)
        {
            var uri = "http://" + cred.IpAddress + "/Top?Language=11";
            Camera cam = new Camera();
            var PassDecod = EncodingPass.DecryptPass(cred.Password).Split("|");
            var pass = PassDecod[1];
            var response = await uow.DeviceApplication.GetDevice(uri, cred.Name, pass);
            if (response == null) return NotFound("No se estableció conexión");
            if (response.StatusCode == 200)
            {
                var result =  unitOf.PanasonicDomain.InfoDeviceTwo(response,1, cam);
                if (result == null) return NotFound("Error");
                uri = "http://" + cred.IpAddress + "/CgiTopViewImage?Language=11";
                response = await uow.DeviceApplication.GetDevice(uri, cred.Name, pass);
                result = unitOf.PanasonicDomain.InfoDeviceTwo(response,2, result);
                uri = "http://" + cred.IpAddress + "/CgiNetworkStatus?Language=11";
                response = await uow.DeviceApplication.GetDevice(uri, cred.Name, pass);
                result = unitOf.PanasonicDomain.InfoDeviceTwo(response, 3, result);
                return Ok(result);

            }
            if (response.StatusCode == 401)
            {
                uri = "http://" + cred.IpAddress + "/cgi-bin/set_basic?Language=11";
                response = await uow.DeviceApplication.GetDevice(uri, cred.Name, pass);
                if (response.StatusCode == 401) return NotFound(response.Content);
                var result =  unitOf.PanasonicDomain.InfoDeviceOne(response);
                if (result == null) return NotFound("Error");
                return Ok(result);

            }
            return Ok(cred);

        }
        
    }

}
