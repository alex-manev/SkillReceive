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

        public Task<bool> CreateAsync(string userId, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Creator>()
                .AnyAsync(c => c.UserId == userId);
        }

        public Task<bool> ExistsByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserHasSkillsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
