using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Issue25411.Models;

public class Job
{
    [JsonPropertyName("jobId")]
    public string Id { get; } = Guid.NewGuid().ToString();

    public string Status => CreatedDateTime > DateTimeOffset.Now.AddSeconds(10) ? "succeeded" : "running";

    public DateTimeOffset CreatedDateTime { get; } = DateTimeOffset.Now;
}
