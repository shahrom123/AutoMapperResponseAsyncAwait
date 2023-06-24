using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Book
{
    [Key]
    public string Isbn { get; set; } 
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(50)]
    public string Type { get; set; }
    public decimal Price { get; set; }
    public decimal Advance { get; set; }
    public decimal YtdSales { get; set; }   
    public DateTime PublisherDate { get; set; }  
    public int  PublisherId { get; set; } 
    public virtual Publisher  Publisher { get; set; }
    public virtual List<BookEditor>BookEditors { get; set; }
    public virtual List<BookAuthor>BookAuthors { get; set; } 
    
}