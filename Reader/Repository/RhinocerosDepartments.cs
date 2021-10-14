using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Reader.Repository
{

    [BsonIgnoreExtraElements]
    public class ObjetDepartment
    {
        [BsonId]        
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CodePostale")]
        public string CodePostale { get; set; }

        [BsonElement("DepartmentNom")]
        public string DepartmentNom { get; set; }

        [BsonElement("Population")]
        public int Population { get; set; }
    }

}
