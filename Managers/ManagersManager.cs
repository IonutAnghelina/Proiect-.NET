using Proiect_DAW.Entities;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Managers
{
    public class ManagersManager : IManagersManager
    {

        private readonly IManagersRepository managersRepository;

        public ManagersManager(IManagersRepository managerRepository)
        {
            this.managersRepository = managerRepository;
        }

        public void Create(ManagerCreationModel model)
        {
            var newMan = new Manager 
            {
               FirstName = model.FirstName,
               LastName = model.LastName,
               Id = model.Id
            };

            managersRepository.Create(newMan);
        }

        public void Update(ManagerCreationModel model)
        {
            var newMan = GetManagerById(model.Id);

            newMan.FirstName = model.FirstName;
            newMan.LastName = model.LastName;


            managersRepository.Update(newMan);

        }
        public void Delete(string id)
        {
            var newMan = GetManagerById(id);
            //System.Diagnostics.Debug.WriteLine(id);

            managersRepository.Delete(newMan);
        }

        public Manager GetManagerById(string id)
        {
            var man = managersRepository
                  .GetManagersIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return man;
        }
        public List<Manager> getManagers()
        {
            return managersRepository.GetManagersIQueriable().ToList();
        }

    }
}
