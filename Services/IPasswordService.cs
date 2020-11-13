using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Services
{
    public interface IPasswordService
    {
        bool IsValid(string hash, string password);
        string Hash(string password);
    }
}
