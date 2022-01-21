using Proiect_DAW.Entities;
using Proiect_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Managers
{
    public interface IManagersManager
    {
        List<Manager> getManagers();
        Manager GetManagerById(string id);
        void Create(ManagerCreationModel model);
        void Update(ManagerCreationModel model);
        void Delete(string id);

    }
}
