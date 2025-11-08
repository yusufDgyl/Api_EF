using MamiYummy.Dto.Product;

namespace MamiYummy.Interfaces
{
    public interface IGeneralService<T,T2,T3> where T : class
    {
        void Add(T entity);//T Add
        void Update(int id, T2 entity); //T2 Update
        void Delete(int id);
        List<T3> GetAll();//T3 Get
        T3 GetById(int id);

    }
}
