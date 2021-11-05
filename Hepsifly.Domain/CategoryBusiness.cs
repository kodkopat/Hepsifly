using AutoMapper;
using Hepsifly.Core;
using Hepsifly.Domain.Base;
using Hepsifly.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain
{
    public class CategoryBusiness : IBaseBusiness<Category>
    {
        private readonly MongoClient mongo;
        private IMongoDatabase database;
        private IMongoCollection<Category> collection;
        public IMapper mapper { get; }
        public CategoryBusiness
            (
            MongoClient mongo,
            IMapper mapper
            )
        {
            this.mongo = mongo;
            this.mapper = mapper;
            this.database = mongo.GetDatabase("Hepsifly");
            this.collection = database.GetCollection<Category>(nameof(Category));
        }

        public virtual IEnumerable<M> Get<M>()
        {
            return collection
                .Aggregate()
                .As<M>()
                .ToList();
        }
        public virtual Category Get(string Id, string Name)
            => collection.Find<Category>(c => c.Id == Id || c.Name == Name).FirstOrDefault();
        public virtual string Add(Category model)
        {
            collection.InsertOne(model);
            return model.Id;
        }
        public virtual bool Delete(string Id)
            => collection.DeleteOne(x => x.Id == Id).DeletedCount > 0;
        public virtual string Update(Category Model)
        {
            collection.ReplaceOne(x => x.Id == Model.Id, Model);
            return Model.Id;
        }
    }
}
