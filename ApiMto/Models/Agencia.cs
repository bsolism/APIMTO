using System.ComponentModel.DataAnnotations;

namespace ApiMto.Models
{
    public class Agencia
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public List<SrvAg>? SrvAg { get; set; }
        public List<Camera>? Cameras { get; set; }
       
    }
}
