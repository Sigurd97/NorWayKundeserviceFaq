using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorWayKundeserviceFaq.DataBase;
using NorWayKundeserviceFaq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeserviceFaq.Controllers
{ 
[Route("api/[controller]")]
[ApiController]
public class FaqController : ControllerBase
{
    private readonly FaqDbContext _context;

    public FaqController(FaqDbContext context)
    {
        _context = context;
    }

    // GET: api/Faq
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDataTransfer>>> GetFaqs()
    {
        var categories = await _context.Categories.ToListAsync();

        var cateogriesDto = new List<CategoryDataTransfer>();
        foreach (var category in categories)
        {
            var newCategoryDto = new CategoryDataTransfer
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };

            var questions = _context.Questions.Where(q => q.CategoryId == category.CategoryId).ToList();

            newCategoryDto.Questions = questions;

            cateogriesDto.Add(newCategoryDto);
        }

        return cateogriesDto;
    }
}
}