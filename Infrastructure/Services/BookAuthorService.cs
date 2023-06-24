using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookAuthorService:IBookAuthorService 
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public BookAuthorService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper; 
    }

    public List<GetBookAuthorDto> GetBookAuthors()
    {
        var bookAuthors =_context.BookAuthors.ToList();
        return _mapper.Map<List<GetBookAuthorDto>>(bookAuthors); 
    }
    
    public AddBookAuthorDto AddBookAuthor(AddBookAuthorDto model)
    {

        var mapped = _mapper.Map<BookAuthor>(model);
        _context.BookAuthors.Add(mapped);
        _context.SaveChanges();
        return model;
    }
    
    public AddBookAuthorDto UpdateBookAuthor(AddBookAuthorDto model)
    {
        var find = _context.BookAuthors.Find(model.AuthorId,model.BookIsbn);
        _mapper.Map(find, model);
        _context.Entry(find).State = EntityState.Modified;
        _context.SaveChanges();
        return model;
    }
    
    public bool DeleteBookAuthor(int authorId,string bookIsbn)
    {
        var bookAuthor =  _context.BookAuthors.Find(authorId,bookIsbn);
        if (bookAuthor == null) return false; 
        _context.BookAuthors.Remove(bookAuthor); 
        var result =  _context.SaveChanges();
        return result == 1;
    } 
}