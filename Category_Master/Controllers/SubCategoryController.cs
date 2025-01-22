using Category_Master.Data;
using Category_Master.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Category_Master.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubCategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryMst>>> GetSubCategories()
        {
            return await _context.SubCategories.ToListAsync();
        }
        //public ActionResult GetSubCategories()
        //{
        //    return Ok(_context.SubCategories.ToList());
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryMst>> GetSubCategoryById(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);

            if (subCategory == null)
            {
                return NotFound();
            }
            return subCategory;
        }
        //public ActionResult GetSubCategory(int id)
        //{
        //    var subCategory = _context.SubCategories.Find(id);
        //    if (subCategory == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(subCategory);
        //}

        [HttpPost]
        public async Task<ActionResult<SubCategoryMst>> AddSubCategory(SubCategoryMst subCategoryMst)
        {
            _context.SubCategories.Add(subCategoryMst);
           await _context.SaveChangesAsync();
            return Ok(subCategoryMst);

        }
        //public IActionResult AddSubCategory(SubCategoryMst subCategoryMst)
        //{
        //    _context.SubCategories.Add(subCategoryMst);
        //    _context.SaveChanges();
        //    return Ok(subCategoryMst);
        //}

        [HttpPut]
        public async Task<ActionResult> UpdateSubCategory(int id, SubCategoryMst subCategoryMst)
        {
            if (id != subCategoryMst.Id)
            {
                return BadRequest();
            }

            _context.Entry(subCategoryMst).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //public IActionResult UpdateSubCategory(int id, SubCategoryMst subCategoryMst)
        //{
        //    if(id!= subCategoryMst.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(subCategoryMst).State= EntityState.Modified;
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var subCategory = _context.SubCategories.Find(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //public IActionResult DeleteSubCategory(int id)
        //{
        //    var subCategory = _context.SubCategories.Find(id);
        //    if (subCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.SubCategories.Remove(subCategory);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

    }
}
