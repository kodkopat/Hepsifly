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

        public IEnumerable<Category> Get()
        {
            throw new NotImplementedException();
        }

        public Category Get(string Id, string Name)
        {
            throw new NotImplementedException();
        }

        public string Add(Category model)
        {
            collection.InsertOne(model);
            return model.Id;
        }

        public string Update(Category Model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
