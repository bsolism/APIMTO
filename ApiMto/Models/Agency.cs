using System.ComponentModel.DataAnnotations;

namespace ApiMto.Models
{
    public class Agency
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<Server>? Servers { get; set; }
        public List<SrvAg>? SrvAg { get; set; }
        public List<Camera>? Cameras { get; set; }
       
    }
}
