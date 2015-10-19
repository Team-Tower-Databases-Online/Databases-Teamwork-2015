namespace CloudTemple.MySQL.Models
{
    using System.Linq;

    using Telerik.OpenAccess;

    public interface IMySqlDbContextUnitOfWork : IUnitOfWork
    {
        IQueryable<Salereport> Salereports { get; }
    }
}