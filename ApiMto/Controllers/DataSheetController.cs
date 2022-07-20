

using ApiMto.Application.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Controllers
{
    public class DataSheetController : BaseController
    {
        private readonly IUnitOfWork uow;

        public DataSheetController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await uow.DataSheetApplication.FindByServerId(id);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
    }
}
