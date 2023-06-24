using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
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

    public List<GetAuthorDto> GetAuthor()
    {
        var authors = _context.Authors.ToList();
        return _mapper.Map<List<GetAuthorDto>>(authors);
    }

    public GetAuthorDto GetAuthorById(int id)
    {
        var author = _context.Authors.Find(id);
        return _mapper.Map<GetAuthorDto>(author);
    }

    public AddAuthorDto AddAuthor(AddAuthorDto model)
    {
        var author = _mapper.Map<Author>(model);
        _context.Authors.Add(author);
        author.Id = model.Id;
        _context.SaveChanges();
        return model;
    }

    public AddAuthorDto UpdateAuthor(AddAuthorDto model)
    {
        var author = _context.Authors.Find(model.Id);
        _mapper.Map(model, author);
        _context.Entry(author).State = EntityState.Modified;
        _context.SaveChanges();
        return model;
    }

    public bool DeleteAuthor(int id)
    {
        var author = _context.Authors.Find(id);
        if (author == null) return false;
        _context.Authors.Remove(author);
        var result = _context.SaveChanges();
        return result == 1;
    }

    public List<GetAllAuthorsWithBooksDto> GetAllAuthorsWithBooksDto()
    {
        var authors = _context.Authors.Select(a => new GetAllAuthorsWithBooksDto()
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

        }).ToList();
        return authors;
    }

    public List<GetListAuthorWithNumberOfBooksDto> GetListAuthorWithNumberOfBooksDtos()
    {
        var authors = _context.Authors.Select(a => new GetListAuthorWithNumberOfBooksDto()
        {
            FullName = string.Concat(a.LastName + " " + a.FirstName),
            CountOfBook = a.BookAuthors.Where(x => x.AuthorId == a.Id).Select(x => x.Book).ToList().Count 
        }).ToList(); 
        return authors;  
    }
}
