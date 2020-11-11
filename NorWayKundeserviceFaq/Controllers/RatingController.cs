using Microsoft.AspNetCore.Mvc;
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
    public class RatingController : ControllerBase
    {
        private readonly FaqDbContext _context;

        public RatingController(FaqDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string Get()
        {
            return "Get";
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<Question>> Like(int id)
        {
            if (id == default)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            question.Likes = question.Likes + 1;

            _context.Questions.Update(question);
            await _context.SaveChangesAsync();

            return question;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<Question>> Dislike(int id)
        {
            if (id == default)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            question.Dislikes = question.Dislikes + 1;

            _context.Questions.Update(question);
            await _context.SaveChangesAsync();

            return question;
        }
    }
}
