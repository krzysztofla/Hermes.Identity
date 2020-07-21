using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Query
{
    public interface IQueryDispacher
    {
        Task<TResult> Execute<T, TResult>(T query) where T : IQuery;
    }
}
