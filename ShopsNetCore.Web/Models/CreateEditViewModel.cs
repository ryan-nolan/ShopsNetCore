using Microsoft.AspNetCore.Mvc.Rendering;
using ShopsNetCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsNetCore.Web.Models
{
    public class CreateEditViewModel
    {
        public Shop Shop { get; set; }
        public IEnumerable<SelectListItem> ShopType { get; set; }
    }
}
