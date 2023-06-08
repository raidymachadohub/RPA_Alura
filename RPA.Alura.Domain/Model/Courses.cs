using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPA.Alura.Domain.Model;

public class Courses
{
    [Key] 
    public virtual long Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string Teacher { get; set; }
    public virtual double WorkLoad { get; set; }
    public virtual string Description { get; set; }
    
    [Column("IdRoutine")]
    [Required]
    public long IdRoutine { get; set; }

    [ForeignKey("IdRoutine")]
    public virtual Routine Routine { get; set; }

    public Courses(string title, string teacher, double workLoad, string description, Routine routine)
    {
        Title = title;
        Teacher = teacher;
        WorkLoad = workLoad;
        Description = description;
        Routine = routine;
    }
}