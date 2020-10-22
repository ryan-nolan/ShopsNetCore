using ShopsNetCore.Core;
using System.Collections.Generic;
using System.Linq;

namespace ShopsNetCore.Data
{
    public class EfShopRepository : IShopRepository
    {
        private readonly ShopsDbContext _db;

        //Inject DbContext via constructor and save in a field
        public EfShopRepository(ShopsDbContext db)
        {
            this._db = db;
        }

        public Shop Add(Shop newShop)
        {
            _db.Shops.Add(newShop);
            return newShop;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Shop Delete(int id)
        {
            Shop shop = GetById(id);
            if(shop != null)
            {
                _db.Shops.Remove(shop);
            }
            return shop;
        }

        public Shop GetById(int id)
        {
            return _db.Shops.Find(id);
        }

        public int GetCountOfShops()
        {
            return _db.Shops.Count();
        }

        public IEnumerable<Shop> GetShopsByName(string name)
        {
            return _db.Shops.Where(s => s.Name.StartsWith(name) || string.IsNullOrEmpty(name));
        }

        public Shop Update(Shop updatedShop)
        {
            var entity = _db.Shops.Attach(updatedShop);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return updatedShop;
        }
    }
}
