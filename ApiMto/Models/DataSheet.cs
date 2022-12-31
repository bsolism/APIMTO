namespace ApiMto.Models
{
    public class DataSheet
    {
        public int Id { get; set; }
        public string DataSheetName { get; set; } = null!;
        public string DeviceId { get; set; } = null!;
        public List<Camera> Cameras { get; set; }
        public List<Server> Servers { get; set; }
    }
}
