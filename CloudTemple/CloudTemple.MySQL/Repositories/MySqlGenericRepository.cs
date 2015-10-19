namespace CloudTemple.MySQL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    public class MySqlGenericRepository : IMySqlGenericRepository
    {
        private readonly MySqlDbContext context;

        public MySqlGenericRepository(MySqlDbContext contextToUse)
        {
            this.context = contextToUse;
        }

        public MySqlGenericRepository()
            : this(new MySqlDbContext())
        {
        }

        public void Add(Salereport entity)
        {
            this.context.Add(entity);
        }

        public void AddMany(IEnumerable<Salereport> entities)
        {
            this.context.Add(entities);
        }

        public void DeleteAllReports()
        {
            this.context.Delete(this.context.Salereports);
        }

        public IQueryable<Salereport> All()
        {
            return this.context.Salereports;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}