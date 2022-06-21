namespace ApiMto.Models
{
    public class SrvAg
    {
        public int Id { get; set; }
        public int AgenciaId { get; set; }
        public Agencia? Agencia { get; set; }
        public int ServerId { get; set; }
        public Server? Server { get; set; }
    }
}
