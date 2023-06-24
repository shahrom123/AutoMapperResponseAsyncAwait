using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;


    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }
    [HttpGet("GePublishers")]
    public List<GetPublisherDto> GePublishers()
    {
        return _publisherService.GetPublishers();
    }
    
    [HttpGet("GePublisherById")]
    public GetPublisherDto GePublishersById(int id)
    {
        return _publisherService.GetPublisherById(id); 
    }
    
    [HttpPost("AddPublisher")]
    public AddPublisherDto AddPublisher(AddPublisherDto model)
    {
        return _publisherService.AddPublisher(model);
    }

    [HttpPut("UpdatePublisher")]
    public AddPublisherDto UpdatePublisher(AddPublisherDto publisher)
    {
        return _publisherService.UpdatePublisher(publisher);  
    }
    
    [HttpDelete("DeletePublisher")]
    public bool DeleteBook(int id)
    {
        return _publisherService.DeletePublisher(id); 
    }
    [HttpGet("GetAllPublisherWithBooks")]  
    public IActionResult GetAllPublisherWithBooks() 
    {
        return Ok(_publisherService.GetAllPublisherWithBooksDto());  
    }


}