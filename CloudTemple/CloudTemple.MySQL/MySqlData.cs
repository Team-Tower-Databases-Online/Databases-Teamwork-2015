namespace CloudTemple.MySQL
{
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    using Repositories;

    public class MySqlData
    {
        private readonly IMySqlGenericRepository salesReportRepository;

        public MySqlData(IMySqlGenericRepository salesReportRepositoryToUse)
        {
            this.salesReportRepository = salesReportRepositoryToUse;
        }

        public MySqlData()
            : this(new MySqlGenericRepository())
        {
        }

        public IQueryable<Salereport> LoadReports()
        {
            return this.salesReportRepository.All();
        }

        public void DeleteAllReports()
        {
            this.salesReportRepository.DeleteAllReports();
            this.salesReportRepository.SaveChanges();
        }

        public void SaveReports(IEnumerable<Salereport> reports)
        {
            this.salesReportRepository.AddMany(reports);

            this.salesReportRepository.SaveChanges();
        }
    }
}