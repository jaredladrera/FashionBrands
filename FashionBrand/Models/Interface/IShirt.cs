using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionBrand.Models.Interface
{
    public interface IShirt
    {
        string Id { get; set; }
        string brand { get; set; }
        string color { get; set; }
        string type { get; set; }
        double prize { get; set; }
        bool available { get; set; }
    }
}
