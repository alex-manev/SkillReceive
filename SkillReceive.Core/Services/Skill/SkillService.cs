using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Contracts.Skill;
using SkillReceive.Core.Enumerations;
using SkillReceive.Core.Models.Skill.Skills;
using SkillReceive.Infrastructure.Data.Common;
using SkillReceive.Infrastructure.Data.Models.Categories;

namespace SkillReceive.Core.Services.Skill
{
    public class SkillService : ISkillService
    {
        private readonly IRepository repository;

        public SkillService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<SkillQueryServiceModel> AllOnlineAsync(string? category = null, string? searchTerm = null, SkillSorting sorting = SkillSorting.Newest, int currPage = 1, int skillsPerPage = 1)
        {
            var onlineToShow = repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>();

            if (category != null)
            {
                onlineToShow = onlineToShow
                    .Where(h => h.Category.Name == category);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                onlineToShow = onlineToShow
                     .Where(s => (s.Title.ToLower().Contains(normalizedSearchTerm) ||
                     s.Description.ToLower().Contains( normalizedSearchTerm)));

            }

            onlineToShow = sorting switch
            {
                SkillSorting.Price => onlineToShow.OrderBy(s => s.PricePerMonth),
                SkillSorting.Participants => onlineToShow
                .OrderBy(s => s.Participants.Count())
                .ThenByDescending(s => s.Id),
                _ => onlineToShow.OrderByDescending(s => s.Id)
            };


            var onlineSkills = await onlineToShow
                .Skip((currPage - 1) * skillsPerPage)
                .Take(skillsPerPage)
                .Select(s => new SkillServiceModel()
                {
                    Id = s.Id,
                    ImageURL = s.ImageURL,
                    PricePerMonth = s.PricePerMonth,
                    Participants = s.Participants.Count(),
                    Title = s.Title

                }).ToListAsync();


            int totalSkills = await onlineToShow.CountAsync();

            return new SkillQueryServiceModel()
            {
                Skills = onlineSkills,
                TotalSkillsCount = totalSkills
            };
        }

        public async Task<SkillQueryServiceModel> AllOnHandAsync(string? category = null, string? searchTerm = null, SkillSorting sorting = SkillSorting.Newest, int currPage = 1, int skillsPerPage = 1)
        {
            var onHandToShow = repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>();


            if (category != null)
            {
                onHandToShow = onHandToShow
                    .Where(h => h.Category.Name == category);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                onHandToShow = onHandToShow
                     .Where(s => (s.Title.ToLower().Contains(normalizedSearchTerm) ||
                     s.Description.ToLower().Contains(normalizedSearchTerm)));
            }

            

            onHandToShow = sorting switch
            {
                SkillSorting.Price => onHandToShow.OrderBy(s => s.PricePerMonth),
                SkillSorting.Participants => onHandToShow
                .OrderBy(s => s.Participants.Count())
                .ThenByDescending(s => s.Id),
                _ => onHandToShow.OrderByDescending(s => s.Id)
            };

           

            var onHandskills = await onHandToShow
                .Skip((currPage - 1) * skillsPerPage)
                .Take(skillsPerPage)
                .Select(s => new SkillServiceModel()
                {
                    Id = s.Id,
                    ImageURL = s.ImageURL,
                    PricePerMonth = s.PricePerMonth,
                    Participants = s.Participants.Count(),
                    Title = s.Title

                }).ToListAsync();


            
            int totalSkills =  await onHandToShow.CountAsync();

            return new SkillQueryServiceModel()
            {
                Skills = onHandskills,
                TotalSkillsCount = totalSkills
            };
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
           var onlineCat =  await repository.AllReadOnly<OnlineCourseCategory>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();

            var onHandCat = await repository.AllReadOnly<OnHandExperienceCategory>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();

            var categories = onlineCat.Concat(onHandCat);

            return categories;
        }

        public async Task<IEnumerable<SkillIndexServiceModel>> LastFourSkillsAsync()
        {
            List<SkillIndexServiceModel> onlineCourses =
             await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                .OrderByDescending(h => h.Id)
                .Take(2)
                .Select(h => new SkillIndexServiceModel() 
                {
                    Id = h.Id,
                    ImageUrl = h.ImageURL,
                    Title = h.Title
                })
                .ToListAsync();

            List<SkillIndexServiceModel> onHandExperiences =
             await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                .OrderByDescending(h => h.Id)
                .Take(2)
                .Select(h => new SkillIndexServiceModel()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageURL,
                    Title = h.Title
                })
                .ToListAsync();

            var skills = onlineCourses.Concat(onHandExperiences);

            return skills;
        }

        public Task<IEnumerable<SkillServiceModel>> AllSkillsByCreatorIdAsync(int creatorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SkillServiceModel>> AllSkillsByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
