using Newtonsoft.Json;

namespace RPA.Alura.Domain.DTO;

public class RoutineDTO
{
    [JsonProperty(Required = Required.Always)]
    public long id { get; set; }

    [JsonProperty(Required = Required.Always)]
    public string titleSearch { get; set; }

    [JsonProperty(Required = Required.Always)]
    public bool active { get; set; } = true;

    [JsonConstructor]
    public RoutineDTO(string titleSearch, bool active)
    {
        this.titleSearch = titleSearch;
        this.active = active;
    }
}