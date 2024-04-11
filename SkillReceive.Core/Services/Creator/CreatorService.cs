using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Contracts.Creator;
using SkillReceive.Infrastructure.Data.Common;

namespace SkillReceive.Core.Services.Creator
{
    public class CreatorService : ICreatorService
    {
        private readonly IRepository repository;

        public CreatorService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new Infrastructure.Data.Models.Creator() 
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Creator>()
                .AnyAsync(c => c.UserId == userId);
        }

        public async Task<bool> UserHasSkillsAsync(string userId)
        {
            bool hasOnlineCourses =  await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                .AnyAsync(oc => oc.Creator.UserId == userId);

            bool hasOnHandExperiences = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                .AnyAsync(oc => oc.Creator.UserId == userId);

            if (hasOnHandExperiences || hasOnlineCourses)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Creator>()
                .AnyAsync (c => c.PhoneNumber == phoneNumber);
        }
    }
}
