using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IAgencyApplication
    {
        Task<IEnumerable<Agency>> Get();
        Task<Agency> FindById(string id);
        Task<ObjectResult> Add(Agency agency);
        Task<ObjectResult> Update(int id, Agency agency);
    }
}
