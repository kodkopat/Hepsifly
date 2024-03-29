﻿using Hepsifly.Domain.ViewModels.Base;
using Hepsifly.Domain.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.Domain.ViewModels.Category
{
    public class CategoryGetViewModel: BaseViewModelModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
