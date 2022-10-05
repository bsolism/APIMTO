using ApiMto.Dto;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Application.Interfaces
{
    public interface IDataSheetApplication
    {
        Task<DataSheet> FindById(string id);
        Task<DataSheet> AddFile(DataSheetDto sdsd);
    }
}
