using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Movies.Data
{
    public class OMDbClient
    {
        private readonly HttpClient _client;

        public OMDbClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<MovieResponseModel>> MovieSearch(string title, int year)
        {
            string yearString;
            if (year == 0) yearString = "";
            else yearString = $"&y={year}";

            return await GetAsync<IEnumerable<MovieResponseModel>>($"&t={title}{yearString}");
        }

        private async Task<T> GetAsync<T>(string endPoint)
        {            
            var response = await _client.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                var model = await JsonSerializer.DeserializeAsync<T>(content);

                return model;
            }
            else
            {
                throw new HttpRequestException("Narp");
            }
        }
    }
}
