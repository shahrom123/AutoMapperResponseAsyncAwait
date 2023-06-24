using Domain.Dtos;

namespace Infrastructure.Services;

public interface IEditorService
{
    List<GetEditorDto> GetEditors();
    GetEditorDto GetEditorById(int id);
    AddEditorDto AddEditor(AddEditorDto model); 
    AddEditorDto UpdateEditor(AddEditorDto model);
    bool DeleteEditor(int id);
}