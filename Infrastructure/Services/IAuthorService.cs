using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface IAuthorService
{
   Task<Response<List<GetAuthorDto>>> GetAuthors();   
   Task<Response<GetAuthorDto>> GetAuthorById(int id);
   Task<Response<AddAuthorDto>> AddAuthor(AddAuthorDto model); 
   Task<Response<AddAuthorDto>> UpdateAuthor(AddAuthorDto model);
   Task<Response<string>>  DeleteAuthor(int id);
   Task<Response<List<GetAllAuthorsWithBooksDto>>> GetAllAuthorsWithBooks(); 
   Task<Response<List<GetListAuthorWithNumberOfBooksDto>>> GetListAuthorWithNumberOfBooks();   
}





