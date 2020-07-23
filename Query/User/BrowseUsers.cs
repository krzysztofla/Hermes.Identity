using System;

namespace Hermes.Identity.Query.User
{
    public class BrowseUser : IQuery
    {
        public Guid Id { get; }
        public BrowseUser(Guid id)
        {
            Id = id;
        }
    }
}
