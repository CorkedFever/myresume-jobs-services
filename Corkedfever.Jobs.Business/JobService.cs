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
            return _jobRepository.GetJobById(id);
        }

        public List<JobModel> GetJobs()
        {
            return _jobRepository.GetJobs();
        }
        public void CreateJob(JobModel job)
        {
            _jobRepository.CreateJob(job);
        }
        public void UpdateJob(int id, JobModel job)
        {
            _jobRepository.UpdateJob(id, job);
        }
    }
}
