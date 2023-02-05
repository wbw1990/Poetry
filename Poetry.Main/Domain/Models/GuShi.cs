using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Poetry.Main.Domain.Models;

public class GuShi
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    
    [BsonElement("id")]
    public String SelfId { get; set; }
    
    [BsonElement("code")]
    public String Code { get; set; }
    
    [BsonElement("title")]
    public String Title { get; set; }
    
    [BsonElement("type")]
    public String Type { get; set; }
    
    [BsonElement("sort")]
    public int Sort { get; set; }
    
    [BsonElement("author")]
    public String Author { get; set; }
    
    [BsonElement("source")]
    public String Source { get; set; }
    
    [BsonElement("tag")]
    public String Tag { get; set; }
    
    [BsonElement("bj")]
    public String Bj { get; set; }
    
    [BsonElement("content")]
    public String Content { get; set; }
    
    [BsonElement("translation")]
    public String Translation { get; set; }
    
    [BsonElement("notes")]
    public String Notes { get; set; }
    
    [BsonElement("appreciation")]
    public IList<String> Appreciation { get; set; }
}