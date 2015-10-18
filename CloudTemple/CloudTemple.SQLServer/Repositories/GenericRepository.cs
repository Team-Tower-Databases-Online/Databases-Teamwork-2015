namespace CloudTemple.SQLServer.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Contracts;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ISqlServerDbContext context;

        public GenericRepository(ISqlServerDbContext dbContext)
        {
            this.context = dbContext;
        }

        public GenericRepository()
            : this(new SqlServerDbContext())
        {
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>().AsQueryable();
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public T GetById(int id)
        {
            try
            {
                return this.context.Set<T>().Find(id);
            }
            catch (Exception)
            {
                return this.context.Set<T>().FirstOrDefault();
            }
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return this.context.Set<T>().Where(predicate);
        }

        public void Detach(T entity)
        {
            this.ChangeState(entity, EntityState.Detached);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            this.context.Entry(entity).State = state;
        }
    }
}