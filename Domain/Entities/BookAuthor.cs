using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class BookAuthor
{
    public int AuthorId { get; set; }
    public Author Author { get; set; } 
    public int AuthorOrder { get; set; }
    public decimal RoyaltyShare  { get; set; }
    public string BookIsbn { get; set; } 
    [ForeignKey("BookIsbn")] 
    public Book Book { get; set; } 
    
}