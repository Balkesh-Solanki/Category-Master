﻿using Category_Master.Data;
using Category_Master.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Category_Master.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryMst>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        //public IActionResult GetCategories() 
        //{
        //  return Ok(_context.Categories.ToList());
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryMst>> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            return category;
        }
        //public IActionResult GetCategory(int id)
        //{
        //    var category = _context.Categories.Find(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(category);
        //}

        [HttpPost]
        public async Task<ActionResult<CategoryMst>> AddCategory(CategoryMst categoryMst)
        {
            _context.Categories.Add(categoryMst);
            await _context.SaveChangesAsync();
            return Ok(categoryMst);

        }
        //public IActionResult AddCategory(CategoryMst categoryMst) 
        //{ 
        //    _context.Categories.Add(categoryMst);
        //    _context.SaveChanges();
        //    return Ok(categoryMst);
        //}

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(int id, CategoryMst categoryMst)
        {
            if (id != categoryMst.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoryMst).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //public IActionResult UpdateCategory(int id, CategoryMst categoryMst)
        //{
        //    if (id != categoryMst.Id)
        //    { 
        //        return BadRequest();
        //    }

        //    _context.Entry(categoryMst).State = EntityState.Modified;
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //public IActionResult DeleteCategory(int id)
        //{
        //    var category = _context.Categories.Find(id);
        //    if(category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Categories.Remove(category);
        //    _context.SaveChanges();
        //    return NoContent();
        //}
    }
}
