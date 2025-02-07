using System.ComponentModel.DataAnnotations;

namespace tenant_api.Dtos
{
    public record LoginDtos
    {
        [Required]
       [EmailAddress]
       public required string Email {get;set;} 
       [Required]
       [StringLength(20,MinimumLength=6)]
       public required string Password {get;set;}    
    }
}