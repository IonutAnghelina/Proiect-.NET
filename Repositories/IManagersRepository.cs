using Proiect_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public interface IManagersRepository
    {

        IQueryable<Manager> GetManagersIQueriable();

        void Create(Manager man);
        void Update(Manager man);
        void Delete(Manager man);

    }
}
