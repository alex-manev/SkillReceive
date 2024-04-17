using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Contracts;
using SkillReceive.Core.Models.Admin;
using SkillReceive.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Core.Services
{
    public class JoinService : IJoinService
    {
        private readonly IRepository repository;

        public JoinService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<JoinServiceModel>> AllAsync()
        {
            var onlines =  await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                .Select(o => new JoinServiceModel()
                {
                    SkillImageURL = o.ImageURL,
                    CreatorEmail = o.Creator.User.Email,
                    CreatorFullName = $"{o.Creator.User.FirstName} {o.Creator.User.LastName}",
                    SkillTitle = o.Title,
                })
                .ToListAsync();

            var onHnads = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                .Select(o => new JoinServiceModel()
                {
                    SkillImageURL = o.ImageURL,
                    CreatorEmail = o.Creator.User.Email,
                    CreatorFullName = $"{o.Creator.User.FirstName} {o.Creator.User.LastName}",
                    SkillTitle = o.Title,
                })
                .ToListAsync();

            var skills = onlines.Concat(onHnads);

            return skills;
        }
    }
}
