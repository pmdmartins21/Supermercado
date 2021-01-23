﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    class Invoice
    {
        //attributes
        private int invoiceNumber;
        private DateTime invoiceDate;
        private string customerName;
        private string employeeName;
        private float totalAmount;
        private List<InvoiceItem> invoiceItems;

        //properties
        public int InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
        public DateTime InvoiceDate { get => invoiceDate; set => invoiceDate = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public float TotalAmount { get => totalAmount; set => totalAmount = value; }
        public List<InvoiceItem> InvoiceItems { get => invoiceItems; set => invoiceItems = value; }


        // contructors
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>(); // inicialização da lista
        }

        public Invoice(int invoiceNumber, DateTime invoiceDate, string customerName, string employeeName, float totalAmount)
        {
            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
            CustomerName = customerName;
            EmployeeName = employeeName;
            TotalAmount = totalAmount;
        }

        public void AddInvoiceItem(InvoiceItem invoiceItem)
        {
            InvoiceItems.Add(invoiceItem);
        }

    }
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
                result += i.InvoiceNumber + "   |  " + i.InvoiceDate + "    |    " + i.CustomerName + " | " + " "
                    + "| " + i.EmployeeName + " | " + i.TotalAmount + " | " + "\n";
            }
            return result;
        }

    }
}