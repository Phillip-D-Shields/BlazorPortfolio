using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.data;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // localhost:5001/api/categories

        private readonly AppDBContext _appDBContext;

        public CategoriesController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            List<Category> categories = await _appDBContext.Categories.ToListAsync();

            return Ok(categories);
        }
    }
}
