using Domain.Dtos;

namespace Infrastructure.Services;

public interface IBookEditorService
{
    List<GetBookEditorDto> GetBookEditors();
    AddBookEditorDto AddBookEditor(AddBookEditorDto model);
    AddBookEditorDto UpdateBookEditor(AddBookEditorDto model); 
    bool DeleteBookEditor(int id);
    
}