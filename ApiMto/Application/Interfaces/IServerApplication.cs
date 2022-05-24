using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IServerApplication
    {
        Task<IEnumerable<Server>> Get();
        Task<Server> FindById(int id);
        Task<ObjectResult> Add(Server server);
        Task<ObjectResult> Update(int id, Server server);
    }
}
