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
        public async Task<IActionResult> Get(string id, string name)
        {
            if (!string.IsNullOrEmpty(id) || !string.IsNullOrEmpty(name))
                return Ok(categoryBusiness.Get(id, name));
            else
                return Ok(categoryBusiness.Get<CategoryGetViewModel>());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category model)
        {
            var Id = categoryBusiness.Add(model);
            return Created("Get", new { Id });
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Category model)
        {
            var Id = categoryBusiness.Update(model);
            return Created("Get", new { Id });
        }
        [HttpDelete]
        public async Task<bool> Delete(string Id)
            => categoryBusiness.Delete(Id);

    }
}
