using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
	public partial class StoreProc : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			#region Functions


			string getJobTraineeCount = @"Create FUNCTION [dbo].[getJobTraineeCount]
				(@JobId AS INT, @stateID AS INT, @depId AS INT)
			RETURNS INT
			AS 
			BEGIN
				DECLARE @Count INT;
				SELECT @Count = COUNT(*)
				FROM traineeJobs  
				WHERE traineeJobs.JobId = @JobId AND (traineeJobs.StateId = @stateID OR @stateID IS NULL) and traineeJobs.IsDeleted=0;
				RETURN @Count;
			END;
			";

			_ = migrationBuilder.Sql(getJobTraineeCount);

			string getJobsCount = @"CREATE FUNCTION getJobsCount
   (@JobId AS INT, @depId AS INT)
RETURNS INT
AS 
BEGIN
    DECLARE @Count INT;
    
    SELECT @Count = COUNT(*)
    FROM Jobs  j
 WHERE (j.Id = @JobId OR @JobId IS NULL) OR (j.DepId = @depId OR @depId IS NULL) and j.IsDeleted=0;

    RETURN @Count;
END;
			";

			_ = migrationBuilder.Sql(getJobsCount);

			#endregion
			#region Store Procedure

			#region Trainee
			#region Get_TraineeRows


			string Get_TraineeRow = @"
			Create PROCEDURE [dbo].[Get_TraineeRow]
			@CallerRole NVARCHAR(100), -- 'Coordinator', 'Department', 'Admin', 'Supervisor'
			@UserId nvarchar(500) = NULL,
			@Id nvarchar(500) = NULL
            AS
            BEGIN
			 SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  -- NOLOCK
	            IF @CallerRole ='Department'
                BEGIN
           select 
					T.Id,	
					J.Id as jobId,
					u.Id as userID,
					u.FullName,
					T.PhoneNo,
					U.Email,
					U.UserName,
					t.IqamaNumber,
					T.ProfilePic,
					t.CV_filePath,
					tjs.TStatusColor as JobStatusColor,
					tjs.TStatusName as JobStatus,
					tjs.Id as JobStatusId,
					T.CreatedOn,
					T.LastUpdatedOn,
					T.CreatedById,
					T.LastUpdatedById,
					T.IsDeleted
					
                    from 
					TraineeProfiles  as T

					left join AspNetUsers u on u.Id = T.UserId
					left join traineeJobs tj on T.Id= tj.traineeProfileId
					left join Jobs j on tj.JobId =j.Id
					left join Departments d on d.Id =j.DepId
					left join TraineeJobStatus tjs on tj.StateId = tjs.Id
                    where T.Id=CONVERT(INT, @Id);
                END
                ELSE IF @CallerRole = 'Admin'
                BEGIN
               select 
			   T.Id,	
			   T.Id as DepartmentDetailsId,	
					AspNetUsers.Id as userId, 
					AspNetUsers.FullName,
					AspNetUsers.PhoneNumber as PhoneNo,
					AspNetUsers.Email,
					AspNetUsers.UserName,
					T.IqamaNumber,
					T.ProfilePic,
					T.CV_filePath,
					tjs.Id as jobId,
					tjs.TStatusName as JobStatus,
					tjs.TStatusColor as JobStatusColor,
					tjs.Id as JobStatusId,
					T.CreatedOn,
					T.LastUpdatedOn,
					T.CreatedById,
					T.LastUpdatedById,
					T.IsDeleted
					
                    from 
					TraineeProfiles  as T
					inner join AspNetUsers on AspNetUsers.Id = T.UserId
					left join traineeJobs tj on T.Id= tj.traineeProfileId
					left join TraineeJobStatus tjs on tj.StateId = tjs.Id
                    where T.Id=CONVERT(INT, @Id);
                END

                ELSE IF @CallerRole = 'Job'
                BEGIN
              select 
					 T.Id,	
					T.Id as DepartmentDetailsId,	
					AspNetUsers.Id as userId, 
					AspNetUsers.FullName,
					AspNetUsers.PhoneNumber as PhoneNo,
					AspNetUsers.Email,
					AspNetUsers.UserName,
					T.IqamaNumber,
					T.ProfilePic,
					T.CV_filePath,
					tJ.Id as jobId,
					tjs.TStatusName as JobStatus,
					tjs.TStatusColor as JobStatusColor,
					tjs.Id as JobStatusId,
					T.CreatedOn,
					T.LastUpdatedOn,
					T.CreatedById,
					T.LastUpdatedById,
					T.IsDeleted
					
                    from 
					TraineeProfiles  as T
					inner join AspNetUsers on AspNetUsers.Id = T.UserId
					left join traineeJobs tJ on T.Id= tJ.traineeProfileId
					left join TraineeJobStatus tjs on tJ.StateId = tjs.Id
                    where tJ.Id=CONVERT(INT, @Id);
    END
	 ELSE IF @CallerRole = 'Supervisor'
                BEGIN
              select 
			   T.Id,	
			   T.Id as DepartmentDetailsId,	
					AspNetUsers.Id as userId, 
					AspNetUsers.FullName,
					AspNetUsers.PhoneNumber as PhoneNo,
					AspNetUsers.Email,
					AspNetUsers.UserName,
					T.IqamaNumber,
					T.ProfilePic,
					T.CV_filePath,
					tjs.Id as jobId,
					tjs.TStatusName as JobStatus,
					tjs.TStatusColor as JobStatusColor,
					tjs.Id as JobStatusId,
					T.CreatedOn,
					T.LastUpdatedOn,
					T.CreatedById,
					T.LastUpdatedById,
					T.IsDeleted
					
                    from 
					TraineeProfiles  as T
					inner join AspNetUsers on AspNetUsers.Id = T.UserId
					left join traineeJobs tj on T.Id= tj.traineeProfileId
					left join TraineeJobStatus tjs on tj.StateId = tjs.Id
                    where T.Id=CONVERT(INT, @Id);
    END
	ELSE IF @CallerRole = 'Coordinator'
                BEGIN
             select 
			   T.Id,	
			   T.Id as DepartmentDetailsId,	
					AspNetUsers.Id as userId, 
					AspNetUsers.FullName,
					AspNetUsers.PhoneNumber as PhoneNo,
					AspNetUsers.Email,
					AspNetUsers.UserName,
					T.IqamaNumber,
					T.ProfilePic,
					T.CV_filePath,
					tjs.Id as jobId,
					tjs.TStatusName as JobStatus,
					tjs.TStatusColor as JobStatusColor,
					tjs.Id as JobStatusId,
					T.CreatedOn,
					T.LastUpdatedOn,
					T.CreatedById,
					T.LastUpdatedById,
					T.IsDeleted
					
                    from 
					TraineeProfiles  as T
					inner join AspNetUsers on AspNetUsers.Id = T.UserId
					left join traineeJobs tj on T.Id= tj.traineeProfileId
					left join TraineeJobStatus tjs on tj.StateId = tjs.Id
                    where T.Id=CONVERT(INT, @Id);
    END
	 SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
