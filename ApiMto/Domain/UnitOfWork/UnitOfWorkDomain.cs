using ApiMto.Context;
using ApiMto.Domain.Domain;
using ApiMto.Domain.Interfaces;

namespace ApiMto.Domain.UnitOfWork
{
    public class UnitOfWorkDomain : IUnitOfWorkDomain
    {
        private readonly DataContext dc;
        private readonly IWebHostEnvironment environment;

        public UnitOfWorkDomain(DataContext dc, IWebHostEnvironment environment)
        {
            this.dc = dc;
            this.environment = environment;
        }
        public ICameraDomain CameraDomain =>
           new CameraDomain(dc);
        public IHelperDomain HelperDomain =>
            new HelperDomain(environment);
        public IDeviceDomain DeviceDomain =>
            new DeviceDomain(dc);
    }
}
