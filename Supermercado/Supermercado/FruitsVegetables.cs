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
        private Section section;
        public DateTime dataValidade;
        internal Section Section { get => section; set => section = value; }

        public FruitsVegetables(string id, string name, float stock, float unitPrice, TypeOfProducts typeOfProducts, Category category, Section section , DateTime dataValidade) : base(id, name, stock, unitPrice, typeOfProducts, category)
        {
            this.Id = id;
            this.Name = name;
            this.Stock = stock;
            this.UnitPrice = unitPrice;
            this.TypeOfProducts = typeOfProducts;
            this.Category = category;
            this.Section = section;
            this.dataValidade = dataValidade;
        }

    }
}
