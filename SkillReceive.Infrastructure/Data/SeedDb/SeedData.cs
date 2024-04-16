using Microsoft.AspNetCore.Identity;
using SkillReceive.Infrastructure.Data.Models;
using SkillReceive.Infrastructure.Data.Models.Categories;
using SkillReceive.Infrastructure.Data.Models.Skills;

namespace SkillReceive.Infrastructure.Data.SeedDb
{
    public class SeedData
    {
        //Users with different roles
        public ApplicationUser OnlineCourseUser { get; set; } = null!;
        public ApplicationUser OnHandExperienceUser { get; set; } = null!;
        public ApplicationUser GuestUser { get; set; } = null!;


        //Types of creators
        public Creator OnlineCourseCreator { get; set; } = null!;
        public Creator OnHandCourseCreator { get; set; } = null!;

        //Online categories

        public OnlineCourseCategory BusinessManagementCategory { get; set; } = null!;
        public OnlineCourseCategory DesignArtsCategory { get; set; } = null!;
        public OnlineCourseCategory ProgrammingCategory { get; set; } = null!;

        //Online courses
        public OnlineCourse JsTutorial { get; set; } = null!;


        //On Hand Categories

        public OnHandExperienceCategory SportsCategory { get; set; } = null!; 
        public OnHandExperienceCategory CulinaryCategory { get; set; } = null!;
        public OnHandExperienceCategory ManualLaborCategory { get; set; } = null!;


        //On Hand Experieces

        public OnHandExperience VolleyballLessons { get; set; } = null!;


        public SeedData()
        {
            SeedUsers();
            SeedCreators();
            SeedOnlineCategories();
            SeedOnHandCategories();
            SeedOnlineCourses();
            SeedOnHandExperiences();
        }


        private void SeedUsers() 
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            OnlineCourseUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "onlineUser@mail.com",
                NormalizedUserName = "onlineUser@mail.com",
                Email = "onlineUser@mail.com",
                NormalizedEmail = "onlineUser@mail.com"
            };

            OnlineCourseUser.PasswordHash = hasher.HashPassword(OnlineCourseUser, "online123");



            
            OnHandExperienceUser= new ApplicationUser()
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                UserName = "realLife@mail.com",
                NormalizedUserName = "realLife@mail.com",
                Email = "realLife@mail.com",
                NormalizedEmail = "realLife@mail.com"
            };

            OnHandExperienceUser.PasswordHash = hasher.HashPassword(OnHandExperienceUser, "realLife123");

            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest123");
        }

        private void SeedCreators() 
        {
            OnlineCourseCreator = new Creator()
            {
                Id = 1,
                PhoneNumber = "1234567890",
                UserId = OnlineCourseUser.Id
            };

            OnHandCourseCreator = new Creator()
            {
                Id = 2,
                PhoneNumber = "4214267391",
                UserId = OnHandExperienceUser.Id
            };
        }

        private void SeedOnlineCategories() 
        {
            BusinessManagementCategory = new OnlineCourseCategory()
            {
                Id = 1,
                Name = "Business & Management"
            };


            DesignArtsCategory = new OnlineCourseCategory()
            {
                Id = 2,
                Name = "Design & Arts"
            };

            ProgrammingCategory = new OnlineCourseCategory()
            {
                Id = 3,
                Name = "Programming"
            };     
        }

        private void SeedOnHandCategories() 
        {
            SportsCategory = new OnHandExperienceCategory()
            {
                Id=1,
                Name = "Sports"
            };

            CulinaryCategory = new OnHandExperienceCategory()
            {
                Id = 2,
                Name = "Culinary"
            };

            ManualLaborCategory = new OnHandExperienceCategory()
            {
                Id = 3,
                Name = "Manual Labor"
            };
        }

        private void SeedOnlineCourses() 
        {
            JsTutorial = new OnlineCourse()
            {
                Id = 1,
                Title = "JavaScript Basics: A Beginner's Guide",
                Description = "Learn the essential syntax of JavaScript, including variables, data types, operators, and control flow structures. Dive into functions and explore how they enable you to write reusable and modular code. Understand the power of JavaScript objects and arrays for organizing and manipulating data. Discover how to interact with HTML elements and dynamically update web pages using JavaScript.",
                NeededTechnologies = "VisualStudio/VisualStudio Code, Microsoft Teams, GitHub",
                PricePerMonth = 10.00m,
                ImageURL = "https://www.tutorialrepublic.com/lib/images/javascript-illustration.png",
                CategoryId = ProgrammingCategory.Id,
                CreatorId = OnlineCourseCreator.Id,
                Participants = new List<ApplicationUser>()
            };
        }

        private void SeedOnHandExperiences() 
        {
            VolleyballLessons = new OnHandExperience()
            {
                Id = 1,
                Title = "Volleyball Fundamentals: Mastering the Basics of the Game",
                Description = "Dive into the exhilarating world of volleyball with our comprehensive Volleyball Fundamentals tutorial. Geared towards beginners, this guide offers a solid foundation in the essential skills and techniques needed to excel in this fast-paced sport. Whether you're stepping onto the court for the first time or looking to refine your game, this tutorial is your ultimate resource.",
                Location = "123 St.Main Street 2700",
                Requirements = "Height: at least 180cm, Weight: at least 75kg, Age: Must be 18 or older",
                PricePerMonth = 15.00m,
                ImageURL = "https://media.istockphoto.com/id/1305166860/vector/volleyball-sports-glyph-icon.jpg?s=612x612&w=0&k=20&c=t67-m41qaiSnaOuWjLtkytN1RAqAiiXc9QmLu68fTS8=",
                CategoryId = SportsCategory.Id,
                CreatorId = OnHandCourseCreator.Id,
                Participants = new List<ApplicationUser>()
            };
        }
    }
}
