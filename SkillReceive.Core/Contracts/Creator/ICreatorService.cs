namespace SkillReceive.Core.Contracts.Creator
{
    public interface ICreatorService
    {
        Task<bool> ExistsByIdAsync(string userId);

        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);

        Task<bool> UserHasSkillsAsync(string userId);

        Task<bool> CreateAsync(string userId, string phoneNumber);


    }
}
