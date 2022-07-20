using System.ComponentModel.DataAnnotations;

namespace ApiMto.Models
{
    public class LogServer
    {
        [Key]
        public int Id { get; set; }
        public string Evento { get; set; }
        public DateTime Date { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int ServerId { get; set; }
        public Server? Server { get; set; }
    }
}
