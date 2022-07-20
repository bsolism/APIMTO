using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface ICameraApplication
    {
        Task<IEnumerable<Camera>> Get();
        Task<IEnumerable<Camera>> GetOnly();
        Task<Camera> FindById(int id);
        Task<Camera> FindByChannel(int id, int serverId);
        Task<ObjectResult> Add(Camera camera);
        Task<ObjectResult> Update(int id, Camera camera);


    }
}
