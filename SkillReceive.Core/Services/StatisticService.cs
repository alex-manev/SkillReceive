using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Contracts;
using SkillReceive.Core.Models.Statistics;
using SkillReceive.Infrastructure.Data.Common;

namespace SkillReceive.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<StatisticServiceModel> TotalAsync()
        {
            int totalSkills = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                .CountAsync() + await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                .CountAsync();

            int totalParticipants = 0;

            var onlineCourses = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                .Where(o => o.Participants.Count() > 0).ToListAsync();

            var onHands = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
               .Where(o => o.Participants.Count() > 0).ToListAsync();

            foreach (var item in onlineCourses)
            {
                totalParticipants += item.Participants.Count();
            }

            foreach (var item in onHands)
            {
                totalParticipants += item.Participants.Count();
            }

            return new StatisticServiceModel()
            {
                TotalSkills = totalSkills,
                TotalParticipants = totalParticipants,
            };
        }
    }
}
