using AutoMapper;
using Hepsifly.Domain.Implementions;
using Hepsifly.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain
{
    public class CategoryBusiness : BaseBusiness<Category>
    {
        public CategoryBusiness
            (
            MongoClient mongo,
            IMapper mapper
            ) : base(mongo, mapper)
        {
        }


    }
}
