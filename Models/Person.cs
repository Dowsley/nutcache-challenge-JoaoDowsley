using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleApi.Models
{
    public enum GenderTypeEnum
    {
        [Display(Name = "Male")]
        Male,
    
        [Display(Name = "Female")]
        Female,
                
        [Display(Name = "Other")]
        Other
    }

    public enum TeamTypeEnum
    {
        [Display(Name = "Mobile")]
        Mobile,
    
        [Display(Name = "Frontend")]
        Frontend,
                
        [Display(Name = "Backend")]
        Backend
    }
    
    public class Person
    {
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; } 
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        
        [Required]
        public GenderTypeEnum  Gender { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "CPF")]
        [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", 
        ErrorMessage = "Please enter a valid CPF!")]
        public string CPF { get; set; }
        
        [Required]
        [RegularExpression(@"^(1[0-2]|0[1-9])\/(20\d{2}|19\d{2})$", 
        ErrorMessage = "Please enter a date in MM/YYYY format!")]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }
        
        [Display(Name = "Team (Optional)")]
        public Nullable<TeamTypeEnum> Team { get; set; }
    }
}