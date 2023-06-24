namespace Domain.Dtos;

public class AuthorBaseDto
{
    public int Id { get; set; } 
    public string Ssn { get; set; }    
    public string FirstName { get; set; }
    public string LastName { get; set; }    
    public string Phone { get; set; } 
    public string Address { get; set; } 
    public string City { get; set; }  
    public string State { get; set; }  
    public string Zip { get; set; }   
}

public class AddAuthorDto : AuthorBaseDto
{ 
    
}

public class GetAuthorDto : AuthorBaseDto
{
        
}