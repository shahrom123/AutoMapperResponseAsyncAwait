namespace Domain.Dtos;

public class GetAllPublisherWithBooksDto
{
    public int PublisherId { get; set; }
    public string PublisherName { get; set; }
    public List<BookBaseDto> Books { get; set; } 
}