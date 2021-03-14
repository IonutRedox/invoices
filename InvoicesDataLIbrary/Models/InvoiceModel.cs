using System;

namespace InvoicesDataLIbrary.Models
{

    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public int LocationId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
    }
}
