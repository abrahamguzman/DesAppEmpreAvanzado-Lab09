namespace Demo09.Models
{
    public class InvoiceModel
    {
        public int invoice_id { get; set; }
        public int customer_id { get; set; }
        public DateTime date { get; set; } 
        public decimal total { get; set; }

        public decimal igv { get; set; }

    }
}
