using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    class InvoiceItem
    {
        //attributes
        private Product product;
        private float quantity;
        private float productPrice;


        //properties
        public Product Product { get => product; set => product = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public float ProductPrice { get => productPrice; set => productPrice = value; }
        


        //constructors
        public InvoiceItem(Product p, float quantity, float productPrice)
        {
            Product = p;
            Quantity = quantity;
            ProductPrice = productPrice;
        }
    }
}
