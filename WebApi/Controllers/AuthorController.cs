using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthorController:ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet("GetAuthors")]
    public async Task<Response<List<GetAuthorDto>>> GetAuthors()
    {
        return await _authorService.GetAuthors();  
    }
    [HttpGet("GetAuthorById")]
    public async Task<Response<GetAuthorDto>> GetAuthorById(int id)
    {
        return await _authorService.GetAuthorById(id);  
    }
    
    [HttpPost("AddAuthor")]
    public async Task<Response<AddAuthorDto>> AddAuthor(AddAuthorDto author) 
    {
        return await _authorService.AddAuthor(author); 
    }

    [HttpPut("UpdateAuthor")]
    public async Task<Response<AddAuthorDto>> UpdateAuthor(AddAuthorDto model)
    {
        return await  _authorService.UpdateAuthor(model); 
    }
    
    [HttpDelete("DeleteAuthor")]
    public async Task<Response<string>> DeleteAuthor(int id)
    {
        return await _authorService.DeleteAuthor(id);   
    }
    [HttpGet("GetAuthorsWithBooks")] 
    public IActionResult GetAuthorsWithBooks() 
    {
        return Ok(_authorService.GetAllAuthorsWithBooks()); 
    }

    [HttpGet("GetListAuthorWithNumberOfBooks")] 
    public IActionResult GetListAuthorWithNumberOfBooks() 
    {
        return Ok(_authorService.GetListAuthorWithNumberOfBooks()); 
    }
}