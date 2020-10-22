using ShopsNetCore.Core;
using System.Collections.Generic;

namespace ShopsNetCore.Data
{
    public interface IShopRepository
    {
        IEnumerable<Shop> GetShopsByName(string name);
        Shop GetById(int id);
        Shop Update(Shop updatedShop);
        Shop Add(Shop newShop);
        Shop Delete(int id);
        int GetCountOfShops();
        int Commit();
    }
}
