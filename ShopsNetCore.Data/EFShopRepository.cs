using ShopsNetCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsNetCore.Data
{
    public class EFShopRepository : IShopData
    {
        private readonly ShopsDbContext db;

        //Inject DbContext in constructor
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
            throw new NotImplementedException();
        }

        public Shop GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfShops()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shop> GetShopsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Shop Update(Shop upatedShop)
        {
            throw new NotImplementedException();
        }
    }
}
