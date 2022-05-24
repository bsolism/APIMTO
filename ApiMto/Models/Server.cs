using System.ComponentModel.DataAnnotations;

namespace ApiMto.Models
{
    public class Server
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        //public string Brand { get; set; }
        public string Model { get; set; }
        public string Mac { get; set; }
        public string? DeviceId { get; set; }
        public string SerialNumber { get; set; }
        public string? FirmwareVersion { get; set; }
        public int CameraCapacity { get; set; }
        public int CameraAvailable { get; set; }
        public string IpAddress { get; set; }
        public string Storage { get; set; }
        public string StorageAvailable { get; set; }
        public int EngravedDays { get; set; }
        public bool isGoodCondition { get; set; }
        public DateTime DateInstallation { get; set; }
        public DateTime DateBuys { get; set; }
        public int BrandId {get; set; }
        public Brand? Brand { get; set; }

        public int AgenciaId { get; set; }
        public Agencia? Agencia { get; set; }
        public List<Camera>? Cameras { get; set; }


    }
}
