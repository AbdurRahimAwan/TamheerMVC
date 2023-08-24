using System.Configuration; // For configuration
using Core.Entity;
using Microsoft.AspNet.Identity.EntityFramework; // Identity DbContext
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Core.Configutration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
        }

        // Your DbSet properties go here

        #region Interview
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<InterviewRows> interviewRows { get; set; }
        public DbSet<InterviewStatus> InterviewStatus { get; set; }
        public DbSet<InterviewDetails> InterviewDetails { get; set; }
        #endregion

        #region TraineeContract
        public DbSet<TraineeContract> TraineeContract { get; set; }
        public DbSet<TraineeContractRow> TraineeContractRow { get; set; }
        public DbSet<TraineeContractDetails> TraineeContractDetails { get; set; }
        #endregion

        #region Ticket
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketRows> TicketRows { get; set; }
        public DbSet<TicketDetails> TicketDetails { get; set; }
        public DbSet<TicketCategory> TicketCategory { get; set; }
        public DbSet<TicketAttachment> TicketAttachment { get; set; }
        public DbSet<TicketResponse> TicketResponse { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
        #endregion

        #region Attendance
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceType> AttendanceTypes { get; set; }
        #endregion

        #region Job
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobDetails> JobDetails { get; set; }
        public DbSet<JobRows> JobRows { get; set; }

        public DbSet<JobInfoDTO> AdminJobInfo { get; set; }
        public DbSet<JobsStatus> JobsStatus { get; set; }
        public DbSet<TraineeJob> traineeJobs { get; set; }
        #endregion

        #region Cities
        public DbSet<City> Cities { get; set; }
        #endregion

        #region Department
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentDetails> departmentDetails { get; set; }
        public DbSet<DepartmentRows> DepartmentRows { get; set; }
        #endregion

        #region Education
        public DbSet<Education> Education { get; set; }
        #endregion

        #region Experience
        public DbSet<Experience> Experiences { get; set; }
        #endregion

        #region Marriage
        public DbSet<MaritalState> MaritalStates { get; set; }
        #endregion

        #region Nationalities
        public DbSet<Nationality> Nationalities { get; set; }
        #endregion


        #region Trainee
        public DbSet<TraineeProfile> TraineeProfiles { get; set; }
        public DbSet<TraineeDetails> traineeDetails { get; set; }
        public DbSet<TraineeRows> TraineeRows { get; set; }
        public DbSet<TraineeJobStatus> TraineeJobStatus { get; set; }
        #endregion

        #region Coordinator
        public DbSet<Coordinators> Coordinators { get; set; }
        public DbSet<CoordinatorRows> CoordinatorRows { get; set; }
        public DbSet<CoordinatorDetails> CoordinatorDetails { get; set; }
        #endregion

        #region Tamheir
        public DbSet<TamheirStatus> TamheirStatuses { get; set; }
        #endregion

        #region supervisors
        public DbSet<Supervisor> Supervisor { get; set; }
        public DbSet<SupervisorRows> SupervisorRows { get; set; }
        public DbSet<SupervisorDetails> SupervisorDetails { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.Ignore<TraineeDTO>();
			modelBuilder.Ignore<JobInfoDTO>();
			modelBuilder.Ignore<TraineeRows>();
			modelBuilder.Ignore<TraineeDetails>();
			modelBuilder.Ignore<TicketDetails>();
			modelBuilder.Ignore<TicketRows>();
			modelBuilder.Ignore<InterviewRows>();
			modelBuilder.Ignore<InterviewDetails>();
			modelBuilder.Ignore<JobRows>();
			modelBuilder.Ignore<JobDetails>();
			modelBuilder.Ignore<DepartmentDetails>();
			modelBuilder.Ignore<DepartmentRows>();
			modelBuilder.Ignore<CoordinatorDetails>();
            modelBuilder.Ignore<CoordinatorRows>();
			modelBuilder.Ignore<TraineeContractDetails>();
			modelBuilder.Ignore<TraineeContractRow>();
			modelBuilder.Ignore<TicketAttachment>();
			modelBuilder.Ignore<SupervisorDetails>();
			modelBuilder.Ignore<SupervisorRows>();



            modelBuilder.Configurations.Add(new ConfigrationEntityAttendance());
            modelBuilder.Configurations.Add(new ConfigrationEntityAttendanceType());

            modelBuilder.Configurations.Add(new ConfigrationEntityJob());
            modelBuilder.Configurations.Add(new ConfigrationEntityCity());
            modelBuilder.Configurations.Add(new ConfigrationEntityDepartment());
            modelBuilder.Configurations.Add(new ConfigrationEntityEducationMajority());
            modelBuilder.Configurations.Add(new ConfigrationEntityExperience());
            modelBuilder.Configurations.Add(new ConfigrationEntityMaritalState());
            modelBuilder.Configurations.Add(new ConfigrationEntityNationality());
            modelBuilder.Configurations.Add(new ConfigrationEntityTamheirStatus());
            modelBuilder.Configurations.Add(new ConfigrationEntityTicket());
            modelBuilder.Configurations.Add(new ConfigrationEntityTicketAttachment());
            modelBuilder.Configurations.Add(new ConfigrationEntityTicketCategory());
            modelBuilder.Configurations.Add(new ConfigrationEntityTicketResponse());
            modelBuilder.Configurations.Add(new ConfigrationEntityTraineeProfile());
            modelBuilder.Configurations.Add(new ConfigrationEntityJobsStatus());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new ConfigrationEntityTraineeJobStatus());


            //Run when DB is oracle
            //if (Database.ProviderName == "Oracle.EntityFrameworkCore")
            //{
            //    //modelBuilder.Entity<BaseEntity>(entity =>
            //    //{
            //    //    entity.Property(e => e.IsDeleted)
            //    //    .HasDefaultValue(0) // Set the default value to 0
            //    //    .IsRequired(); // Assuming IsDeleted is a required property
            //    //});

            //    modelBuilder.ToUpperCaseTables();
            //    modelBuilder.ToUpperCaseColumns();

            //}

            //To ignore from migration to make table in database

            modelBuilder.Entity<TraineeProfile>()
           .Property(u => u.IqamaNumber)
           .HasColumnAnnotation(IndexAnnotation.AnnotationName,
           new IndexAnnotation(new IndexAttribute("IX_IqamaNumber") { IsUnique = true }));

            modelBuilder.Entity<Coordinators>()
                     .HasRequired(c => c.Department)
                     .WithMany()
                     .HasForeignKey(c => c.DepartmentId)
                     .WillCascadeOnDelete(false); // Set the cascade behavior to NoAction
                                                         //

            modelBuilder.Entity<Coordinators>()
                .HasRequired(c => c.Department) // Use HasRequired for One-to-Many relationship
                .WithMany()                     // You can specify the navigation property name if needed
                .HasForeignKey(c => c.DepartmentId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Supervisor>()
                     .HasRequired(c => c.Department)
                     .WithMany()
                     .HasForeignKey(c => c.DepartmentId)
                     .WillCascadeOnDelete(false); // Set the cascade behavior to NoAction                                                  //
            modelBuilder.Entity<TraineeContract>()
                     .HasRequired(c => c.traineeProfile)
                     .WithMany()
                     .HasForeignKey(c => c.traineeProfileId)
                     .WillCascadeOnDelete(false); // Set the cascade behavior to NoAction
            base.OnModelCreating(modelBuilder);
        }
    }
}