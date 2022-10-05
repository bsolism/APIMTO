using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiMto.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
       [IgnoreDataMember]
        public List<Server>? Servers { get; set; }
        [IgnoreDataMember]
        public List<Camera>? Cameras { get; set; }
    }
}
