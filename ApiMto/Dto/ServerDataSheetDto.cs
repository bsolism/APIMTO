using ApiMto.Models;

namespace ApiMto.Dto
{
    public class ServerDataSheetDto
    {
       
        public string DataSheetName { get; set; }
        public int ServerId { get; set; }
        public IFormFile File { get; set; }

    }
}