END


";

			_ = migrationBuilder.Sql(Get_TraineeRow);
			#endregion

			#region Get_TraineeDetails
			string Get_TraineeDetails = @"Create Procedure [dbo].[Get_TraineeDetails]
			@CallerRole NVARCHAR(100), -- 'Admin', 'Supervisor'
			@UserId nvarchar(450) = NULL,
			@Id nvarchar(450) = NULL
			AS
			BEGIN
			SET @UserId = NULLIF(@UserId, 'null');
			SET @Id = NULLIF(@Id, 'null');
		IF @CallerRole = 'Admin'
			BEGIN
			SELECT 
			DISTINCT 
			tp.Id,
			tp.PhoneNo,
			AspNetUsers.FullName,
			tp.EnglishName,
			tp.ArabicName,
			tp.Gender,
			AspNetUsers.Email,	
			AspNetUsers.UserName,
			tp.IqamaNumber,
			tp.Iqama_Expiry_Date,
			tp.Address,
			Cities.Name as City,
			tp.BirthDate,
			tp.GraduationDate,
			tp.ProfilePic,
			tp.CV_CoverLetter,
			tp.CV_filePath,
			tp.license_State,
			tp.Training_File_Path,
			tp.Donation_Hours_Status,
			tp.Donation_Hours_File_Path,
			tp.GraduationFilePath,
			Education.Majority as Education,
			tp.TamheirStatusId,
			tp.License_File,	
			MaritalStates.Name as MaritalStatus,
			AspNetUsers.Id UserID,	
			tp.Social_Duration,	
			tp.Social_Status_Id,
			tp.Tamheir_Status_Id,
			tp.Tamheir_Duration,		
			tp.IsDeleted,
			tp.CreatedById,
			tp.CreatedOn,
			tp.LastUpdatedById,
			tp.LastUpdatedOn

			from 
			TraineeProfiles tp
			--traineeJobs inner join TraineeProfiles on traineeJobs.traineeProfileId=TraineeProfiles.Id
			inner join AspNetUsers on tp.UserId=AspNetUsers.id
			inner join Cities on tp.CityId=Cities.id
			inner join MaritalStates on tp.MaritalStatesId=MaritalStates.Id
			--inner join TraineeJobStatus on traineeJobs.StateId=TraineeJobStatus.Id
			inner join Education on Education.Id=tp.EducationMajorityId
			where tp.UserId=@UserId;
		end
		----------------Supervisor-----------------
	else IF @CallerRole = 'Supervisor'
		BEGIN
			SELECT 
			DISTINCT 
			TraineeProfiles.Id,
			TraineeProfiles.PhoneNo,
			AspNetUsers.FullName,
			TraineeProfiles.Gender,
			AspNetUsers.Email,	
			AspNetUsers.UserName,
			TraineeProfiles.IqamaNumber,
			TraineeProfiles.Iqama_Expiry_Date,
			TraineeProfiles.Address,
			Cities.Name as City,
			TraineeProfiles.BirthDate,
			TraineeProfiles.GraduationDate,
			TraineeProfiles.ProfilePic,
			TraineeProfiles.CV_CoverLetter,
			TraineeProfiles.CV_filePath,
			TraineeProfiles.license_State,
			TraineeProfiles.Training_File_Path,
			TraineeProfiles.Donation_Hours_Status,
			TraineeProfiles.Donation_Hours_File_Path,
			TraineeProfiles.GraduationFilePath,
			Education.Majority as Education,
			TraineeProfiles.TamheirStatusId,
			TraineeProfiles.License_File,	
			MaritalStates.Name as MaritalStatus,
			AspNetUsers.Id UserID,	
			TraineeProfiles.Social_Duration,	
			TraineeProfiles.Social_Status_Id,
			TraineeProfiles.Tamheir_Status_Id,
			TraineeProfiles.Tamheir_Duration,

			TraineeProfiles.IsDeleted,
			TraineeProfiles.CreatedById,
			TraineeProfiles.CreatedOn,
			TraineeProfiles.LastUpdatedById,
			TraineeProfiles.LastUpdatedOn

			from 
			traineeJobs inner join TraineeProfiles on traineeJobs.traineeProfileId=TraineeProfiles.Id
			inner join AspNetUsers on TraineeProfiles.UserId=AspNetUsers.id
			inner join Cities on TraineeProfiles.CityId=Cities.id
			inner join MaritalStates on TraineeProfiles.MaritalStatesId=MaritalStates.Id
			inner join TraineeJobStatus on traineeJobs.StateId=TraineeJobStatus.Id
			inner join Education on Education.Id=TraineeProfiles.EducationMajorityId
			where TraineeProfiles.UserId=@UserId;
		end
		----------------Coordinator-----------------
	else IF @CallerRole = 'Coordinator'
		BEGIN
			SELECT 
			DISTINCT 
			TraineeProfiles.Id,
			TraineeProfiles.PhoneNo,
			AspNetUsers.FullName,
			TraineeProfiles.Gender,
			AspNetUsers.Email,	
			AspNetUsers.UserName,
			TraineeProfiles.IqamaNumber,
			TraineeProfiles.Iqama_Expiry_Date,
			TraineeProfiles.Address,
			Cities.Name as City,
			TraineeProfiles.BirthDate,
			TraineeProfiles.GraduationDate,
			TraineeProfiles.ProfilePic,
			TraineeProfiles.CV_CoverLetter,
			TraineeProfiles.CV_filePath,
			TraineeProfiles.license_State,
			TraineeProfiles.Training_File_Path,
			TraineeProfiles.Donation_Hours_Status,
			TraineeProfiles.Donation_Hours_File_Path,
			TraineeProfiles.GraduationFilePath,
			Education.Majority as Education,
			TraineeProfiles.TamheirStatusId,
			TraineeProfiles.License_File,	
			MaritalStates.Name as MaritalStatus,
			AspNetUsers.Id UserID,	
			TraineeProfiles.Social_Duration,	
			TraineeProfiles.Social_Status_Id,
			TraineeProfiles.Tamheir_Status_Id,
			TraineeProfiles.Tamheir_Duration,	
			TraineeProfiles.IsDeleted,
			TraineeProfiles.CreatedById,
			TraineeProfiles.CreatedOn,
			TraineeProfiles.LastUpdatedById,
			TraineeProfiles.LastUpdatedOn

			from 
			traineeJobs inner join TraineeProfiles on traineeJobs.traineeProfileId=TraineeProfiles.Id
			inner join AspNetUsers on TraineeProfiles.UserId=AspNetUsers.id
			inner join Cities on TraineeProfiles.CityId=Cities.id
			inner join MaritalStates on TraineeProfiles.MaritalStatesId=MaritalStates.Id
			inner join TraineeJobStatus on traineeJobs.StateId=TraineeJobStatus.Id
			inner join Education on Education.Id=TraineeProfiles.EducationMajorityId
			where TraineeProfiles.UserId=@UserId;
		end
