using DTOModels.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApICoreCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _catService;

        public CategoryController(ICategoryService catService)
        {
            _catService = catService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var list = await _catService.GetAllAsync();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            if (id > 0)
            {
                var cat = await _catService.GetByIdAsync(id);
                if (cat != null)
                {
                    return Ok(cat);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                var IsCreated = await _catService.CreateAsync(categoryDTO);
                if (!IsCreated)
                {
                    return BadRequest();
                }
                return Ok(categoryDTO);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id ,CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                if(categoryDTO.Id == id)
                {
                   await _catService.UpdateAsync(categoryDTO);
                    return Ok(categoryDTO);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id) 
        {
            if(id > 0)
            {
                await _catService.DeleteAsync(id);
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
