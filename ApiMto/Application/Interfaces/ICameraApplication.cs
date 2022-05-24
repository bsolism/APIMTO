using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface ICameraApplication
    {
        Task<IEnumerable<Camera>> Get();
        Task<Camera> FindById(int id);
        Task<ObjectResult> Add(Camera camera);
        Task<ObjectResult> Update(int id, Camera camera);


    }
}
