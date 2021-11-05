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
    public class ProductBusiness : IBaseBusiness<Product>
    {
        private readonly MongoClient mongo;
        private IMongoDatabase database;
        private IMongoCollection<Product> collection;
        public IMapper mapper { get; }
        public ProductBusiness
            (
            MongoClient mongo,
            IMapper mapper
            )
        {
            this.mongo = mongo;
            this.mapper = mapper;
            this.database = mongo.GetDatabase("Hepsifly");
            this.collection = database.GetCollection<Product>(nameof(Product));
        }
        public virtual IEnumerable<M> Get<M>()
            => mapper.Map<List<M>>(collection.Find<Product>(_ => true).ToList());
        public virtual M Get<M>(string Id)
            => mapper.Map<M>(collection.Find<Product>(x => x.Id == Id).FirstOrDefault());
        public virtual string Add<M>(M model)
        {
            var entity = mapper.Map<Product>(model);
            collection.InsertOne(entity);
            return entity.Id;
        }
        public virtual bool Delete(string Id)
            => collection.DeleteOne(x => x.Id == Id).DeletedCount > 0;
        public virtual string Update<M>(M Model)
        {
            var entity = mapper.Map<Product>(Model);
            collection.ReplaceOne(x => x.Id == entity.Id, entity);
            return entity.Id;
        }
    }
}
