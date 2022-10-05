using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMto.Application
{
    public class IncidentApplication: IIncidentApplication
    {
        private readonly DataContext dc;

        public IncidentApplication(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Incident>> Get()
        {
            return await dc.Incidents.Include(x=> x.Camera).ThenInclude(x=> x.Server).ToListAsync();
        }
        public async Task<Incident> FindByCam(string id)
        {
            var data = await dc.Incidents.OrderByDescending(x=> x.Id).FirstOrDefaultAsync(x=> x.CameraId== id);
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<Incident> FindById(int id)
        {
            var data = await dc.Incidents.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<ObjectResult> Add(Incident evento)
        {

            dc.Incidents.Add(evento);
            await dc.SaveChangesAsync();
            return new ObjectResult(evento);

        }
        public async Task<ObjectResult> Delete(Incident evento)
        {
            dc.Incidents.Remove(evento);
            await dc.SaveChangesAsync();
            return new ObjectResult("successful") { StatusCode = 200 };
        }
    }
}
