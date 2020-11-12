using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorWayKundeserviceFaq.Models;
using System.Data.Common;
using System.Linq;
using System.Web;
using NorWayKundeserviceFaq.DataBase;

namespace NorWayKundeserviceFaq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserQuestionsController
    {
        private readonly FaqDbContext _context;

        public UserQuestionsController(FaqDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserQuestion>>> GetUserQuestions()
        {
            return await _context.UserQuestions.Include(uq => uq.Category).OrderByDescending(uq => uq.Id).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserQuestion>> GetUserQuestion(int id)
        {
            return await _context.UserQuestions.Include(uq => uq.Category).SingleAsync(uq => uq.Id == id);
        }

        // POST api/Kunde
        [HttpPost]
        public ActionResult<UserQuestion> Post([FromBody] UserQuestonDataTransfer inUserQuestion)
        {

            if (ModelState.Isvalid)
            {
                var userQuestion = new UserQuestion
                {
                    Firstname = inUserQuestion.firstname,
                    Lastname = inUserQuestion.lastname,
                    Question = inUserQuestion.question,
                    CategoryId = inUserQuestion.categoryId
                };

                try
                {
                    // lagre kunden
                    _context.UserQuestions.Add(userQuestion);
                    _context.SaveChanges();
                    return CreatedAtAction("GetUserQuestion", new { id = userQuestion.Id }, userQuestion);
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }
            return NotFound();
        }
    }
}
