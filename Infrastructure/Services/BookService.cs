using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Filters;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookService:IBookService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public BookService(DataContext context , IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetBookDto>>> Books()
    {
        try
        {
            var books =await _context.Books.ToListAsync();
            var result =_mapper.Map<List<GetBookDto>>(books);
            return new Response<List<GetBookDto>>(result);   
        }
        catch (Exception ex)
        {
            return new Response<List<GetBookDto>>(HttpStatusCode.InternalServerError, ex.Message ); 
        } 
    }
    
    public async Task<Response<GetBookDto>> GetBookById(string id)
    {
        try
        {
            var find =await _context.Books.FindAsync(id); 
            var result = _mapper.Map<GetBookDto>(find);
            return new Response<GetBookDto>(result); 
        }
        catch (Exception ex)
        {
            return new Response<GetBookDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message }); 

        } 
    }

    public async Task<Response<AddBookDto>> AddBook(AddBookDto model)
    {
        try
        {
            var book =  _mapper.Map<Book>(model);  
            await _context.Books.AddAsync(book); 
            await _context.SaveChangesAsync();
            return new Response<AddBookDto>(model);  
           
        }
        catch (Exception ex)
        {
            return new Response<AddBookDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message }); 

        }
    }
    
    public async Task<Response<AddBookDto>> UpdateBook(AddBookDto model)
    {
        try
        {
            var book = await _context.Books.FindAsync(model.Isbn); 
            _mapper.Map(model, book);
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var response = _mapper.Map<AddBookDto>(book); 
            return new Response<AddBookDto>(response); 
        }
        catch (Exception ex)
        {
            return new Response<AddBookDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    
    public async Task<Response<string>> DeleteBook(string id)
    {
        try
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return new Response<string>(HttpStatusCode.NotFound, new List<string>() { "Not Found Id" }); 
            var  remove = _context.Books.Remove(book); 
            var result = await _context.SaveChangesAsync();
            return new Response<string>("deleted successfully");  
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,  ex.Message ); 

        }
      
    }

    public async Task<Response<List<GetAllBooksDto>>> GetAllBooksAuthorPublisher()
    {
     
        try
        {
            var book =await _context.Books.Select(b => new GetAllBooksDto()
            {
                Isbn = b.Isbn, 
                PublisherName = b.Publisher.Name,
                Title = b.Title,
                PublisherId = b.PublisherId,
                PublisherDate = b.PublisherDate,
                Advance = b.Advance,
                YtdSales = b.YtdSales,
                Price = b.Price,
                Type = b.Type,
                Authors  = b.BookAuthors.Where(s=>s.BookIsbn==b.Isbn).Select(x=>new GetAuthorDto() 
                {
                    Id = x.Author.Id,  
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName,
                    Phone = x.Author.Phone,
                    Address = x.Author.Address,
                    City = x.Author.City,
                    Ssn = x.Author.Ssn,
                    State = x.Author.State,
                    Zip = x.Author.Zip 
                }).ToList()   
            
            }).OrderBy(x=>x.PublisherDate).ToListAsync();
            return new Response<List<GetAllBooksDto>>(book);
        }
        catch (Exception ex)
        {
            return new Response<List<GetAllBooksDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { ex.Message }); 

        }
    }

    public async Task<PagedResponse<List<GetAllBooksDto>>> GetAllBooks(GetFilterBook filter)
    {
       
        var validFilters = new PaginationFilter(filter.PageNumber, filter.PageSize);
        var books =  _context.Books.AsQueryable();  
        if (string.IsNullOrEmpty(filter.Title) == false)
        {
            books = books.Where(b => b.Title.ToLower().Contains(filter.Title.ToLower()));
        }
        try
        {
            var joined = await 
                (from b in books 
                select new GetAllBooksDto()  
                {
                    Isbn = b.Isbn,
                    PublisherName = b.Publisher.Name,
                    Title = b.Title,
                    PublisherId = b.PublisherId,
                    PublisherDate = b.PublisherDate,
                    Advance = b.Advance,
                    YtdSales = b.YtdSales,
                    Price = b.Price,
                    Type = b.Type,
                    Authors =_mapper.Map<List<GetAuthorDto>>(b.BookAuthors.Select(x => x.Author).ToList()
                    )  
                }).Skip((validFilters.PageNumber - 1) * validFilters.PageSize)
                .Take(validFilters.PageSize)
                .OrderBy(p=>p.PublisherDate).ToListAsync();
            var totalRecords = books.Count();  
            return new PagedResponse<List<GetAllBooksDto>>(joined, filter.PageNumber,filter.PageSize, totalRecords) ; 
        }
        catch (Exception ex)
        {
            return new PagedResponse<List<GetAllBooksDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message }); 
        }
    }

}