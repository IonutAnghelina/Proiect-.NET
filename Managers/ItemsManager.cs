using Proiect_DAW.Entities;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Managers
{
    public class ItemsManager : IItemsManager
    {
        private readonly IItemsRepository itemsRepository;

        public ItemsManager(IItemsRepository itemRepository)
        {
            this.itemsRepository = itemRepository;
        }

        public void Create(ItemCreationModel model)
        {
            var newItm = new Item
            {
                Name = model.Name,
                Price = model.Price,
                Sport = model.Sport,
                Id = model.Id
            };

            itemsRepository.Create(newItm);
        }


        public void Update(ItemCreationModel model)
        {
            var newItm = GetItemById(model.Id);

            newItm.Name = model.Name;
            newItm.Price = model.Price;
            newItm.Sport = model.Sport;


            //itemsRepository.Update(newItm);


            itemsRepository.Update(newItm);

        }
        public void Delete(string id)
        {
            var newItm = GetItemById(id);
            //System.Diagnostics.Debug.WriteLine(id);

            itemsRepository.Delete(newItm);
        }

        public Item GetItemById(string id)
        {
            var itm = itemsRepository
                  .GetItemsIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return itm;
        }
        public List<Item> getItems()
        {
            return itemsRepository.GetItemsIQueriable().ToList();
        }

       
    }
}
