namespace Domain.Dtos;

public class GetAllAuthorsWithBooksDto
{
    public int AuthorId { get; set; }
    public string AuthorFullName { get; set; }
    public List<BookBaseDto> Books { get; set; } 
}