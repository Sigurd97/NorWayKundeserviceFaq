using Microsoft.EntityFrameworkCore;
using NorWayKundeserviceFaq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeserviceFaq.DataBase
{
    public class FaqDbContext : DbContext
    {
        public FaqDbContext(DbContextOptions<FaqDbContext> options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
