namespace CloudTemple.MongoDB.Mappings
{
    using global::MongoDB.Bson;
    using global::MongoDB.Bson.Serialization.Attributes;

    public class ProductMap
    {
        [BsonConstructor]
        public ProductMap(
            int productId,
            string productName,
            string dimensions,
            double weight,
            int productTypeId,
            string shortDescription,
            int manufacturerId,
            int releaseYear,
            double price)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Dimensions = dimensions;
            this.Weight = weight;
            this.ProductTypeId = productTypeId;
            this.ShortDescription = shortDescription;
            this.ManufacturerId = manufacturerId;
            this.ReleaseYear = releaseYear;
            this.Price = price;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Dimensions { get; set; }

        public double Weight { get; set; }

        public int ProductTypeId { get; set; }

        public string ShortDescription { get; set; }

        public int ManufacturerId { get; set; }

        public int ReleaseYear { get; set; }

        public double Price { get; set; }
    }
}