using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Domain.UnitOfWork;
using ApiMto.Dto;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMto.Application
{
    public class DataSheetApplication : IDataSheetApplication
    {
        private readonly DataContext dc;
        private readonly IUnitOfWorkDomain uowd;

        public DataSheetApplication(DataContext dc, IUnitOfWorkDomain uowd)
        {
            this.dc = dc;
            this.uowd = uowd;
        }
        public async Task<DataSheet> FindById(string id)
        {
            var data = await dc.DataSheets.AsNoTracking().FirstOrDefaultAsync(x => x.DeviceId== id);
            return data;
            
            
        }
        public async Task<DataSheet> AddFile(DataSheetDto sdsd)
        {
            if (sdsd.File != null)
            {
                var itemInDb = await FindById(sdsd.DeviceId);
                if (itemInDb != null)
                {
                    if(itemInDb.DataSheetName != sdsd.DataSheetName)
                    {
                        itemInDb.DataSheetName= uowd.HelperDomain.UploadFilePdf(sdsd.File);
                        dc.Entry(itemInDb).State = EntityState.Modified;
                        await dc.SaveChangesAsync();
                        return itemInDb;
                    }

                }
                else
                {
                    var file = uowd.HelperDomain.UploadFilePdf(sdsd.File);
                    var dataSheet = new DataSheet { DataSheetName = file, DeviceId = sdsd.DeviceId };
                    dc.DataSheets.Add(dataSheet);
                    await dc.SaveChangesAsync();
                    return dataSheet;
                }

            }
            return null;
        }

    }
}
