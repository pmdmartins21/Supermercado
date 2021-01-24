using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Supermercado
{
    [Serializable]
    class Invoice
    {
        //attributes
        private int invoiceNumber;
        private DateTime invoiceDate;
        private string customerName;
        private string employeeName;
        private List<Product> invoiceProducts;

        //properties
        public int InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
        public DateTime InvoiceDate { get => invoiceDate; set => invoiceDate = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public List<Product> InvoiceProducts { get => invoiceProducts; set => invoiceProducts = value; }


        // contructors
        public Invoice()
        {
            InvoiceProducts = new List<Product>(); // inicialização da lista
        }

        public Invoice(int invoiceNumber, DateTime invoiceDate, string customerName, string employeeName)
        {
            this.invoiceNumber = invoiceNumber;
            this.invoiceDate = invoiceDate;
            this.customerName = customerName;
            this.employeeName = employeeName;
            this.invoiceProducts = new List<Product>();
        }

        public void AddInvoiceProduct(Product product)
        {
            InvoiceProducts.Add(product);
        }

        public override string ToString()
        {
            float totalInvoice = 0;
            string result = "NUMERO FATURA   |   DATA   |   CLIENTE   |   FUNCIONÁRIO   |   TOTAL  |\n";
            result += "   " + InvoiceNumber + "    " + invoiceDate + "    " + customerName + "    " + EmployeeName + "\n";
            foreach (Product p in invoiceProducts)
            {
                
                result += p.Name + "   |  " + p.Stock + "    |    " + p.UnitPrice + " | " + " " + "| Total da linha: " + (p.Stock * p.UnitPrice) + "\n";
                totalInvoice += (p.Stock * p.UnitPrice);
            }
            result += "Total da fatura: \n" + totalInvoice;
            return result;
        }

    }
    [Serializable]
    class InvoiceList
    {
        private List<Invoice> invoiceListing;

        public List<Invoice> InvoiceListing { get => invoiceListing; set => invoiceListing = value; }


        public InvoiceList()
        {
            InvoiceListing = new List<Invoice>(); // inicialização da lista de faturas
        }

        public override string ToString()
        {
            string result = "NUMERO FATURA   |   DATA   |   CLIENTE   |   FUNCIONÁRIO   |   TOTAL  |\n";
            foreach (Invoice i in InvoiceListing)
            {
                result += i.InvoiceNumber + "   |  " + i.InvoiceDate + "    |    " + i.CustomerName + " | " + " " + "| " + i.EmployeeName + "\n";
            }
            return result;
        }

        public void SaveInvoiceList(InvoiceList il)
        {
            string location = Directory.GetCurrentDirectory();
            string fileName = "invoicelist.txt";

            if (File.Exists(fileName))
            {
                Console.WriteLine("Deleting old file");
                File.Delete(fileName);
            }

            FileStream fileStream = File.Create(fileName);
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(fileStream, il);
            fileStream.Close();
        }

        public InvoiceList ReadInvoiceList()
        {
            string location = Directory.GetCurrentDirectory();
            string fileName = "/../../../invoicelist.txt";

            if (File.Exists(fileName))
            {
                FileStream fileStream = File.OpenRead(fileName);
                BinaryFormatter f = new BinaryFormatter();

                while (fileStream.Position < fileStream.Length)
                {
                    InvoiceList il = f.Deserialize(fileStream) as InvoiceList;
                    return il;

                }
                fileStream.Close();

            }
            else
            {
                return null;
            }
            return null;
        }

    }
}