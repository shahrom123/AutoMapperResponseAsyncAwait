using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class BookBaseDto
{ 
        [Required]
        public string Isbn { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int PublisherId { get; set; }
        public decimal YtdSales { get; set; }
        public DateTime PublisherDate { get; set; } 
        public decimal Advance { get; set; } 
}

public class AddBookDto : BookBaseDto
{

}

public class GetBookDto : BookBaseDto
{ 
       
        
}