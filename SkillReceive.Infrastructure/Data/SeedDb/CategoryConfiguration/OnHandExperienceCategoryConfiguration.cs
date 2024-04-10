using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillReceive.Infrastructure.Data.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Infrastructure.Data.SeedDb.CategoryConfiguration
{
    internal class OnHandExperienceCategoryConfiguration : IEntityTypeConfiguration<OnHandExperienceCategory>
    {
        public void Configure(EntityTypeBuilder<OnHandExperienceCategory> builder)
        {
            var data = new SeedData();

            builder.HasData(new OnHandExperienceCategory[] { data.CulinaryCategory, data.ManualLaborCategory, data.SportsCategory });
        }
    }
}
