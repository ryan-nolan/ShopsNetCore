using ShopsNetCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsNetCore.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Shop> Shops { get; set; }
        //public string SearchTerm { get; set; }
    }
}
