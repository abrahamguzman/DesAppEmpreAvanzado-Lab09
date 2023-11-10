using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class BInvoice
    {
        public List<Invoice> GetInvoiceActives()
        {
            DInvoice data = new DInvoice();
            var invoices = data.Get();
            var result = invoices.Where(x => x.active == true).ToList();
            return result;
        }

        public List<Invoice> GetByDate(DateTime date)
        {
            DInvoice data = new DInvoice();
            var invoices = GetInvoiceActives();
            var result = invoices.Where(x => x.date.Date == date.Date).ToList();
            return result;
        }

        public void Insert(Invoice invoice)
        {
            DInvoice data = new DInvoice();
            data.CreateInvoice(invoice);
        }

        public void DeleteInvoice(int id)
        {
            DInvoice data = new DInvoice();
            data.DeleteInvoice(id);
        }
    }
}
