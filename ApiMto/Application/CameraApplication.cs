using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Domain.UnitOfWork;
using ApiMto.Dto;
using ApiMto.Helper;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMto.Application
{
    public class CameraApplication : ICameraApplication
    {
        private readonly DataContext dc;
        private readonly IUnitOfWorkDomain uowd;

        public CameraApplication(DataContext dc, IUnitOfWorkDomain uowd)
        {
            this.dc = dc;
            this.uowd = uowd;
        }

        public async Task<IEnumerable<Camera>> Get()
        {
            return await dc.Cameras.Include(x=> x.Brand).Include(x=> x.Server).ThenInclude(x=> x.Brand).OrderByDescending(x=> x.Id).ToListAsync();
        }
        public async Task<IEnumerable<Camera>> GetAll()
        {
            return await dc.Cameras.ToListAsync();
        }
        public async Task<IEnumerable<Camera>> GetOnly()
        {
            return await dc.Cameras.ToListAsync();
        }
        public async Task<Camera> FindById(string id)
        {
            var data = await dc.Cameras.FirstOrDefaultAsync(x=> x.Id== id);
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<Camera> FindByChannel(int id, string serverId)
        {
            var data = await dc.Cameras.FirstOrDefaultAsync(x => x.PortChannel == id && x.ServerId== serverId );
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<Camera> FindBySerial(Camera camera)
        {
            var data = await dc.Cameras.FirstOrDefaultAsync(x => x.SerialNumber == camera.SerialNumber);
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<SrvAg> FindBySrvAg(Camera camera)
        {
            var data = await dc.SrvAgs.AsNoTracking().FirstOrDefaultAsync(x => x.AgencyId== camera.AgencyId && x.ServerId== camera.ServerId);      
            if (data != null)
            {
                return data;
            }
            return null;
        }
        public async Task<ObjectResult> AddFile(CameraDataSheetDto sdsd)
        {
            if (sdsd.File != null)
            {
                var file = uowd.HelperDomain.UploadFilePdf(sdsd.File);
                var cameraDataSheet = new CameraDataSheet { DataSheetName = file, CameraId = sdsd.CameraId };
                dc.CameraDataSheets.Add(cameraDataSheet);
                await dc.SaveChangesAsync();

            }


            return new ObjectResult(sdsd);
        }
        public async Task<ObjectResult> Add(Camera camera)
        {
            var find = FindBySerial(camera);
          //  var srvAg = await dc.SrvAgs.AsNoTracking().FirstOrDefaultAsync(x => x.AgencyId == camera.AgencyId && x.ServerId == camera.ServerId);
            if (find.Result == null)
            {
                var code = camera.Id + "-" + (GetAll().Result.Count() + 1).ToString("D" + 4);
                camera.Id = code;

                //var passEnco = EncodingPass.EncryptPass(camera.SerialNumber + "|" + camera.Password);
                //camera.Password = passEnco;
                dc.Cameras.Add(camera);
                await dc.SaveChangesAsync();
                var srvAg = FindBySrvAg(camera);
                if (srvAg == null)
                {
                    var srv = new SrvAg { AgencyId = camera.AgencyId, ServerId = camera.ServerId };
                    dc.SrvAgs.Add(srv);
                    await dc.SaveChangesAsync();

                }
                return new ObjectResult(camera) { StatusCode = 200 };
            }
            return new ObjectResult("Camera Already") { StatusCode= 500 };


        }
        public async Task<ObjectResult> Update(string id, Camera camera)
        {
            dc.Entry(camera).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(camera) { StatusCode = 200 };

        }
       
    }
}
