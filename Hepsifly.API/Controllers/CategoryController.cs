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
        public async Task<IEnumerable<Category>> Get()
            => categoryBusiness.Get();
        [HttpGet("{Id}")]
        public async Task<Category> Get(string Id, string Name)
         => categoryBusiness.Get(Id, Name);
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category model)
        {
            var Id = categoryBusiness.Add(model);
            return RedirectToAction("Get", new { Id });
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Category model)
        {
            var Id = categoryBusiness.Update(model);
            return RedirectToAction("Get", new { Id });
        }
        [HttpDelete("{Id}")]
        public async Task<bool> Delete(string Id)
            => categoryBusiness.Delete(Id);

    }
}
