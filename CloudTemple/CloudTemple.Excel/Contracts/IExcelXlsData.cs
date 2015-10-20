namespace CloudTemple.Excel.Contracts
{
    using System;
    using System.Collections.Generic;

    using Models;

    public interface IExcelXlsData
    {
        void ReadAllPurchases(Action<int, int, decimal, string, DateTime> action);

        void ReadAllPurchases(IDictionary<string, int> locationsMapping, Action<Purchase> action);

        void ReadAllPurchases(string zipFileLocation, Action<int, int, decimal, string, DateTime> action);
    }
}