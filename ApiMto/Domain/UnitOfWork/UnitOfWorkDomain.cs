using ApiMto.Context;
using ApiMto.Domain.Domain;
using ApiMto.Domain.Interfaces;

namespace ApiMto.Domain.UnitOfWork
{
    public class UnitOfWorkDomain : IUnitOfWorkDomain
    {
        private readonly DataContext dc;

        public UnitOfWorkDomain(DataContext dc)
        {
            this.dc = dc;
        }
        public ICameraDomain CameraDomain =>
           new CameraDomain(dc);
    }
}
