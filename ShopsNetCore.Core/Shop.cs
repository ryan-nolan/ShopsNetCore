using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DisplayName("Address Line 1")]
        public string AddressLineOne { get; set; }

        [Required, StringLength(40)]
        [DisplayName("Address Line 2")]
        public string AddressLineTwo { get; set; }

        [Required, StringLength(40),
            RegularExpression(@"([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})")]
        public string Postcode { get; set; }
        [DisplayName("Type")]
        public ShopType ShopType { get; set; }

        [Required, DataType(DataType.Time)]
        public DateTime OpeningTime { get; set; }
        [Required, DataType(DataType.Time)]
        public DateTime ClosingTime { get; set; }
    }
}

