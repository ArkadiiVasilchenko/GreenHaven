using IdentityService.Repositories;

namespace IdentityService.Services
{
    public interface IBaseService<TModel, T> where TModel : class where T : class
    {
        void Delete(T id);
        List<TModel> Read();
        TModel ReadById(T id);
    }
    public class BaseService<TModel, T> : IBaseService<TModel, T>
         where TModel : class
         where T : class
    {
        IBaseRepository<TModel, T> repository;
        public BaseService(IBaseRepository<TModel, T> repository)
        {
            this.repository = repository;
        }

        public void Delete(T id)
        {
            repository.Delete(id);
        }

        public List<TModel> Read()
        {
            return repository.Read();
        }

        public TModel ReadById(T id)
        {
            return repository.ReadById(id);
        }
    }
}
