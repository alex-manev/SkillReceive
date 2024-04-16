using Microsoft.AspNetCore.Identity;
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

            var users = await repository.AllReadOnly<IdentityUser>().CountAsync();

            
            return new StatisticServiceModel()
            {
                TotalSkills = totalSkills,
                TotalParticipants = users,
            };
        }
    }
}
