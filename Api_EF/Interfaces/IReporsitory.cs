using MamiYummy.Models;

namespace MamiYummy.Interfaces
{
    public interface IReporsitory<T> where T : class
    {
        void Add(T entity);
        void Delete(int id);

        void Update(int id, T entity);

        List<T> GetAll();
        T GetById(int id);  

    }
}
