using TrungBook.WebApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TrungBook.WebApi.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Books> _booksCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _booksCollection = database.GetCollection<Books>(mongoDBSettings.Value.CollectionName);

    }

    public async Task CreateAsync(Books books)
    {
        await _booksCollection.InsertOneAsync(books);
        return;
    }

    public async Task<List<Books>> GetAsync()
    {
        return await _booksCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Books> filter = Builders<Books>.Filter.Eq("Id", id);
        await _booksCollection.DeleteOneAsync(filter);
        return;
    }


}