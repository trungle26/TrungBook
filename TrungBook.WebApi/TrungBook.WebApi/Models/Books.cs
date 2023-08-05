using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;


namespace TrungBook.WebApi.Models
{
    public class Books
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("title")]
        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [BsonElement("author")]
        [JsonPropertyName("author")]
        public string Author { get; set; } = null!;

        [BsonElement("genre")]
        [JsonPropertyName("genre")]
        public string Genre { get; set; } = null!;

        [BsonElement("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [BsonElement("cover_image_url")]
        [JsonPropertyName("cover_image_url")]
        public string CoverImageUrl { get; set; } = null!;

        [BsonElement("epub_file")]
        [JsonPropertyName("epub_file")]
        public EpubFile EpubFile { get; set; } = null!;
    }

    public class EpubFile
    {
        [BsonElement("filename")]
        [JsonPropertyName("filename")]
        public string Filename { get; set; } = null!;

        [BsonElement("contentType")]
        [JsonPropertyName("contentType")]
        public string ContentType { get; set; } = null!;

        [BsonElement("data")]
        [JsonPropertyName("data")]
        public byte[] Data { get; set; } = null!;
    }

}
