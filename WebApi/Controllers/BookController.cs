using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    
    public BookController(IBookService bookService)
    {
        _bookService = bookService; 
    }
    [HttpGet("GetBooks")]
    public async Task<Response<List<GetBookDto>>> GetBooks()
    {
        return  await _bookService.Books(); 
    }
    
    [HttpGet("GetBookById")]
    public async Task<Response<GetBookDto>> GetBookById(string id)
    {
        return await _bookService.GetBookById(id);  
    }
    
    [HttpPost("AddBook")]
    public async Task<Response<AddBookDto>> AddBook(AddBookDto book)
    {
        return await _bookService.AddBook(book); 
    }

    [HttpPut("UpdateBook")]
    public async Task<IActionResult> UpdateBook(AddBookDto book)
    {
        var result = await _bookService.UpdateBook(book);
        return StatusCode((int)result.StatusCode, result);  
    }
    
    [HttpDelete("DeleteBook")]
    public async Task<Response<string>> DeleteBook(string id)
    {
        return await _bookService.DeleteBook(id);   
    }

    [HttpGet("GetBookWithPublisherAuthor")]
    public async Task<Response<List<GetAllBooksDto>>> GetBookWithPublisherAuthor()
    {
        return await _bookService.GetAllBooksAuthorPublisher(); 
    }
    [HttpGet("GetAllBooks")] 
    public async Task<Response<List<GetAllBooksDto>>> GetAllBooks()
    {
        return await _bookService.GetAllBooks();    
    }
}