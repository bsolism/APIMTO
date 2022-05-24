using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IAgenciaApplication
    {
        Task<IEnumerable<Agencia>> Get();
        Task<Agencia> FindById(int id);
        Task<ObjectResult> Add(Agencia agencia);
        Task<ObjectResult> Update(int id, Agencia agencia);
    }
}
