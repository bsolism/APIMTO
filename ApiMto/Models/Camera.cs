using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ApiMto.Models
{
    public class Camera
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string Connection { get; set; }
        public string? PatchPanel { get; set; }
        public string? Switch { get; set; }
        public int? PortPatchPanel { get; set; }
        public int? PortSwitch { get; set; }
        public int? PortChannel { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string IpAddress { get; set; }
        public string Mac { get; set; }
        public string? AssetId { get; set; }
        public string? DeviceId { get; set; }
        public string? DeviceDescription { get; set; }
        public string SerialNumber { get; set; }
        public string? FirmwareVersion { get; set; }
        public bool Online { get; set; }
        public bool Retired { get; set; }
        public DateTime DateInstallation{ get; set; }
        public DateTime DateBuy { get; set; }
        public string? Note { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public string ServerId { get; set; }
        public Server? Server { get; set; }
        public string AgencyId { get; set; }
        [IgnoreDataMember]
        public Agency? Agency { get; set; }
    }
}
