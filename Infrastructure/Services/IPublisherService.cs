using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Services;

public interface IPublisherService
{
    List<GetPublisherDto> GetPublishers();
    GetPublisherDto GetPublisherById(int id); 
    AddPublisherDto AddPublisher(AddPublisherDto model); 
    AddPublisherDto UpdatePublisher(AddPublisherDto publisher);
    bool DeletePublisher(int id);
    List<GetAllPublisherWithBooksDto> GetAllPublisherWithBooksDto();
}