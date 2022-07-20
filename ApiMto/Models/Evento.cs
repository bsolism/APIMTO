namespace ApiMto.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public int CameraId { get; set; }
        public string Comment { get; set; }
        public Camera? Camera { get; set; }
        public DateTime Date { get; set; }
    }
}
