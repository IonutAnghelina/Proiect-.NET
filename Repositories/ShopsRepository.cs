using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public class ShopsRepository : IShopsRepository
    {
        private readonly ProiectContext db;


        public ShopsRepository(ProiectContext db)
        {
            this.db = db;
        }

        public void Create(Shop shop)
        {
            db.Shops.Add(shop);
            db.SaveChanges();
        }

        public void Update(Shop shop)
        {
            db.Shops.Update(shop);
            db.SaveChanges();
        }
        public void Delete(Shop shop)
        {
            db.Shops.Remove(shop);
            db.SaveChanges();
        }
        public IQueryable<Shop> GetShopsIQueriable()
        {
            var shops = db.Shops;

            return shops;
        }

        public IQueryable<Shop> GetShopsWithEmployees()
        {
            var shops = GetShopsIQueriable().Include(x => x.Employees);

            return shops;
        }
    }
}
