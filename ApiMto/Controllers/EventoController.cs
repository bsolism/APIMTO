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
        public Task<IEnumerable<Incident>> Get()
        {

            return uow.IncidentApplication.Get();        }

        [HttpGet("{id}")]
        public Task<Incident> GetById(int id)
        {
            var data = uow.IncidentApplication.FindById(id);
            return data;
        }
        [HttpGet("camera/{id}")]
        public Task<Incident> GetByCameraId(string id)
        {
            var data = uow.IncidentApplication.FindByCam(id);
            return data;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Incident evento)
        {
            var data = await uow.IncidentApplication.Add(evento);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await uow.IncidentApplication.FindById(id);

            if (item != null)
            {
               var data = await uow.IncidentApplication.Delete(item);
            if (data.StatusCode == 500)
            {
                return BadRequest(data.Value);
            }
            return Ok(data.Value);
            }
            return BadRequest("Error");

        }
        [HttpDelete("camera/{id}")]
        public async Task<IActionResult> DeleteByCameraId(string id)
        {
            var item = await uow.IncidentApplication.FindByCam(id);

            if (item != null)
            {
                var data = await uow.IncidentApplication.Delete(item);
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
