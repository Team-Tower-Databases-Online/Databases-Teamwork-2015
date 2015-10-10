namespace CloudTemple.MongoDB.Mappings
{
    using global::MongoDB.Bson;
    using global::MongoDB.Bson.Serialization.Attributes;

    public class CountryMap
    {
        [BsonConstructor]
        public CountryMap(int countryId, string name)
        {
            this.CountryId = countryId;
            this.Name = name;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public int CountryId { get; set; }

        public string Name { get; set; }
    }
}