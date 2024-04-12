namespace SkillReceive.Core.Contracts.Creator
{
    public interface ICreatorService
    {
        Task<bool> ExistsByIdAsync(string userId);

        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);

        Task<bool> UserHasSkillsAsync(string userId);

        Task CreateAsync(string userId, string phoneNumber);

        Task<int?> GetCreatorIdAsync(string userId);


    }
}
