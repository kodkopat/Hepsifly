using Hepsifly.Domain;
using Hepsifly.Domain.Models;
using Hepsifly.Domain.ViewModels.Category;
using Hepsifly.Domain.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<ProductGetViewModel>> Get()
            => productBusiness.Get<ProductGetViewModel>();
        [HttpGet("{Id}")]
        public async Task<ProductGetViewModel> Get(string Id)
         => productBusiness.Get<ProductGetViewModel>(Id);
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductSaveViewModel model)
        {
            var Id = productBusiness.Add(model);
            return RedirectToAction("Get", new { Id });
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductSaveViewModel model)
        {
            var Id = productBusiness.Update(model);
            return RedirectToAction("Get", new { Id });
        }
        [HttpDelete("{Id}")]
        public async Task<bool> Delete(string Id)
            => productBusiness.Delete(Id);

    }
}
