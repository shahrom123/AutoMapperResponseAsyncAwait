using System.Net;

namespace Domain.Wrapper;

public class PagedResponse<T>:Response<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }

    public PagedResponse(T data, int pageNumber, int pageSize,  int totalRecords) : base(data)
    {
        TotalRecords = totalRecords;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalRecords = (int)Math.Ceiling(totalRecords / (double)pageSize); 
    }

    public PagedResponse(HttpStatusCode statusCode, List<string> errors) : base(statusCode, errors)
    {
        
    }

    public PagedResponse(HttpStatusCode statusCode, string errors) : base(statusCode, errors)
    {
        
    }
}