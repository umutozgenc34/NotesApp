using Microsoft.AspNetCore.Mvc;
using NotesApp.Model.Dtos;
using NotesApp.Service.Abstracts;

namespace NotesApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController(INoteService noteService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await noteService.GetAllNotesAsync());
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await noteService.GetNoteByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNoteRequest request) => Ok(await noteService.AddNoteAsync(request));

    [HttpPut]
    public async Task<IActionResult> Update( [FromBody] UpdateNoteRequest noteRequest)
    {
      
        await noteService.UpdateNoteAsync(noteRequest);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await noteService.DeleteNoteAsync(id);
        return NoContent();
    }
}
