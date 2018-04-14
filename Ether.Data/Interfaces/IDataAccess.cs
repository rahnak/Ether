using System.Collections.Generic;

namespace Ether.Data.Interfaces
{
    public interface IDataAccess<T> where T : IEntity
    {
        List<T> GetAll();

        T GetById(int id);

        int Create(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}