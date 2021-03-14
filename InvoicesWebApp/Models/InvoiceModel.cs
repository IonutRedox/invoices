using System;
using System.ComponentModel.DataAnnotations;

namespace InvoicesWebApp.Models
{
    public class InvoiceModel
    {
        [Range(1,999999,ErrorMessage = "Invoice ID is invalid.")]
        [Required(ErrorMessage = "Invoid ID is required.")]
        [Display(Name = "Invoice ID")]
        public int InvoiceId { get; set; }

        [Range(1, 999999, ErrorMessage = "Invoice details ID is invalid.")]
        [Required(ErrorMessage = "Invoid details ID is required.")]
        [Display(Name = "Invoice details ID")]
        public int InvoiceDetailsId { get; set; }

        [Range(1, 999999, ErrorMessage = "Location ID is invalid.")]
        [Required(ErrorMessage = "Location ID is required.")]
        [Display(Name = "Location ID")]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Invoice number is required.")]
        [Display(Name = "Invoice number")]
        public string InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0: MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Client name is required.")]
        [Display(Name = "Client name")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Product name required.")]
        [Display(Name = "Product name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Display(Name = "Quantity")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public decimal Value { get { return Price * Quantity; } }
    }
}