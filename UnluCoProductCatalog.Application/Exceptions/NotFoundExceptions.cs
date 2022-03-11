using System;

namespace UnluCoProductCatalog.Application.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string name, object key = null) : base($"Entity '{name}' {key} was not found")
        {

        }
    }
}
