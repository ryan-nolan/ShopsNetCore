using ShopsNetCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsNetCore.Data
{
    public interface IShopData
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
