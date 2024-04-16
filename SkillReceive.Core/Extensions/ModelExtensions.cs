using SkillReceive.Core.Contracts;
using System.Text.RegularExpressions;

namespace SkillReceive.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ISkillModel skill)
        {
            string info =  skill.Title.Replace(" ","-");

            Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

    }
}
