using System.ComponentModel.DataAnnotations;

namespace RPA.Alura.Domain.Model;

public class Routine
{
    [Key] public virtual long Id { get; set; }
    public virtual string TitleSearch { get; set; }
    public virtual bool Active { get; set; } = true;

    public Routine(string titleSearch, bool active)
    {
        TitleSearch = titleSearch;
        Active = active;
    }

    public Routine()
    {
    }
}