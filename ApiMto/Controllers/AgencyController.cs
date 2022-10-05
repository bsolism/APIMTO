using ApiMto.Application.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Controllers
{
    public class AgencyController : BaseController
    {
        private readonly IUnitOfWork uow;

        public AgencyController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<Agency>> Get()
        {

            return uow.AgencyApplication.Get();
        }

        [HttpGet("{id}")]
        public Task<Agency> GetById(string id)
        {
            var pet = uow.AgencyApplication.FindById(id);
            return pet;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Agency agency)
        {
            var data = await uow.AgencyApplication.Add(agency);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Agency agency)
        {
            var user = await uow.AgencyApplication.Update(id, agency);
            if (user.StatusCode == 500)
            {
                return BadRequest(user.Value);

            }

            return Ok(user.Value);
        }
    }
}
