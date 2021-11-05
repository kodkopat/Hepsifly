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
            => mapper.Map<List<M>>(collection.Find<Category>(_ => true).ToList());
        public virtual M Get<M>(string Id, string Name)
            => mapper.Map<M>(collection.Find<Category>(c => c.Id == Id || c.Name == Name).FirstOrDefault());
        public virtual string Add<M>(M model)
        {
            var entity = mapper.Map<Category>(model);
            collection.InsertOne(entity);
            return entity.Id;
        }
        public virtual bool Delete(string Id)
            => collection.DeleteOne(Helpers.MakeExpression<Category>("Id", Id)).DeletedCount > 0;
        public virtual string Update<M>(M Model)
        {
            var entity = mapper.Map<Category>(Model);
            collection.ReplaceOne(Helpers.MakeExpression<Category>("Id", entity.Id), entity);
            return entity.Id;
        }
    }
}
