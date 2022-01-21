using Proiect_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public class ManagersRepository : IManagersRepository
    {

        private readonly ProiectContext db;

        public ManagersRepository(ProiectContext db)
        {
            this.db = db;
        }

        public void Create(Manager man)
        {
            db.Managers.Add(man);
            db.SaveChanges();
        }
        public void Update(Manager man)
        {
            db.Managers.Update(man);
            db.SaveChanges();
        }
        public void Delete(Manager man)
        {
            db.Managers.Remove(man);
            db.SaveChanges();
        }

        public IQueryable<Manager> GetManagersIQueriable()
        {
            var managers = db.Managers;

            return managers;
        }

        
    }
}
