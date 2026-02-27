using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Application.Models;

public class BookDTO
{
    public int Id { get; init; }

    
    public required string Name { get; set; }
    
    public int Price { get; set; }
      

}
