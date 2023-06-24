using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class PublisherBaseDto
{
    public int  Id { get; set; }
    [MaxLength(50)] 
    public string Name { get; set; }
    [MaxLength(50)]
    public string Address { get; set; }
    [MaxLength(50)]
    public string City { get; set; }
    [MaxLength(50)] 
    public string State { get; set; }
}

public class AddPublisherDto:PublisherBaseDto 
{ 
    
}

public class GetPublisherDto : PublisherBaseDto
{
    
}