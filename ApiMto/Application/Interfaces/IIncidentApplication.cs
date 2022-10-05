using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IIncidentApplication
    {
        Task<IEnumerable<Incident>> Get();
        Task<Incident> FindById(int id);
        Task<Incident> FindByCam(string id);
        Task<ObjectResult> Add(Incident evento);
        Task<ObjectResult> Delete(Incident evento);
    }
}
