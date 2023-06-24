using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class BookAuthorController:ControllerBase
{
    private readonly IBookAuthorService _bookAuthorService;

    public BookAuthorController(IBookAuthorService bookAuthorService)
    {
        _bookAuthorService = bookAuthorService; 
    }

    [HttpGet("GetBookAuthors")]
    public List<GetBookAuthorDto> GetBookAuthors()
    {
        return _bookAuthorService.GetBookAuthors(); 
    }
  
    
    [HttpPost("AddBookAuthor")]
    public AddBookAuthorDto AddAuthor(AddBookAuthorDto author)
    {
        return _bookAuthorService.AddBookAuthor(author); 
    }

    [HttpPut("UpdateBookAuthor")]
    public AddBookAuthorDto UpdateAuthor(AddBookAuthorDto model) 
    {
        return _bookAuthorService.UpdateBookAuthor(model); 
    }
    
    [HttpDelete("DeleteBookAuthor")]
    public bool DeleteAuthor(int authorId,string bookIsbn)
    {
        return _bookAuthorService.DeleteBookAuthor( authorId, bookIsbn);   
    }

}