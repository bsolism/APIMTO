using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface ILogServerApplication
    {
        Task<IEnumerable<LogServer>> Get();
        Task<LogServer> FindById(int id);
        Task<IEnumerable<LogServer>> FindByServer(int id);
        Task<ObjectResult> Add(LogServer LogsServer);
        Task<ObjectResult> Update(int id, LogServer LogsServer);
    }
}
