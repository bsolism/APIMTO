using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMto.Application
{
    public class ServerApplication : IServerApplication
    {
        private readonly DataContext dc;

        public ServerApplication(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Server>> Get()
        {
            return await dc.Servers.Include(x=> x.Brand).ToListAsync();
        }
        public async Task<Server> FindById(int id)
        {
            var pet = await dc.Servers.FirstOrDefaultAsync(x => x.Id == id);
            if (pet != null)
            {
                return pet;
            }
            return null;
        }
        public async Task<Server> FindBySerial(Server server)
        {
            var data = await dc.Servers.FirstOrDefaultAsync(x => x.SerialNumber == server.SerialNumber);
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<ObjectResult> Add(Server server)
        {
            var find = FindBySerial(server);
            if (find.Result == null)
            { 
                dc.Servers.Add(server);
                await dc.SaveChangesAsync();            
                return new ObjectResult(server);
            }
            return new ObjectResult("Server Already") { StatusCode = 500 };

        }
        public async Task<ObjectResult> Update(int id, Server server)
        {

            dc.Entry(server).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(server) { StatusCode = 200 };

        }
    }
}
