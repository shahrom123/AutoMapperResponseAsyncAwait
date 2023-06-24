using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Author
{
    [Key]
    public int Id { get; set; } 
    [MaxLength(100)]
    public string Ssn { get; set; }    
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }    
    [MaxLength(50)]
    public string Phone { get; set; } 
    [MaxLength(100)]
    public string Address { get; set; } 
    [MaxLength(50)]
    public string City { get; set; }  
    [MaxLength(50)]
    public string State { get; set; }  
    [MaxLength(50)]
    public string Zip { get; set; }   
    public virtual List<BookAuthor> BookAuthors { get; set; }   
    
}