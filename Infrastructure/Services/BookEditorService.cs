using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookEditorService :IBookEditorService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public BookEditorService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper; 
    }

    public List<GetBookEditorDto> GetBookEditors()
    {
        var bookEditors =_context.BookEditors.ToList();
        return _mapper.Map<List<GetBookEditorDto>>(bookEditors); 
    }
    
    public AddBookEditorDto AddBookEditor(AddBookEditorDto model)
    {
        var mapped = _mapper.Map<BookEditor>(model);
        _context.BookEditors.Add(mapped); 
        _context.SaveChanges();
        return model;
    }
    
    public AddBookEditorDto UpdateBookEditor(AddBookEditorDto model)
    {
        var find = _context.BookEditors.Find(model.EditorId);
        _mapper.Map(find, model);
        _context.Entry(find).State = EntityState.Modified;
        _context.SaveChanges(); 
        return model;
    }
    
    public bool DeleteBookEditor(int id)
    {
        var bookEditor =  _context.BookEditors.Find(id);
        if (bookEditor == null) return false; 
        _context.BookEditors.Remove(bookEditor);  
        var result =  _context.SaveChanges();
        return result == 1;
    } 
}