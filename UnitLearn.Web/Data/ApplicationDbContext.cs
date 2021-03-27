using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UnitLearn.Web.Models.Entity.Assigmnet;
using UnitLearn.Web.Models.Entity.Auth;
using UnitLearn.Web.Models.Entity.Base;
using UnitLearn.Web.Models.Entity.Base.Lookup;
using UnitLearn.Web.Models.Entity.Chat;
using UnitLearn.Web.Models.Entity.Competition;
using UnitLearn.Web.Models.Entity.Course;
using UnitLearn.Web.Models.Entity.Knowledge;
using UnitLearn.Web.Models.Entity.Mailing;
using UnitLearn.Web.Models.Entity.Questionnaire;

namespace UnitLearn.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourseStudent>()
                .HasKey(bc => new { bc.CourseId, bc.StudentId });

            modelBuilder.Entity<CompetitionMemberGroup>()
               .HasKey(bc => new { bc.CompetitionGroupId, bc.StudentId });

            modelBuilder.Entity<Competition>()
                .Property(b => b.TotalMark)
                .HasDefaultValue(0);
        }

        #region Assigmnet
        public DbSet<AssigmentFile> AssigmentFile { get; set; }
        public DbSet<AssigmentGrade> AssigmentGrade { get; set; }
        public DbSet<AssigmentSubmission> AssigmentSubmission { get; set; }
        public DbSet<AssigmentSubmissionFile> AssigmentSubmissionFile { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        #endregion

        #region Lookup
        public DbSet<City> City { get; set; }
        public DbSet<Educational> Educational { get; set; }
        public DbSet<FileType> FileType { get; set; }
        public DbSet<QuestionType> QuestionType { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<UserType> UserType { get; set; }
        #endregion

        #region Chat
        public DbSet<ChatCourse> ChatCourse { get; set; }
        #endregion

        #region Competition
        public DbSet<Competition> Competition { get; set; }
        public DbSet<CompetitionAnswer> CompetitionAnswer { get; set; }
        public DbSet<CompetitionGroup> CompetitionGroup { get; set; }
        public DbSet<CompetitionMemberGroup> CompetitionMemberGroup { get; set; }
        public DbSet<CompetitionQuestion> CompetitionQuestion { get; set; }
        public DbSet<CompetitionQuestionOptions> CompetitionQuestionOptions { get; set; }
        #endregion

        #region Course
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        #endregion

        #region Knowledge
        public DbSet<KnowledgeContent> KnowledgeContent { get; set; }
        public DbSet<KnowledgeContentFile> KnowledgeContentFile { get; set; }
        public DbSet<KnowledgeCategory> KnowledgeCategory { get; set; }
        public DbSet<KnowledgeSubCategory> KnowledgeSubCategory { get; set; }
        #endregion

        #region Mailing
        public DbSet<Mailing> Mailing { get; set; }
        public DbSet<Notification> Notification { get; set; }
        #endregion

        #region Questionnaire
        public DbSet<Questionnaire> Questionnaire { get; set; }
        public DbSet<QuestionnaireAnswer> QuestionnaireAnswer { get; set; }
        public DbSet<QuestionnaireQuestion> QuestionnaireQuestion { get; set; }
        public DbSet<QuestionOptions> QuestionOptions { get; set; }
        #endregion
    }
}
