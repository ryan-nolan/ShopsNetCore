using ShopsNetCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopsNetCore.Data
{
    public class EFShopRepository : IShopRepository
    {
        private readonly ShopsDbContext db;

        //Inject DbContext via constructor and save in a field
        public EFShopRepository(ShopsDbContext db)
        {
            this.db = db;
        }

        public Shop Add(Shop newShop)
        {
            db.Shops.Add(newShop);
            return newShop;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Shop Delete(int id)
        {
            Shop shop = GetById(id);
            if(shop != null)
            {
                db.Shops.Remove(shop);
            }
            return shop;
        }

        public Shop GetById(int id)
        {
            return db.Shops.Find(id);
        }

        public int GetCountOfShops()
        {
            return db.Shops.Count();
        }

        public IEnumerable<Shop> GetShopsByName(string name)
        {
            return db.Shops.Where(s => s.Name.StartsWith(name) || string.IsNullOrEmpty(name));
        }

        public Shop Update(Shop updatedShop)
        {
            var entity = db.Shops.Attach(updatedShop);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedShop;
        }
    }
}
