using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IDeviceApplication
    {
        Task<ObjectResult> Get(string IP, string user, string pass);
        Task<IActionResult> Put(string IP, string user, string pass, HttpContent content);
        Task<IActionResult> PutMic(string IP, string user, string pass, HttpContent content);
    }
}
