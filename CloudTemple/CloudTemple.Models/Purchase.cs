﻿namespace CloudTemple.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Purchase
    {
        public int Id { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int LocationId { get; set; }

        public virtual PurchaseLocation Location { get; set; }

        [NotMapped]
        public decimal Sum => this.UnitPrice * this.Quantity;
    }
}