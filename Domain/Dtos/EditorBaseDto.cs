namespace Domain.Dtos;

public class EditorBaseDto
{
    public int EditorId { get; set; }
    public string Ssn { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string EditorPosition { get; set; }
    public decimal Salary { get; set; } 
}

public class AddEditorDto : EditorBaseDto
{
    
}

public class GetEditorDto : EditorBaseDto
{
    
}