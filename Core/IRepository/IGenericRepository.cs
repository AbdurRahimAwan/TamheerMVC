using Core.Entity;
using System.Linq.Expressions;

namespace Core.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>?, IOrderedQueryable<T>>? orderBy = null,
        string? includeProperties = null,
        bool isTracking = true
        );


        T GetById(object id);
        void Insert(T entity);
        //void Insert(T entity,IList<int> T);
        void Update(T entity);
        void Delete(object id);

        public bool CheckIfEntityExists(Expression<Func<T, bool>> expr);

        #region Trainee
        IEnumerable<TraineeDetails> Get_TraineeDetail(string? callerRole, string? UserId, string? Id);
        IEnumerable<TraineeRows> Get_TraineeRows(string? callerRole, string? UserId, string? Id);
        #endregion

        #region Supervisor
        IEnumerable<SupervisorDetails> Get_SupervisorDetail(string? callerRole, string? UserId, string? Id);
        IEnumerable<SupervisorRows> Get_SupervisorRows(string? callerRole, string? UserId, string? Id);
        #endregion

        #region Coordinator
        IEnumerable<CoordinatorDetails> Get_CoordinatorDetails(string? callerRole, string? UserId, string? Id);
        IEnumerable<CoordinatorRows> Get_CoordinatorRows(string? callerRole, string? UserId, string? Id);
        #endregion


        #region Job
        IEnumerable<JobDetails> Get_JobDetails(string? callerRole, string? UserId, string? Id);
        IEnumerable<JobRows> Get_JobRows(string? callerRole, string? UserId, string? Id);
        #endregion
        
        #region Department
        IEnumerable<DepartmentDetails> Get_DepartmentDetails(string? callerRole, string? UserId, string? Id);
        IEnumerable<DepartmentRows> Get_DepartmentRows(string? callerRole, string? UserId, string? Id);
        #endregion

        #region Ticket
        IEnumerable<TicketDetails> Get_TicketDetail(string? callerRole, string? UserId, string? Id);
        IEnumerable<TicketRows> Get_TicketRows(string? callerRole, string? UserId, string? Id);
        #endregion
        
        #region Ticket
        IEnumerable<TraineeContractDetails> Get_TraineeContractDetail(string? callerRole, string? UserId, string? Id);
        IEnumerable<TraineeContractRow> Get_TraineeContractRows(string? callerRole, string? UserId, string? Id);
        #endregion

        #region Interview
        IEnumerable<InterviewDetails> Get_InterviewDetails(string? callerRole, string? UserId, string? Id);
        IEnumerable<InterviewRows> Get_InterviewRows(string? callerRole, string? UserId, string? Id);
        #endregion

    }

    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepository<T> Entity { get; }
        void Save();
    }
}

