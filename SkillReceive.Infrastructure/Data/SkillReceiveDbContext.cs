using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillReceive.Infrastructure.Data.Models;
using SkillReceive.Infrastructure.Data.Models.Categories;
using SkillReceive.Infrastructure.Data.Models.Skills;

namespace SkillReceive.Infrastructure.Data
{
    public class SkillReceiveDbContext : IdentityDbContext
    {
        public SkillReceiveDbContext(DbContextOptions<SkillReceiveDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        // Creators DbSet
        public DbSet<Creator> Creators { get; set; } = null!;

        //Categories DbSets

        public DbSet<OnHandExperienceCategory> OnHandExperienceCategories { get; set; } = null!;

        public DbSet<OnlineCourseCategory> OnlineCourseCategories { get; set; } = null!;

        //Skills DbSets

        public DbSet<OnHandExperience> OnHandExperiences { get; set; } = null!;

        public DbSet<OnlineCourse> OnlineCourses { get; set; } = null!;
    }
}
