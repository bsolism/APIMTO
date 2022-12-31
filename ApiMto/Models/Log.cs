using System.ComponentModel.DataAnnotations;

namespace ApiMto.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string logType { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string DeviceId { get; set; }
        public List<Camera> Cameras { get; set; }
        public List<Server> Servers { get; set; }
        public bool Type { get; set; }
    }
}
