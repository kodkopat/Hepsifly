using Hepsifly.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Hepsifly.EntityFramework.Mappings
{
    public class MapperCategory
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(x =>
            {
            });
        }
    }
}
