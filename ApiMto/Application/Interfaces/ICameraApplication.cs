using ApiMto.Dto;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface ICameraApplication
    {
        Task<IEnumerable<Camera>> Get();
        Task<IEnumerable<Camera>> GetOnly();
        Task<Camera> FindById(string id);
        Task<Camera> FindByChannel(int id, string serverId);
        Task<ObjectResult> Add(Camera camera);
        Task<ObjectResult> AddFile(CameraDataSheetDto sdsd);
        Task<ObjectResult> Update(string id, Camera camera);


    }
}
