using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.AutoMapperProfiles;

public class ServiceProfile:Profile
{

    public ServiceProfile()
    {
        // Author
        CreateMap<Author, GetAuthorDto>();
        CreateMap<Author, AddAuthorDto>();
        CreateMap<AddAuthorDto, Author>();
        
        // Books
        CreateMap<Book, GetBookDto>().ReverseMap();
        CreateMap<Book, AddBookDto>().ReverseMap();
        CreateMap<AddBookDto, Book>().ReverseMap();  
        
        // Editor
        CreateMap<Editor, GetEditorDto>();
        CreateMap<Editor, AddEditorDto>();
        CreateMap<AddEditorDto, Editor>(); 
        
        // Publisher
        CreateMap<Publisher, GetPublisherDto>();
        CreateMap<AddPublisherDto, Publisher>();
        CreateMap<Publisher, AddPublisherDto>();
        
        //BookEditor
        CreateMap<BookEditor, GetEditorDto>();
        CreateMap<BookEditor, AddBookEditorDto>();
        CreateMap<AddBookEditorDto, BookEditor>();
        
        //BookAuthor
        CreateMap<BookAuthor, GetBookAuthorDto>();
        CreateMap<AddBookAuthorDto, BookAuthor>();
        CreateMap<BookAuthor, GetBookAuthorDto>();

    }
}