using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corkedfever.Jobs.Data.Models;
using Corkedfever.Common.Data;
using Microsoft.EntityFrameworkCore;
using Corkedfever.Common.Data.DBModels;

namespace Corkedfever.Jobs.Data
{
    public interface IJobRepository
    {
        void CreateJob(JobModel job);
        void CreateJobType(JobTypeModel jobType);
        JobModel GetJobById(int id);
        List<JobModel> GetJobs();
        void UpdateJob(int id, JobModel job);
    }
    public class JobRepository : IJobRepository
    {
        private readonly IDbContextFactory<CorkedFeverDataContext> _context;

        public JobRepository(IDbContextFactory<CorkedFeverDataContext> context)
        {
            _context = context;
        }

        public void CreateJob(JobModel jobModel)
        {
            using (var dbContext = _context.CreateDbContext())
            {
                var existingJobType = dbContext.JobType.Where(jt => jt.JobTypeName == jobModel.JobType).FirstOrDefault();
                if (existingJobType == null)
                {
                    return;
                }
                var newJob = new Job
                {
                    JobTitle = jobModel.JobTitle,
                    JobDescription = jobModel.JobDescription,
                    JobLocation = jobModel.JobLocation,
                    StartDate = jobModel.StartDate,
                    JobType = existingJobType,
                    EndDate = jobModel.EndDate,
                    CreatedDate = DateTime.Now
                };
                dbContext.Job.Add(newJob);
                dbContext.SaveChanges();
            }
        }

        public void CreateJobType(JobTypeModel jobType)
        {
            using (var dbContext = _context.CreateDbContext())
            {
                var newJobType = new JobType
                {
                    JobTypeName = jobType.JobTypeName,
                    JobTypeDescription = jobType.JobTypeDescription
                };
                dbContext.JobType.Add(newJobType);
                dbContext.SaveChanges();
            }
        }

        public JobModel GetJobById(int id)
        {
            using (var dbContext = _context.CreateDbContext())
            {
                var job = dbContext.Job.FirstOrDefault(j => j.Id == id);
                if (job == null)
                {
                    return null;
                }
                return new JobModel
                {
                    JobTitle = job.JobTitle,
                    JobDescription = job.JobDescription,
                    JobLocation= job.JobLocation,
                    StartDate = job.StartDate,
                    EndDate = job.EndDate
                };
            }
        }

        public List<JobModel> GetJobs()
        {
            using (var dbContext = _context.CreateDbContext())
            {
                return dbContext.Job.Include(j=>j.JobType).Select(j => new JobModel
                {
                    JobTitle = j.JobTitle,
                    JobDescription = j.JobDescription,
                    JobLocation = j.JobLocation,
                    JobType = j.JobType.JobTypeName,
                    StartDate = j.StartDate,
                    EndDate = j.EndDate
                }).ToList();
            }
        }

        public void UpdateJob(int id, JobModel job)
        {
            using (var dbContext = _context.CreateDbContext())
            {
                var existingJob = dbContext.Job.FirstOrDefault(j => j.Id == id);
                if (existingJob == null)
                {
                    return;
                }
                existingJob.JobTitle = job.JobTitle;
                existingJob.JobDescription = job.JobDescription;
                existingJob.JobLocation = job.JobLocation;
                existingJob.StartDate = job.StartDate;
                existingJob.EndDate = job.EndDate;
                dbContext.SaveChanges();
            }
        }
    }
}