end";
			_ = migrationBuilder.Sql(Get_TraineeDetails);
			#endregion
			#endregion


			#region Tickets
			string Get_TicketRows = @"Create PROCEDURE [dbo].[Get_TicketRows]
				 @CallerRole NVARCHAR(100), -- 'Trainee', 'Admin', 'Supervisor', 'Coordinator'
				 @UserId nvarchar(450) = NULL,
				 @Id nvarchar(450) = NULL
				AS
				BEGIN
		 SET @UserId = NULLIF(@UserId, 'null');
			SET @Id = NULLIF(@Id, 'null');

				   IF @CallerRole = 'Trainee'
		BEGIN
		SELECT  
		t.Id, 
		null as UserID,
		t.Subject,
		t.Details,  t.Notes,
		Tby.FullName as TicketByName,
		c.CategoryName as ticketCategory,
		s.Name as ticketStatus,
		null as TicketForName,
		t.IsDeleted,
		t.CreatedById,
		t.CreatedOn,
		t.LastUpdatedById,
		t.LastUpdatedOn
		FROM 
		Ticket t
		left JOIN AspNetUsers Tby ON t.CreatedById = Tby.Id
		left JOIN AspNetUsers Tfor ON t.CreatedForId = Tfor.Id
		left JOIN TicketStatus s ON s.Id = t.StatusId
		left join TicketCategory c on c.Id =t.TicketCategoryId
		WHERE (@UserId = '' OR Tby.Id = @UserId OR Tfor.Id = @UserId)
		END;
               
		ELSE IF @CallerRole = 'Admin'
		BEGIN
		SELECT  
		t.Id, 
		null as UserID,
		t.Subject,
		t.Details,  t.Notes,
		Tby.FullName as TicketByName,
		Tfor.FullName as TicketForName,
		s.Name as ticketStatus,
		c.CategoryName as ticketCategory,
		t.IsDeleted,
		t.CreatedById,
		t.CreatedOn,
		t.LastUpdatedById,
		t.LastUpdatedOn
		FROM 
		Ticket t
		left JOIN AspNetUsers Tby ON t.CreatedById = Tby.Id
		left JOIN AspNetUsers Tfor ON t.CreatedForId = Tfor.Id
		left JOIN TicketStatus s ON s.Id = t.StatusId
		left join TicketCategory c on c.Id =t.TicketCategoryId
		WHERE (@UserId = '' OR Tby.Id = @UserId OR Tfor.Id = @UserId)
		END


		ELSE IF @CallerRole = 'Coordinator'
    		BEGIN
		SELECT  
		t.Id, 
		null as UserID,
		t.Subject,
		t.Details,  t.Notes,
		Tby.FullName as TicketByName,
		Tfor.FullName as TicketForName,
		s.Name as ticketStatus,
		c.CategoryName as ticketCategory,
		t.IsDeleted,
		t.CreatedById,
		t.CreatedOn,
		t.LastUpdatedById,
		t.LastUpdatedOn
		FROM 
		Ticket t
		left JOIN AspNetUsers Tby ON t.CreatedById = Tby.Id
		left JOIN AspNetUsers Tfor ON t.CreatedForId = Tfor.Id
		left JOIN TicketStatus s ON s.Id = t.StatusId
		left join TicketCategory c on c.Id =t.TicketCategoryId
		WHERE (@UserId = '' OR Tby.Id = @UserId OR Tfor.Id = @UserId)
	
