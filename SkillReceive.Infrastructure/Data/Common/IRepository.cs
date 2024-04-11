namespace SkillReceive.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnlyOnly<T>() where T : class;
    }
}
