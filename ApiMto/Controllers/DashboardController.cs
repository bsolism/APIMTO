using ApiMto.Application.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly IUnitOfWork uow;

        public DashboardController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        
       
    }
}
