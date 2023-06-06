using Newtonsoft.Json;

namespace RPA.Alura.Domain.DTO;

public class CoursesDTO
{
    public long id { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public  string title { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public  string teacher { get; set; }
    [JsonProperty(Required = Required.Always)]
    public  double workLoad { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public  string description { get; set; }
    
    [JsonProperty(Required = Required.AllowNull)]
    public  long idRoutine { get; set; }

    [JsonConstructor]
    public CoursesDTO(string title, string teacher, double workLoad, string description)
    {
        this.title = title;
        this.teacher = teacher;
        this.workLoad = workLoad;
        this.description = description;
    }
}