END
ELSE IF @CallerRole = 'Supervisor'
    		BEGIN
		SELECT  
		t.Id, 
		null as UserID,
		t.Subject,
		t.Details,  t.Notes,
		Tby.FullName as TicketByName,
		Tfor.FullName as TicketForName,
		s.Name as ticketStatus,
		c.CategoryName as ticketCategory,
		t.IsDeleted,
		t.CreatedById,
		t.CreatedOn,
		t.LastUpdatedById,
		t.LastUpdatedOn
		FROM 
		Ticket t
		left JOIN AspNetUsers Tby ON t.CreatedById = Tby.Id
		left JOIN AspNetUsers Tfor ON t.CreatedForId = Tfor.Id
		left JOIN TicketStatus s ON s.Id = t.StatusId
		left join TicketCategory c on c.Id =t.TicketCategoryId
		WHERE (@UserId = '' OR Tby.Id = @UserId OR Tfor.Id = @UserId)
		END
		END";

			_ = migrationBuilder.Sql(Get_TicketRows);
			#endregion


			#region Jobs

			#region Get_JobDetails
			string Get_JobDetails = @"Create PROCEDURE [dbo].[Get_JobDetails]
  @CallerRole NVARCHAR(100), -- 'Trainee', 'Department', 'Admin', 'Supervisor'
                @UserId NVARCHAR(100) null,
                @Id NVARCHAR(100) null
            AS
            BEGIN
                IF @CallerRole = 'Trainee'
                BEGIN
                   select 
		            J.Id, 
		            J.Name,
					Departments.Name as Department,
					Majority as Education,
					ExperiencesName as Experience,
					AspNetUsers.FullName as Coordinator,
					J.ExplaningOfTranningTask,
					J.Notes,
					s.name as Supervisor,
                    J.StartDate,
		            J.EndDate,
		            Interviews.InterViewDate,
		            Interviews.InterviewStatusId,
		            J.IsDeleted,
		            TraineeJobStatus.TStatusName as traineeStatus,
		            J.CountRequiredToJobs,
		            [dbo].[getJobTraineeCount](J.Id,null, null) TraineeCount,
		           J.CreatedById,
		           J.CreatedOn,
		           J.LastUpdatedById,
		           J.LastUpdatedOn
                    from 
					Jobs J
                    left join Departments on Departments.Id=J.DepId
                    left join Interviews on Interviews.JobId=J.Id
                    left join Experiences on Experiences.Id=J.ExpId and Experiences.IsDeleted=0
					left join AspNetUsers on AspNetUsers.Id =Departments.CoordinatorId
					left join Supervisor s on s.DepartmentId =Departments.Id and s.IsDeleted=0

					left join traineeJobs on traineeJobs.JobId =J.Id
					left join TraineeJobStatus on traineeJobs.StateId =TraineeJobStatus.Id
                    left join Education  on Education.Id=J.EducId
                                      WHERE 
					(J.Id =CONVERT(INT, @Id) AND (@UserId IS NULL OR @UserId ='' OR @UserId = 0))
					OR
					(J.Id = CONVERT(INT, @Id) AND J.Id IN (SELECT JobId FROM TraineeJobs WHERE TraineeProfileId = @UserId))
					OR
					(@UserId IS NULL OR @UserId =''  AND @UserId <> 0 AND J.Id IN (SELECT JobId FROM TraineeJobs WHERE Id = @UserId));
