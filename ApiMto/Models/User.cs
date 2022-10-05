using System.ComponentModel.DataAnnotations;

namespace ApiMto.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
