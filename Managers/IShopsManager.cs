using Proiect_DAW.Entities;
using Proiect_DAW.Models;
using System.Collections.Generic;

namespace Proiect_DAW.Managers
{
    public interface IShopsManager
    {
        List<Shop> getShops();

        Shop GetShopById(string id);

        void Create(ShopCreationModel model);

        void Update(ShopCreationModel model);

        void Delete(string id);

        List<Shop> GetShopsWithEmployees();

        List<ShopEmployeeModel> GetOrderedShops();
    }
}