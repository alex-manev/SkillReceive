using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillReceive.Infrastructure.Data.Models;
using SkillReceive.Infrastructure.Data.Models.Categories;
using SkillReceive.Infrastructure.Data.Models.Skills;
using SkillReceive.Infrastructure.Data.SeedDb;
using SkillReceive.Infrastructure.Data.SeedDb.CategoryConfiguration;
using SkillReceive.Infrastructure.Data.SeedDb.CreatorConfiguration;
using SkillReceive.Infrastructure.Data.SeedDb.SkillTypesConfiguration;
using SkillReceive.Infrastructure.Data.SeedDb.UserConfiguration;

namespace SkillReceive.Infrastructure.Data
{
    public class SkillReceiveDbContext : IdentityDbContext<ApplicationUser>
    {
        public SkillReceiveDbContext(DbContextOptions<SkillReceiveDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CreatorConfiguration());
            builder.ApplyConfiguration(new OnHandExperienceCategoryConfiguration());
            builder.ApplyConfiguration(new OnlineCourseCategoryConfiguration());
            builder.ApplyConfiguration(new OnHandExperienceConfiguration());
            builder.ApplyConfiguration(new OnlineCourseConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());



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
