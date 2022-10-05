using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IDeviceApplication
    {
        Task<ContentResult> GetDevice(string uri, string user, string pass);
        Task<ObjectResult> Get(string IP, string user, string pass);
        Task<IActionResult> GetPlayBack(string ip, string user, string pass);
        Task<IActionResult> Put(string IP, string user, string pass, HttpContent content);
        Task<IActionResult> PutMic(string IP, string user, string pass, HttpContent content);
        Task<IActionResult> Update(string uri, string user, string pass, HttpContent content);
        Task<IActionResult> PostDevice(string uri, string user, string pass, HttpContent content);
    }
}
