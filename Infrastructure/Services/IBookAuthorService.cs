using Domain.Dtos;

namespace Infrastructure.Services;

public interface IBookAuthorService
{ 
    List<GetBookAuthorDto> GetBookAuthors();
    AddBookAuthorDto AddBookAuthor(AddBookAuthorDto model);
    AddBookAuthorDto UpdateBookAuthor(AddBookAuthorDto model);
    bool DeleteBookAuthor(int authorId,string bookIsbn);   
}