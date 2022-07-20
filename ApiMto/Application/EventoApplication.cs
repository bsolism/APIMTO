using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMto.Application
{
    public class EventoApplication: IEventoApplication
    {
        private readonly DataContext dc;

        public EventoApplication(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Evento>> Get()
        {
            return await dc.Eventos.Include(x=> x.Camera).ToListAsync();
        }
        public async Task<Evento> FindByCam(int id)
        {
            var data = await dc.Eventos.OrderByDescending(x=> x.Id).FirstOrDefaultAsync(x=> x.CameraId== id);
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<Evento> FindById(int id)
        {
            var data = await dc.Eventos.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<ObjectResult> Add(Evento evento)
        {

            dc.Eventos.Add(evento);
            await dc.SaveChangesAsync();
            return new ObjectResult(evento);

        }
        public async Task<ObjectResult> Delete(Evento evento)
        {
            dc.Eventos.Remove(evento);
            await dc.SaveChangesAsync();
            return new ObjectResult("successful") { StatusCode = 200 };
        }
    }
}
