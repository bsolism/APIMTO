using ApiMto.Models;

namespace ApiMto.Application.Interfaces
{
    public interface IVivotekApplication
    {
        Task<byte[]> GetImage(Camera camera);
    }
}
