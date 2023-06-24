using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EditorService:IEditorService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public EditorService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper; 
    }

    public List<GetEditorDto> GetEditors()
    {
        var editors = _context.Editors.ToList();
       return  _mapper.Map<List<GetEditorDto>>(editors);
    }
    public GetEditorDto GetEditorById(int id)
    {
        var find = _context.Editors.Find(id);
        return _mapper.Map<GetEditorDto>(find); 
    }
    public AddEditorDto AddEditor(AddEditorDto model)
    {
        var editor = _mapper.Map<Editor>(model);
        _context.Editors.Add(editor);
        _context.SaveChanges();
        return model;
    }
    public AddEditorDto UpdateEditor(AddEditorDto model)
    {
        var find = _context.Editors.Find(model.EditorId);
        _mapper.Map(model, find);
        _context.Entry(find).State = EntityState.Modified;
        _context.SaveChanges();
        return model;
    }

    public bool DeleteEditor(int id)
    { 
        var editor = _context.Editors.Find(id);
        if (editor == null) return false;
        _context.Editors.Remove(editor); 
        var  result =  _context.SaveChanges(); 
        return result == 1;  
    }
}