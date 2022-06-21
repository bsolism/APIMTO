using System.ComponentModel.DataAnnotations;

namespace ApiMto.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
