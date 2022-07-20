using ApiMto.Application.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Controllers
{
    public class EventoController : BaseController
    {
        private readonly IUnitOfWork uow;

        public EventoController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpGet]
        public Task<IEnumerable<Evento>> Get()
        {

            return uow.EventoApplication.Get();        }

        [HttpGet("{id}")]
        public Task<Evento> GetById(int id)
        {
            var data = uow.EventoApplication.FindById(id);
            return data;
        }
        [HttpGet("camera/{id}")]
        public Task<Evento> GetByCameraId(int id)
        {
            var data = uow.EventoApplication.FindByCam(id);
            return data;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Evento evento)
        {
            var data = await uow.EventoApplication.Add(evento);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await uow.EventoApplication.FindById(id);

            if (item != null)
            {
               var data = await uow.EventoApplication.Delete(item);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
            }
            return BadRequest("Error");

        }
        [HttpDelete("camera/{id}")]
        public async Task<IActionResult> DeleteByCameraId(int id)
        {
            var item = await uow.EventoApplication.FindByCam(id);

            if (item != null)
            {
                var data = await uow.EventoApplication.Delete(item);
                if (data.StatusCode == 500)
                {
                    return BadRequest(data.Value);
                }
                return Ok(data.Value);
            }
            return BadRequest("Error");

        }
    }
}
