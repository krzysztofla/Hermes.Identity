using Hermes.Identity.Common.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Services
{
    interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}
