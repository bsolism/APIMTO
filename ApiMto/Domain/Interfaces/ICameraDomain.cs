using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Domain.Interfaces
{
    public interface ICameraDomain
    {
        Task<Camera> FindCameraBySerial(Camera camera);
    }
}
