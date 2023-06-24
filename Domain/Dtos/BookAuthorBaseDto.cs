namespace Domain.Dtos;

public class BookAuthorBaseDto
{
    public int AuthorId { get; set; } 
    public int AuthorOrder { get; set; }
    public decimal RoyaltyShare  { get; set; }
    public string BookIsbn { get; set; } 
}

public class AddBookAuthorDto : BookAuthorBaseDto
{
    
}
public class GetBookAuthorDto : BookAuthorBaseDto
{ 
    
    
}
