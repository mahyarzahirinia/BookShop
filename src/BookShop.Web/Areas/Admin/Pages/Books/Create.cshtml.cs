using BookShop.Application;
using BookShop.Infrastructure.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Web.Areas.Admin.Pages.Books;

public class CreateModel : PageModel
{

    private readonly IBookService _bookService;

    public CreateModel(IBookService bookService)
    {
        _bookService = bookService;
    }

    [BindProperty]
    public CreateInputModel Input { get; set; }

    public IActionResult OnPost()
    {
        if(Input.Year > DateTime.Now.Year)
        {
            ModelState.AddModelError("Year", "year invalid");
        }

        if(ModelState.IsValid == false)
        {
            ModelState.AddModelError(nameof(Pages), "Please correct the errors and try again.");
        }
        
        _bookService.Create(new Application.Models.BookCreateDto 
        {   
            Author = Input.Author,
            Description = Input.Description,
            Name = Input.Name,
            Pages = Input.Pages,
            Price = Input.Price,
            Year = Input.Year
        });

        return RedirectToPage("./index");
    }
}

public class CreateInputModel
{

    [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
    public string? Name { get; set; }

    public string? Description { get; set; }
    public int Price { get; set; }

    public string? Author { get; set; }
    public int Year { get; set; }

    [Range(1, 5000, ErrorMessage = "Pages must be between {1} and {2}")]
    public int Pages { get; set; }
}