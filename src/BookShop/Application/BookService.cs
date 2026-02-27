using BookShop.Application.Models;
using BookShop.Infrastructure;
using BookShop.Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Application;

public class BookService : IBookService
{
    private ApplicationDbContext _db;

    public BookService(ApplicationDbContext db)
    {
        _db = db;
    }

    public void Create(BookCreateDto bookInput)
    {
        _db.Books.Add(new BookData 
        { Author = bookInput.Author,
            Description = bookInput.Description,
            Name = bookInput.Name, Pages = bookInput.Pages,
            Price = bookInput.Price,
            Year = bookInput.Year 
        });

        _db.SaveChanges();  
    }

    public IList<BookDTO> GetAll()
    {
        return _db.Books.Select(b=>new BookDTO { Id= b.Id, Name = b.Name, Price= b.Price}).ToList();
    }



}
