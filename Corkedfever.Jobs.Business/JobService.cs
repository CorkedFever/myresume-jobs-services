using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corkedfever.Jobs.Data.Models;
using Corkedfever.Jobs.Data;

namespace Corkedfever.Jobs.Business
{
    public interface IJobService
    {
        JobModel GetJobById(int id);
        List<JobModel> GetJobs();

        void CreateJob(Jobs.Data.Models.JobModel job);
        void UpdateJob(int id, Jobs.Data.Models.JobModel job);
    }
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public JobModel GetJobById(int id)
        {
            throw new NotImplementedException();
        }

        public List<JobModel> GetJobs()
        {
            throw new NotImplementedException();
        }
        public void CreateJob(JobModel job)
        {
            throw new NotImplementedException();
        }
        public void UpdateJob(int id, JobModel job)
        {
            throw new NotImplementedException();
        }
    }
}
