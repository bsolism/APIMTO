using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IDataSheetApplication
    {
        Task<ObjectResult> FindByServerId(int id);
    }
}
