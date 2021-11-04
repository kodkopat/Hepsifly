using Hepsifly.Domain.Models.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
