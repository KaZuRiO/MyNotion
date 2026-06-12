using Microsoft.AspNetCore.Mvc;
using backend.Application.UseCases;
using System.Threading.Tasks;
using backend.Application.DTOs.Block;
namespace backend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlocksController : ControllerBase
{
    private readonly BlockUseCase _blockUseCase;

    public BlocksController(BlockUseCase blockUseCase)
    {
        _blockUseCase = blockUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetBlocksByPageId([FromQuery] int pageId)
    {
        try
        {
            var blocks = await _blockUseCase.GetBlocksByPageId(pageId);
            return Ok(blocks);
        }
        catch
        {
            return StatusCode(500, "An error occurred while retrieving blocks.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlockById(int id)
    {
        try
        {
            var block = await _blockUseCase.GetBlockById(id);

            if (block == null)
                return NotFound($"Block with ID {id} not found.");

            return Ok(block);
        }
        catch
        {
            return StatusCode(500, "An error occurred while retrieving the block.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlock([FromBody] CreateBlockDto dto)
    {
        try
        {
            var created = await _blockUseCase.CreateBlockAsync(dto);
            return Ok(created);
        }
        catch
        {
            return StatusCode(500, "An error occurred while creating the block.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlock(int id, [FromBody] UpdateBlockDto dto)
    {
        try
        {
            var updated = await _blockUseCase.UpdateBlockAsync(id, dto);
            if (updated == null)
                return NotFound($"Block with ID {id} not found.");
            return NoContent();
        }
        catch
        {
            return StatusCode(500, "An error occurred while updating the block.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlock(int id)
    {
        try
        {
            await _blockUseCase.DeleteBlockAsync(id);
            return NoContent();
        }
        catch
        {
            return StatusCode(500, "An error occurred while deleting the block.");
        }
    }

    // GET children
    [HttpGet("{id}/children")]
    public async Task<IActionResult> GetChildren(int id)
    {
        try
        {
            var children = await _blockUseCase.GetChildrenAsync(id);
            return Ok(children);
        }
        catch
        {
            return StatusCode(500, "An error occurred while retrieving children blocks.");
        }
    }
}