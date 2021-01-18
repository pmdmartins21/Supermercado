using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
   class PurchasedProduct
    {
        //attributes
        private Product product;
        private float quantity;
        private float productPrice;


        //properties
        public float Quantity { get => quantity; set => quantity = value; }
        public float ProductPrice { get => productPrice; set => productPrice = value; }
        internal Product Product { get => product; set => product = value; }


        //constructors
        public PurchasedProduct(Product p, float quantity, float productPrice)
        {
            this.Product = p;
            this.Quantity = quantity;
            this.ProductPrice = productPrice;
        }
    }

    class Invoice
    {
        //attributes
        private int invoiceNumber;
        private DateTime invoiceDate;
        private string customerName;
        private string employeeName;
        private float totalAmount;

        public List<PurchasedProduct> purchasedProducts;

        public Invoice()
        {
            this.purchasedProducts = new List<PurchasedProduct>(); // inicialização da lista
        }


        //properties
        public int InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
        public DateTime InvoiceDate { get => invoiceDate; set => invoiceDate = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public float TotalAmount { get => totalAmount; set => totalAmount = value; }



        // contructors
        public Invoice(int invoiceNumber, DateTime invoiceDate, string customerName, string employeeName, float totalAmount)
        {
            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
            CustomerName = customerName;
            EmployeeName = employeeName;
            TotalAmount = totalAmount;
        }
    }

    class InvoiceList
    {
        public List<Invoice> invoiceList;

        public InvoiceList()
        {
            this.invoiceList = new List<Invoice>(); // inicialização da lista de faturas
        }

        public override string ToString()
        {
            string result = "NUMERO FATURA   |   DATA   |   CLIENTE   |   FUNCIONÁRIO   |   TOTAL  |\n";
            foreach (Invoice i in this.invoiceList)
            {
                result += i.InvoiceNumber + "   |  " + i.InvoiceDate + "    |    " + i.CustomerName + " | " + " " 
                    + "| " + i.EmployeeName + " | " + i.TotalAmount + " | " + "\n";
            }
            return result;
        }

    }
}