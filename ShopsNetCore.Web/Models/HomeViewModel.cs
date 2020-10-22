using ShopsNetCore.Core;
using System.Collections.Generic;

namespace ShopsNetCore.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Shop> Shops { get; set; }
        public string SearchTerm { get; set; }
    }
}
