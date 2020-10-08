using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hermes.Identity.Query
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> Handle(TQuery query);
    }
}
