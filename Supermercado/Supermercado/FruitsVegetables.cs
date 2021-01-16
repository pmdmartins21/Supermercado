using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    class FruitsVegetables : Product
    {
        enum Section
        {
           Legumes,
           Frutas,
           verduras
        }
        public Section section { get => section; set => section = value; }

        public FruitsVegetables(string id, string name, float stock, float unitPrice, TypeOfProducts typeOfProducts, Category category, Section section) : base(id, name, stock, unitPrice, typeOfProducts, category)
        {

        }
    }
}
