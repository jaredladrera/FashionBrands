using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using FashionBrand.Models;

namespace FashionBrand.Services
{
    public class ShoeService
    {
        private readonly IMongoCollection<Shoes> _shoe;

        public ShoeService(IFashionDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _shoe = database.GetCollection<Shoes>(settings.ShoesCollectionName);
        }

        public List<Shoes> Get() =>
            _shoe.Find(sapatos => true).ToList();


        public Shoes Get(string id) =>
            _shoe.Find<Shoes>(sapatos => sapatos.Id == id).FirstOrDefault();
        
        public Shoes Gawa(Shoes sapatos)
        {
            _shoe.InsertOne(sapatos);
            return sapatos;
        }

        public void Updating(string id, Shoes sapatos) => 
            _shoe.ReplaceOne(shoe => shoe.Id == id, sapatos);
        
           
        public void Burahin(Shoes sapatos) =>
            _shoe.DeleteOne(shoe => shoe.Id == sapatos.Id);

        public void Burahin(string id) =>
            _shoe.DeleteOne(sapatos => sapatos.Id == id);

    }
}
