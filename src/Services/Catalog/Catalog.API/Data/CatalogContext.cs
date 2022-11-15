using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration config) { 
        var client = new MongoClient(config.GetValue<string>("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(config.GetValue<string>("DatabaseSettings:ConnectionString"));

            Products = database.GetCollection<Prodcut>(config.GetValue<string>("DatabaseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Products)

        }
        public IMongoCollection<Prodcut> Products { get; }
    }
}
