using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface IBookService
{
    Task<Response<List<GetBookDto>>> Books(); 
    Task<Response<GetBookDto>> GetBookById(string id); 
    Task<Response<AddBookDto>> AddBook(AddBookDto model);
    Task<Response<AddBookDto>> UpdateBook(AddBookDto book);
    Task<Response<string>> DeleteBook(string id);  
    Task<Response<List<GetAllBooksDto>>> GetAllBooksAuthorPublisher(); 
    Task<Response<List<GetAllBooksDto>>> GetAllBooks(); 
}