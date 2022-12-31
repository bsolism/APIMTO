using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Domain.UnitOfWork;
using ApiMto.Dto;
using ApiMto.Helper;
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
        private readonly IUnitOfWorkDomain unitOf;

        public ServerApplication(DataContext dc, IMapper mapper, IUnitOfWorkDomain unitOf)
        {
            this.dc = dc;
            this.mapper = mapper;
            this.unitOf = unitOf;
        }
        public async Task<IEnumerable<Server>> Get()
        {
            return await dc.Servers
                .Include(x => x.Cameras.Where(x=> !x.Retired))
                .ThenInclude(x=> x.Brand).Include(x => x.Brand)
                .Where(x=> !x.Retired )
                .ToListAsync();
        }
        public async Task<IEnumerable<Server>> GetAll()
        {
            return await dc.Servers.ToListAsync();
        }
        public async Task<Server> FindById(string id)
        {
            var data = await dc.Servers.Include(x => x.Cameras).FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                return data;
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
            //var server = mapper.Map<Server>(serverDto);
            var find = FindBySerial(server);
            if (find.Result == null)
            {
                var code = server.Id + "-" + (GetAll().Result.Count() + 1).ToString("D" + 4);
                server.Id= code;
                dc.Servers.Add(server);
                await dc.SaveChangesAsync();
                var srvAg = new SrvAg
                {
                    AgencyId = server.AgencyId,
                    ServerId = server.Id
                };
                dc.SrvAgs.Add(srvAg);
                

                await dc.SaveChangesAsync();
                var brand = await dc.Brands.FirstOrDefaultAsync(x=> x.Id== server.BrandId);
                server.Brand = brand;


                return new ObjectResult(server);
            }
            return new ObjectResult("Server Already") { StatusCode = 500 };

        }
        public async Task<ObjectResult> AddFile(DataSheetDto sdsd)
        {
            if (sdsd.File != null)
            {
                var file = unitOf.HelperDomain.UploadFilePdf(sdsd.File);
                var dataSheet = new DataSheet { DataSheetName = file, DeviceId = sdsd.DeviceId };
                dc.DataSheets.Add(dataSheet);
                await dc.SaveChangesAsync();

            }


            return new ObjectResult(sdsd);
        }
        public async Task<ObjectResult> Update(string id, Server server)
        {

            dc.Entry(server).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(server) { StatusCode = 200 };

        }
    }
}
