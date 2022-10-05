using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface ILogApplication
    {
        Task<IEnumerable<Log>> Get();
        Task<Log> FindById(int id);
        Task<Log> FindByCameraId(string id);
        Task<IEnumerable<Log>> FindByDevice(string id);
        Task<ObjectResult> Add(Log Logs);
        Task<ObjectResult> Update(int id, Log Logs);
    }
}
