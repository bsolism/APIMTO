using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Dto;
using ApiMto.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace ApiMto.Application
{
    public class ServerApplication : IServerApplication
    {
        private readonly DataContext dc;
        private readonly IMapper mapper;

        public ServerApplication(DataContext dc, IMapper mapper)
        {
            this.dc = dc;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<Server>> Get()
        {
            return await dc.Servers.Include(x => x.Cameras).Include(x => x.Brand).ToListAsync();
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
        public async Task<ObjectResult> Add(ServerDto serverDto)
        {
            var server = mapper.Map<Server>(serverDto);
           
            var find = FindBySerial(server);

            if (find.Result == null)
            { 
                dc.Servers.Add(server);
                await dc.SaveChangesAsync();
                var srvAg = new SrvAg
                {
                    AgenciaId = serverDto.agenciaId,
                    ServerId = server.Id
                };
                dc.SrvAgs.Add(srvAg);
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
