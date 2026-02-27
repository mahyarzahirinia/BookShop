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

    public IList<BookDTO> GetAll()
    {
        return _db.Books.Select(b=>new BookDTO { Id= b.Id, Name = b.Name, Price= b.Price}).ToList();
    }

}
