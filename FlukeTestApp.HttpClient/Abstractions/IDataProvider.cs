using System.Collections.Generic;
using System.Threading.Tasks;
using FlukeTestApp.DataProvider.Models;
using FlukeTestApp.DomainModels.Models;

namespace FlukeTestApp.DataProvider.Abstractions
{
    public interface IDataProvider
    {
        Task<IEnumerable<Event>> Get(int limit = 20, string source = "", int days = 365);
        Task<Event> Get(string id);
    }
}
