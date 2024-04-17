using SkillReceive.Core.Models.Admin;

namespace SkillReceive.Core.Contracts
{
    public interface IJoinService
    {
        Task<IEnumerable<JoinServiceModel>> AllAsync();
    }
}
