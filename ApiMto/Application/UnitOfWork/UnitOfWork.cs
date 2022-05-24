using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Domain.UnitOfWork;

namespace ApiMto.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        private readonly IUnitOfWorkDomain uowd;

        public UnitOfWork(DataContext dc, IUnitOfWorkDomain uowd)
        {
            this.dc = dc;
            this.uowd = uowd;
        }
        public ICameraApplication CameraApplication => 
            new CameraApplication(dc, uowd);
        public IServerApplication ServerApplication =>
            new ServerApplication(dc);
        public IAgenciaApplication AgenciaApplication =>
           new AgenciaApplication(dc, uowd);
        public IBrandApplication BrandApplication =>
           new BrandApplication(dc, uowd);
    }
}
