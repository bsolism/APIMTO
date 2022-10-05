namespace ApiMto.Models
{
    public class ServerDataSheet
    {
        public int Id { get; set; }
        public string DataSheetName { get; set; }
        public string ServerId { get; set; }
        public Server? Server { get; set; }
    }
}
