using ApiMto.Application.Interfaces;

namespace ApiMto.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICameraApplication CameraApplication { get; }
        IServerApplication ServerApplication { get; }
        IAgenciaApplication AgenciaApplication { get; }
        IBrandApplication BrandApplication { get; }
        IDeviceApplication DeviceApplication { get; }
        ILogApplication LogApplication { get; }

    }
}
