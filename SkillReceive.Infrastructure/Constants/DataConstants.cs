using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Infrastructure.Constants
{
    public static class DataConstants
    {
        // Online Courses data constants class
        public class OnlineCourses
        {
            // Online Courses data constants class
            public class OnlineCourse
            {
                // Online Courses title length requirements 
                public const int TitleMinLength = 10;
                public const int TitleMaxLength = 40;

                public const int DescriptionMinLength = 50;
                public const int DescriptionMaxLength = 500;

                public const int NeededTechnologiesMinLength = 30;
                public const int NeededTechnologiesMaxLength = 200;

                public const string PricePerMonthMaximum = "1000.00";
            }

            // Online Courses Category data constants class
            public class OnlineCourseCategory
            {
                // Online Courses Category name max length  
                public const int NameMaxLength = 50;
            }

        }

        // OnHandExperience data constants class
        public class OnHandExperiences
        {
            // OnHandExperience data constants class
            public class OnHandExperience
            {
                // OnHandExperience title length requirements 
                public const int TitleMinLength = 10;
                public const int TitleMaxLength = 100;

                // OnHandExperience description length requirements
                public const int DescriptionMinLength = 50;
                public const int DescriptionMaxLength = 500;

                // OnHandExperience recipe length requirements
                public const int LocationMinLength = 20;
                public const int LocationMaxLength = 100;

                // OnHandExperience price length requirements
                public const int RequirementsMinLength = 50;
                public const int RequirementsMaxLength = 300;


                public const string PricePerMonthMaximum = "1000.00";
            }

            // OnHandExperience Category data constants class
            public class OnHandExperienceCategory
            {
                // OnHandExperience Category name max length  
                public const int NameMaxLength = 50;
            }

        }

        // Skill Creator data constants class 
        public class Creator
        {
            public const int CreatorPhoneNumberMaxLength = 100;

            public const int CreatorPhoneNumberMinLength = 10;
        }

        // Skill Participant data constants class 
        public class User
        {
            public const int UserFirstNameMaxLength = 50;
            public const int UserFirstNameMinLength = 1;

            public const int UserLastNameMaxLength = 50;
            public const int UserLastNameMinLength = 1;
        }
    }
}
