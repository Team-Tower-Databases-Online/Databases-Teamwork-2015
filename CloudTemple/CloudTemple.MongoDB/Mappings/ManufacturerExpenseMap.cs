namespace CloudTemple.MongoDB.Mappings
{
    using System;
    using global::MongoDB.Bson;
    using global::MongoDB.Bson.Serialization.Attributes;

    public class ManufacturerExpenseMap
    {
        [BsonConstructor]
        public ManufacturerExpenseMap()
        {
        }

        [BsonConstructor]
        public ManufacturerExpenseMap(DateTime reportDate, decimal expense, int manufacturerId)
        {
            this.ReportDate = reportDate;
            this.Expense = expense;
            this.ManufacturerId = manufacturerId;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public DateTime ReportDate { get; set; }

        public decimal Expense { get; set; }

        public int ManufacturerId { get; set; }
    }
}