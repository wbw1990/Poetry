using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using Poetry.Main.Domain.Models;
using Microsoft.Extensions.Options;

namespace Poetry.Main.Application.Queriers;
// https://www.bbsmax.com/A/pRdBa1Ee5n/
public class GuShiQueryHandler
{
    private readonly IMongoCollection<GuShi> _gsCollection;

    private String DatabaseName = "gs";
    private String MongoCollectionName = "gss";
    
    public GuShiQueryHandler(
        IOptions<MongoDatabaseSettings> gsDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            gsDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(DatabaseName);

        _gsCollection = mongoDatabase.GetCollection<GuShi>(MongoCollectionName);
    }
    
    public async Task<GuShi?> GetAsync(string id) =>
        await _gsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    
    public async Task<GuShi?> GetBySelfIdAsync(string id) =>
        await _gsCollection.Find(x => x.SelfId == id).FirstOrDefaultAsync();

    public async Task<GuShi?> GetByTitleAsync(string title,String author) =>
        await _gsCollection.Find(x => x.Title == title && x.Author == author).FirstOrDefaultAsync();


    public async Task<List<GuShi>?> GetListAsync(GetListQueryArgs query){
    

        var queryCondition = new BsonDocument();
        
        string keyword = query.key;
        //queryCondition.Add("Name", new BsonRegularExpression($"/{keyword}/"));

        //手动高亮
        var orLikeArray = new BsonArray {
            {
                new BsonDocument
                {
                    {"title",new BsonRegularExpression($"/{keyword}/") }
                }
            },
            {
                new BsonDocument
                {
                    {"author",new BsonRegularExpression($"/{keyword}/") }
                }
            },
            {
                new BsonDocument
                {
                    {"content",new BsonRegularExpression($"/{keyword}/") }
                }
            },
            {
                new BsonDocument
                {
                    {"tag",new BsonRegularExpression($"/{keyword}/") }
                }
            }
        };


        var bsonOr = new BsonDocument
        {
            {
                "$or",orLikeArray
            }
        };

        queryCondition.AddRange(bsonOr);
        
        var sort = Builders<BsonDocument>.Sort.Ascending("sort").ToBsonDocument();
        var result = _gsCollection.Find(queryCondition)
            // .Sort(sort)
            .Skip(query.start)
            .Limit(query.count).ToListAsync();

        return await result;
        //filter = filter.Regex("title", new BsonRegularExpression(new Regex(".*" + Regex.Escape(query.key) + ".*", RegexOptions.IgnoreCase)));
    }
    
        // var filter = _gsCollection.f
        // _gsCollection.Find()

    // public async Task<List<Book>> GetAsync() =>
    //     await _booksCollection.Find(_ => true).ToListAsync();
    //

    // public async Task CreateAsync(Book newBook) =>
    //     await _booksCollection.InsertOneAsync(newBook);
    //
    // public async Task UpdateAsync(string id, Book updatedBook) =>
    //     await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);
    //
    // public async Task RemoveAsync(string id) =>
    //     await _booksCollection.DeleteOneAsync(x => x.Id == id);
    //
    // public GuShi FindById(String id)
    // {
    //     var filter = Builders<BsonDocument>.Filter.Eq("student_id", 10000);
    // }
}