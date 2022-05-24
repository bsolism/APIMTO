using System.ComponentModel.DataAnnotations;

namespace ApiMto.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public List<Server>? Servers { get; set; }
        public List<Camera>? Cameras { get; set; }
    }
}
