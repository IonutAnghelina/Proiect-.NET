using Proiect_DAW.Entities;
using System.Linq;

namespace Proiect_DAW.Repositories
{
    public interface IShopsRepository
    {
        IQueryable<Shop> GetShopsIQueriable();
        IQueryable<Shop> GetShopsWithEmployees();
        void Create(Shop shop);

        void Update(Shop shop);

        void Delete(Shop shop);

    }
}