using System;

namespace FlukeTestApp.DomainModels.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public int StatusCode = 404;

        public ItemNotFoundException()
            : base("The specified item was not found")
        {
        }
    }
}