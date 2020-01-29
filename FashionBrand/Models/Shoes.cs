using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FashionBrand.Models
{
    public class Shoes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("brand")]
        public string brand { get; set; }
        public string model { get; set; }
        public double prize { get; set; }
        public string release { get; set; }
        public bool available { get; set; }

    }
}
