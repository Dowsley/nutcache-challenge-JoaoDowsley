
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
        public string CPF { get; set; }
        
        [Required]
        // TODO: Regular Expression Validator
        [Display(Name = "Start Date (MM/YYYY)")]
        public string StartDate { get; set; }
        
        public TeamTypeEnum Team { get; set; }
    }
}