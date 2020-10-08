using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Query
{
    public class QueryDispacher : IQueryDispacher
    {
        private readonly IComponentContext componentContext;

        public QueryDispacher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public async Task<TResult> Execute<T, TResult>(T query) where T : IQuery
        {
            if (query == null)
            {
                throw new ArgumentNullException();
            }
            return await componentContext.Resolve<IQueryHandler<T, TResult>>().Handle(query);
        }
    }
}
