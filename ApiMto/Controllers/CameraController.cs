using ApiMto.Application.UnitOfWork;
using ApiMto.Dto;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiMto.Controllers
{
    public class CameraController : BaseController
    {
        private readonly IUnitOfWork uow;

        public CameraController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<Camera>> Get()
        {

            return uow.CameraApplication.Get();
        }
        [HttpGet("only")]
        public Task<IEnumerable<Camera>> GetOnly()
        {

            return uow.CameraApplication.GetOnly();
        }

        [HttpGet("{id}")]
        public Task<Camera> GetById(int id)
        {
            var data = uow.CameraApplication.FindById(id);
            return data;
        }
        [HttpGet("channel/{id}/server/{serverId}")]
        public Task<Camera> GetByChannel(int id, int serverId)
        {
            var data = uow.CameraApplication.FindByChannel(id, serverId);
            return data;
        }
        [HttpPost("pdf")]
        public async Task<IActionResult> AddFile([FromForm] CameraDataSheetDto cameraDataSheetDto)
        {
            var data = await uow.CameraApplication.AddFile(cameraDataSheetDto);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Camera camera)
        {
            var data = await uow.CameraApplication.Add(camera);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpPost("deviceinfo")]
        [Produces("application/xml")]
        public async Task<IActionResult> CameraInfo(connected cred)
        {
            var uri="";
            if(cred.brand==1)
            {
                uri = "http://" + cred.IpAddress + "/ISAPI/System/deviceinfo";
            }
            if(cred.brand==2)
            {
                uri = "http://" + cred.IpAddress + "/cgi-bin/viewer/getparam.cgi?system";
            }
            
            var credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Digest", new NetworkCredential(cred.Name, cred.Password));
            HttpClient client = new HttpClient( new HttpClientHandler { Credentials= credCache });
            var response = await client.GetAsync(uri);
            return new ContentResult
            {
                ContentType = "application/xml",
                Content = await response.Content.ReadAsStringAsync(),
                StatusCode=200

            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Camera camera)
        {
            var user = await uow.CameraApplication.Update(id, camera);
            if (user.StatusCode == 500)
            {
                return BadRequest(user.Value);

            }

            return Ok(user.Value);
        }
    }
}