END;
                ELSE 
	            IF @CallerRole ='Department'
                BEGIN
           select 
					J.Name,
					J.IsDeleted,
					J.Id ,	
                    J.StartDate,
					J.EndDate,
					J.InterViewDate,
					J.CountRequiredToJobs,
					[dbo].[getJobTraineeCount](J.Id,null, null) TraineeCount,
					J.CreatedById,
					J.CreatedOn,
					J.LastUpdatedById,
					J.LastUpdatedOn,
					---Below traineeStatusId and traineeStatus are only for model reuqirement 
					J.Id as traineeStatusId,
					J.Id as DepartmentDetailsId,
					J.CreatedById as userId,
					J.Name as traineeStatus
					
                    from 
					jobs  as J 
                    where J.DepId=@Id;
                END

                ELSE IF @CallerRole = 'Admin'
                BEGIN
               select 
					 
		            J.Id, 
		            J.Name,
					Departments.Name as Department,
					Majority as Education,
					ExperiencesName as Experience,
					AspNetUsers.FullName as Coordinator,
					J.ExplaningOfTranningTask,
					J.Notes,
					s.name as Supervisor,
                    J.StartDate,
		            J.EndDate,
		            Interviews.InterViewDate,
		            Interviews.InterviewStatusId,
		            J.IsDeleted,
		            TraineeJobStatus.TStatusName as traineeStatus,
		            J.CountRequiredToJobs,
		            [dbo].[getJobTraineeCount](J.Id,null, null) TraineeCount,
		           J.CreatedById,
		           J.CreatedOn,
		           J.LastUpdatedById,
		           J.LastUpdatedOn
                    from 
					Jobs J
                    left join Departments on Departments.Id=J.DepId
                    left join Interviews on Interviews.JobId=J.Id
                    left join Experiences on Experiences.Id=J.ExpId and Experiences.IsDeleted=0
					left join AspNetUsers on AspNetUsers.Id =Departments.CoordinatorId
					left join Supervisor s on s.DepartmentId =Departments.Id and s.IsDeleted=0

					left join traineeJobs on traineeJobs.JobId =J.Id
					left join TraineeJobStatus on traineeJobs.StateId =TraineeJobStatus.Id
                    left join Education  on Education.Id=J.EducId
                                      WHERE 
					(J.Id =CONVERT(INT, @Id) AND (@UserId IS NULL OR @UserId ='' OR @UserId = 0))
					OR
					(J.Id = CONVERT(INT, @Id) AND J.Id IN (SELECT JobId FROM TraineeJobs WHERE TraineeProfileId = @UserId))
					OR
					(@UserId IS NULL OR @UserId =''  AND @UserId <> 0 AND J.Id IN (SELECT JobId FROM TraineeJobs WHERE Id = @UserId));

                END
                ELSE IF @CallerRole = 'Supervisor'
                BEGIN
              select 
					J.Id as Id,	
					J.Name,
					J.IsDeleted,
                    J.StartDate,
					J.EndDate,
					J.InterViewDate,
					J.CountRequiredToJobs,
					[dbo].[getJobTraineeCount](J.Id,null, null) TraineeCount,
					J.CreatedById,
					J.CreatedOn,
					J.LastUpdatedById,
					J.LastUpdatedOn,
					---Below traineeStatusId and traineeStatus are only for model reuqirement 
					J.Id as traineeStatusId,
					J.Id as DepartmentDetailsId,
					J.CreatedById as userId,
					J.Name as traineeStatus
					
                    from 
					jobs  as J 
                    where J.DepId=@Id;
					END
				END";
			_ = migrationBuilder.Sql(Get_JobDetails);
			#endregion


			#region Get_JobRows
			string Get_JobRows = @"Create PROCEDURE [dbo].[Get_JobRows]
             @CallerRole NVARCHAR(100), -- 'Trainee', 'Department', 'Admin', 'Supervisor'
             @UserId nvarchar(450) = NULL,
             @Id nvarchar(450) = NULL
            AS
            BEGIN
	 SET @UserId = NULLIF(@UserId, 'null');
		SET @Id = NULLIF(@Id, 'null');

               IF @CallerRole = 'Trainee'
    BEGIN
        SELECT DISTINCT 
            j.Id AS Id, 
            u.Id AS UserID,
            j.Name,
            d.Name AS Department,
            c.name AS Coordinator,
            s.name AS Supervisor,
            ts.TStatusColor AS traineeStatusColor,
            ts.TStatusName AS traineeStatus,
            [dbo].[getJobTraineeCount](j.Id, NULL, null) AS TraineeCount,	
            j.interviewDate,
            j.CountRequiredToJobs,
            j.StartDate,
            j.EndDate, 
			NULL AS Applied,
			NULL AS Granted,
			NULL AS Rejected,
			NULL AS Interview,
			NULL AS RefusedCount,
            j.IsDeleted,
            j.CreatedById,
            j.CreatedOn,
            j.LastUpdatedById,
            j.LastUpdatedOn
        FROM 
            traineeJobs tj
        left JOIN TraineeProfiles tp ON tj.traineeProfileId = tp.Id
        left JOIN Jobs j ON tj.JobId = j.Id
        left JOIN AspNetUsers u ON tp.UserId = u.id
        left JOIN Departments d ON j.DepId = d.id
        left JOIN Coordinators c ON d.CoordinatorId = c.UserId
        left JOIN Supervisor s ON s.DepartmentId = d.id
        left JOIN TraineeJobStatus ts ON tj.StateId = ts.Id
WHERE tp.UserId = @UserId
    AND (TRY_CONVERT(INT, @Id) IS NULL OR  @Id = '' OR tj.StateId = TRY_CONVERT(INT, @Id) );
    END;

                ELSE
	            IF @CallerRole ='Department'
                BEGIN
          SELECT DISTINCT 
            j.Id AS Id, 
            u.Id AS UserID,
            j.Name,
            d.Name AS Department,
            c.name AS Coordinator,
            s.name AS Supervisor,
           ts.TStatusColor AS traineeStatusColor,
        null as traineeStatusId,
        ts.TStatusName as traineeStatus,
            [dbo].[getJobTraineeCount](j.Id, NULL, null) AS TraineeCount,	
            j.interviewDate,
            j.CountRequiredToJobs,
            j.StartDate,
            j.EndDate, 
			NULL AS Applied,
			NULL AS Granted,
			NULL AS Rejected,
			NULL AS Interview,
			NULL AS RefusedCount,
            j.IsDeleted,
            j.CreatedById,
            j.CreatedOn,
            j.LastUpdatedById,
            j.LastUpdatedOn
        FROM 
            Jobs j
        left JOIN traineeJobs tj ON j.Id = tj.JobId
        left JOIN TraineeProfiles tp ON tj.traineeProfileId = tp.Id
        left JOIN AspNetUsers u ON tp.UserId = u.id
        left JOIN Departments d ON j.DepId = d.id
        left JOIN Coordinators c ON d.CoordinatorId = c.UserId
        left JOIN Supervisor s ON s.DepartmentId = d.id
        left JOIN TraineeJobStatus ts ON tj.StateId = ts.Id
		WHERE 
		j.DepId = CONVERT(INT, @Id)
		
		
		END

        ELSE IF @CallerRole = 'Admin'
