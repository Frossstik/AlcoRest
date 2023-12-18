using AlcoRest.Data.Models;

namespace AlcoRest.Interfaces
{
    public interface IBaseRepository<TDbModel> where TDbModel : BaseEntity
    {
        public List<TDbModel> GetAll();
        public TDbModel GetById(int id);
        public TDbModel Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(int id);
    }
}
