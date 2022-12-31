using ApiMto.Application.Interfaces;

namespace ApiMto.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICameraApplication CameraApplication { get; }
        IServerApplication ServerApplication { get; }
        IAgencyApplication AgencyApplication { get; }
        IBrandApplication BrandApplication { get; }
        IDeviceApplication DeviceApplication { get; }
        ILogApplication LogApplication { get; }
       
        IDataSheetApplication DataSheetApplication { get; }
   
        IHikvisionApplication HikvisionApplication { get; }
        IVivotekApplication VivotekApplication { get; }

    }
}
