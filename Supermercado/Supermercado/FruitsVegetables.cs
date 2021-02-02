using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    [Serializable]
    enum Section
    {
        Legumes,
        Frutas,
        verduras
    }
    [Serializable]
    class FruitsVegetables : Product
    {
        //atributos
        private Section section;
        public bool dentroValidade;
        internal Section Section { get => section; set => section = value; }

        //construtor
        public FruitsVegetables(string id, string name, float stock, float unitPrice, TypeOfProducts typeOfProducts, Category category, Section section , bool dentroValidade) : base(id, name, stock, unitPrice, typeOfProducts, category)
        {
            this.Id = id;
            this.Name = name;
            this.Stock = stock;
            this.UnitPrice = unitPrice;
            this.TypeOfProducts = typeOfProducts;
            this.Category = category;
            this.Section = section;
            this.dentroValidade = dentroValidade;
        }
        
        //metodo proprio
        private void Estragar()
        {
            this.dentroValidade = false;
        }

        public void PassouDoPrazo()
        {
            Console.WriteLine("Passou do prazo, por favor deitar fora!");
            this.Estragar();
        }

    }
}
