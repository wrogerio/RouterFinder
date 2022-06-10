using System;
using System.ComponentModel.DataAnnotations;

namespace RouterFinder.Application.DTO
{
    public class RouteDTO
    {
        // key
        [Key] public Guid Id { get; set; }

        // properties
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [MinLength(3, ErrorMessage = "The field {0} must be minimum {1} characters")]
        [Display(Name = "From")]

        public string routeFrom { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [MinLength(3, ErrorMessage = "The field {0} must be minimum {1} characters")]
        [Display(Name = "To")]
        public string routeTo { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Cost")]
        public double routeValue { get; set; }

        [Display(Name = "Description")] public string routeDescription { get; set; }
    }
}