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
    
    [HttpGet("get")]
    public async Task<ActionResult<GuShi>> Get(string id)
    {
        var data = await _guShiQueryHandler.GetAsync(id);

        if (data is null)
        {
            return NotFound();
        }

        return data;
    }
    
    [HttpGet("get_by_self_id")]
    public async Task<ActionResult<GuShi>> GetBySelfId(string id)
    {
        var data = await _guShiQueryHandler.GetBySelfIdAsync(id);

        if (data is null)
        {
            return NotFound();
        }

        return data;
    }
    
    [HttpGet("get_by_title")]
    public async Task<ActionResult<GuShi>> GetByTitle(string title,string author)
    {
        var data = await _guShiQueryHandler.GetByTitleAsync(title,author);

        if (data is null)
        {
            return NotFound();
        }

        return data;
    }
    
    [HttpPost("get_list")]
    public async Task<ActionResult<List<GuShi>>> GetList(GetListQueryArgs query)
    {
        var data = await _guShiQueryHandler.GetListAsync(query);

        if (data is null)
        {
            return NotFound();
        }

        return data;
    }


}