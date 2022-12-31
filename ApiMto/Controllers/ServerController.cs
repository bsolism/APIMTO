using ApiMto.Application.UnitOfWork;
using ApiMto.Dto;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiMto.Controllers
{
    public class ServerController : BaseController
    {
        private readonly IUnitOfWork uow;

        public ServerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<Server>> Get()
        {

            return uow.ServerApplication.Get();
        }

        [HttpGet("{id}")]
        public Task<Server> GetById(string id)
        {
            var pet = uow.ServerApplication.FindById(id);
            return pet;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Server server)
        {
            var data = await uow.ServerApplication.Add(server);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpPost("file")]
        public async Task<IActionResult> AddFile([FromForm] DataSheetDto dataSheetDto)
        {
            var data = await uow.ServerApplication.AddFile(dataSheetDto);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Server server)
        {
            var user = await uow.ServerApplication.Update(id, server);
            if (user.StatusCode == 500)
            {
                return BadRequest(user.Value);

            }

            return Ok(user.Value);
        }
    }
}
