using Proiect_DAW.Entities;
using Proiect_DAW.Models;
using System.Collections.Generic;

namespace Proiect_DAW.Managers
{
    public interface IItemsManager
    {
        List<Item> getItems();

        Item GetItemById(string id);

        void Create(ItemCreationModel model);
        void Update(ItemCreationModel model);
        void Delete(string id);
       
   
    }
}