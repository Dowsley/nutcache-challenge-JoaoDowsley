
using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleApi.Models
{
    public class Person
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

        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; } 
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        [Required]
        public GenderTypeEnum  Gender { get; set; }
        
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Birth { get; set; }
        
        [Required]
        public string CPF { get; set; }
        
        [Required]
        public string StartDate { get; set; }
        
        public TeamTypeEnum Team { get; set; }
    }
}