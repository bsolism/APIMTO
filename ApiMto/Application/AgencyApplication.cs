using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Domain.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ApiMto.Application
{
    public class AgencyApplication : IAgencyApplication
    {
        private readonly DataContext dc;
        private readonly IUnitOfWorkDomain uowd;

        public AgencyApplication(DataContext dc, IUnitOfWorkDomain uowd)
        {
            this.dc = dc;
            this.uowd = uowd;
        }

        public async Task<IEnumerable<Agency>> Get()
        {
            return await dc.Agencies.Include(x=> x.Cameras.Where(x=> x.Retired==false)).ThenInclude(x=>x.Brand).Include(x=> x.SrvAg.Where(x=> x.Server.Retired==false)).ThenInclude(x=> x.Server).ThenInclude(x=>x.Brand).ToListAsync();
        }
        public async Task<Agency> FindById(string id)
        {
            var data = await dc.Agencies.Include(x=> x.Cameras).ThenInclude(c=> c.Brand).Include(b=> b.SrvAg).ThenInclude(e=>e.Server).ThenInclude(x=>x.Brand).FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                return data;
            }
            return null;
        }
        
        public async Task<ObjectResult> Add(Agency agency)
        {
            var code = agency.Id+"-"+(Get().Result.Count()+1).ToString("D"+4);            
            agency.Id = code;
            dc.Agencies.Add(agency);
            await dc.SaveChangesAsync();
            return new ObjectResult(agency);
        }
        public async Task<ObjectResult> Update(int id, Agency agency)
        {

            dc.Entry(agency).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(agency) { StatusCode = 200 };

        }
    }
}
