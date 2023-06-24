using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AuthorService : IAuthorService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AuthorService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetAuthorDto>>> GetAuthors() 
    {
        var authors =await _context.Authors.ToListAsync();
        var map = _mapper.Map<List<GetAuthorDto>>(authors);
        return new Response<List<GetAuthorDto>>(map); 
    }

    public async Task<Response<GetAuthorDto>> GetAuthorById(int id)
    {
        var author =await _context.Authors.FindAsync(id);
        var map = _mapper.Map<GetAuthorDto>(author);
        return new Response<GetAuthorDto>(map);
    }

    public async Task<Response<AddAuthorDto>> AddAuthor(AddAuthorDto model)
    {
        var author = _mapper.Map<Author>(model);
        _context.Authors.Add(author);
        author.Id = model.Id;
        var  result =await _context.SaveChangesAsync();
        return new Response<AddAuthorDto>(model); 
    }

    public async Task<Response<AddAuthorDto>> UpdateAuthor(AddAuthorDto model)
    {
        var author = await _context.Authors.FindAsync(model.Id); 
        _mapper.Map(model, author);
        _context.Entry(author).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        var result = _mapper.Map<AddAuthorDto>(author);
        return new Response<AddAuthorDto>(result);  
    }

    public async Task<Response<string>> DeleteAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return new Response<string>("Author not found");
        _context.Authors.Remove(author);
        var result =await _context.SaveChangesAsync();
        return new Response<string>("deleted successfully "); 
    }

    public async Task<Response<List<GetAllAuthorsWithBooksDto>>> GetAllAuthorsWithBooks()
    {
        var authors =await _context.Authors.Select(a => new GetAllAuthorsWithBooksDto()
        {
            AuthorId = a.Id,
            AuthorFullName = string.Concat(a.LastName + " " + a.FirstName),
            Books = a.BookAuthors.Where(x => x.AuthorId == a.Id).Select(b => new BookBaseDto()
            { 
                Isbn = b.Book.Isbn, 
                Title = b.Book.Title,
                PublisherId = b.Book.PublisherId,
                Type = b.Book.Type,
                Advance = b.Book.Advance,
                Price = b.Book.Price,
                YtdSales = b.Book.YtdSales,
                PublisherDate = b.Book.PublisherDate

            }).ToList()

        }).ToListAsync();
        return new Response<List<GetAllAuthorsWithBooksDto>>(authors); 
    }

    public async Task<Response<List<GetListAuthorWithNumberOfBooksDto>>> GetListAuthorWithNumberOfBooks()  
    {
        var authors =await _context.Authors.Select(a => new GetListAuthorWithNumberOfBooksDto()
        {
            FullName = string.Concat(a.LastName + " " + a.FirstName),
            CountOfBook = a.BookAuthors.Where(x => x.AuthorId == a.Id).Select(x => x.Book).ToList().Count 
        }).ToListAsync(); 
        return new Response<List<GetListAuthorWithNumberOfBooksDto>>(authors);   
    }
}
