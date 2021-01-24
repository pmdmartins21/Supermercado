﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace Supermercado
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee activeUser = new Employee();
            /*System f = new System(); // inicializar lista
            f.LerFicheiro(); // ler a listagem dos produtos

            Console.WriteLine(f.ToString());*/




            MostrarMenu(activeUser);




        }

        public static void MostrarMenu(Employee activeuser)
        {
            int menuOption;

            EmployeeList list1 = new EmployeeList();


            do
            {
                list1.LerFicheiro();
                Console.WriteLine("************SUPERMERCADO BINHAS ONTE***************");
                Console.WriteLine("**                                               **");
                Console.WriteLine("**                  Bem-vindo/a!                 **");
                Console.WriteLine("**                                               **");
                Console.WriteLine("**\t" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm") + "\t\t**");
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("1- Entrar");
                Console.WriteLine("2- Recuperar a password\n"); // como será possivel recuperar a pass
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("0- Sair");

                while (int.TryParse(Console.ReadLine(), out menuOption) == false)
                {
                    Console.WriteLine("Opçao errada");
                }

                Console.Clear();

                switch (menuOption)
                {
                    case 0:
                        break;
                    case 1:

                        bool successfull = false;

                        while (!successfull)
                        {
                            Console.WriteLine("Introduza o seu ID");
                            string id = Console.ReadLine();
                            Console.WriteLine("Introduza a sua password");
                            string password = Console.ReadLine();
                            successfull = list1.ValidateEntry(id, password);
                            activeuser = list1.FindEmployee(id);
                        }
                        MostrarPrincipal(activeuser);
                        break;
                    case 2:
                        Console.WriteLine("2");

                        break;
                    default:
                        Console.WriteLine("Escolheu uma opção inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            } while (menuOption != 0);
        }
        public static void MostrarPrincipal(Employee activeuser) //Menu principal
        {
            int menuOption2;

            EmployeeList list2 = new EmployeeList();


            do
            {
                list2.LerFicheiro();
                Console.WriteLine("************SUPERMERCADO BINHAS ONTE***************");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**                  Bem-vindo/a!                **");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**\t" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm") + "\t\t**");
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("1- Vendas\n");
                Console.WriteLine("2- Stock\n");
                Console.WriteLine("3- Funcionarios\n");
                Console.WriteLine("4- Listagem de Faturas\n");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("0- Sair");

                while (int.TryParse(Console.ReadLine(), out menuOption2) == false)
                {
                    Console.WriteLine("Opçao errada");
                }

                Console.Clear();

                switch (menuOption2)
                {
                    case 0:
                        MostrarMenu(activeuser);
                        break;
                    case 1:
                        MenuVendas(activeuser);
                        break;
                    case 2:
                        MenuStock(activeuser);
                        break;
                    case 3:
                        MenuFuncionarios(activeuser);
                        break;
                    case 4:
                        Console.WriteLine("4");
                        break;
                    default:
                        Console.WriteLine("Escolheu uma opção inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            } while (menuOption2 != 0);
        }


        public static void MenuVendas(Employee activeuser)
        {
            int menuOption2;
            Invoice compraTotal = new Invoice();


            ProductList productList = new ProductList();
            InvoiceList invoiceList = new InvoiceList();

            do
            {
                productList.LerFicheiro();
                invoiceList.ReadInvoiceList();
                Console.WriteLine("************SUPERMERCADO BINHAS ONTE***************");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**                  Bem-vindo/a!                **");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**\t" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm") + "\t\t**");
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("**MENU Vendas**\n");
                Console.WriteLine("Selecione uma categoria\n");
                Console.WriteLine("1- Carne\n");
                Console.WriteLine("2- Frutas e Legumes\n");
                Console.WriteLine("3- Mercearia\n");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("4- Ver carrinho de produtos\n");
                Console.WriteLine("5- Cancelar venda\n");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("0- Terminar venda");

                while (int.TryParse(Console.ReadLine(), out menuOption2) == false)
                {
                    Console.WriteLine("Opçao errada");
                }


                Console.Clear();

                switch (menuOption2)
                {
                    case 0:



                        Console.WriteLine("Introduza o número da fatura:");
                        compraTotal.InvoiceNumber = int.Parse(Console.ReadLine());

                        Console.WriteLine("Data");
                        compraTotal.InvoiceDate = DateTime.Now;

                        Console.WriteLine("Introduza o nome do cliente:");
                        compraTotal.CustomerName = Console.ReadLine();

                        compraTotal.EmployeeName = activeuser.Name;
                        Console.WriteLine("O total da fatura: ");

                        Console.WriteLine(compraTotal.ToString());
                       

                        invoiceList.InvoiceListing.Add(compraTotal);
                        invoiceList.SaveInvoiceList(invoiceList);
                        Console.WriteLine(invoiceList.InvoiceListing[0].CustomerName);
                        Console.WriteLine(invoiceList.InvoiceListing[0].InvoiceProducts[0].Name);

                        break;
                    case 1:
                        Console.WriteLine(productList.ListProductsByCategory(Category.Carne));
                        compraTotal = MenuVenda(activeuser, compraTotal);
                        productList.ClearList();
                        break;
                    case 2:
                        Console.WriteLine(productList.ListProductsByCategory(Category.FrutasLegumes));
                        compraTotal = MenuVenda(activeuser, compraTotal);
                        productList.ClearList();
                        break;
                    case 3:
                        Console.WriteLine(productList.ListProductsByCategory(Category.Mercearia));

                        compraTotal = MenuVenda(activeuser, compraTotal);
                        productList.ClearList();

                        break;
                    case 4:
                        Console.WriteLine(compraTotal.ToString());
                        break;
                    case 5:
                        MostrarPrincipal(activeuser);
                        break;
                    default:
                        Console.WriteLine("Escolheu uma opção inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            } while (menuOption2 != 0);
        }

        public static Invoice MenuVenda(Employee activeuser, Invoice compraTotal)
        {

            ProductList productList = new ProductList(); //LISTAGEM DO STOCK
            productList.LerFicheiro();

            int repeat = 1;

            string idPurchase;

            float quantityPurchase = -1; ;
            float prodQuantity = 0;

            Product productPurchase = new Product();

            do
            {
                Console.WriteLine("Introduza o id do produto a adicionar ao carrinho");
                idPurchase = Console.ReadLine();
                if (productList.FindProduct(idPurchase) == null)
                {
                    Console.WriteLine("Id inválido!");
                }


            } while (productList.FindProduct(idPurchase) == null);

            productPurchase = productList.FindProduct(idPurchase);
            //Verificar id Produto e FAZER CÓPIA DO PRODUTO ORIGINAL
            while (quantityPurchase <= 0)
            {

                Console.WriteLine("Introduza a quantidade");
                quantityPurchase = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (quantityPurchase > 0)
                {
                    if (quantityPurchase <= productPurchase.Stock)
                    {
                        //INCORPORAR A QUANTIDADE NO PRODUTO A COMPRAR
                        productPurchase.Stock = quantityPurchase;
                        //produtoEscolhido = productList.FindProduct(idPurchase);
                    }
                    else
                    {
                        Console.WriteLine("Nao tem stock");
                        quantityPurchase = -1;
                    }
                }
                else
                {
                    Console.WriteLine("Quantidade inválida!");
                }

            }


            //prodQuantity = productList.VerifyStock(idPurchase);

            compraTotal.InvoiceProducts.Add(productPurchase);

            Console.WriteLine(compraTotal.ToString());

            do
            {
                Console.WriteLine("Deseja inserir mais items desta categoria? Sim= 1, Nao = Outro numero qualquer\n");
                while (int.TryParse(Console.ReadLine(), out repeat) == false)
                {
                    Console.WriteLine("Opçao errada");
                }
                if (repeat == 1)
                {

                    do
                    {
                        Console.WriteLine("Introduza o id do produto a adicionar ao carrinho");
                        idPurchase = Console.ReadLine();
                        if (productList.FindProduct(idPurchase) == null)
                        {
                            Console.WriteLine("Id inválido!");
                        }

                    } while (productList.FindProduct(idPurchase) == null);

                    productPurchase = productList.FindProduct(idPurchase);
                    quantityPurchase = -1;

                    while (quantityPurchase <= 0)
                    {

                        Console.WriteLine("Introduza a quantidade");
                        quantityPurchase = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        if (quantityPurchase > 0)
                        {
                            if (quantityPurchase <= productPurchase.Stock)
                            {
                                //INCORPORAR A QUANTIDADE NO PRODUTO A COMPRAR
                                productPurchase.Stock = quantityPurchase;
                                //produtoEscolhido = productList.FindProduct(idPurchase);
                            }
                            else
                            {
                                Console.WriteLine("Nao tem stock");
                                quantityPurchase = -1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Quantidade inválida!");
                            
                        }

                    } 

 
                    compraTotal.InvoiceProducts.Add(productPurchase);
                    Console.WriteLine(compraTotal.ToString());
                }
            } while (repeat == 1);

            return compraTotal;
        }


        public static void MenuFuncionarios(Employee activeuser)
        {
            int menuOption;

            EmployeeList list1 = new EmployeeList();

            Console.WriteLine(activeuser.Name);
            do
            {
                list1.LerFicheiro();
                Console.WriteLine("************SUPERMERCADO BINHAS ONTE***************");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**                  Bem-vindo/a!                **");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**\t" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm") + "\t\t**");
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("1- Registar Funcionario");
                Console.WriteLine("2- Remover Funcionario\n");
                Console.WriteLine("3- Editar Funcionario\n");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("0- Sair");

                while (int.TryParse(Console.ReadLine(), out menuOption) == false)
                {
                    Console.WriteLine("Opçao errada");
                }


                Console.Clear();

                switch (menuOption)
                {
                    case 0:
                        Console.WriteLine("0");
                        break;
                    case 1:
                        Console.WriteLine(list1.ToString());
                        Console.WriteLine("Introduza o ID\n");
                        string id = Console.ReadLine();
                        Console.WriteLine("Introduza o Nome\n");
                        string name = Console.ReadLine();
                        Console.WriteLine("Introduza a Password\n");
                        string password = Console.ReadLine();
                        Console.WriteLine("Qual o Cargo? \n");
                        Console.WriteLine("Para Gerente prima '0'\n");
                        Console.WriteLine("Para Repositor prima '1'\n");
                        Console.WriteLine("Para Caixa prima '2'\n");
                        string role = Console.ReadLine();
                        Enum.TryParse(role, out EmployeeRole employeeRole);
                        list1.NewEmployee(id, name, password, employeeRole);
                        list1.GravarParaFicheiro(); //Depois de adicionarmos um user, qd tentamos logar com o mesmo o programa crasha. Problema com a leitura do txt apos a modificaçao??  
                        Console.WriteLine(list1.ToString());
                        list1.ClearList();
                        Console.WriteLine(list1.ToString());
                        break;
                    case 2:
                        Console.WriteLine(list1.ToString());
                        Console.WriteLine("Introduza o ID a remover\n");
                        string idARemover = Console.ReadLine();
                        list1.RemoveEmployee(idARemover);
                        Console.WriteLine(list1.ToString());
                        list1.GravarParaFicheiro();
                        list1.ClearList();
                        Console.WriteLine(list1.ToString());
                        break;
                    case 3:
                        Console.WriteLine(list1.ToString());
                        Console.WriteLine("Introduza o ID do funcionário a editar\n");
                        string newId = Console.ReadLine();
                        Console.WriteLine("Introduza o novo nome\n");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Introduza a nova password\n");
                        string newPassword = Console.ReadLine();
                        Console.WriteLine("Introduza a nova função\n");
                        string newRole = Console.ReadLine();
                        Enum.TryParse(newRole, out EmployeeRole newEmployeeRole);
                        list1.EditEmployee(newId, newName, newPassword, newEmployeeRole);
                        Console.WriteLine(list1.ToString());
                        list1.GravarParaFicheiro();
                        list1.ClearList();
                        Console.WriteLine(list1.ToString());
                        break;
                    default:
                        Console.WriteLine("Escolheu uma opção inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            } while (menuOption != 0);
        }

        public static void MenuStock(Employee activeuser)
        {
            int menuOption;
            int limparStock;

            ProductList list1 = new ProductList();

            do
            {
                list1.LerFicheiro();
                Console.WriteLine("************SUPERMERCADO BINHAS ONTE***************");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**                  Bem-vindo/a!                **");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**\t" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm") + "\t\t**");
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("1- Ver / Editar Stock");
                Console.WriteLine("2- Adicionar Novo Produto\n");
                Console.WriteLine("3- Remover Produto\n");
                Console.WriteLine("4- Limpar Stock\n");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("0- Sair");

                while (int.TryParse(Console.ReadLine(), out menuOption) == false)
                {
                    Console.WriteLine("Opçao errada");
                }



                Console.Clear();

                switch (menuOption)
                {
                    case 0:
                        Console.WriteLine("0");
                        break;
                    case 1:
                        MenuStock2(activeuser);
                        break;
                    case 2:
                        Console.WriteLine(list1.ToString()); // Listar
                        Console.WriteLine("Escolha o id do Produto:");
                        string idProdutoAAdicionar = Console.ReadLine();

                        Console.WriteLine("Escolha o Nome do Produto:");
                        string nomeDoProdutoAAdicionar = Console.ReadLine();

                        Console.WriteLine("Escolha o Stock do Produto:");
                        float stockProdutoAAdicionar = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                        Console.WriteLine("Escolha o Preco do Produto:");
                        float precoProdutoAAdicionar = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                        Console.WriteLine("Escolha o Tipo do Produto: Congelado = 0, Prateleira = 1, Enlatado = 2");
                        Enum.TryParse(Console.ReadLine(), out TypeOfProducts typeOfproducts);


                        Console.WriteLine("Escolha a Categoria: FrutasLegumes = 0, Carne = 1, Mercearia = 2");
                        Enum.TryParse(Console.ReadLine(), out Category categoria);


                        Product x = new Product(idProdutoAAdicionar, nomeDoProdutoAAdicionar, stockProdutoAAdicionar, precoProdutoAAdicionar, typeOfproducts, categoria);
                        Console.WriteLine(x.ToString());

                        list1.AddProduct(x);

                        Console.WriteLine(list1.ToString()); // Listar
                        list1.GravarParaFicheiro();

                        list1.ClearList();

                        break;
                    case 3:
                        Console.WriteLine(list1.ToString()); // Listar
                        Console.WriteLine("escolha o id a remover:");
                        string produtoARemover = Console.ReadLine();
                        list1.RemoveProduct(produtoARemover);
                        list1.GravarParaFicheiro();
                        list1.ClearList();
                        break;
                    case 4:
                        Console.WriteLine("Vai remover o stock completo! Tem a certeza? \n(Opcao 1 - Limpar Stock| Outro numero para cancelar");
                        while (!int.TryParse(Console.ReadLine(), out limparStock))
                        {
                            Console.WriteLine("Opcao Errada");
                        }
                        if (limparStock == 1)
                        {
                            list1.ClearList();
                            list1.GravarParaFicheiro();
                        }
                        break;
                    default:
                        Console.WriteLine("Escolheu uma opção inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            } while (menuOption != 0);
        }

        public static void MenuStock2(Employee activeuser)
        {
            int menuOption;

            ProductList list1 = new ProductList();

            do
            {
                list1.LerFicheiro(); // lista produtos acima
                Console.WriteLine("************SUPERMERCADO BINHAS ONTE***************");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**                  Bem-vindo/a!                **");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**\t" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm") + "\t\t**");
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("1- Ver Stock");
                Console.WriteLine("2- Adicionar Stock\n");
                Console.WriteLine("3- Remover Stock\n");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("0- Sair");

                while (int.TryParse(Console.ReadLine(), out menuOption) == false)
                {
                    Console.WriteLine("Opçao errada");
                }

                Console.Clear();
                switch (menuOption)
                {
                    case 0:
                        MenuStock(activeuser); // <<-- ir para menu anterior
                        list1.ClearList();
                        break;
                    case 1:
                        Console.WriteLine(list1.ToString());
                        list1.ClearList();
                        break;
                    case 2:
                        Console.WriteLine(list1.ToString());
                        Console.WriteLine("**ADICIONAR STOCK**\n");
                        Console.WriteLine("**TECLA 0 - PARA SAIR OU CANCELAR**\n");
                        Console.WriteLine("Introduza o id do produto:\n");
                        string idAddStock = Console.ReadLine();
                        Console.WriteLine("Introduza a quantidade:\n"); // !!atenção se a quantidade só aceita int ou float e qtd negativa
                        float quantityAddStock = float.Parse(Console.ReadLine());
                        bool resultAddStock = list1.AddStock(idAddStock, quantityAddStock);
                        list1.GravarParaFicheiro();
                        if (resultAddStock) // true
                        {
                            Console.WriteLine("Quantidade adicionada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Falhou");
                        }
                        Console.WriteLine(list1.ToString());
                        list1.ClearList();
                        break;
                    case 3:
                        Console.WriteLine(list1.ToString());
                        Console.WriteLine("**REMOVER STOCK**\n");
                        Console.WriteLine("**TECLA 0 - PARA SAIR OU CANCELAR**\n");
                        Console.WriteLine("Introduza o id do produto:\n");
                        string idRemoveStock = Console.ReadLine();
                        Console.WriteLine("Introduza a quantidade:\n"); // !!atenção se a quantidade só aceita int ou float e qtd negativa
                        float quantityRemoveStock = float.Parse(Console.ReadLine());
                        bool resultRemoveStock = list1.RemoveStock(idRemoveStock, quantityRemoveStock);
                        list1.GravarParaFicheiro();
                        if (resultRemoveStock) // true
                        {
                            Console.WriteLine("Quantidade removida com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Falhou");
                        }
                        Console.WriteLine(list1.ToString());
                        list1.ClearList();
                        break;
                    case 4:
                        Console.WriteLine("4");
                        break;
                    default:
                        Console.WriteLine("Escolheu uma opção inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            } while (menuOption != 0);
        }
    }

}
