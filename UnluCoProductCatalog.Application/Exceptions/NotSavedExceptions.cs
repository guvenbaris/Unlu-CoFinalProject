using System;

namespace UnluCoProductCatalog.Application.Exceptions
{
    public class NotSavedExceptions : Exception
    {
        public NotSavedExceptions(string name) : base($"Entity '{name}' not saved on database")
        {

        }
    }
}
