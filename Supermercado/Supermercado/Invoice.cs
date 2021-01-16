﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    class Invoice
    {
        private int invoiceNumber;
        private DateTime invoiceDate;
        private string customerName;
        private string purchasedProducts;
        private string employeeName;
        private float amount;
        private float price;

        public int InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
        public DateTime InvoiceDate { get => invoiceDate; set => invoiceDate = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string PurchasedProducts { get => purchasedProducts; set => purchasedProducts = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public float Amount { get => amount; set => amount = value; }
        public float Price { get => price; set => price = value; }

        public Invoice(int invoiceNumber, DateTime invoiceDate, string customerName, string purchasedProducts, string employeeName, float amount, float price)
        {
            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
            CustomerName = customerName;
            PurchasedProducts = purchasedProducts;
            EmployeeName = employeeName;
            Amount = amount;
            Price = price;
        }
    }

    class InvoiceList
    {
        public List<Invoice> invoiceList;

        public InvoiceList()
        {
            this.invoiceList = new List<Invoice>(); // inicialização da lista
        }
    }
}