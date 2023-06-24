namespace Domain.Dtos;

public class BookEditorBaseDto
{
    public string Isbn { get; set; } 
    public int EditorId { get; set; }
}

public class AddBookEditorDto : BookEditorBaseDto
{
    
}

public class GetBookEditorDto : BookEditorBaseDto
{
    
}