using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMto.Application
{
    public class DataSheetApplication : IDataSheetApplication
    {
        private readonly DataContext dc;

        public DataSheetApplication(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<ObjectResult> FindByServerId(int id)
        {
            var data = await dc.ServerDataSheets.FirstOrDefaultAsync(x => x.ServerId == id);
            if (data != null)
            {
                return new ObjectResult(data) { StatusCode = 200 };
            }
            return new ObjectResult("DataSheet not found") { StatusCode = 500 };
        }
        public async Task<ObjectResult> FindByCameraId(int id)
        {
            var data = await dc.CameraDataSheets.FirstOrDefaultAsync(x => x.CameraId == id);
            if (data != null)
            {
                return new ObjectResult(data) { StatusCode = 200 };
            }
            return new ObjectResult("DataSheet not found") { StatusCode = 500 };
        }
    }
}
