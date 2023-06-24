using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class EditorController:ControllerBase
{
    private readonly IEditorService _editorService;

    public EditorController(IEditorService editorService)
    {
        _editorService = editorService;
    }

    [HttpGet("GetEditors")]
    public List<GetEditorDto> GetEditors()
    {
        return _editorService.GetEditors();  
    }
    [HttpGet("GetEditorById")]
    public GetEditorDto GetEditorById(int id)
    {
        return _editorService.GetEditorById(id);  
    }
    
    [HttpPost("AddEditor")]
    public AddEditorDto AddEditor(AddEditorDto model)
    {
        return _editorService.AddEditor(model); 
    }

    [HttpPut("UpdateEditor")]
    public AddEditorDto UpdateBook(AddEditorDto model)
    {
        return _editorService.UpdateEditor(model); 
    }
    
    [HttpDelete("DeleteEditor")]
    public bool DeleteBook(int id)
    {
        return _editorService.DeleteEditor(id);  
    }
}