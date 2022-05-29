using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Localization;
using Kis.Authorization.Users;
using Kis.General.Api.Entity;
using Kis.TaskTrecker.Api.Entity;
using Kis.TaskTrecker.Dal.Mapping;
using Kis.TaskTrecker.Dal.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kis.TaskTrecker.Dal
{
    /// <summary>
    /// Класс взаимодействия служб Entity Framework с кодом описывающим модель бизнесс данных посредством DbContext.
    /// Этот класс вынесен на уровень DAO с целью сделать независимым доменную модель от способа взаимодействия с БД
    /// На уровне модуля этот класс расширяется DbSet сущностями своей бизнес модели
    /// </summary>
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(TaskTreckerRepositoryBase<>),
        typeof(TaskTreckerRepositoryBase<,>))]
    public class TaskTreckerDbContext : AbpDbContext
    {
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<IssueComment> IssueComments { get; set; }
        public virtual DbSet<IssueMedia> IssueMediae { get; set; }
        public virtual DbSet<IssuePriority> IssuePriorities { get; set; }
        public virtual DbSet<IssueState> IssueStates { get; set; }
        public virtual DbSet<IssueWorkflow> IssueWorkflows { get; set; }
        public virtual DbSet<Project> Projects{ get; set; }
        public virtual DbSet<ProjectMilestone> ProjectMilestones { get; set; }
        public virtual DbSet<ProjectMilestoneIssueRel> ProjectMilestoneIssueRels { get; set; }
        public virtual DbSet<ProjectState> ProjectStates { get; set; }
        public virtual DbSet<ProjectWorkflow> ProjectWorkflows { get; set; }

        public TaskTreckerDbContext(DbContextOptions<TaskTreckerDbContext> options) : base(options)
        {}
   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationLanguageText>()
            //    .Property(p => p.Value)
            //    .HasMaxLength(10485759); // any integer that is smaller than 10485760

            base.OnModelCreating(modelBuilder);
            //https://www.npgsql.org/efcore/value-generation.html - для автогенерации Id типа Guid
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new ProjectStateMap());
            modelBuilder.ApplyConfiguration(new ProjectMilestoneMap());
            modelBuilder.ApplyConfiguration(new ProjectMilestoneIssueRelMap());
            modelBuilder.ApplyConfiguration(new IssueMap());
            modelBuilder.ApplyConfiguration(new IssueCommentMap());
            modelBuilder.ApplyConfiguration(new IssueMediaMap());
            modelBuilder.ApplyConfiguration(new IssuePriorityMap());
            modelBuilder.ApplyConfiguration(new IssueStateMap());
            modelBuilder.ApplyConfiguration(new ProjectWorkflowMap());
            modelBuilder.ApplyConfiguration(new IssueWorkflowMap());


            // Т.к. в сущностях модуля есть связь с User, эти сущности требуется исключить,
            // иначе они попадают в миграцию, даже если есть Ignore в конфигурации маппинга
            // (возможно баг в EF или ABP)
            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<PermissionSetting>();
            modelBuilder.Ignore<UserPermissionSetting>();
            modelBuilder.Ignore<RolePermissionSetting>();
            modelBuilder.Ignore<Setting>();
            modelBuilder.Ignore<UserClaim>();
            modelBuilder.Ignore<UserLogin>();
            modelBuilder.Ignore<UserRole>();
            modelBuilder.Ignore<UserToken>();
            modelBuilder.Ignore<Comment>();
            modelBuilder.Ignore<Link>();
            modelBuilder.Ignore<MediaType>();
            modelBuilder.Ignore<State>();
            modelBuilder.Ignore<Workflow>();
            modelBuilder.Ignore<CommentLink>();
            modelBuilder.Ignore<Media>();
            modelBuilder.Ignore<CommentMedia>();

        }

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
    }

  
}
