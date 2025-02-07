using System.ComponentModel.DataAnnotations;
namespace tenant_api.Dtos
{
    public record RegisterDto
    {
       [Required]
       [EmailAddress]
       public required string Email {get;set;} 
       [Required]
       [StringLength(20,MinimumLength=6)]
       public required string Password {get;set;} 
       [Required]
       [Compare("Password",ErrorMessage="The password and confirm Pasword do not match")]
       public string? ConfirmPassword {get;set;} 
        
    }
}