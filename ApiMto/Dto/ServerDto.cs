using ApiMto.Models;

namespace ApiMto.Dto
{
    public class ServerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string AgencyId { get; set; }
        public string Model { get; set; }
        public string Mac { get; set; }
        public string? DeviceId { get; set; }
        public string SerialNumber { get; set; }
        public string? FirmwareVersion { get; set; }
        public string IpAddress { get; set; }
        public string? AssetId { get; set; }
        public int SlotSata { get; set; }
        public int CapacityBySlot { get; set; }
        public int SataAvailable { get; set; }
        public int CapacityTotal { get; set; }
        public int EngravedDays { get; set; }
        public bool Online { get; set; }
        public bool Retired { get; set; }
        public int PortAnalogo { get; set; }
        public int PortIpPoe { get; set; }
        public int ChannelIP { get; set; }
        public string? Note { get; set; }
        public DateTime DateInstallation { get; set; }
        public DateTime DateBuy { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

       
    }
}
