using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Supermercado
{
    class System
    {

        public List<Product> productList;

        public System()
        {
            this.productList = new List<Product>(); // inicialização da lista
        }

        public static object Globalization { get; private set; }

        public void LerFicheiro()
        {
            string path = Directory.GetCurrentDirectory();
            string filename = "/productlist.txt";

            StreamReader streamReader = new StreamReader(path + filename);

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string id = line.Split(",")[0];
                string name = line.Split(",")[1];
                float stock = float.Parse(line.Split(",")[2], CultureInfo.InvariantCulture.NumberFormat);
                float unitPrice = float.Parse(line.Split(",")[3], CultureInfo.InvariantCulture.NumberFormat);
                Enum.TryParse(line.Split(",")[4], out TypeOfProducts typeOfProducts);
                Enum.TryParse(line.Split(",")[5], out Category category);
                

                productList.Add(new Product(id, name, stock, unitPrice, typeOfProducts, category));
                //Console.WriteLine(streamReader.ReadLine());
            }

            streamReader.Close();
        }


        public void GravarParaFicheiro()
        {
            //Escolher directorio
            string path = Directory.GetCurrentDirectory();

            //nome do ficheiro
            string fileName = "/productlist.txt";

            //abrir a Stream para escrita
            StreamWriter streamWriter = new StreamWriter(path + fileName, false);


            //Percorrer e escrever a lista
            foreach (Product item in this.productList)
            {
                streamWriter.Write(item.Id + "," + item.Name + "," + item.Stock + "," + item.UnitPrice + "," + item.TypeOfProducts + "," + item.Category + "\n");
                //streamWriter.Write(item.ToString());
            }
            

            //Fechar a stream de escrit
            streamWriter.Close();
        }

        public Product AddProduct(string newId, string newName, float newStock, float newUnitPrice, TypeOfProducts newTypeOfProducts, Category newCategory)
        {
            Product newProduct = new Product(newId, newName, newStock, newUnitPrice, newTypeOfProducts,newCategory);
            this.productList.Add(newProduct);
            return newProduct;
        }
        public Product AddProduct(Product p)
        {
            Product newProduct = new Product(p.Id, p.Name, p.Stock, p.UnitPrice, p.TypeOfProducts, p.Category);
            this.productList.Add(newProduct);
            return newProduct;
        }
        public override string ToString()
        {
            string result = "ID   | NOME    | STOCK  | PREÇO UNITÁRIO  |   TIPO DE PRODUTO  |   CATEGORIA  \n";
            foreach (Product f in this.productList)
            {
                result += f.Id + "   |  " + f.Name + "    |    " + f.Stock + " | " + f.UnitPrice + " | " + f.TypeOfProducts + " | " + f.Category + "\n";
            }
            return result;
        }
    }
}
