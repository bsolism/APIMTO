using ApiMto.Dto;
using ApiMto.Models;
using AutoMapper;

namespace ApiMto.Helper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<ServerDto, Server>();
        }
    }
}
