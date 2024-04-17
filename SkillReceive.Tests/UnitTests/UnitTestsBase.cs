using AutoMapper;
using SkillReceive.Infrastructure.Data;
using SkillReceive.Infrastructure.Data.Models;
using SkillReceive.Infrastructure.Data.Models.Skills;
using SkillReceive.Infrastructure.Data.SeedDb;
using SkillReceive.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Tests.UnitTests
{

    public class UnitTestsBase
    {
        protected SkillReceiveDbContext _data;

        [OneTimeSetUp]
        public void SettUpBase() 
        {
            _data = DatabaseMock.Instance;
            SeedDataBase();
        }

        public ApplicationUser Person { get; set; }

        public Creator Creator { get; set; }

        public OnlineCourse OnlineCourse { get; set; }  

        public OnHandExperience OnHandExperience { get; set; }

        private void SeedDataBase()
        {
            Person = new ApplicationUser()
            {
                Id = "PersonUserId",
                Email = "person@mail.bg",
                FirstName = "Per",
                LastName ="Son"
            };
            _data.Users.Add(Person);

            Creator = new Creator()
            {
                PhoneNumber = "1234567890",
                User = new ApplicationUser()
                {
                    Id = "tESUserId",
                    Email = "TSE@mail.bg",
                    FirstName = "TS",
                    LastName = "ET"
                }
            };
            _data.Creators.Add(Creator);

            OnlineCourse = new OnlineCourse()
            {
                Title = "AAAAAAAAA",
                NeededTechnologies = "Tset/sas/asaas/asa",
                Description = "test description,test description,test description,test description,test description,test description,test description,test description,test description",
                ImageURL= "https://images.ctfassets.net/hrltx12pl8hq/28ECAQiPJZ78hxatLTa7Ts/2f695d869736ae3b0de3e56ceaca3958/free-nature-images.jpg?fit=fill&w=1200&h=630",
                Creator = Creator,
                CategoryId = 1

            };
            _data.OnlineCourses.Add(OnlineCourse);

            OnHandExperience = new OnHandExperience()
            {
                Title = "AAAAAAAAA",
                Location = "ul. Sofiq 132",
                Requirements = "Tset/sas/asaas/asa",
                Description = "test description,test description,test description,test description,test description,test description,test description,test description,test description",
                ImageURL = "https://images.ctfassets.net/hrltx12pl8hq/28ECAQiPJZ78hxatLTa7Ts/2f695d869736ae3b0de3e56ceaca3958/free-nature-images.jpg?fit=fill&w=1200&h=630",
                Creator = Creator,
                CategoryId = 2

            };
            _data.OnHandExperiences.Add(OnHandExperience);

            _data.SaveChanges();
        }

        [OneTimeSetUp]

        public void TearDownBase() => _data.Dispose();
    }
}
