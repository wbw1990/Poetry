using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Poetry.Main.Domain.Models;

public class GuShi
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    
    [BsonElement("id")]
    public string SelfId { get; set; }
    
    [BsonElement("code")]
    public string Code { get; set; }
    
    
    [BsonElement("index")]
    public int Index { get; set; }
    
    [BsonElement("title")]
    public string Title { get; set; }
    
    [BsonElement("type")]
    public string Type { get; set; }
    
    [BsonElement("sort")]
    public int Sort { get; set; }
    
    [BsonElement("author")]
    public string Author { get; set; }
    
    [BsonElement("source")]
    public string Source { get; set; }
    
    [BsonElement("tag")]
    public string Tag { get; set; }
    
    [BsonElement("bj")]
    public string Bj { get; set; }
    
    [BsonElement("content")]
    public string Content { get; set; }
    
    [BsonElement("translation")]
    public string Translation { get; set; }
    
    [BsonElement("notes")]
    public string Notes { get; set; }
    
    [BsonElement("appreciation")]
    public IList<string> Appreciation { get; set; }
}