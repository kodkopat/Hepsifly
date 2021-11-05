using Hepsifly.Domain.Models.Base;
using Hepsifly.Domain.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CurrencyType Currency { get; set; }
        public string CategoryId { get; set; }

    }
}
