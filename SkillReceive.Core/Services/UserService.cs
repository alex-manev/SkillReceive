using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Contracts;
using SkillReceive.Core.Models.Admin.User;
using SkillReceive.Infrastructure.Data.Common;
using SkillReceive.Infrastructure.Data.Models;

namespace SkillReceive.Core.Services
{
    public class UserService : IUserService
    {

        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
               .Include(u => u.Creator)
               .Select(u => new UserServiceModel()
               {
                   Email = u.Email,
                   FullName = $"{u.FirstName} {u.LastName}",
                   PhoneNumber = u.PhoneNumber,
                   IsCreator = u.Creator != null
               })
               .ToListAsync();

        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;
            
            var user =  await repository
                .GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result ;
        }
    }
}
