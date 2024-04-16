using SkillReceive.Core.Models.Statistics;

namespace SkillReceive.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}
