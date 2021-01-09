﻿using CreaFormDemo.Entitys.Clientprofile;
using CreaFormDemo.Entitys.Identity;
using CreaFormDemo.Entitys.LifestyleModel.Habits;
using CreaFormDemo.Entitys.LifestyleModel.job;
using CreaFormDemo.Entitys.LifestyleModel.Privat;
using CreaFormDemo.Entitys.Users;
using CreaFormDemo.Repository;
using CreaFormDemo.Services.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys
{
    public class CreaFormDBcontext:IdentityDbContext<User,Role,int,IdentityUserClaim<int>,UserRole,IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>>
    {
       

        public CreaFormDBcontext( DbContextOptions<CreaFormDBcontext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRole>(
                userRole =>
                {
                    userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                    userRole.HasOne(ur => ur.role)
                    .WithMany(R => R.userRoles)
                    .HasForeignKey(F => F.RoleId)
                    .IsRequired();
                    userRole.HasOne(ur => ur.user)
                    .WithMany(R => R.userRoles)
                    .HasForeignKey(F => F.UserId)
                    .IsRequired();


                }
                );
               
          

            #region//Vanor//



            modelBuilder.Entity<PlusMinusGroup>()
                .HasMany<HabitsChoise>(h => h.habitsChoise)
                .WithOne(P => P.plusMinusGroup)
                .HasForeignKey(H => H.plusMinusGroupID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlusMinusUnderGroup>()
                .HasMany<HabitsChoise>(H => H.habitsChoises)
                .WithOne(P => P.plusMinusUnderGroup)
                .HasForeignKey(h => h.plusMinusUnderGroupID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HabitsQuestion>()
                .HasMany<HabitsChoise>(h => h.habitschois)
                .WithOne(h => h.question)
                .HasForeignKey(h => h.QuestionID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProgramsChoise>()
                .HasKey(p => new { p.ChoiseID, p.ProgramPlanID });
            modelBuilder.Entity<ProgramsChoise>()
                .HasOne<HabitsChoise>(x => x.choise)
                .WithMany(x => x.programsChoises)
                .HasForeignKey(x => x.ChoiseID);
            modelBuilder.Entity<ProgramsChoise>()
                .HasOne(x => x.program)
                .WithMany(x => x.programsChoises)
                .HasForeignKey(x => x.ProgramPlanID);

            modelBuilder.Entity<HabitsCategory>()
                .HasMany<HabitsQuestion>(x => x.habitsQuestions)
                .WithOne(x => x.habitsCategory)
                .HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LifestyleArea>()
                           .HasOne<HabitsCategory>(x => x.habitscategory)
                           .WithOne(p => p.lifestyleArea)
                           .HasForeignKey<HabitsCategory>(p => p.LifestyleAreaID);

            modelBuilder.Entity<PlusMinusGroup>()
                .HasMany<PlusMinusUnderGroup>(x => x.plusMinusUnderGroups)
                .WithOne(x => x.plusMinusGroup)
                .HasForeignKey(x => x.PlusMinusGroupID)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
            #region//Arbete//
            modelBuilder.Entity<StrengthLackGroup>()
                .HasMany<JobChoise>(x => x.jobChoises)
                .WithOne(x => x.strengthLackGroup)
                .HasForeignKey(x => x.StrengthLackGroupID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StrengthLackUnderGroup>()
             .HasMany<JobChoise>(x => x.jobChoises)
             .WithOne(x => x.strengthLackUnderGroup)
             .HasForeignKey(x => x.StrengthLackUnderGroupID)
             .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<JobQuestion>()
            .HasMany<JobChoise>(x => x.jobchoises)
            .WithOne(x => x.jobQuestion)
            .HasForeignKey(x => x.QuestionID)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<JobCategory>()
          .HasMany<JobQuestion>(x => x.jobQuestions)
          .WithOne(x => x.JobCategory)
          .HasForeignKey(x => x.CategoryID)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<JobCategory>()
                          .HasOne<LifestyleArea>(L => L.lifestyleArea)
                          .WithOne(p => p.jobcategory)
                          .HasForeignKey<JobCategory>(p => p.LifestylAreaID);


            #endregion
            #region//Privat//
            modelBuilder.Entity<LifestyleArea>()
                          .HasOne<PrivatCategory>(L => L.privatcategory)
                          .WithOne(p => p.lifestyleArea)
                          .HasForeignKey<PrivatCategory>(p => p.LifestylAreaID);
            modelBuilder.Entity<PrivatCategory>()
                .HasMany<PrivatQuestion>(x => x.privatQuestions)
                .WithOne(x => x.privatCategory)
                .HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StrengthLackGroup>()
              .HasMany<PrivatChoise>(x => x.PrivatChoises)
              .WithOne(x => x.strengthLackGroup)
              .HasForeignKey(x => x.StrengthLackGroupID)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StrengthLackUnderGroup>()
             .HasMany<PrivatChoise>(x => x.privatChoises)
             .WithOne(x => x.strengthLackUnderGroup)
             .HasForeignKey(x => x.StrengthLackUnderGroupID)
             .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PrivatQuestion>()
           .HasMany<PrivatChoise>(x => x.privatchoises)
           .WithOne(x => x.question)
           .HasForeignKey(x => x.QuestionID)
           .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StrengthLackGroup>()
           .HasMany<StrengthLackUnderGroup>(x => x.strengthLackUnderGroups)
           .WithOne(x => x.strengthLackGroup)
           .HasForeignKey(x => x.StrengthLackGroupID)
           .OnDelete(DeleteBehavior.NoAction);

            #endregion
            #region//Konton//
            modelBuilder.Entity<User>()
                .HasOne<Client>(x => x.client)
                .WithOne(x => x.user)
                .HasForeignKey<Client>(x => x.UserID);


            modelBuilder.Entity<User>()
              .HasOne<Advisor>(x => x.advisor)
              .WithOne(x => x.user)
              .HasForeignKey<Advisor>(x => x.UserID);
            
             
            
            modelBuilder.Entity<Advisor>()
                .HasMany<Client>(x => x.clients)
                .WithOne(x => x.advisor)
                .HasForeignKey(x => x.AdvisorID)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region//Allmänt//
            modelBuilder.Entity<Client>()
                .HasOne<clientProfile>(X => X.clientProfile)
                .WithOne(X => X.client)
                .HasForeignKey<clientProfile>(X => X.ClientID);
            modelBuilder.Entity<ClientMedicine>()
              .HasKey(CM => new { CM.ClientID,CM.MedicineID});
            modelBuilder.Entity<ClientMedicine>()
                .HasOne<Client>(x => x.client)
                .WithMany(x => x.clientMedicines)
                .HasForeignKey(x => x.ClientID);
            modelBuilder.Entity<ClientMedicine>()
                .HasOne(x => x.medicine)
                .WithMany(x => x.clientMedicines)
                .HasForeignKey(x => x.MedicineID);

            #endregion
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<LifestyleArea> lifestyleAreas { get; set; }
        public DbSet<HabitsCategory> habitsCategories { get; set; }
        public DbSet<HabitsQuestion> habitsQuestions { get; set; }
        public DbSet<HabitsChoise> habitsChoises { get; set; }
        public DbSet<PlusMinusGroup> plusMinusGroups { get; set; }
        public DbSet<PlusMinusUnderGroup> plusMinusUnderGroups { get; set; }
        public DbSet<ProgramPlan> programPlans { get; set; }
        public DbSet<ProgramsChoise> programsChoises { get; set; }
        public DbSet<JobCategory> jobCategories { get; set; }
        public DbSet<JobChoise> jobChoises { get; set; }
        public DbSet<JobQuestion> jobQuestions { get; set; }
        public DbSet<PrivatCategory> privatCategories { get; set; }
        public DbSet<PrivatChoise> privatChoises { get; set; }
        public DbSet<PrivatQuestion> privatQuestions { get; set; }
        public DbSet<StrengthLackGroup> strengthLackGroups { get; set; }
        public DbSet<StrengthLackUnderGroup> strengthLackUnderGroups { get; set; }
        public DbSet<Client>  clients { get; set; }
        public DbSet<Advisor>  advisors { get; set; }
        //public DbSet<User>  users{ get; set; }
        public DbSet<Medicine> medicines { get; set; }
        public DbSet<clientProfile>  clientProfiles { get; set; }
        public DbSet<ClientMedicine>  clientMedicines{ get; set; }
        public DbSet<UserRole> userRoles { get; set; } 










    }
}
