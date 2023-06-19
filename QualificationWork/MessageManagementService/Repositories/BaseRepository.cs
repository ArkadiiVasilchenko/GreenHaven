using IdentityService.Data;
using Microsoft.EntityFrameworkCore;

namespace MessageManagementService.Repositories
{
    public interface IBaseRepository<TModel, T>
    {
        void Create(TModel entity);
        void Delete(T id);
        List<TModel> Read();
        TModel ReadById(T id);
        void Update(TModel entity);
    }

    public class BaseRepository<TModel, T> : IBaseRepository<TModel, T>
         where TModel : class
         where T : class
    {
        public AppDbContext repositoryContext { get; set; }
        private DbSet<TModel> table = null;

        public BaseRepository(AppDbContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
            table = repositoryContext.Set<TModel>();
        }

        public void Create(TModel entity)
        {
            table.Add(entity);
            repositoryContext.SaveChanges();
        }

        public void Delete(T id)
        {
            var entity = table.Find(id);
            table.Remove(entity);
            repositoryContext.SaveChanges();
        }

        public List<TModel> Read()
        {
            List<TModel> list = new List<TModel>();
            foreach (var model in table)
            {
                list.Add(model);
            }
            return list;
        }

        public TModel ReadById(T id)
        {
            return table.Find(id);
        }

        public void Update(TModel entity)
        {
            table.Update(entity);
            repositoryContext.SaveChanges();
        }
    }
}
