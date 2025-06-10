using AutoMapper;
using Hepsifly.Core;
using Hepsifly.Domain.Base;
using Hepsifly.Domain.Models;
using Hepsifly.Domain.ViewModels.Reservation;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Hepsifly.Domain
{
    public class ReservationBusiness : IBaseBusiness<Reservation>
    {
        private readonly MongoClient mongo;
        private IMongoDatabase database;
        private IMongoCollection<Reservation> reservations;
        private IMongoCollection<Product> products;
        public IMapper mapper { get; }
        public ReservationBusiness(MongoClient mongo, IMapper mapper)
        {
            this.mongo = mongo;
            this.mapper = mapper;
            this.database = mongo.GetDatabase("Hepsifly");
            this.reservations = database.GetCollection<Reservation>(nameof(Reservation));
            this.products = database.GetCollection<Product>(nameof(Product));
        }

        public IEnumerable<M> Get<M>()
        {
            return reservations
                .Aggregate()
                .Lookup("Product", "ProductId", "_id", @as: "Product")
                .Unwind("Product")
                .As<M>()
                .ToList();
        }

        public Reservation Get(string Id, string Name)
        {
            return reservations.Find(x => x.Id == Id).FirstOrDefault();
        }

        public string Add(Reservation model)
        {
            reservations.InsertOne(model);
            return model.Id;
        }

        public string Update(Reservation model)
        {
            reservations.ReplaceOne(x => x.Id == model.Id, model);
            return model.Id;
        }

        public bool Delete(string Id)
            => reservations.DeleteOne(x => x.Id == Id).DeletedCount > 0;
    }
}
