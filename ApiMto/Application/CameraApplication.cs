using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Domain.UnitOfWork;
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
            return await dc.Cameras.Include(x=> x.Brand).Include(x=> x.Server).ToListAsync();
        }
        public async Task<IEnumerable<Camera>> GetOnly()
        {
            return await dc.Cameras.ToListAsync();
        }
        public async Task<Camera> FindById(int id)
        {
            var data = await dc.Cameras.FirstOrDefaultAsync(x=> x.Id== id);
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
        public async Task<ObjectResult> Add(Camera camera)
        {
            var find = FindBySerial(camera);
            if (find.Result == null)
            {
                dc.Cameras.Add(camera);
                await dc.SaveChangesAsync();
                return new ObjectResult(camera);
            }
            return new ObjectResult("Camera Already") { StatusCode= 500 };


        }
        public async Task<ObjectResult> Update(int id, Camera camera)
        {
            
            dc.Entry(camera).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(camera) { StatusCode = 200 };

        }
    }
}
