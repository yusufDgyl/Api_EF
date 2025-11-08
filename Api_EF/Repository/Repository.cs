using MamiYummy.Data;
using MamiYummy.Interfaces;
using MamiYummy.Models;
using Microsoft.EntityFrameworkCore;

namespace MamiYummy.Repository
{
    public class Repository<T> : IReporsitory<T> where T : class    
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _products;
        public Repository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
            _products = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _products.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var silinecek = GetById(id);
            _products.Remove(silinecek);
            _appDbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            var liste = _products.ToList();
            return liste;
        }

        public T GetById(int id)
        {
            var yakalanan = _products.Find(id);
            return yakalanan;
        }

        public void Update(int id, T entity)
        {
            var guncelleme = _products.Find(id);
            _products.Update(guncelleme);
            _appDbContext.SaveChanges();
        }
    }
}
