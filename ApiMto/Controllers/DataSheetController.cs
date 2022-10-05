

using ApiMto.Application.UnitOfWork;
using ApiMto.Dto;
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
        public async Task<IActionResult> GetById(string id)
        {
            var data = await uow.DataSheetApplication.FindById(id);
            if (data == null)
            {
                return BadRequest(data);
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddFile([FromForm] DataSheetDto dataSheetDto)
        {
            var data = await uow.DataSheetApplication.AddFile(dataSheetDto);
            if (data == null)
            {
                return BadRequest(data);
            }
            return Ok(data);
        }
    }
}
