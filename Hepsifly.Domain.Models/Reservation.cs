using Hepsifly.Domain.Models.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Hepsifly.Domain.Models
{
    public class Reservation : BaseModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
    }
}
