﻿namespace CloudTemple.Models
{
    using System.Collections.Generic;

    public class Product
    {
        private ICollection<Purchase> purchases;

        public Product()
        {
            this.purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public int CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; }

        public int DetailsId { get; set; }

        public virtual ProductDetails Details { get; set; }

        public ProductMeasureUnit Measure { get; set; }

        public decimal BasePrice { get; set; }

        public virtual ICollection<Purchase> Purchases
        {
            get
            {
                return this.purchases;
            }

            set
            {
                this.purchases = value;
            }
        }
    }
}