using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

using Cluno.Api.Models;
using Cluno.Api.CustomExceptions;

namespace Cluno.Api
{
    public class Calls
    {
        private static Calls _instance = null;
        public static Calls Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Calls();

                return _instance;
            }
        }

        private static HttpClient _httpClient;

        public Calls()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.cluno.com");
        }

        public async Task<Offers> GetAllOffersAsync()
        {
            Offers offers = null;
            string endpoint = "/offerservice/v1/offer/query";
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            string offersJson = await response.Content.ReadAsStringAsync();

            ValidateSchema(offersJson, Path.Combine(System.Environment.CurrentDirectory, @"Schemas\AllOffersSchema.json"));

            offers = await response.Content.ReadAsAsync<Offers>();

            if (offers == null)
                throw new NullReferenceException();

            return offers;
        }

        public async Task<DetailedOffer> GetDetailedOfferAsync(string id)
        {
            DetailedOffer detailedOffer = null;
            string endpoint = $"/offerservice/v1/offer/{id}";
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            string detailedOffersJson = await response.Content.ReadAsStringAsync();

            ValidateSchema(detailedOffersJson, Path.Combine(System.Environment.CurrentDirectory, @"Schemas\DetailedOfferSchema.json"));

            detailedOffer = await response.Content.ReadAsAsync<DetailedOffer>();

            if (detailedOffer == null)
                throw new NullReferenceException();

            return detailedOffer;
        }

        private void ValidateSchema(string jsonContent, string pathToSchema)
        {
            JSchema schema = JSchema.Parse(File.ReadAllText(pathToSchema));
            JObject offersJObject = JObject.Parse(jsonContent);

            bool result = offersJObject.IsValid(schema);

            if (!result)
                throw new SchemaException();
        }
    }
}
