using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Publisher
{
    [Key]
    public int  Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Address { get; set; }
    [MaxLength(50)]
    public string City { get; set; }
    [MaxLength(50)] 
    public string State { get; set; }
    public List<Book> Books { get; set; }
}