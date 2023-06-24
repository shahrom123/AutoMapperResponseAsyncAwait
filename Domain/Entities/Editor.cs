using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Editor
{
    [Key]
    public int EditorId { get; set; }
    [MaxLength(100)]
    public string Ssn { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(50)]
    public string Phone { get; set; }
    [MaxLength(50)]
    public string EditorPosition { get; set; }
    public decimal Salary { get; set; }
    public List<BookEditor> BookEditors { get; set; }
}