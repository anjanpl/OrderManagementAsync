using Microsoft.AspNetCore.Http;
using OrderManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.ViewModels
{
    public class SupplierCreateViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Address line 1 cannot exceed 50 characters")]
        [Display(Name = "Address line 1")]
        public string AddresslineOne { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Address line 2 cannot exceed 50 characters")]
        [Display(Name = "Address line 2")]
        public string AddresslineTwo { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public StateList? State { get; set; }
    }
}