BEGIN
     SELECT DISTINCT 
        j.Id, 
        null as UserID,
        j.Name,
        d.Name AS Department,
        c.name AS Coordinator,
        s.name AS Supervisor,
		ts.TStatusColor AS traineeStatusColor,
        null as traineeStatusId,
        ts.TStatusName as traineeStatus,
        j.interviewDate,
        j.CountRequiredToJobs,
        j.StartDate,
        j.EndDate, 
		[dbo].[getJobTraineeCount](j.Id, NULL, null) AS TraineeCount,	
		[dbo].[getJobTraineeCount](J.Id,1, null) Applied,
		[dbo].[getJobTraineeCount](J.Id,2, null) Interview,
		[dbo].[getJobTraineeCount](J.Id,3, null) Granted,
		[dbo].[getJobTraineeCount](J.Id,4, null) Rejected,

		null as RefusedCount,
        j.IsDeleted,
        j.CreatedById,
        j.CreatedOn,
        j.LastUpdatedById,
        j.LastUpdatedOn
    FROM 
        Jobs j
    left JOIN TraineeProfiles tp ON j.Id = tp.Id
	left join traineeJobs tj on tj.traineeProfileId =tp.Id
	left join TraineeJobStatus ts on tj.StateId =ts.Id
    left JOIN AspNetUsers u ON tp.UserId = u.id
    left JOIN Departments d ON j.DepId = d.id
    left JOIN Coordinators c ON d.CoordinatorId = c.UserId
    left JOIN Supervisor s ON s.DepartmentId = d.id
    WHERE (@UserId = '' OR tp.UserId = @UserId)
END

                ELSE IF @CallerRole = 'Supervisor'
                BEGIN
              SELECT 
            j.Id AS Id, 
           s.UserId AS UserID,
            j.Name,
            d.Name AS Department,
          c.name AS Coordinator,
            s.name AS Supervisor,
           ts.id AS traineeStatusId,
		ts.TStatusColor AS traineeStatusColor,
            ts.TStatusName AS traineeStatus,
           [dbo].[getJobTraineeCount](j.Id, NULL, null) AS TraineeCount,	
            j.interviewDate,
            j.CountRequiredToJobs,
            j.StartDate,
            j.EndDate, 
			NULL AS Applied,
			NULL AS Granted,
			NULL AS Rejected,
			NULL AS Interview,
			NULL AS RefusedCount,
            j.IsDeleted,
            j.CreatedById,
            j.CreatedOn,
            j.LastUpdatedById,
            j.LastUpdatedOn
        FROM 
       Supervisor s
	   left join Departments d on d.Id=s.DepartmentId
	   left join Jobs J on J.DepId =d.Id
	   left join Coordinators c on c.DepartmentId=d.Id
	  left JOIN TraineeProfiles tp ON j.Id = tp.Id
	left join traineeJobs tj on tj.traineeProfileId =tp.Id
	left join TraineeJobStatus ts on tj.StateId =ts.Id
	   WHERE S.UserId = @UserId
    END
 ELSE IF @CallerRole = 'Coordinator'
		BEGIN
		SELECT 
            j.Id, 
            null AS UserID,
            j.Name,
            d.Name AS Department,
            null as Coordinator,
            s.name AS Supervisor,
            ts.TStatusColor AS traineeStatusColor,
			ts.Id as traineeStatusId,
			ts.TStatusName as traineeStatus,
           [dbo].[getJobTraineeCount](j.Id, NULL, null) AS TraineeCount,	
            j.interviewDate,
            j.CountRequiredToJobs,
            j.StartDate,
            j.EndDate, 
			NULL AS Applied,
			NULL AS Granted,
			NULL AS Rejected,
			NULL AS Interview,
			NULL AS RefusedCount,
            j.IsDeleted,
            j.CreatedById,
            j.CreatedOn,
            j.LastUpdatedById,
            j.LastUpdatedOn
        FROM 
              Departments d
		left join Jobs J on J.DepId =d.Id
		left join Supervisor s on s.DepartmentId=d.Id
		left join TraineeProfiles tp ON j.Id = tp.Id
		left join traineeJobs tj on tj.traineeProfileId =tp.Id
		left join TraineeJobStatus ts on tj.StateId =ts.Id
	   WHERE d.CoordinatorId = @UserId
    END
