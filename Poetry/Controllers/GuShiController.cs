using Microsoft.AspNetCore.Mvc;
using Poetry.Main.Application.Queriers;
using Poetry.Main.Domain.Models;

namespace Poetry.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuShiController: ControllerBase
{
    
    private readonly GuShiQueryHandler _guShiQueryHandler;

    public GuShiController(GuShiQueryHandler guShiQueryHandler) =>
        _guShiQueryHandler = guShiQueryHandler;
    
    [HttpGet("get/{id}")]
    public async Task<ActionResult<GuShi>> Get(string id)
    {
        var book = await _guShiQueryHandler.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }
    
    [HttpGet("get_by_self_id/{id}")]
    public async Task<ActionResult<GuShi>> GetBySelfId(string id)
    {
        var book = await _guShiQueryHandler.GetBySelfIdAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }
    
    [HttpGet("get_by_title")]
    public async Task<ActionResult<GuShi>> GetByTitle(string title,string author)
    {
        var book = await _guShiQueryHandler.GetByTitleAsync(title,author);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }


}