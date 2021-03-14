namespace InvoicesDataLIbrary.Models
{
    public class InvoiceDetailsModel
    {
        public int InvoiceDetailsId { get; set; }
        public int InvoiceId { get; set; }
        public int LocationId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Value { get; set; }
    }
}