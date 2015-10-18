namespace CloudTemple.XML
{
    using System.Collections.Generic;

    using Models;

    using ReportsModels;

    public interface IXmlData
    {
        IEnumerable<VendorExpense> GetAllVendorExpenses();

        void GenerateAllLocationsReport(IEnumerable<LocationReport> locationReports);
    }
}