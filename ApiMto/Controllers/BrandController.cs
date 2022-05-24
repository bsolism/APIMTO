using ApiMto.Application.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IUnitOfWork uow;

        public BrandController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<Brand>> Get()
        {

            return uow.BrandApplication.Get();
        }

        [HttpGet("{id}")]
        public Task<Brand> GetById(int id)
        {
            var pet = uow.BrandApplication.FindById(id);
            return pet;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Brand Brand)
        {
            var data = await uow.BrandApplication.Add(Brand);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Brand Brand)
        {
            var user = await uow.BrandApplication.Update(id, Brand);
            if (user.StatusCode == 500)
            {
                return BadRequest(user.Value);

            }

            return Ok(user.Value);
        }
    }
}
