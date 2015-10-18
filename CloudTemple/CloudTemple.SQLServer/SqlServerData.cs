namespace CloudTemple.SQLServer
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    using Models;

    using Repositories;

    public class SqlServerData : ISqlServerData
    {
        private readonly ISqlServerDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public SqlServerData(ISqlServerDbContext dbContext)
        {
            this.context = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public SqlServerData()
            : this(new SqlServerDbContext())
        {
        }

        public IGenericRepository<Product> Products => this.GetRepository<Product>();

        public IGenericRepository<ProductCategory> ProductCategories => this.GetRepository<ProductCategory>();

        public IGenericRepository<ProductDetails> ProductDetails => this.GetRepository<ProductDetails>();

        public IGenericRepository<Purchase> Purchases => this.GetRepository<Purchase>();

        public IGenericRepository<PurchaseLocation> PurchaseLocations => this.GetRepository<PurchaseLocation>();

        public IGenericRepository<Vendor> Vendors => this.GetRepository<Vendor>();

        public IGenericRepository<VendorExpense> VendorExpenses => this.GetRepository<VendorExpense>();

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}