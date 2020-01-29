using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using FashionBrand.Models.Interface;

namespace FashionBrand.Models
{
    public class Shirt : IShirt
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Brand")]
        public string brand { get; set; }
        public string color { get; set; }
        public string type { get; set; }
        public double prize { get; set; }
        public bool available { get; set; }
    }
}
