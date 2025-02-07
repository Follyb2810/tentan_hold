using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace tenant_api.Models
{
    public class Product
    {
    //      public Product(){
    //     ProductIngredients = new List<ProductIngredient>();
    // }
       public int ProductId { get; set; } 
       public string? Name { get; set; } 
       public string? Description { get; set; } 
       public decimal Price { get; set; } 
       public int Stock { get; set; } 
       [NotMapped]
       public IFormFile? ImageFile {get;set;}
       public string ImageUrl { get; set; } = "https://placehold.co/150@2x.png";//"https://via-placeholder.com/150";//https://via.placeholder.com/150
       public int CategoryId { get; set; } 
    //    [ValidateNever]
    //    public Category? Category { get; set; }  //? A product can only belong to one category
    //    [ValidateNever]
    //    public ICollection<OrderItem>? OrderItems { get; set; } //? A product can have many order many to one
    //    [ValidateNever]
    //    public ICollection<ProductIngredient>? ProductIngredients { get; set; } //? A product can have many ingrdient many to one
    }
}