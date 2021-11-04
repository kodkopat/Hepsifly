﻿using AutoMapper;
using Hepsifly.Domain.Abstractions;
using Hepsifly.Domain.Models.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.Implementions
{
    public static partial class ExpressionUtils
    {
        public static Expression<Func<T, bool>> BuildPredicate<T>(string propertyName, string comparison, string value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var left = propertyName.Split('.').Aggregate((Expression)parameter, Expression.Property);
            var body = MakeComparison(left, comparison, value);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
        private static Expression MakeComparison(Expression left, string comparison, string value)
        {
            switch (comparison)
            {
                case "==":
                    return MakeBinary(ExpressionType.Equal, left, value);
                case "!=":
                    return MakeBinary(ExpressionType.NotEqual, left, value);
                case ">":
                    return MakeBinary(ExpressionType.GreaterThan, left, value);
                case ">=":
                    return MakeBinary(ExpressionType.GreaterThanOrEqual, left, value);
                case "<":
                    return MakeBinary(ExpressionType.LessThan, left, value);
                case "<=":
                    return MakeBinary(ExpressionType.LessThanOrEqual, left, value);
                case "Contains":
                case "StartsWith":
                case "EndsWith":
                    return Expression.Call(MakeString(left), comparison, Type.EmptyTypes, Expression.Constant(value, typeof(string)));
                default:
                    throw new NotSupportedException($"Invalid comparison operator '{comparison}'.");
            }
        }
        private static Expression MakeString(Expression source)
        {
            return source.Type == typeof(string) ? source : Expression.Call(source, "ToString", Type.EmptyTypes);
        }
        private static Expression MakeBinary(ExpressionType type, Expression left, string value)
        {
            object typedValue = value;
            if (left.Type != typeof(string))
            {
                if (string.IsNullOrEmpty(value))
                {
                    typedValue = null;
                    if (Nullable.GetUnderlyingType(left.Type) == null)
                        left = Expression.Convert(left, typeof(Nullable<>).MakeGenericType(left.Type));
                }
                else
                {
                    var valueType = Nullable.GetUnderlyingType(left.Type) ?? left.Type;
                    typedValue = valueType.IsEnum ? Enum.Parse(valueType, value) :
                        valueType == typeof(Guid) ? Guid.Parse(value) :
                        Convert.ChangeType(value, valueType);
                }
            }
            var right = Expression.Constant(typedValue, left.Type);
            return Expression.MakeBinary(type, left, right);
        }
    }
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
            this.collection = database.GetCollection<T>(nameof(T));
        }
        public virtual IEnumerable<M> Get<M>()
        {
            var ss = collection.Find<T>(_ => true).ToList();
            var data = mapper.Map<List<M>>(ss);
            return data;
        }
        public virtual M Get<M>(string Id)
        {
            var ss = collection.Find<T>()
                .FirstOrDefault();
            var data = mapper.Map<M>(ss);
            return data;
        }
        public virtual string Add<M>(M model)
        {
            var entity = mapper.Map<T>(model);
            collection.InsertOne(entity);
            return entity.GetType().GetProperty("Id").GetValue(entity).ToString();
        }
        public virtual bool Delete(string Id)
        {
            throw new NotImplementedException();
        }
        public virtual M Update<M>(M Model)
        {
            throw new NotImplementedException();
        }
    }
}
