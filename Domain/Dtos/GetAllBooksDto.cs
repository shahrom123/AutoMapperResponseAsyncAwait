using Domain.Entities;

namespace Domain.Dtos;

public class GetAllBooksDto :GetBookDto
{
    public List<GetAuthorDto> Authors{ get; set; }
    public string PublisherName { get; set; } 
        
}
