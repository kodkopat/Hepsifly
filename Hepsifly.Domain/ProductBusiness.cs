using AutoMapper;
using Hepsifly.Core;
using Hepsifly.Domain.Base;
using Hepsifly.Domain.Models;
using Hepsifly.Domain.ViewModels.Product;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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
        private IMongoCollection<Product> products;
        private IMongoCollection<Category> categories;
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
            this.products = database.GetCollection<Product>(nameof(Product));
            this.categories = database.GetCollection<Category>(nameof(Category));
        }
        public virtual IEnumerable<M> Get<M>()
        {

            return products
                .Aggregate()
                .Lookup("Category", "CategoryId", "_id", @as: "Category")
                .Unwind("Category")
                .As<M>()
                .ToList();

             
        }
        public virtual Product Get(string Id, string Name)
            => products.Find<Product>(c => c.Id == Id || c.Name == Name).FirstOrDefault();
        public virtual string Add(Product model)
        {
            products.InsertOne(model);
            return model.Id;
        }
        public virtual bool Delete(string Id)
            => products.DeleteOne(x => x.Id == Id).DeletedCount > 0;
        public virtual string Update(Product Model)
        {
            products.ReplaceOne(x => x.Id == Model.Id, Model);
            return Model.Id;
        }


    }
}
