namespace CloudTemple.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ManufacturerExpense
    {
        [Key]
        public int ExpenseId { get; set; }

        public DateTime ReportDate { get; set; }

        public decimal Expense { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}