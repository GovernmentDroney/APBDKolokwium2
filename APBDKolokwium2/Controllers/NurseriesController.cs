using APBDKolokwium2.Services;
using APBDKolokwium2.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace APBDKolokwium2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NurseriesController : ControllerBase
{
    private readonly INurseryService _nurseryService;

    public NurseriesController(INurseryService nurseryService)
    {
        _nurseryService = nurseryService;
    }

    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetNursery(int id)
    {
        try
        {
            var getNursery = await _nurseryService.GetNursery(id);
            return Ok(getNursery);
        }
        catch (NotFoundException )
        {
            return NotFound();
        }
    }
}