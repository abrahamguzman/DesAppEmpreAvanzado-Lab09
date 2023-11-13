using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DInvoice
    {
        private readonly string connectionString = "Data Source=MGUZMAN-ACER\\SQLEXPRESS;Initial Catalog=db;User ID=user;Password=123456";

        public List<Invoice> Get()
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("listar_invoices", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Invoice invoice = new Invoice
                            {
                                invoice_id = (int)reader["Invoice_id"],
                                customer_id = (int)reader["Customer_id"],
                                date = (DateTime)reader["Date"],
                                total = (decimal)reader["Total"],
                                active = (bool)reader["Active"]
                            };
                            invoices.Add(invoice);
                        }
                    }
                }
            }
            return invoices;
        }
        public bool DeleteInvoice(int invoiceId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("eliminar_invoices", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@invoice_id", invoiceId);

                    int rowsAffected = command.ExecuteNonQuery();
                }
                
            }
            return true;

        }


        public void CreateInvoice(Invoice invoice)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("agregar_invoices", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Int));
                    command.Parameters["@customer_id"].Value = invoice.customer_id;

                    command.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime));
                    command.Parameters["@date"].Value = invoice.date;

                    command.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal));
                    command.Parameters["@total"].Value = invoice.total;

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
