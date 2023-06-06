using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPA.Alura.Domain.DTO;
using RPA.Alura.Domain.Model;
using RPA.Alura.Services.Services.Interfaces;

namespace RPA.Alura.Application.Controllers;

[Route("v1/[controller]")]
public class CourseController : Controller
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;
    
    public CourseController(ICourseService courseService,
                            IMapper mapper)
    {
        _courseService = courseService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<ActionResult<CoursesDTO>> Post([FromBody] CoursesDTO courseDto)
    {
        try
        {
            var courses = _mapper.Map<Courses>(courseDto);
            var result = await _courseService.AddCourseAsync(courses);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<CoursesDTO>> Get()
    {
        try
        {
            var result = await _courseService.GetCoursesAsync();

            var response = _mapper.Map<IEnumerable<CoursesDTO>>(result.Value);

            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}