using BookShop.Application.Models;
using BookShop.Infrastructure.DataModels;

namespace BookShop.Application;

public interface IBookService
{
    IList<BookDTO> GetAll();

    void Create(BookCreateDto bookInput);
}