using MongoDB.Bson;
using MongoDB.Driver;
using Poetry.Main.Domain.Models;
using Microsoft.Extensions.Options;

namespace Poetry.Main.Application.Queriers;

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