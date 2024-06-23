using Newtonsoft.Json;

namespace backend.Models
{
    public class Task
    {
        [JsonProperty("taskdescription")]
        public string Taskdescription { get; set; }

        public Task() { }
    }
}