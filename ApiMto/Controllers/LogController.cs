using ApiMto.Application.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Controllers
{
    public class LogController:BaseController
    {
        private readonly IUnitOfWork uow;

        public LogController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<Log>> Get()
        {

            return uow.LogApplication.Get();
        }

        [HttpGet("{id}")]
        public Task<Log> GetById(int id)
        {
            var log = uow.LogApplication.FindById(id);
            return log;
        }
        [HttpGet("device/{id}")]
        public Task<IEnumerable<Log>> GetByDeviceId(string id)
        {
            var Log = uow.LogApplication.FindByDevice(id);
            return Log;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Log Log)
        {
            var data = await uow.LogApplication.Add(Log);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Log Log)
        {
            var user = await uow.LogApplication.Update(id, Log);
            if (user.StatusCode == 500)
            {
                return BadRequest(user.Value);

            }

            return Ok(user.Value);
        }
    }
}
