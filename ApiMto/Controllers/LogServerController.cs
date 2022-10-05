using ApiMto.Application.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Controllers
{
    public class LogServerController : BaseController
    {
        private readonly IUnitOfWork uow;

        public LogServerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<LogServer>> Get()
        {

            return uow.LogServerApplication.Get();
        }

        [HttpGet("{id}")]
        public Task<LogServer> GetById(int id)
        {
            var log = uow.LogServerApplication.FindById(id);
            return log;
        }
        [HttpGet("server/{id}")]
        public Task<IEnumerable<LogServer>> GetByServerId(string id)
        {
            var LogServer = uow.LogServerApplication.FindByServer(id);
            return LogServer;
        }
        [HttpPost]
        public async Task<IActionResult> Add(LogServer LogServer)
        {
            var data = await uow.LogServerApplication.Add(LogServer);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LogServer LogServer)
        {
            var user = await uow.LogServerApplication.Update(id, LogServer);
            if (user.StatusCode == 500)
            {
                return BadRequest(user.Value);

            }

            return Ok(user.Value);
        }
    }
}
