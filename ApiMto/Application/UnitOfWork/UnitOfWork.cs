﻿using ApiMto.Application.Interfaces;
using ApiMto.Context;
using ApiMto.Domain.UnitOfWork;
using AutoMapper;

namespace ApiMto.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        private readonly IUnitOfWorkDomain uowd;
        private readonly IMapper mapper;

        public UnitOfWork(DataContext dc, IUnitOfWorkDomain uowd, IMapper mapper)
        {
            this.dc = dc;
            this.uowd = uowd;
            this.mapper = mapper;
        }
        public ICameraApplication CameraApplication => 
            new CameraApplication(dc, uowd);
        public IServerApplication ServerApplication =>
            new ServerApplication(dc, mapper);
        public IAgenciaApplication AgenciaApplication =>
           new AgenciaApplication(dc, uowd);
        public IBrandApplication BrandApplication =>
           new BrandApplication(dc, uowd);
        public IDeviceApplication DeviceApplication =>
            new DeviceApplication();
        public ILogApplication LogApplication =>
          new LogApplication(dc, uowd);
    }
}
