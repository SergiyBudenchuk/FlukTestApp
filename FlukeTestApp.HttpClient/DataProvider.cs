using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using FlukeTestApp.DataProvider.Abstractions;
using FlukeTestApp.DataProvider.Models;
using FlukeTestApp.DomainModels.Exceptions;
using FlukeTestApp.DomainModels.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FlukeTestApp.DataProvider
{
    internal class DataProvider : IDataProvider
    {
        private const string AppSettingEonetUrlKey = "EonetBaseUrl";
        private readonly string _baseUrl;

        private readonly IHttpClientFactory _httpClient;
        private readonly IMapper _mapper;

        public DataProvider(IHttpClientFactory httpClient, IConfiguration config, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;

            _baseUrl = config.GetSection(AppSettingEonetUrlKey).Value;
        }

        public async Task<IEnumerable<Event>> GetAsync(int limit = 20, string source = "", int days = 365)
        {
            var client = _httpClient.CreateClient();

            var requestResult = await client.GetAsync($"{_baseUrl}?limit={limit}&source={source}&days={days}");
            var responseContent = await GetContentAsync(requestResult);

            if (responseContent == null)
            {
                throw new ItemNotFoundException();
            }

            var originalRoot = JsonConvert.DeserializeObject<OriginalRoot>(responseContent);

            var result = _mapper.Map<List<OriginalEvent>, List<Event>>(originalRoot.events);

            return result;
        }

        public async Task<Event> GetAsync(string id)
        {
            var client = _httpClient.CreateClient();

            var requestResult = await client.GetAsync($@"{_baseUrl}/{id}");
            var responseContent = await GetContentAsync(requestResult);

            if (responseContent == null)
            {
                throw new ItemNotFoundException();
            }

            var @event = JsonConvert.DeserializeObject<OriginalEvent>(responseContent);

            var result = _mapper.Map<OriginalEvent, Event>(@event);
            return result;
        }

        private async Task<string> GetContentAsync(HttpResponseMessage response)
        {
            string result = null;

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}