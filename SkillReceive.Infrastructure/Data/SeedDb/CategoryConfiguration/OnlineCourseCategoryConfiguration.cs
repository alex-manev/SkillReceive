using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillReceive.Infrastructure.Data.Models.Categories;

namespace SkillReceive.Infrastructure.Data.SeedDb.CategoryConfiguration
{
    internal class OnlineCourseCategoryConfiguration : IEntityTypeConfiguration<OnlineCourseCategory>
    {
        public void Configure(EntityTypeBuilder<OnlineCourseCategory> builder)
        {
            var data = new SeedData();

            builder.HasData(new OnlineCourseCategory[] {data.DesignArtsCategory,data.ProgrammingCategory,data.BusinessManagementCategory });
        }
    }
}
