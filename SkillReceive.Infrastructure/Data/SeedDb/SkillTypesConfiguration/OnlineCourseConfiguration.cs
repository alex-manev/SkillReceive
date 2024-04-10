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
    internal class OnlineCourseConfiguration : IEntityTypeConfiguration<OnlineCourse>
    {
        public void Configure(EntityTypeBuilder<OnlineCourse> builder)
        {
            builder
                .HasOne(c => c.Category)
                .WithMany(oc => oc.OnlineCourses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Creator)
                .WithMany(oc => oc.OnlineCourses)
                .HasForeignKey(c => c.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new OnlineCourse[] { data.JsTutorial });

        }
    }
}
