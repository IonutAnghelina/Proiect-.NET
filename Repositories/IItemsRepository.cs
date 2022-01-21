using Proiect_DAW.Entities;
using System.Linq;

namespace Proiect_DAW.Repositories
{
    public interface IItemsRepository
    {
        IQueryable<Item> GetItemsIQueriable();

        void Create(Item itm);

        void Update(Item itm);

        void Delete(Item itm);
        


    }
}