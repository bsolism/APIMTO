using ApiMto.Models;
using System.Web.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IHikvisionApplication
    {
        Task<byte[]> GetImage(Camera camera);
    }
}
