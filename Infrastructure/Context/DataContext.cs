using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext>options):base(options)
    {
        
    }

    public DbSet<Author> Authors { get; set; }  
    public DbSet<Book> Books { get; set; }  
    public DbSet<BookAuthor> BookAuthors { get; set; }  
    public DbSet<BookEditor> BookEditors { get; set; }  
    public DbSet<Publisher> Publishers { get; set; }  
    public DbSet<Editor> Editors { get; set; }  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.AuthorId, ba.BookIsbn });
        base.OnModelCreating(modelBuilder); 
        modelBuilder.Entity<BookEditor>().HasKey(be => new { be.EditorId, be.Isbn });
        base.OnModelCreating(modelBuilder);
    }
}