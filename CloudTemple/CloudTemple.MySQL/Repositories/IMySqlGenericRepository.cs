namespace CloudTemple.MySQL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    public interface IMySqlGenericRepository
    {
        void Add(Salereport entity);

        void AddMany(IEnumerable<Salereport> entities);

        void DeleteAllReports();

        IQueryable<Salereport> All();

        void SaveChanges();
    }
}