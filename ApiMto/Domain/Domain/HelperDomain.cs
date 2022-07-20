using ApiMto.Domain.Interfaces;
using ApiMto.Helper;

namespace ApiMto.Domain.Domain
{
    public class HelperDomain: IHelperDomain
    {
        private readonly IWebHostEnvironment environment;

        public HelperDomain(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        public string UploadFilePdf(IFormFile File)
        {
            string guidImagen = null;


            if (File != null)
            {
                if (!Directory.Exists(environment.WebRootPath + "\\DataSheet\\"))
                {
                    Directory.CreateDirectory(environment.WebRootPath + "\\DataSheet\\");
                }
                string fichero = Path.Combine(environment.WebRootPath, "DataSheet");
                guidImagen = Guid.NewGuid().ToString() + File.FileName;
                string url = Path.Combine(fichero, guidImagen);
                File.CopyTo(new FileStream(url, FileMode.Create));

                return guidImagen;
            }

            return guidImagen;

        }
    }
}
