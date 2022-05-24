using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Domain.UnitOfWork;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMto.Application
{
    public class BrandApplication : IBrandApplication
    {
        private readonly DataContext dc;
        private readonly IUnitOfWorkDomain uowd;

        public BrandApplication(DataContext dc, IUnitOfWorkDomain uowd)
        {
            this.dc = dc;
            this.uowd = uowd;
        }

        public async Task<IEnumerable<Brand>> Get()
        {
            return await dc.Brands.ToListAsync();
        }
        public async Task<Brand> FindById(int id)
        {
            var data = await dc.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<ObjectResult> Add(Brand Brand)
        {

            dc.Brands.Add(Brand);
            await dc.SaveChangesAsync();
            return new ObjectResult(Brand);



        }
        public async Task<ObjectResult> Update(int id, Brand Brand)
        {

            dc.Entry(Brand).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(Brand) { StatusCode = 200 };

        }
    }
}
