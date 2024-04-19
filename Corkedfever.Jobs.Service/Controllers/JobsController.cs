using Corkedfever.Jobs.Business;
using Corkedfever.Jobs.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corkedfever.Jobs.Service.Controllers
{
    [Route("jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetJobs()
        {
            try
            {
                return Ok(_jobService.GetJobs());
            }
            catch (Exception ex)
            {
               return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetJob(int id)
        {
            try
            {
                return Ok(_jobService.GetJobById(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateJob")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateJob([FromBody] JobModel job)
        {
            try
            {
                _jobService.CreateJob(job);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateJob(int id, [FromBody] JobModel job)
        {
            try
            {
                _jobService.UpdateJob(id, job);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [HttpPost("CreateJobType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateJobType([FromBody] JobTypeModel jobType)
        {
            try
            {
                _jobService.CreateJobType(jobType);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        
    }
}
