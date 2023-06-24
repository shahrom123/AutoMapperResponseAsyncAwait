using Domain.Dtos;
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
    public List<GetAuthorDto> GetAuthors()
    {
        return _authorService.GetAuthor(); 
    }
    [HttpGet("GetAuthorById")]
    public GetAuthorDto GetAuthorById(int id)
    {
        return _authorService.GetAuthorById(id); 
    }
    
    [HttpPost("AddAuthor")]
    public AddAuthorDto AddAuthor(AddAuthorDto author)
    {
        return _authorService.AddAuthor(author);
    }

    [HttpPut("UpdateAuthor")]
    public AddAuthorDto UpdateAuthor(AddAuthorDto model)
    {
        return _authorService.UpdateAuthor(model); 
    }
    
    [HttpDelete("DeleteAuthor")]
    public bool DeleteAuthor(int id)
    {
        return _authorService.DeleteAuthor(id);  
    }
    [HttpGet("GetAuthorsWithBooks")] 
    public IActionResult GetAuthorsWithBooks() 
    {
        return Ok(_authorService.GetAllAuthorsWithBooksDto()); 
    }

    [HttpGet("GetListAuthorWithNumberOfBooksDtos")] 
    public IActionResult GetListAuthorWithNumberOfBooksDtos() 
    {
        return Ok(_authorService.GetListAuthorWithNumberOfBooksDtos()); 
    }
}