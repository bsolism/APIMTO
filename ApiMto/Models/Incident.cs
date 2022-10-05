namespace ApiMto.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public string CameraId { get; set; }
        public string Comment { get; set; }
        public Camera? Camera { get; set; }
        public DateTime Date { get; set; }
    }
}
