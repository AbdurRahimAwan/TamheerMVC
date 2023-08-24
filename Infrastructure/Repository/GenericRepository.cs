using Core.Entity;
using Core.IRepository;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using System.Data.Entity;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Linq.Expressions;
using System.Security.Policy;

namespace Infrastructure.Repository
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly IUnitOfWork<TraineeProfileAdmin>? _TraineeProfileAdmin;

        private DbSet<T>? table = null;

        public GenericRepository()
        {
        }

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            table = this.context.Set<T>();
        }

		public bool CheckIfEntityExists(Expression<Func<T, bool>> expr)
        {
            return table.Any(expr);
        }

        public void Delete(object id)
        {
            T existing = GetById(id);
            table.Remove(existing);
        }

        //public IEnumerable<T> GetAll()
        //{
        //   return table.ToList();
        //}


        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>,
            IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null,
            bool isTracking = true)
        {
            IQueryable<T> query = context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return query.ToList();
        }

        public T GetById(object id)
        {
            return table!.Find(id);
        }
        public void Insert(T entity)
        {
            table!.Add(entity);
        }

        public void Update(T entity)
        {
            //table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }


        #region Coordinator
        public IEnumerable<CoordinatorDetails> Get_CoordinatorDetails(string? callerRole, string? UserId, string? Id)
        {
            var CoordinatorDetails = context.CoordinatorDetails.FromSqlRaw($"[dbo].[Get_CoordinatorDetails] '{callerRole}','{UserId}','{Id}'").ToList();
            return CoordinatorDetails;
        }

        public IEnumerable<CoordinatorRows> Get_CoordinatorRows(string? callerRole, string? UserId, string? Id)
        {
            if (UserId == null)
                return null;
            var CoordinatorRows = context.CoordinatorRows.FromSqlRaw($"[dbo].[Get_CoordinatorRows] '{callerRole}','{UserId}','{Id}'").ToList();
            return CoordinatorRows;
        }
        #endregion

        #region Trainee Contracts
        public IEnumerable<TraineeContractDetails> Get_TraineeContractDetail(string? callerRole, string? UserId, string? Id)
        {
            var contractDetails = context.TraineeContractDetails.FromSqlRaw($"[dbo].[Get_TraineeContractDetail] '{callerRole}','{UserId}','{Id}'").ToList();
            if (contractDetails == null)
                return null;
            else
            {
                return contractDetails;
            }

        }

        public IEnumerable<TraineeContractRow> Get_TraineeContractRows(string? callerRole, string? UserId, string? Id)
        {
            if (UserId == null)
                return null;
            var contractRows = context.TraineeContractRow.FromSqlRaw($"[dbo].[Get_TraineeContractRows] '{callerRole}','{UserId}','{Id}'").ToList();
            return contractRows;
        }
        #endregion

        #region Supervisors
        public IEnumerable<SupervisorDetails> Get_SupervisorDetail(string? callerRole, string? UserId, string? Id)
        {
            var departmentDetails = context.SupervisorDetails.FromSqlRaw($"[dbo].[Get_SupervisorDetail] '{callerRole}','{UserId}','{Id}'").ToList();
            if (departmentDetails == null)
                return null;
            else
            {
                return departmentDetails;
            }

        }

        public IEnumerable<SupervisorRows> Get_SupervisorRows(string? callerRole, string? UserId, string? Id)
        {
            if (UserId == null)
                return null;
            var jobs = context.SupervisorRows.FromSqlRaw($"[dbo].[Get_SupervisorRows] '{callerRole}','{UserId}','{Id}'").ToList();
            return jobs;
        }
        #endregion

        #region Departments           
        public IEnumerable<DepartmentDetails> Get_DepartmentDetails(string? callerRole, string? UserId, string? Id)
        {
            var departmentDetails = context.departmentDetails.FromSqlRaw($"[dbo].[Get_DepartmentDetails] '{callerRole}','{UserId}','{Id}'").ToList();
            if (departmentDetails == null)
                return null;
            else
            {
                return departmentDetails;
            }

        }
        
        public IEnumerable<DepartmentRows> Get_DepartmentRows(string? callerRole, string? UserId, string? Id)
        {
            if (UserId == null)
                return null;
            var DepartmentRows = context.DepartmentRows.FromSqlRaw($"[dbo].[Get_DepartmentRows] '{callerRole}','{UserId}','{Id}'")?.ToList(); 
            return DepartmentRows;
        }

        #endregion

        #region Jobs

        public IEnumerable<JobInfoDTO> Get_Admin_Job_info() // 
        {
            var AdminJobInfo = context.AdminJobInfo.FromSqlRaw($"[dbo].[Get_Admin_Job_info]").ToList();
            return AdminJobInfo;
        }
        public IEnumerable<JobDetails> Get_JobDetails(string? callerRole, string? UserId, string? Id)
        {

            var jobs = context.JobDetails.FromSqlRaw($"[dbo].[Get_JobDetails] '{callerRole}','{UserId}','{Id}'").ToList();
            return jobs;
        }
        public IEnumerable<JobRows> Get_JobRows(string? callerRole, string? UserId, string? Id)
        {
            var jobRows = context.JobRows.FromSqlRaw($"[dbo].[Get_JobRows] '{callerRole}','{UserId}','{Id}'").ToList();

            return jobRows;
        }

        #endregion

        #region Trainee

        public IEnumerable<TraineeRows> Get_TraineeRows(string? callerRole, string? UserId, string? Id)
        {
            var TraineeList = context.TraineeRows.FromSqlRaw($"[dbo].[Get_TraineeRow] '{callerRole}','{UserId}','{Id}'").ToList();
            return TraineeList;
        }

        public IEnumerable<TraineeDetails> Get_TraineeDetail(string? callerRole, string? UserId, string? Id)
        {
            if (UserId == null)
                return null;
            var jobs = context.traineeDetails.FromSqlRaw($"[dbo].[Get_TraineeDetails]'{callerRole}','{UserId}','{Id}'").ToList();
            if (jobs == null)
                return null;
            else
            {
                return jobs;
            }

        }

        #endregion

        #region Tickets
        public IEnumerable<TicketRows> Get_TicketRows(string? callerRole, string? UserId, string? Id)
        {
            if (UserId == null)
                return null;
            var TicketRows = context.TicketRows.FromSqlRaw($"[dbo].[Get_TicketRows]'{callerRole}','{UserId}','{Id}'").ToList();
            return TicketRows;
        }
        public IEnumerable<TicketDetails> Get_TicketDetail(string? callerRole, string? UserId, string? Id)
        {
            if (UserId == null)
                return null;
            var TicketDetails = context.TicketDetails.FromSqlRaw($"[dbo].[Get_TicketDetails]'{callerRole}','{UserId}','{Id}'").ToList();
            return TicketDetails;
        }
        #endregion
        
        #region Interview
        public IEnumerable<InterviewRows> Get_InterviewRows(string? callerRole, string? UserId, string? Id)
        {
            if (UserId == null)
                return null;
            var interviewRow = context.interviewRows.FromSqlRaw($"[dbo].[Get_InterviewRows] '{callerRole}','{UserId}','{Id}'").ToList();
            return interviewRow;
        }

        public IEnumerable<InterviewDetails> Get_InterviewDetails(string? callerRole, string? UserId, string? Id)
        {
            if (UserId == null)
                return null;
            var interview = context.InterviewDetails.FromSqlRaw($"[dbo].[Get_InterviewDetails] '{callerRole}','{UserId}','{Id}'");
            return interview;
        }
        #endregion

    }
}
