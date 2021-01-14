using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    enum TypeOfProducts
    {
        Congelado,
        Prateleira,
        Enlatado
    }
    enum Category //secçao
    {
        FrutasLegumes,
        Carne,
        Mercearia
    }
    class Product
    {
        //atributos
        private string id;
        private string name;
        private float stock;
        private float unitPrice;
        private TypeOfProducts typeOfProducts;
        private Category category;


        //properties
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public float Stock { get => stock; set => stock = value; }
        public float UnitPrice { get => unitPrice; set => unitPrice = value; }
        public TypeOfProducts TypeOfProducts { get => typeOfProducts; set => typeOfProducts = value; }
        public Category Category { get => category; set => category = value; }


        // contructors
        public Product(string id, string name, float stock, float unitPrice, TypeOfProducts typeOfProducts, Category category)
        {
            this.id = id;
            this.name = name;
            this.stock = stock;
            this.unitPrice = unitPrice;
            this.typeOfProducts = typeOfProducts;
            this.category = category;
        }

    }



}
