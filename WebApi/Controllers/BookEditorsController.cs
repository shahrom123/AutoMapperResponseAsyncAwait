using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookEditorController : ControllerBase
{
    private readonly IBookEditorService _bookEditorService;
    
    public BookEditorController(IBookEditorService bookEditorService)
    {
        _bookEditorService = bookEditorService;  
    }
    [HttpGet("GetBookEditors")]
    public List<GetBookEditorDto> GetBookEditors()
    {
        return _bookEditorService.GetBookEditors(); 
    } 

    [HttpPost("AddBookEditor")]
    public AddBookEditorDto AddBookEditor(AddBookEditorDto book)
    {
        return _bookEditorService.AddBookEditor(book); 
    }

    [HttpPut("UpdateBookEditor")]
    public AddBookEditorDto UpdateBookEditor(AddBookEditorDto book)
    {
        return _bookEditorService.UpdateBookEditor(book); 
    }
    
    [HttpDelete("DeleteBookEditor")]
    public IActionResult DeleteBookEditor(int id)
    {
        var res =  _bookEditorService.DeleteBookEditor(id);
        if (res == true) return Ok("Success");
        return BadRequest("Data not deleted !");  
    }
    
    
}