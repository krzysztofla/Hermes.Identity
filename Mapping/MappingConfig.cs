using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Mapping
{
    public static class MappingConfig
    {
        public static IMapper Initialize() => new MapperConfiguration(cfg =>
            { }
        ).CreateMapper();
    }
}
