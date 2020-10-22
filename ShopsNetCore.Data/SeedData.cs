using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopsNetCore.Core;
using System;
using System.Linq;

namespace ShopsNetCore.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ShopsDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ShopsDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Shops.Any() || context.Shops.Count() <= 1)
            {
                context.Shops.AddRange(
                    new Shop
                    {
                        Name = "H&M",
                        Description = "H&M Clothing Store",
                        AddressLineOne = "53 Livingston Road",
                        AddressLineTwo = "Wirral",
                        Postcode = "CH49 6LL",
                        ShopType = ShopType.Clothing,
                        OpeningTime = DateTime.Parse("14:30"),
                        ClosingTime = DateTime.Parse("17:30"),

                    },
                    new Shop
                    {
                        Name = "Pat's Bakery",
                        Description = "Pat's Bakery, For baking goods",
                        AddressLineOne = "124 Kingsley Street",
                        AddressLineTwo = "Wirral",
                        Postcode = "CH49 6LL",
                        ShopType = ShopType.Bakery,
                        OpeningTime = DateTime.Parse("12:30"),
                        ClosingTime = DateTime.Parse("18:30"),
                    }, new Shop
                    {
                        Name = "John's Barbers",
                        Description = "For Haircuts",
                        AddressLineOne = "4 Stevenson Road",
                        AddressLineTwo = "Wirral",
                        Postcode = "CH49 6LL",
                        ShopType = ShopType.Barbershop,
                        OpeningTime = DateTime.Parse("06:30"),
                        ClosingTime = DateTime.Parse("16:30"),

                    });
                context.SaveChanges();
            }
        }
    }
}
