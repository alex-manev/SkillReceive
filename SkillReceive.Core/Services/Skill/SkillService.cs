﻿using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Contracts.Skill;
using SkillReceive.Core.Enumerations;
using SkillReceive.Core.Models.Skill.OnHandExperience;
using SkillReceive.Core.Models.Skill.OnlineCourse;
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
                .ProjectOnlineCourse()
                .ToListAsync();


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
                .ProjectOnHand()
                .ToListAsync();


            
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

        public async Task<IEnumerable<SkillServiceModel>> AllOnlineSkillsByCreatorIdAsync(int creatorId)
        {
            var onlineCourses =  await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                 .Where(c => c.CreatorId == creatorId)
                 .ProjectOnlineCourse()
                 .ToListAsync();

            return onlineCourses;
        }

        public async Task<IEnumerable<SkillServiceModel>> AllOnHandSkillsByCreatorIdAsync(int creatorId)
        {
            var onHandExps = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                 .Where(c => c.CreatorId == creatorId)
                 .ProjectOnHand()
                 .ToListAsync();

            
            return onHandExps;
        }

        public async Task<IEnumerable<SkillServiceModel>> AllOnlineSkillsByUserId(string userId)
        {
            var onlineCourses = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                 .Where(c => c.Participants.Any(p => p.Id == userId))
                 .ProjectOnlineCourse()
                 .ToListAsync();

            return onlineCourses;
        }


        public async Task<IEnumerable<SkillServiceModel>> AllOnHandSkillsByUserId(string userId)
        {
            var onHandExps = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                 .Where(c => c.Participants.Any(p => p.Id == userId))
                 .ProjectOnHand()
                 .ToListAsync();
            return onHandExps;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            bool onlineExist = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                .AnyAsync(o => o.Id == id);

            bool onHandExist = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                .AnyAsync(o => o.Id == id);

            if (onlineExist || onHandExist)
            {
                return true;
            }
            return false;
        }

        public async Task<OnlineDetailServiceModel> OnlineDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                .Where(o => o.Id == id)
                .Select(o => new OnlineDetailServiceModel()
                { 
                   Id = o.Id,
                   NeededTechnologies = o.NeededTechnologies,
                   Creator = new Models.Creator.CreatorServiceModel() 
                   {
                       Email = o.Creator.User.Email,
                       PhoneNumber = o.Creator.PhoneNumber,
                   },
                   Category = o.Category.Name,
                   Description = o.Description,
                   ImageURL = o.ImageURL,
                   Participants = o.Participants.Count(),
                   PricePerMonth = o.PricePerMonth,
                   Title = o.Title
                }
                )
                .FirstAsync();

        }

        public async Task<OnHandDetailsServiceModel> OnHandDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                .Where(o => o.Id == id)
                .Select(o => new OnHandDetailsServiceModel()
                {
                    Id = o.Id,
                    Location = o.Location,
                    Requirements = o.Requirements,  
                    Creator = new Models.Creator.CreatorServiceModel()
                    {
                        Email = o.Creator.User.Email,
                        PhoneNumber = o.Creator.PhoneNumber,
                    },
                    Category = o.Category.Name,
                    Description = o.Description,
                    ImageURL = o.ImageURL,
                    Participants = o.Participants.Count(),
                    PricePerMonth = o.PricePerMonth,
                    Title = o.Title
                }
                )
                .FirstAsync();

        }

        public async Task<bool> ExistsOnlineAsync(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                .AnyAsync(o => o.Id == id);
        }

        public async Task<bool> ExistsOnHandAsync(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                .AnyAsync(o => o.Id == id);
        }

        public async Task DeleteOnlineAsync(int skillId)
        {
            await repository.DeleteAsync<Infrastructure.Data.Models.Skills.OnlineCourse>(skillId);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteOnHandAsync(int skillId)
        {
            await repository.DeleteAsync<Infrastructure.Data.Models.Skills.OnHandExperience>(skillId);
            await repository.SaveChangesAsync();
        }
    }
}
