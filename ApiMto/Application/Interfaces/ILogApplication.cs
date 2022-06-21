using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface ILogApplication
    {
        Task<IEnumerable<Log>> Get();
        Task<Log> FindById(int id);
        Task<IEnumerable<Log>> FindByCam(int id);
        Task<ObjectResult> Add(Log Logs);
        Task<ObjectResult> Update(int id, Log Logs);
    }
}
