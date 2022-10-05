using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Domain.Interfaces
{
    public interface IPanasonicDomain
    {
        Camera InfoDeviceOne(ContentResult response);
        Camera InfoDeviceTwo(ContentResult response, int count, Camera cam);
    }
}
