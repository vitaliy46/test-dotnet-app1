using System;

namespace Kis.Noris.Api.Data
{
    public class NoMatchRepositoryException : Exception
    {
        public NoMatchRepositoryException(Type entityType) : this(entityType, null)
        { }

        public NoMatchRepositoryException(Type entityType, Exception innerException) :
            base(
            $"Can't found matched repository for type \"{entityType.Name}\". Context is not configured to manage this entity type.",
            innerException)
        { }
    }
}
