using Microsoft.AspNetCore.Mvc.Rendering;
using ShopsNetCore.Core;
using System.Collections.Generic;

namespace ShopsNetCore.Web.Models
{
    public class CreateEditViewModel
    {
        public Shop Shop { get; set; }
        public IEnumerable<SelectListItem> ShopType { get; set; }
    }
}
