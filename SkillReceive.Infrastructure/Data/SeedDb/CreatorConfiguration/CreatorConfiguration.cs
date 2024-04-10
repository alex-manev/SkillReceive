using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillReceive.Infrastructure.Data.Models;

namespace SkillReceive.Infrastructure.Data.SeedDb.CreatorConfiguration
{
    internal class CreatorConfiguration : IEntityTypeConfiguration<Creator>
    {
        public void Configure(EntityTypeBuilder<Creator> builder)
        {
            var data = new SeedData();

            builder.HasData(new Creator[] { data.OnHandCourseCreator, data.OnlineCourseCreator });
        }
    }
}
