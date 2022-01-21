using Proiect_DAW.Entities;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Managers
{
    public class ShopsManager : IShopsManager
    {
        private readonly IShopsRepository shopsRepository;

        public ShopsManager(IShopsRepository shopRepository)
        {
            this.shopsRepository = shopRepository;
        }
        public void Create(ShopCreationModel model)
        {
            var newShop = new Shop
            {
                Id = model.Id,
                ManagerId = model.ManagerId,
                City = model.City,
                OpenningDay = model.OpenningDay,
                NoEmployees = model.NoEmployees
            };

            shopsRepository.Create(newShop);
        }

        public void Update(ShopCreationModel model)
        {
            var newShop = GetShopById(model.Id);

            newShop.Id = model.Id;
            newShop.ManagerId = model.ManagerId;
            newShop.City = model.City;
            newShop.OpenningDay = model.OpenningDay;
            newShop.NoEmployees = model.NoEmployees;


            shopsRepository.Update(newShop);

        }

        public void Delete(string id)
        {
            var newShop = GetShopById(id);
            //System.Diagnostics.Debug.WriteLine(id);

            shopsRepository.Delete(newShop);
        }

        public Shop GetShopById(string id)
        {
            var shop = shopsRepository
                  .GetShopsIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return shop;
        }

        public List<Shop> getShops()
        {
            return shopsRepository.GetShopsIQueriable().ToList();
        }

        public List<Shop> GetShopsWithEmployees()
        {
            var shopsWithEmployees = shopsRepository.GetShopsWithEmployees();

            return shopsWithEmployees.ToList();
        }

        public List<ShopEmployeeModel> GetOrderedShops()
        {
            var orderedShops = shopsRepository.GetShopsWithEmployees()
               .Where(x => x.Employees.Count > 0)
               .Select(x => new ShopEmployeeModel { Id = x.Id, EmpName = x.Employees.FirstOrDefault().LastName })
               .OrderBy(x => x.EmpName)
               .ToList();

            return orderedShops;
        }

    }
}
