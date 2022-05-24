using ApiMto.Application.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Controllers
{
    public class AgenciaController : BaseController
    {
        private readonly IUnitOfWork uow;

        public AgenciaController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<Agencia>> Get()
        {

            return uow.AgenciaApplication.Get();
        }

        [HttpGet("{id}")]
        public Task<Agencia> GetById(int id)
        {
            var pet = uow.AgenciaApplication.FindById(id);
            return pet;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Agencia agencia)
        {
            var data = await uow.AgenciaApplication.Add(agencia);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Agencia agencia)
        {
            var user = await uow.AgenciaApplication.Update(id, agencia);
            if (user.StatusCode == 500)
            {
                return BadRequest(user.Value);

            }

            return Ok(user.Value);
        }
    }
}
