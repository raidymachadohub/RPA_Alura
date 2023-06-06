using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPA.Alura.Domain.DTO;
using RPA.Alura.Domain.Model;
using RPA.Alura.Services.Services.Interfaces;

namespace RPA.Alura.Application.Controllers;

[Route("v1/[controller]")]
public class RoutineController : Controller
{
    private readonly IRoutineService _routineService;
    private readonly IMapper _mapper;

    public RoutineController(IRoutineService routineService,
        IMapper mapper)
    {
        _routineService = routineService;
        _mapper = mapper;
    }

    /// <summary>
    /// Inclusão de dados para rotina.
    /// No TitleSearch = Informar o nome que será pesquisado no site do Alura
    /// </summary>
    /// <param name="routineDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<RoutineDTO>> Post([FromBody] RoutineDTO routineDto)
    {
        try
        {
            var routine = _mapper.Map<Routine>(routineDto);
            var result = await _routineService.AddRoutineAsync(routine);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Obter todas as rotinas
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<RoutineDTO>> Get()
    {
        try
        {
            var result = await _routineService.GetRoutineAsync();
            if (result == null)
                return NotFound();

            if (result.Value == null)
                return NotFound();

            var response = _mapper.Map<IEnumerable<RoutineDTO>>(result.Value);

            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}