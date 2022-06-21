using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ApiMto.Models
{
    public class Camera
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string UbicacionFisica { get; set; }
        public string UbicacionConexion { get; set; }
        public string? PatchPanel { get; set; }
        public string? Switch { get; set; }
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
        public DateTime FechaInstalacion{ get; set; }
        public DateTime FechaCompra { get; set; }
        public string? Nota { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int ServerId { get; set; }
        public Server? Server { get; set; }
        public int AgenciaId { get; set; }
        [IgnoreDataMember]
        public Agencia? Agencia { get; set; }
    }
}
