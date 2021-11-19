using Issue25411.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Issue25411.Controllers;

[ApiController]
[Route("jobs")]
public class JobController : ControllerBase
{
    private static readonly ConcurrentDictionary<string, Job> _jobs = new(StringComparer.OrdinalIgnoreCase);
    private readonly ILogger<JobController> _logger;

    public JobController(ILogger<JobController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult<Job> Start()
    {
        if (!IsSupported)
        {
            return BadRequest();
        }

        Job job = new();
        _jobs.AddOrUpdate(job.Id, job, (id, j) => j);

        UriBuilder builder = new(Request.Scheme, Request.Host.Host, Request.Host.Port ?? (Request.IsHttps ? 443 : 80));
        builder.Path = Url.Content($"~/jobs/{job.Id}");

        Response.Headers.Add("Operation-Location", builder.Uri.ToString());
        return job;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Job>> List()
    {
        if (!IsSupported)
        {
            return BadRequest();
        }

        return Ok(_jobs.Values);
    }

    [HttpGet("{jobId}")]
    public ActionResult<Job> Status(string jobId)
    {
        if (!IsSupported)
        {
            return BadRequest();
        }

        if (_jobs.TryGetValue(jobId, out var job))
        {
            return Ok(job);
        }

        return NotFound();
    }

    private bool IsSupported => Request.Query.TryGetValue("api-version", out var value) && value == "2021-11-18";
}
