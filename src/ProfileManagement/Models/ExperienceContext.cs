using Microsoft.EntityFrameworkCore;

namespace ProfileManagement.Models
{
    public class ExperienceContext : DbContext
    {
        public ExperienceContext(DbContextOptions<ExperienceContext> options) : base(options)
        {

        }
        public DbSet<Experience> Experience { get; set; }
    }
}
