namespace CloudTemple.MongoDB.Mappings
{
    using global::MongoDB.Bson;
    using global::MongoDB.Bson.Serialization.Attributes;

    public class CityMap
    {
        [BsonConstructor]
        public CityMap(int cityId, int countryId, string name)
        {
            this.CityId = cityId;
            this.CountryId = countryId;
            this.Name = name;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public int CityId { get; set; }

        public int CountryId { get; set; }

        public string Name { get; set; }
    }
}