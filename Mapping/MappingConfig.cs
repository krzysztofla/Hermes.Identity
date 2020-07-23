using AutoMapper;
using Hermes.Identity.Dto;
using Hermes.Identity.Entities;
using Hermes.Identity.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Mapping
{
    public static class MappingConfig
    {
        public static IMapper Initialize() => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDocument>();
                cfg.CreateMap<UserDocument, User>();
                cfg.CreateMap<User, UserDto>();
            }
        ).CreateMapper();
    }
}
