using ApiMto.Application.UnitOfWork;
using ApiMto.Dto;
using Microsoft.AspNetCore.Mvc;

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
    }
}
