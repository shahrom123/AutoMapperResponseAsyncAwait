using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PublisherService : IPublisherService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PublisherService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetPublisherDto> GetPublishers() 
    {
        var publishers =_context.Publishers.ToList();
        return _mapper.Map<List<GetPublisherDto>>(publishers); 
    }

    public GetPublisherDto GetPublisherById(int id)
    {
       var publisher = _context.Publishers.Find(id);
       return new GetPublisherDto()
       {
           Id = publisher.Id,
           Name = publisher.Name,
           Address = publisher.Address,
           City = publisher.City, 
           State = publisher.State,
       };
    }

    public AddPublisherDto AddPublisher(AddPublisherDto model)
    {
        var publisher = _mapper.Map<Publisher>(model); 
        _context.Publishers.Add(publisher);
        _context.SaveChanges();
        return model;
    }

    public AddPublisherDto UpdatePublisher(AddPublisherDto publisher)
    {
        var find = _context.Publishers.Find(publisher.Id);
        _mapper.Map(find, publisher);
        _context.Entry(find).State = EntityState.Modified;
        _context.SaveChanges();
        return publisher;
    }

    public bool DeletePublisher(int id)
    {
        var publisher = _context.Publishers.Find(id);
        if (publisher == null) return false; 
        _context.Publishers.Remove(publisher);
        var result = _context.SaveChanges();
        return result == 1;
    }

    public List<GetAllPublisherWithBooksDto> GetAllPublisherWithBooksDto()
    {
        var publishers = _context.Publishers.Select(x => new GetAllPublisherWithBooksDto()
        {
            PublisherId = x.Id,
            PublisherName = x.Name, 
            Books = x.Books.Select(b=> new BookBaseDto()
            {
                Isbn = b.Isbn,
                Title = b.Title,
                PublisherId = b.PublisherId,
                Type = b.Type,
                Advance = b.Advance,
                Price = b.Price,
                YtdSales = b.YtdSales,
                PublisherDate = b.PublisherDate
                
            }).ToList() 

        }).ToList();
        return publishers; 
    }

}
