using Proiect_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly ProiectContext db;

        public ItemsRepository(ProiectContext db)
        {
            this.db = db;
        }

        public void Create(Item itm)
        {
            db.Items.Add(itm);
            db.SaveChanges();
        }

        public void Update(Item itm)
        {
            db.Items.Update(itm);
            db.SaveChanges();
        }
        public void Delete(Item itm)
        {
            db.Items.Remove(itm);
            db.SaveChanges();
        }

        public IQueryable<Item> GetItemsIQueriable()
        {
            var items = db.Items;

            return items;
        }

       
    }
}
