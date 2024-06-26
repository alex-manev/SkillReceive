﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillReceive.Infrastructure.Data;

#nullable disable

namespace SkillReceive.Infrastructure.Migrations
{
    [DbContext(typeof(SkillReceiveDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApplicationUserOnHandExperience", b =>
                {
                    b.Property<int>("OnHandExperiencesId")
                        .HasColumnType("int");

                    b.Property<string>("ParticipantsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OnHandExperiencesId", "ParticipantsId");

                    b.HasIndex("ParticipantsId");

                    b.ToTable("ApplicationUserOnHandExperience", (string)null);
                });

            modelBuilder.Entity("ApplicationUserOnlineCourse", b =>
                {
                    b.Property<int>("OnlineCoursesId")
                        .HasColumnType("int");

                    b.Property<string>("ParticipantsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OnlineCoursesId", "ParticipantsId");

                    b.HasIndex("ParticipantsId");

                    b.ToTable("ApplicationUserOnlineCourse", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a91f5171-57cf-40cb-b3e8-bde50b2c712b",
                            Email = "onlineUser@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Online",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "onlineUser@mail.com",
                            NormalizedUserName = "onlineUser@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEMWhlgXXZk5MumzhTLXha6gsXjUaBtVIRs8V6jX0zrqeFjPvQLO/BPRF89zOm3qViA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cc583172-e0b8-452f-8f34-e19c0ab09569",
                            TwoFactorEnabled = false,
                            UserName = "onlineUser@mail.com"
                        },
                        new
                        {
                            Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0ec5ac99-291a-4e3b-846d-564573daac78",
                            Email = "realLife@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Real",
                            LastName = "Life",
                            LockoutEnabled = false,
                            NormalizedEmail = "realLife@mail.com",
                            NormalizedUserName = "realLife@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEA7+murzk0W5ynAdG/GkZnBJOvCXv1EThq3wnG5auaMaKMoxNxDCFUdz8rDeAYuNOg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a8c5ab9b-77d0-49fc-a84c-8e678fd4c518",
                            TwoFactorEnabled = false,
                            UserName = "realLife@mail.com"
                        },
                        new
                        {
                            Id = "df83445d-7e23-4fea-a2c5-5cd1232083c4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "830d4eba-dcd6-4a57-989f-1de395c53864",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Great",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGYUesoHKRYWv96aB54KzqZRC7mp60UYNK8MHPifxidQ9qfGEMMPnCeVN1ySU/vT5g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "00c66291-f9e5-45ef-8812-7c36ad775961",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        });
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.Categories.OnHandExperienceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("OnHandExperience category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Online course category name");

                    b.HasKey("Id");

                    b.ToTable("OnHandExperienceCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Culinary"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Manual Labor"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Sports"
                        });
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.Categories.OnlineCourseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Online course category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Online course category name");

                    b.HasKey("Id");

                    b.ToTable("OnlineCourseCategories", (string)null);

                    b.HasComment("Online course category");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Design & Arts"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Programming"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Business & Management"
                        });
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.Creator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Creator identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Creator phone number");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User identifier");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Creators", (string)null);

                    b.HasComment("Skill Creator");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            PhoneNumber = "4214267391",
                            UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6"
                        },
                        new
                        {
                            Id = 1,
                            PhoneNumber = "1234567890",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 4,
                            PhoneNumber = "08934257381",
                            UserId = "df83445d-7e23-4fea-a2c5-5cd1232083c4"
                        });
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.Skills.OnHandExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("On Hand Experience identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasComment("On Hand Experience creator identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("On Hand Experience description");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("On Hand Experience image url");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit")
                        .HasComment("Is skill approved by admin");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("On Hand Experience location");

                    b.Property<decimal>("PricePerMonth")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Monthly price");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("On Hand Experience location");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("On Hand Experience title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("OnHandExperiences", (string)null);

                    b.HasComment("On Hand Experience");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatorId = 2,
                            Description = "Dive into the exhilarating world of volleyball with our comprehensive Volleyball Fundamentals tutorial. Geared towards beginners, this guide offers a solid foundation in the essential skills and techniques needed to excel in this fast-paced sport. Whether you're stepping onto the court for the first time or looking to refine your game, this tutorial is your ultimate resource.",
                            ImageURL = "https://media.istockphoto.com/id/1305166860/vector/volleyball-sports-glyph-icon.jpg?s=612x612&w=0&k=20&c=t67-m41qaiSnaOuWjLtkytN1RAqAiiXc9QmLu68fTS8=",
                            IsApproved = false,
                            Location = "123 St.Main Street 2700",
                            PricePerMonth = 15.00m,
                            Requirements = "Height: at least 180cm, Weight: at least 75kg, Age: Must be 18 or older",
                            Title = "Volleyball Fundamentals: Mastering the Basics of the Game"
                        });
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.Skills.OnlineCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Online course identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasComment("Online course creator identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Online course description");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Online course image url");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit")
                        .HasComment("Is skill approved by admin");

                    b.Property<string>("NeededTechnologies")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Online course description");

                    b.Property<decimal>("PricePerMonth")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Monthly price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Online course title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("OnlineCourses", (string)null);

                    b.HasComment("Online Course");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 3,
                            CreatorId = 1,
                            Description = "Learn the essential syntax of JavaScript, including variables, data types, operators, and control flow structures. Dive into functions and explore how they enable you to write reusable and modular code. Understand the power of JavaScript objects and arrays for organizing and manipulating data. Discover how to interact with HTML elements and dynamically update web pages using JavaScript.",
                            ImageURL = "https://www.tutorialrepublic.com/lib/images/javascript-illustration.png",
                            IsApproved = false,
                            NeededTechnologies = "VisualStudio/VisualStudio Code, Microsoft Teams, GitHub",
                            PricePerMonth = 10.00m,
                            Title = "JavaScript Basics: A Beginner's Guide"
                        });
                });

            modelBuilder.Entity("ApplicationUserOnHandExperience", b =>
                {
                    b.HasOne("SkillReceive.Infrastructure.Data.Models.Skills.OnHandExperience", null)
                        .WithMany()
                        .HasForeignKey("OnHandExperiencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillReceive.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationUserOnlineCourse", b =>
                {
                    b.HasOne("SkillReceive.Infrastructure.Data.Models.Skills.OnlineCourse", null)
                        .WithMany()
                        .HasForeignKey("OnlineCoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillReceive.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SkillReceive.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SkillReceive.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillReceive.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SkillReceive.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.Creator", b =>
                {
                    b.HasOne("SkillReceive.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.Skills.OnHandExperience", b =>
                {
                    b.HasOne("SkillReceive.Infrastructure.Data.Models.Categories.OnHandExperienceCategory", "Category")
                        .WithMany("OnHandExperiences")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SkillReceive.Infrastructure.Data.Models.Creator", "Creator")
                        .WithMany("OnHandExperiences")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.Skills.OnlineCourse", b =>
                {
                    b.HasOne("SkillReceive.Infrastructure.Data.Models.Categories.OnlineCourseCategory", "Category")
                        .WithMany("OnlineCourses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SkillReceive.Infrastructure.Data.Models.Creator", "Creator")
                        .WithMany("OnlineCourses")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.Categories.OnHandExperienceCategory", b =>
                {
                    b.Navigation("OnHandExperiences");
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.Categories.OnlineCourseCategory", b =>
                {
                    b.Navigation("OnlineCourses");
                });

            modelBuilder.Entity("SkillReceive.Infrastructure.Data.Models.Creator", b =>
                {
                    b.Navigation("OnHandExperiences");

                    b.Navigation("OnlineCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
