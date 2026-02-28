using BookShop.Application.Models;
using BookShop.Infrastructure;
using BookShop.Infrastructure.DataModels;
using BookShop.Migrations;
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
        {
            Author = bookInput.Author,
            Description = bookInput.Description,
            Name = bookInput.Name,
            Pages = bookInput.Pages,
            Price = bookInput.Price,
            Year = bookInput.Year,
            CoverImage = bookInput.CoverImage


        });

        _db.SaveChanges();
    }

    public IList<BookDTO> GetAll()
    {
        return _db.Books.Select(b => new BookDTO { Id = b.Id, Name = b.Name, Price = b.Price }).ToList();
    }


    public BookDetails GetDetails(int bookId)
    {
        var book = _db.Books.Find(bookId);
        var results = new BookDetails
        {
            Author = book.Author,
            Description = book.Description,
            Name = book.Name,
            Pages = book.Pages,
            Price = book.Price,
            Year = book.Year,
            CoverImage = book.CoverImage
 
        };

        return results;
    }

}
