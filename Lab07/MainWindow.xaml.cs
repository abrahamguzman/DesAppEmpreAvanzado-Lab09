using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Data;
using Entity;


namespace Lab07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BInvoice bInvoice = new BInvoice();
        public MainWindow()
        {
            InitializeComponent();
            ListInvoice();
        }

        private void DeleteInvoice(object sender, RoutedEventArgs e)
        {
            int invoiceId = (int)((Button)sender).CommandParameter;
            bInvoice.DeleteInvoice(invoiceId);
            ListInvoice();
        }

        private void ListInvoiceByDate(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = datepicker.SelectedDate;
            Console.WriteLine(selectedDate);
            if (selectedDate.HasValue)
            {
                List<Invoice> invoices = bInvoice.GetByDate(selectedDate.Value);
                dataGrid.ItemsSource = invoices;
            }
        }

        private void ListInvoice()
        {
            List<Invoice> invoices = bInvoice.GetInvoiceActives();
            dataGrid.ItemsSource = invoices;
        }

        private void Listar(object sender, RoutedEventArgs e)
        {
            ListInvoice();
        }

    }
}
