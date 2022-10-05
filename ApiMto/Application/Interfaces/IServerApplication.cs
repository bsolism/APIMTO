using ApiMto.Dto;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IServerApplication
    {
        Task<IEnumerable<Server>> Get();
        Task<Server> FindById(string id);
        Task<ObjectResult> Add(ServerDto serverDto);
        Task<ObjectResult> AddFile(DataSheetDto sdsd);
        Task<ObjectResult> Update(string id, Server server);
    }
}