END
";
			_ = migrationBuilder.Sql(Get_JobRows);
			#endregion
			#endregion


			#region Interview

			string Get_InterviewRow = @"Create PROCEDURE [dbo].[Get_InterviewRow]
                @CallerRole NVARCHAR(100),
				@UserId NVARCHAR(450),
				@Id NVARCHAR(450)
			AS
			BEGIN
				SET @UserId = NULLIF(@UserId, 'null');

				IF @CallerRole = 'Trainee'
				BEGIN
					SELECT DISTINCT 
						i.Id,
						i.interviewDate,
						InterviewStatus.StatusName,
						i.notes,
						u.FullName as student,
						j.Name as jobName,			
						i.IsDeleted,
						i.CreatedById,
						i.CreatedOn,
						i.LastUpdatedById,
						i.LastUpdatedOn
					FROM 
					Interviews i
					left JOIN TraineeProfiles tp ON i.TraineeProfileId = tp.Id
					left JOIN InterviewStatus  ON i.InterviewStatusId = InterviewStatus.Id
					left JOIN Jobs j ON i.JobId = j.Id
					left JOIN AspNetUsers u ON u.Id = i.InterviewerId
					left JOIN Departments d ON j.DepId = d.id
					WHERE i.InterviewerId = @UserId and i.JobId=CONVERT(INT, @Id);
				END;				END;";

			_ = migrationBuilder.Sql(Get_InterviewRow);


			string Get_InterviewDetails = @"Create PROCEDURE [dbo].[Get_InterviewDetails]
                @CallerRole NVARCHAR(100),
				@UserId NVARCHAR(450),
				@Id NVARCHAR(450)
			AS
			BEGIN
				SET @UserId = NULLIF(@UserId, 'null');

				IF @CallerRole = 'Trainee'
				BEGIN
					SELECT DISTINCT 
						i.Id,
						i.interviewDate,
						InterviewStatus.StatusName as interviewState,
						i.locationUrl,
						i.notes,
						interviewer.FullName as InterviewBy,
						trainee.FullName as TraineeName,
						j.Name as jobName,			
						i.IsDeleted,
						i.CreatedById,
						i.CreatedOn,
						i.LastUpdatedById,
						i.LastUpdatedOn
					FROM 
					Interviews i
					left JOIN TraineeProfiles tp ON tp.UserId = @UserId
					left JOIN AspNetUsers interviewer ON interviewer.Id = i.InterviewerId					
					left JOIN AspNetUsers trainee ON trainee.Id = tp.UserId
					left JOIN InterviewStatus  ON i.InterviewStatusId = InterviewStatus.Id
					left JOIN Jobs j ON i.JobId = j.Id	
					left JOIN Departments d ON j.DepId = d.id
					WHERE i.JobId=CONVERT(INT, @Id) and i.IsDeleted=0;
				END;				
				END;";

			_ = migrationBuilder.Sql(Get_InterviewDetails);

			#endregion



			#region TraineeContract

			string Get_TraineeContractRows = @"Create PROCEDURE [dbo].[Get_TraineeContractRows]
	as";

			_ = migrationBuilder.Sql(Get_TraineeContractRows);


			string Get_TraineeContractDetail = @"Create PROCEDURE [dbo].[Get_TraineeContractDetail]
                @CallerRole NVARCHAR(100),
				@UserId NVARCHAR(450),
				@Id NVARCHAR(450)
			AS
			BEGIN
				SET @UserId = NULLIF(@UserId, 'null');

				IF @CallerRole = 'Trainee'
				BEGIN
					SELECT DISTINCT 
						tc.Id,
						trainee.FullName as contractFor,
						contractor.FullName as ContractBy,
						tc.StartDate,
						tc.EndDate,
						tc.contractDuration,
						TC.Name,
						tc.Details,
						tc.ContractFile as Attachment,
							d.Name as DepartmentName,
													TJS.TStatusColor as ContractStatusColor,
						TJS.TStatusName as ContractStatus,
						j.Name as jobName,	
						null as AcceptContract,
						tc.IsDeleted,
						tc.CreatedById,
						tc.CreatedOn,
						tc.LastUpdatedById,
						tc.LastUpdatedOn
					FROM 
					TraineeContract tc
					left JOIN TraineeProfiles tp ON tp.UserId = @UserId				
					left JOIN AspNetUsers trainee ON trainee.Id = tp.UserId
					left JOIN Jobs j ON tc.JobId = j.Id	
					left join TraineeJobStatus TJS on TJS.Id=tc.StatusId
					LEFT JOIN AspNetUsers contractor ON contractor.Id = tc.CreatedById
					left JOIN Departments d ON j.DepId = d.id
					WHERE (tc.JobId=CONVERT(INT, @Id) and tc.IsDeleted=0) OR (tc.Id=CONVERT(INT, @Id) and tc.IsDeleted=0) OR (trainee.Id= @UserId and tc.IsDeleted=0)
				END;				
				
				else IF @CallerRole = 'Admin'
				BEGIN
					SELECT DISTINCT 
						tc.Id,
						trainee.FullName as ContractFor,
						contractor.FullName as ContractBy,
						tc.StartDate,
						tc.EndDate,
						tc.ContractDuration,
						TC.Name,
						tc.Details,
						d.Name as DepartmentName,
						j.Name as JobName,
						null as AcceptContract,
						tc.IsDeleted,
						tc.CreatedById,
						tc.ContractFile as Attachment,
						tc.CreatedOn,
						tc.LastUpdatedById,
						TJS.TStatusColor as ContractStatusColor,
						TJS.TStatusName as ContractStatus,
						tc.LastUpdatedOn
					
					FROM TraineeContract tc
					LEFT JOIN TraineeProfiles tp ON tp.Id = tc.traineeProfileId
					LEFT JOIN AspNetUsers trainee ON trainee.Id = tp.UserId
					LEFT JOIN AspNetUsers contractor ON contractor.Id = tc.CreatedById
					left join TraineeJobStatus TJS on TJS.Id=tc.StatusId
					LEFT JOIN Jobs j ON tc.JobId = j.Id	
					LEFT JOIN Departments d ON j.DepId = d.Id
					WHERE (tc.Id = CONVERT(INT, @Id) AND tc.IsDeleted = 0) OR (trainee.Id = @UserId AND tc.IsDeleted = 0)
				END;				
			
				END;";

			_ = migrationBuilder.Sql(Get_TraineeContractDetail);

			#endregion


			#region Department

			string Get_DepartmentDetails = @"


