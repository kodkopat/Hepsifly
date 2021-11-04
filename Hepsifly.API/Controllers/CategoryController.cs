using Hepsifly.Domain;
using Hepsifly.Domain.Models;
using Hepsifly.Domain.ViewModels.Category;
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
    public class CategoryController : ControllerBase
    {
        private CategoryBusiness categoryBusiness;
        public CategoryController
             (
            CategoryBusiness categoryBusiness
             )
        {
            this.categoryBusiness = categoryBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryGetViewModel>> Get() 
            => categoryBusiness.Get<CategoryGetViewModel>();
        [HttpGet("{id}")]
        public async Task<CategoryGetViewModel> Get(string Id)
         => categoryBusiness.Get<CategoryGetViewModel>(Id);
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategorySaveViewModel model)
        {
            var Id = categoryBusiness.Add(model);
            return RedirectToAction("Get", new { Id });
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
