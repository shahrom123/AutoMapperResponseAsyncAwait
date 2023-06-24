using Domain.Dtos;

namespace Infrastructure.Services;

public interface IAuthorService
{
    List<GetAuthorDto> GetAuthor();
    GetAuthorDto GetAuthorById(int id);
    AddAuthorDto AddAuthor(AddAuthorDto model);
    AddAuthorDto UpdateAuthor(AddAuthorDto model);
    bool DeleteAuthor(int id);
    List<GetAllAuthorsWithBooksDto> GetAllAuthorsWithBooksDto();
    List<GetListAuthorWithNumberOfBooksDto> GetListAuthorWithNumberOfBooksDtos();
}