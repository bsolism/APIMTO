using System.ComponentModel.DataAnnotations;

namespace ApiMto.Models
{
    public class Camera
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string LocationConnection { get; set; }
        public string? IdPatchPanel { get; set; }
        public string? IdSwitch { get; set; }
        public int? PortPatchPanel { get; set; }
        public int? PortSwitch { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string IpAddress { get; set; }
        public string Mac { get; set; }
        public string? DeviceId { get; set; }
        public string? DeviceDescription { get; set; }
        public string SerialNumber { get; set; }
        public string? FirmwareVersion { get; set; }
        public bool IsGoodCondition { get; set; }
        public DateTime DateInstallation { get; set; }
        public DateTime DateBuys { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int ServerId { get; set; }
        public Server? Server { get; set; }
    }
}
