using Domain.Entities;

namespace Domain.Dtos;

public class GetListAuthorWithNumberOfBooksDto
{
    public string FullName { get; set; }
    public int CountOfBook { get; set; } 
} 

