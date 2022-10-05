using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Domain.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMto.Application
{
    public class LogApplication : ILogApplication
    {
        private readonly DataContext dc;
        private readonly IUnitOfWorkDomain uowd;

        public LogApplication(DataContext dc, IUnitOfWorkDomain uowd)
        {
            this.dc = dc;
            this.uowd = uowd;
        }

        public async Task<IEnumerable<Log>> Get()
        {
            return await dc.Logs.Include(x=> x.User).ToListAsync();
        }
        public async Task<IEnumerable<Log>> FindByDevice(string id)
        {
            var data = await dc.Logs.Include(x=> x.User).Where(x=> x.DeviceId==id).ToListAsync();
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<Log> FindById(int id)
        {
            var data = await dc.Logs.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<Log> FindByCameraId(string id)
        {
            var data = await dc.Logs.OrderByDescending(x=> x.Id).FirstOrDefaultAsync(x=> x.DeviceId== id && x.logType=="System");
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<ObjectResult> Add(Log Log)
        {

            dc.Logs.Add(Log);
            await dc.SaveChangesAsync();
            return new ObjectResult(Log);



        }
        public async Task<ObjectResult> Update(int id, Log Log)
        {

            dc.Entry(Log).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(Log) { StatusCode = 200 };

        }
    }
}
