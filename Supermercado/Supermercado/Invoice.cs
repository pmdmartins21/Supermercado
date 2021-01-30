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
            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
            CustomerName = customerName;
            EmployeeName = employeeName;
            InvoiceProducts = new List<Product>();
        }

        public void AddInvoiceProduct(Product product)
        {
            InvoiceProducts.Add(product);
        }

        public void AddListProductsToInvoice(ProductList productList)
        {
            foreach (Product p in productList.productList)
            {
                InvoiceProducts.Add(p);
            }
        }

        public override string ToString()
        {
            string result = "";
            float totalInvoice = 0;

            Table.PrintLine();
            Table.PrintRow("NOME", "STOCK", "PREÇO UNITÁRIO", "TOTAL");
            Table.PrintLine();
            //result += "   " + InvoiceNumber + "    " + invoiceDate + "    " + customerName + "    " + EmployeeName + "\n"; 
            foreach (Product p in invoiceProducts)
            {
                Table.PrintLine();
                Table.PrintRow(p.Name, p.Stock.ToString("F2"), p.UnitPrice.ToString("F2"), (p.Stock * p.UnitPrice).ToString("F2"));
                Table.PrintLine();
                //result += p.Name + "   |  " + p.Stock + "    |    " + p.UnitPrice + " | " + " " + "| Total da linha: " + (p.Stock * p.UnitPrice) + "\n"; 
                //totalInvoice += (p.Stock * p.UnitPrice); 
            }
            //result += "Total da fatura: \n" + totalInvoice; 
            return result;
        }

    }
    [Serializable]
    class InvoiceList
    {
        public List<Invoice> invoiceListing;

        


        public InvoiceList()
        {
            invoiceListing = new List<Invoice>(); // inicialização da lista de faturas
        }

        public override string ToString()
        {
            string result = "";

            foreach (Invoice i in invoiceListing)
            {
                Table.PrintLine();
                Table.PrintRow("NUMERO FATURA", "DATA", "CLIENTE", "FUNCIONÁRIO");
                Table.PrintLine();
                Table.PrintRow(i.InvoiceNumber.ToString(), i.InvoiceDate.ToString(), i.CustomerName, i.EmployeeName, i.InvoiceProducts[0].ToString());
                Table.PrintLine();
                //result += i.InvoiceNumber + "   |  " + i.InvoiceDate + "    |    " + i.CustomerName + " | " + " " + "| " + i.EmployeeName + "\n";
                Console.WriteLine("Lista de Produtos: \n");
            }
            return result;
        }

        public static void SaveInvoiceList(InvoiceList il)
        {
            string location = Directory.GetCurrentDirectory();
            string fileName = "/../../../invoicelist.txt";

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

        public static InvoiceList ReadInvoiceList()
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
        public bool ClearList()
        {
            this.invoiceListing.Clear();
            return true;
        }

        public void RemoveInvoiceFromList(InvoiceList il)
        {
            int id;
            do
            {
                Console.WriteLine("Insira o ID da Fatura que pretende remover da lista");
                while (int.TryParse(Console.ReadLine(), out id) == false)
                {
                    Console.WriteLine("Id inválido");
                }
                if (il.FindInvoiceInList(il,id) == null)
                {
                    Console.WriteLine("Id inválido!");
                } 
            } while (il.FindInvoiceInList(il,id) == null);
            il.invoiceListing.Remove(il.FindInvoiceInList(il,id));
            //Nao se pode apagar faturas por lei, este metodo é apenas para remover as faturas ques estamos a testar.
        }

        public Invoice FindInvoiceInList(InvoiceList il, int id)
        {
            Invoice i = new Invoice();
            for (int j = 0; j < il.invoiceListing.Count; j++)
            {
                if (il.invoiceListing[j].InvoiceNumber == id)
                {
                    i = il.invoiceListing[j];
                    return i;
                }
            }
            return null;
        }

        public void ListInvoiceList(InvoiceList il)
        {
            foreach (Invoice item in il.invoiceListing)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void AddInvoice(Invoice i)
        {
            this.invoiceListing.Add(i);
        }

    }
}