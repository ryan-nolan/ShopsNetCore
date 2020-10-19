using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopsNetCore.Core
{
    public class Shop
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [Required, StringLength(80)]
        public string Description { get; set; }

        [Required, StringLength(40)]
        public string Location { get; set; }

        public ShopType ShopType { get; set; }

        [Required, DataType(DataType.Time)]
        public DateTime OpeningTime { get; set; }

        [Required, DataType(DataType.Time)]
        public DateTime ClosingTime { get; set; }
    }
}

