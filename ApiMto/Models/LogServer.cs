using System.ComponentModel.DataAnnotations;

namespace ApiMto.Models
{
    public class LogServer
    {
        [Key]
        public int Id { get; set; }
        public string LogName { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string ServerId { get; set; }
        public Server? Server { get; set; }
    }
}
