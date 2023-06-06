using Microsoft.AspNetCore.Mvc;
using RPA.Alura.Services.Services.Interfaces;

namespace RPA.Alura.Application.Controllers;

[Route("v1/[controller]")]
public class SeleniumController : Controller
{
    private readonly ISeleniumService _seleniumService;

    public SeleniumController(ISeleniumService seleniumService)
    {
        _seleniumService = seleniumService;
    }
    
    /// <summary>
    /// Endpoint para executar as capturas de dados.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("ExecutarColeta")]
    public async Task<ActionResult> Get()
    {
        try
        {
            var result = await _seleniumService.CaptureData();
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}