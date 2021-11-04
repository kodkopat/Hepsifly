using AutoMapper;
using Hepsifly.Core;
using Hepsifly.Domain.Abstractions;
using Hepsifly.Domain.Models.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.Implementions
{

    public class BaseBusiness<T> : IBaseBusiness<T> where T : class
    {
        private readonly MongoClient mongo;
        private IMongoDatabase database;
        private IMongoCollection<T> collection;
        public IMapper mapper { get; }
        public BaseBusiness
            (
            MongoClient mongo,
            IMapper mapper
            )
        {
            this.mongo = mongo;
            this.mapper = mapper;
            this.database = mongo.GetDatabase("Hepsifly");
            this.collection = database.GetCollection<T>(typeof(T).Name);
        }
        public virtual IEnumerable<M> Get<M>()
            => mapper.Map<List<M>>(collection.Find<T>(_ => true).ToList());
        public virtual M Get<M>(string Id)
            => mapper.Map<M>(collection.Find<T>(Helpers.MakeExpression<T>("Id", Id)).FirstOrDefault());
        public virtual string Add<M>(M model)
        {
            var entity = mapper.Map<T>(model);
            collection.InsertOne(entity);
            return entity.GetType().GetProperty("Id").GetValue(entity).ToString();
        }
        public virtual bool Delete(string Id)
            => collection.DeleteOne(Helpers.MakeExpression<T>("Id", Id)).DeletedCount > 0;
        public virtual string Update<M>(M Model)
        {
            var entity = mapper.Map<T>(Model);
            var id = entity.GetType().GetProperty("Id").GetValue(entity).ToString();
            collection.ReplaceOne(Helpers.MakeExpression<T>("Id", id), entity);
            return id;
        }
    }
}
