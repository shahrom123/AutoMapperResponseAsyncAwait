using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class BookEditor 
{
    public string Isbn { get; set; } 
    public int EditorId { get; set; }
    [ForeignKey("Isbn")]
    public Book Book { get; set; }   
    public Editor Editor { get; set; }
    
}