using APBDKolokwium2.DTOs;
using APBDKolokwium2.Exceptions;
using APBDKolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDKolokwium2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BatchesController : ControllerBase
{
    private readonly IBatchService _batchService;

    public BatchesController(IBatchService batchService)
    {
        _batchService = batchService;
    }

    [HttpPost]
    public async Task<IActionResult> PostBatch(PostBatchDTO Batch)
    {
        try
        {
            await _batchService.PostBatch(Batch);
            return Created();
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
    }
}