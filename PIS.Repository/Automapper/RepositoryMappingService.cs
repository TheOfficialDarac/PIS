using AutoMapper;
using PIS.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using PIS.Model;

namespace PIS.Repository.Automapper
{
    public class RepositoryMappingService : IRepositoryMappingService
    {
        public Mapper mapper;

        public RepositoryMappingService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PisUsersDrupcic, UsersDTO>(); 
                cfg.CreateMap<UsersDTO, PisUsersDrupcic>();
            });
            mapper = new Mapper(config);
        }

        public TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
