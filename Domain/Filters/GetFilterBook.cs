namespace Domain.Filters;

public class GetFilterBook:PaginationFilter
{
    public string? Title { get; set; }
    public GetFilterBook():base() 
    {
        
    }

    public GetFilterBook(int pageNumber, int pageSize):base(pageNumber,pageSize)
    {
        
    }
}