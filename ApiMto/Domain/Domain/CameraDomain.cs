using ApiMto.Context;
using ApiMto.Domain.Interfaces;
using ApiMto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMto.Domain.Domain
{
    public class CameraDomain : ICameraDomain
    {
        private readonly DataContext dc;

        public CameraDomain(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<Camera> FindCameraBySerial(Camera camera)
        {
            var result= dc.Cameras.FirstOrDefault(x => x.SerialNumber == camera.SerialNumber);

            return result;
            
        }

    }
}
