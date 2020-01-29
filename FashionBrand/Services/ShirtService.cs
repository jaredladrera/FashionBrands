using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using FashionBrand.Models;

namespace FashionBrand.Services
{
    public class ShirtService
    {
        private readonly IMongoCollection<Shirt> _shirt;

        public ShirtService(IFashionDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _shirt = database.GetCollection<Shirt>(settings.ShirtCollectionName);
        }

        public List<Shirt> Get() =>
            _shirt.Find(damit => true).ToList();

        public Shirt Get(string id) =>
            _shirt.Find<Shirt>(damit => damit.Id == id).FirstOrDefault();
        
        public Shirt Create(Shirt damit)
        {
            _shirt.InsertOne(damit);
            return damit;
        }

        public void Update(string id, Shirt damit) =>
            _shirt.ReplaceOne(shirt => shirt.Id == id, damit);

        public void Remove(Shirt shirt) =>
            _shirt.DeleteOne(damit => damit.Id == shirt.Id);

        public void Remove(string id) =>
            _shirt.DeleteOne(damit => damit.Id == id);
    }
}
