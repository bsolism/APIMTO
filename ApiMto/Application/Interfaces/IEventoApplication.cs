using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IEventoApplication
    {
        Task<IEnumerable<Evento>> Get();
        Task<Evento> FindById(int id);
        Task<Evento> FindByCam(int id);
        Task<ObjectResult> Add(Evento evento);
        Task<ObjectResult> Delete(Evento evento);
    }
}
