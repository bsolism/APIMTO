using System.ComponentModel.DataAnnotations;

namespace ApiMto.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string Evento { get; set; }
        public DateTime Date { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int CameraId { get; set; }
        public Camera? Camera { get; set; }
    }
}
