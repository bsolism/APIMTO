namespace ApiMto.Models
{
    public class SrvAg
    {
        public int Id { get; set; }
        public string AgencyId { get; set; }
        public Agency? Agency { get; set; }
        public string ServerId { get; set; }
        public Server? Server { get; set; }
    }
}
