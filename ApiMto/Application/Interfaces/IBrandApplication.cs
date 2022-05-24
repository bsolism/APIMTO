using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IBrandApplication
    {
        Task<IEnumerable<Brand>> Get();
        Task<Brand> FindById(int id);
        Task<ObjectResult> Add(Brand Brand);
        Task<ObjectResult> Update(int id, Brand Brand);
    }
}
