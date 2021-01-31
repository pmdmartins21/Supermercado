using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Supermercado
{
    [Serializable]
    enum TypeOfProducts
    {
        Congelado,
        Prateleira,
        Enlatado
    }
    [Serializable]
    enum Category //secçao
    {
        FrutasLegumes,
        Carne,
        Mercearia
    }
    [Serializable]
    class Product
    {
        //attributes
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
        public Product()
        {

        }

        public Product(Product p)
        {
            this.Id = p.id;
            this.Name = p.name;
            this.Stock = p.stock;
            this.UnitPrice = p.unitPrice;
            this.TypeOfProducts = p.typeOfProducts;
            this.Category = p.category;
        }
        public Product(string id, string name, float stock, float unitPrice, TypeOfProducts typeOfProducts, Category category)
        {
            this.Id = id;
            this.Name = name;
            this.Stock = stock;
            this.UnitPrice = unitPrice;
            this.TypeOfProducts = typeOfProducts;
            this.Category = category;
        }

        public override string ToString()
        {
            string result = "";
            Table.PrintLine();
            Table.PrintRow("ID", "NOME", "STOCK", "PREÇO UNITÁRIO", "TIPO DE PRODUTO", "CATEGORIA");
            Table.PrintLine();
            Table.PrintRow(Id, Name, Stock.ToString(), UnitPrice.ToString("F2"), TypeOfProducts.ToString(), Category.ToString());
            Table.PrintLine();
            
            return result;
        }
    }
    [Serializable]
    class ProductList
    {
        public List<Product> productList;

        public ProductList()
        {
            this.productList = new List<Product>(); // inicialização da lista
        }

        public static object Globalization { get; private set; }

   
        public ProductList LerFicheiro()
        {

            string location = Directory.GetCurrentDirectory();
            string fileName = "/../../../productlist.txt";

            if (File.Exists(location + fileName))
                
                {
                using (FileStream fileStream = File.OpenRead(location + fileName))
                {
                    BinaryFormatter f = new BinaryFormatter();

                    while (fileStream.Position < fileStream.Length)
                    {
                        ProductList pl = f.Deserialize(fileStream) as ProductList;
                        return pl;

                    }
                    fileStream.Close();
                }
            }
            else
            {
                return null;
            }
            return null;

            /*
            string path = Directory.GetCurrentDirectory();
            string filename = "/../../../productlist.txt";

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
            */
        }


        public void GravarParaFicheiro(ProductList pl)
        {
            string location = Directory.GetCurrentDirectory();
            string fileName = "/../../../productlist.txt";

            if (File.Exists(location + fileName))
            {
                Console.WriteLine("Deleting old file");
                File.Delete(location + fileName);
            }

            FileStream fileStream = File.Create(location + fileName);
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(fileStream, pl);
            fileStream.Close();
        }

        public Product AddProduct(string newId, string newName, float newStock, float newUnitPrice, TypeOfProducts newTypeOfProducts, Category newCategory)
        {
            Product newProduct = new Product(newId, newName, newStock, newUnitPrice, newTypeOfProducts, newCategory);
            this.productList.Add(newProduct);
            return newProduct;
        }
        public Product AddProduct(Product p)
        {
            Product newProduct = new Product(p.Id, p.Name, p.Stock, p.UnitPrice, p.TypeOfProducts, p.Category);
            this.productList.Add(newProduct);
            return newProduct;
        }

        public bool RemoveProduct(string id) // Para remover temos que no menu entrar o id a remover e passar aqui como parametro.
        {
            int idARemover = -1;
            for (int i = 0; i < this.productList.Count; i++)
            {
                if (this.productList[i].Id == id)
                {
                    idARemover = i;
                }
            }
            if (idARemover != -1)
            {
                this.productList.RemoveAt(idARemover);
                return true;
            }

            return false;
        }

        public bool ClearList()
        {
            this.productList.Clear();
            return true;
        }

        public bool AddStock(string id, float amountToAdd)
        {
            for (int i = 0; i < this.productList.Count; i++) 
            {
            
                if (this.productList[i].Id == id)
                {
                    this.productList[i].Stock += amountToAdd;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveStock(string id, float amountToRemove)
        {
            for (int i = 0; i < this.productList.Count; i++)
            {

                if (this.productList[i].Id == id)
                {
                    this.productList[i].Stock -= amountToRemove;
                    return true;
                }
            }   
            return false;
        }

        public override string ToString()
        {
            string result = "";
            Table.PrintLine();
            Table.PrintRow("ID", "NOME", "STOCK", "PREÇO UNITÁRIO", "TIPO DE PRODUTO", "CATEGORIA");
            foreach (Product f in this.productList)
            {
                Table.PrintLine();
                Table.PrintRow(f.Id, f.Name, f.Stock.ToString("F2"), f.UnitPrice.ToString("F2"), f.TypeOfProducts.ToString(), f.Category.ToString());
                Table.PrintLine();
            }
            return result;
        }
        

        public void ListProductsByCategory(Category category)
        {
            Table.PrintLine();
            Table.PrintRow("ID", "NOME", "STOCK", "PREÇO UNITÁRIO", "TIPO DE PRODUTO", "CATEGORIA");
            foreach (Product p in this.productList)
            {
                if (p.Category == category)
                {
                    Table.PrintLine();
                    Table.PrintRow(p.Id, p.Name, p.Stock.ToString("F2"), p.UnitPrice.ToString("F2"), p.TypeOfProducts.ToString(), p.Category.ToString());
                    Table.PrintLine();
                }
            }
        }

        public Product FindProduct(string id)
        {

            foreach (Product p in this.productList)
            {
                if (p.Id.Equals(id))
                {
                    return p;
                }
            }

            return null;

        }

        public float VerifyStock(string id)
        {
            foreach (Product p in this.productList)
            {
                if (p.Id.Equals(id))
                {
                    return p.Stock;
                }
            }
            return -1;
        }
    }
}
