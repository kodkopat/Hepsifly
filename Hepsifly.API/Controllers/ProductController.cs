using Hepsifly.Domain;
using Hepsifly.Domain.Models;
using Hepsifly.Domain.ViewModels.Category;
using Hepsifly.Domain.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Hepsifly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductBusiness productBusiness;
        public ProductController
             (
            ProductBusiness productBusiness
             )
        {


            this.productBusiness = productBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id, string name)
        {
            if (!string.IsNullOrEmpty(id) || !string.IsNullOrEmpty(name))
                return Ok(productBusiness.Get(id, name));
            else
                return Ok(productBusiness.Get<ProductGetViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product model)
        {
            var Id = productBusiness.Add(model);
            return RedirectToAction("Get", new { Id });
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product model)
        {
            var Id = productBusiness.Update(model);
            return RedirectToAction("Get", new { Id });
        }
        [HttpDelete]
        public async Task<bool> Delete(string Id)
            => productBusiness.Delete(Id);

    }
}
