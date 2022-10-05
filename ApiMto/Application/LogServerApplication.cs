using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Domain.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMto.Application
{
    public class LogServerApplication : ILogServerApplication
    {
        private readonly DataContext dc;
        private readonly IUnitOfWorkDomain uowd;

        public LogServerApplication(DataContext dc, IUnitOfWorkDomain uowd)
        {
            this.dc = dc;
            this.uowd = uowd;
        }

        public async Task<IEnumerable<LogServer>> Get()
        {
            return await dc.LogServers.Include(x => x.User).ToListAsync();
        }
        public async Task<IEnumerable<LogServer>> FindByServer(string id)
        {
            var data = await dc.LogServers.Include(x => x.User).Where(x => x.ServerId == id).ToListAsync();
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<LogServer> FindById(int id)
        {
            var data = await dc.LogServers.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<ObjectResult> Add(LogServer LogServer)
        {

            dc.LogServers.Add(LogServer);
            await dc.SaveChangesAsync();
            return new ObjectResult(LogServer);



        }
        public async Task<ObjectResult> Update(int id, LogServer LogServer)
        {

            dc.Entry(LogServer).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(LogServer) { StatusCode = 200 };

        }
    }
}
