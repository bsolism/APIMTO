using ApiMto.Domain.Interfaces;

namespace ApiMto.Domain.UnitOfWork
{
    public interface IUnitOfWorkDomain
    {
        ICameraDomain CameraDomain { get; }
        IHelperDomain HelperDomain { get; }
        IDeviceDomain DeviceDomain { get; }
    }
}
