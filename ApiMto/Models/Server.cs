using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiMto.Models
{
    public class Server
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Ubicacion { get; set; }
        public string Type { get; set; }
        //public string Brand { get; set; }
        public string Modelo { get; set; }
        public string Mac { get; set; }
        public string? DeviceId { get; set; }
        public string SerialNumber { get; set; }
        public string? FirmwareVersion { get; set; }
        public string IpAddress { get; set; }
        public string? AssetId { get; set; }
        public int Sata { get; set; }
        public int CapacidadSata { get; set; }
        public int SataInstalado { get; set; }
        public int CapacidadSataInstalado { get; set; }
        public int EngravedDays { get; set; }
        public bool Online { get; set; }
        public bool Retired { get; set; }
        public int PortAnalogo { get; set; }
        public int PortIpPoe { get; set; }
        public int CanalesIP { get; set; }
        public string? nota { get; set; }
        public DateTime FechaInstalacion { get; set; }
        public DateTime FechaCompra { get; set; }
        public int BrandId {get; set; }
        public Brand? Brand { get; set; }
        
        public List<Camera>? Cameras { get; set; }
        [IgnoreDataMember]
        public List<SrvAg>? srvAgs { get; set; }


    }
}
