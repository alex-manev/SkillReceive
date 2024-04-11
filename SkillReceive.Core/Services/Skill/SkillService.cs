using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Contracts.Skill;
using SkillReceive.Core.Models.Skill.Skills;
using SkillReceive.Infrastructure.Data.Common;

namespace SkillReceive.Core.Services.Skill
{
    public class SkillService : ISkillService
    {
        private readonly IRepository repository;

        public SkillService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<SkillIndexServiceModel>> LastFourSkills()
        {
            List<SkillIndexServiceModel> onlineCourses =
             await repository.AllReadOnlyOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                .OrderByDescending(h => h.Id)
                .Take(2)
                .Select(h => new SkillIndexServiceModel() 
                {
                    Id = h.Id,
                    ImageUrl = h.ImageURL,
                    Title = h.Title
                })
                .ToListAsync();

            List<SkillIndexServiceModel> onHandExperiences =
             await repository.AllReadOnlyOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                .OrderByDescending(h => h.Id)
                .Take(2)
                .Select(h => new SkillIndexServiceModel()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageURL,
                    Title = h.Title
                })
                .ToListAsync();

            var skills = onlineCourses.Concat(onHandExperiences);

            return skills;
        }
    }
}
