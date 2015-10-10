namespace CloudTemple.MongoDB.Mappings
{
    using global::MongoDB.Bson;
    using global::MongoDB.Bson.Serialization.Attributes;

    public class ProductTypeMap
    {
        [BsonConstructor]
        public ProductTypeMap(int productTypeId, string name)
        {
            this.ProductTypeId = productTypeId;
            this.Name = name;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public int ProductTypeId { get; set; }

        public string Name { get; set; }
    }
}