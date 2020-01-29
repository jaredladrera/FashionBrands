using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionBrand.Models
{
    public class FashionDatabaseSettings : IFashionDatabaseSettings
    {
        public string ShoesCollectionName { get; set; }
        public string ShirtCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IFashionDatabaseSettings
    {
        string ShoesCollectionName { get; set; }
        string ShirtCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
