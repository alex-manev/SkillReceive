using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillReceive.Infrastructure.Data.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Infrastructure.Data.SeedDb.SkillTypesConfiguration
{
    internal class OnHandExperienceConfiguration : IEntityTypeConfiguration<OnHandExperience>
    {
        public void Configure(EntityTypeBuilder<OnHandExperience> builder)
        {
            builder
                .HasOne(c => c.Category)
                .WithMany(oe => oe.OnHandExperiences)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Creator)
                .WithMany(oe => oe.OnHandExperiences)
                .HasForeignKey(c => c.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new OnHandExperience[] { data.VolleyballLessons });
        }
    }
}
