using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Domain.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ApiMto.Application
{
    public class AgenciaApplication : IAgenciaApplication
    {
        private readonly DataContext dc;
        private readonly IUnitOfWorkDomain uowd;

        public AgenciaApplication(DataContext dc, IUnitOfWorkDomain uowd)
        {
            this.dc = dc;
            this.uowd = uowd;
        }

        public async Task<IEnumerable<Agencia>> Get()
        {
            return await dc.Agencias.Include(x=> x.Cameras.Where(x=> x.Retired==false)).ThenInclude(x=>x.Brand).Include(x=> x.SrvAg.Where(x=> x.Server.Retired==false)).ThenInclude(x=> x.Server).ThenInclude(x=>x.Brand).ToListAsync();
        }
        public async Task<Agencia> FindById(int id)
        {
            var data = await dc.Agencias.Include(x=> x.Cameras).ThenInclude(c=> c.Brand).Include(b=> b.SrvAg).ThenInclude(e=>e.Server).ThenInclude(x=>x.Brand).FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                return data;
            }
            return null;
        }
        
        public async Task<ObjectResult> Add(Agencia agencia)
        {
           
                dc.Agencias.Add(agencia);
                await dc.SaveChangesAsync();
                return new ObjectResult(agencia);
          


        }
        public async Task<ObjectResult> Update(int id, Agencia agencia)
        {

            dc.Entry(agencia).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(agencia) { StatusCode = 200 };

        }
    }
}
