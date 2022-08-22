using System.Text;

namespace ApiMto.Helper
{
    public class EncodingPass
    {
        public static string EncryptPass(string pass)
        {
            var plain = Encoding.UTF8.GetBytes(pass);
            return System.Convert.ToBase64String(plain);
        }
        public static string DecryptPass(string pass)
        {
            var baseEn = System.Convert.FromBase64String(pass);
            return Encoding.UTF8.GetString(baseEn);
        }
    }
}
