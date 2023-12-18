using AlcoRest.Data;
using AlcoRest.Data.Models;
using AlcoRest.Interfaces;

namespace AlcoRest.Repos
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : BaseEntity
    {
        private AlcoContext alcoContext { get; set; }
        public BaseRepository(AlcoContext context)
        {
            alcoContext = context;
        }

        public TDbModel Create(TDbModel model)
        {
            alcoContext.Set<TDbModel>().Add(model);
            alcoContext.SaveChanges();
            return model;
        }

        public void Delete(int id)
        {
            var toDelete = alcoContext.Set<TDbModel>().FirstOrDefault(m => m.id == id);
            alcoContext.Set<TDbModel>().Remove(toDelete);
            alcoContext.SaveChanges();
        }

        public List<TDbModel> GetAll()
        {
            return alcoContext.Set<TDbModel>().ToList();
        }

        public TDbModel Update(TDbModel model)
        {
            var toUpdate = alcoContext.Set<TDbModel>().FirstOrDefault(m => m.id == model.id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            alcoContext.Update(toUpdate);
            alcoContext.SaveChanges();
            return toUpdate;
        }

        public TDbModel GetById(int id)
        {
            return alcoContext.Set<TDbModel>().FirstOrDefault(m => m.id == id);
        }
    }
}