Create PROCEDURE Get_DepartmentDetails
 @CallerRole NVARCHAR(100), -- 'Trainee', 'Department', 'Admin', 'Supervisor'
    @UserId NVARCHAR(450) = NULL,
    @Id NVARCHAR(450) = NULL
AS
BEGIN

 IF @CallerRole = 'Supervisor'
    BEGIN
		SELECT Distinct
		d.Id,
			  d.Name,
			    null as Supervisor,
			   [dbo].[getJobTraineeCount](j.Id, NULL, null) AS TraineeCount,
			 [dbo].[getJobsCount](NULL,d.Id) as JobCount,
			   u.FullName as Coordinator,
				d.IsDeleted,
				d.CreatedById,
				d.CreatedOn,
				d.LastUpdatedById,
				d.LastUpdatedOn
			FROM 
			Departments d
			left join Supervisor s on s.DepartmentId=d.Id
			LEFT JOIN Jobs j ON j.DepId = d.Id
			left join Coordinators c on c.UserId=d.CoordinatorId
			left join AspNetUsers u on u.Id =c.UserId
		WHERE S.UserId = @UserId
	END;
	else  IF @CallerRole = 'Admin'
    BEGIN
		SELECT Distinct
		d.Id,
			  d.Name,
			   c.FullName as CoordinatorName,
			   sup.FullName as SupervisorName,
			   [dbo].[getJobTraineeCount](j.Id, NULL, null) AS TraineeCount,
			 [dbo].[getJobsCount](NULL,d.Id) as JobCount,
				d.IsDeleted,
				d.CreatedById,
				d.CreatedOn,
				d.LastUpdatedById,
				d.LastUpdatedOn
			FROM 
			Departments d
			left join Supervisor s on s.DepartmentId=d.Id
			LEFT JOIN Jobs j ON j.DepId = d.Id
			left join AspNetUsers c on c.Id =d.CoordinatorId
			left join AspNetUsers sup on sup.Id = s.UserId

		WHERE 
		(@UserId='' or s.UserId=@UserId )
        OR (@Id = '' OR @Id = CONVERT(INT, @Id)) 
		AND d.IsDeleted=0;
END;
    --ELSE IF @CallerRole = 'Trainee'
    --BEGIN
    --    -- Include Trainee-related query logic here
    --END;
    --ELSE IF @CallerRole = 'Department'
    --BEGIN
    --    -- Include Department-related query logic here
    --END;
END;




";
			_ = migrationBuilder.Sql(Get_DepartmentDetails);
			string Get_DepartmentRows = @"Create PROCEDURE [dbo].[Get_DepartmentRows]
    @CallerRole NVARCHAR(100), -- 'Trainee', 'Department', 'Admin', 'Supervisor'
    @UserId NVARCHAR(450) = NULL,
    @Id NVARCHAR(450) = NULL
AS
BEGIN

 IF @CallerRole = 'Supervisor'
    BEGIN
		SELECT Distinct
		d.Id,
			  d.Name,
			    null as Supervisor,
			   [dbo].[getJobTraineeCount](j.Id, NULL, null) AS TraineeCount,
			 [dbo].[getJobsCount](NULL,d.Id) as JobCount,
			   u.FullName as Coordinator,
				d.IsDeleted,
				d.CreatedById,
				d.CreatedOn,
				d.LastUpdatedById,
				d.LastUpdatedOn
			FROM 
			Departments d
			left join Supervisor s on s.DepartmentId=d.Id
			LEFT JOIN Jobs j ON j.DepId = d.Id
			left join Coordinators c on c.UserId=d.CoordinatorId
			left join AspNetUsers u on u.Id =c.UserId
		WHERE S.UserId = @UserId
	END;
	else  IF @CallerRole = 'Admin'
    BEGIN
		SELECT Distinct
		d.Id,
			  d.Name,
			   null as Supervisor,
			   [dbo].[getJobTraineeCount](NULL, NULL, d.Id) AS TraineeCount,
			 [dbo].[getJobsCount](NULL,d.Id) as JobCount,
			   u.FullName as Coordinator,
				d.IsDeleted,
				d.CreatedById,
				d.CreatedOn,
				d.LastUpdatedById,
				d.LastUpdatedOn
			FROM 
			Departments d
			left join Supervisor s on s.DepartmentId=d.Id
			LEFT JOIN Jobs j ON j.DepId = d.Id
			left join Coordinators c on c.UserId=d.CoordinatorId
			left join AspNetUsers u on u.Id =c.UserId
		WHERE s.UserId = @UserId
          AND (@Id = '' OR @Id = CONVERT(INT, @Id)) and d.IsDeleted=0;
END;END;	

";

			_ = migrationBuilder.Sql(Get_DepartmentRows);

			#endregion

			#endregion
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}