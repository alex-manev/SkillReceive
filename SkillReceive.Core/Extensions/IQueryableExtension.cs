using SkillReceive.Core.Models.Skill.Skills;
using SkillReceive.Infrastructure.Data.Models.Skills;

namespace System.Linq
{
    public static class IQueryableSkillExtension
    {
        public static IQueryable<SkillServiceModel> ProjectOnlineCourse(this IQueryable<OnlineCourse> onlineCourses) 
        {
            return onlineCourses
                .Select(o => new SkillServiceModel()
                {
                    Id = o.Id,
                    ImageURL = o.ImageURL,
                    Title = o.Title,
                    PricePerMonth = o.PricePerMonth,
                    Participants = o.Participants.Count()
                });
        }

        public static IQueryable<SkillServiceModel> ProjectOnHand(this IQueryable<OnHandExperience> onHandExps)
        {
            return onHandExps
                .Select(o => new SkillServiceModel()
                {
                    Id = o.Id,
                    ImageURL = o.ImageURL,
                    Title = o.Title,
                    PricePerMonth = o.PricePerMonth,
                    Participants = o.Participants.Count()
                });
        }
    }
}
