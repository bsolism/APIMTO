namespace ApiMto.Domain.Interfaces
{
    public interface IDeviceDomain
    {
        Task<HttpResponseMessage> conDevice(string uri, string user, string pass);
        Task<int> DayPlayback(string uri, string user, string pass);
    }
}
