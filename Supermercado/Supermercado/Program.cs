using System;

namespace Supermercado
{
    [Serializable]
    class Program
    {
       
        static void Main(string[] args)
        {
            Employee activeUser = new Employee();
            
            MostrarMenu(activeUser);

        }

        

        public static void MostrarMenu(Employee activeuser)
        {
            int menuOption;

            

            EmployeeList employeeList = new EmployeeList();
            do
            {
                employeeList.LerFicheiro();
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
                            string password = null;
                            while (true)
                            {
                                var key = System.Console.ReadKey(true);
                                if (key.Key == ConsoleKey.Enter)
                                {
                                    Console.WriteLine("\n");
                                    break;
                                }
                                else if (key.Key == ConsoleKey.Backspace)
                                {
                                    password = password.Remove(password.Length - 1);
                                    Console.Write("\b \b");
                                }
                                else
                                {
                                    password += key.KeyChar;
                                    Console.Write("*");
                                }
                                     
                            }
                            
                            successfull = employeeList.ValidateEntry(id, password);
                            activeuser = employeeList.FindEmployee(id);
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

            EmployeeList employeelist = new EmployeeList();
            InvoiceList invoiceList = new InvoiceList();

            do
            {
                employeelist.LerFicheiro();
                invoiceList = GravadorFaturas.ReadInvoiceList();
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
                Console.WriteLine("5- Remover Faturas\n");
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
                        break;
                    case 1:
                        Invoice newInvoice = (MenuVendas(activeuser,invoiceList));
                        if (newInvoice.InvoiceProducts.Count > 0)
                        {
                            invoiceList.AddInvoice(newInvoice);
                            GravadorFaturas.SaveInvoiceList(invoiceList);
                        }
                        
                        break;
                    case 2:
                        MenuStock(activeuser);
                        break;
                    case 3:
                        MenuFuncionarios(activeuser);
                        break;
                    case 4:
                        Table.PrintLine();
                        Table.PrintRow("LISTAGEM DE FATURAS");
                        Table.PrintLine();
                        invoiceList.ToString();
                        
                        //invoiceList.ListInvoiceList(invoiceList);
                        break;
                    case 5:
                        invoiceList.ListInvoiceList(invoiceList);
                        invoiceList.RemoveInvoiceFromList(invoiceList);
                        GravadorFaturas.SaveInvoiceList(invoiceList);
                        break;
                    default:
                        Console.WriteLine("Escolheu uma opção inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            } while (menuOption2 != 0);
        }


        public static Invoice MenuVendas(Employee activeuser, InvoiceList il)
        {
            int menuOption2;
            Invoice compraTotal = new Invoice();
            ProductList productList = new ProductList(); 
            ProductList productListOriginal = new ProductList();
            productListOriginal = ProductList.LerFicheiro();

            do
            {
                productList = ProductList.LerFicheiro();
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
                        if (compraTotal.InvoiceProducts.Count > 0) // Só pede detalhes para faturas com algum produto
                        {
                            compraTotal.InvoiceNumber = Operator.AtribuirIDFatura(il);
                            Console.WriteLine("ID da Fatura: {0}",compraTotal.InvoiceNumber);


                            //Console.WriteLine("Data");
                            compraTotal.InvoiceDate = DateTime.Now;

                            Console.WriteLine("Introduza o nome do cliente:");
                            compraTotal.CustomerName = Console.ReadLine();

                            compraTotal.EmployeeName = activeuser.Name;

                            Console.WriteLine(compraTotal.ToString());
                        }
                        else // sem produtos faz reset à fatura(pode já ter items adicionados) e grava o stock original.
                        {
                            compraTotal = new Invoice();
                            ProductList.GravarParaFicheiro(productListOriginal);
                            productList.ClearList();
                        }
                        break;
                    case 1:
                        Table.PrintLine();
                        Table.PrintRow("MENU VENDAS - CATEGORIA: CARNE");
                        productList.ListProductsByCategory(Category.Carne);
                        compraTotal.AddListProductsToInvoice(MenuVenda(activeuser));
                        productList.ClearList();
                        break;
                    case 2:
                        Table.PrintLine();
                        Table.PrintRow("MENU VENDAS - CATEGORIA: FRUTAS E LEGUMES");
                        productList.ListProductsByCategory(Category.FrutasLegumes);

                        compraTotal.AddListProductsToInvoice(MenuVenda(activeuser));
                        productList.ClearList();
                        break;
                    case 3:
                        Table.PrintLine();
                        Table.PrintRow("MENU VENDAS - CATEGORIA: MERCEARIA");
                        productList.ListProductsByCategory(Category.Mercearia);
                        compraTotal.AddListProductsToInvoice(MenuVenda(activeuser));
                        productList.ClearList();

                        break;
                    case 4:
                        Console.WriteLine(compraTotal.ToString());
                        productList.ClearList();
                        break;
                    case 5:
                        compraTotal = new Invoice();
                        ProductList.GravarParaFicheiro(productListOriginal);
                        productList.ClearList();
                        MostrarPrincipal(activeuser);
                        break;
                    default:
                        Console.WriteLine("Escolheu uma opção inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            } while (menuOption2 != 0);
            return compraTotal;
        }

        public static ProductList MenuVenda(Employee activeuser)
        {
            ProductList productList = new ProductList(); //LISTAGEM DO STOCK
            ProductList productPurchaseList = new ProductList(); //LISTAGEM DOS PRODUTOS COMPRADOS
            productList = ProductList.LerFicheiro();

            int repeat = 1;
            string idPurchase;
            float quantityPurchase = -1;

            Console.WriteLine("**TECLA 0 - PARA SAIR OU CANCELAR**\n");
            do
            {
                
                Console.WriteLine("Introduza o id do produto a adicionar ao carrinho");
                idPurchase = Console.ReadLine();
                if(idPurchase == "0") break; 
                if (productList.FindProduct(idPurchase) == null)
                {
                    Console.WriteLine("Id inválido!");
                }


            } while (productList.FindProduct(idPurchase) == null);

            Product productPurchase = new Product();

            if (idPurchase != "0")
            {

                productPurchase = new Product(productList.FindProduct(idPurchase));
            }
            
            
            //Verificar id Produto e FAZER CÓPIA DO PRODUTO ORIGINAL
            while (quantityPurchase <= 0 && idPurchase != "0")
            {

                Console.WriteLine("Introduza a quantidade");
                
                while (float.TryParse(Console.ReadLine(), out quantityPurchase) == false)
                {
                    Console.WriteLine("Quantidade incorrecta, tente novamente:");
                }
                if (quantityPurchase == 0) break;

                if (quantityPurchase > 0)
                {
                    if (quantityPurchase <= productPurchase.Stock)
                    {
                        //INCORPORAR A QUANTIDADE NO PRODUTO A COMPRAR
                        productPurchase.Stock = quantityPurchase;
                        //INCORPORAR O PRODUTO NA LISTA DE PRODUTOS A COMPRAR
                        productPurchaseList.productList.Add(productPurchase);
                        //Remover do stock a quantidade de produto comprada
                        productList.RemoveStock(productPurchase.Id, productPurchase.Stock);
                        
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

            do
            {
                string idPurchaseRepeat;
                float quantityPurchaseRepeat = -1;
                
                Console.WriteLine("Deseja inserir mais items desta categoria? Sim= 1, Nao = Outro numero qualquer\n");
                while (int.TryParse(Console.ReadLine(), out repeat) == false)
                {
                    Console.WriteLine("Opçao errada");
                }
                if (repeat == 1)
                {
                    do
                    {
                        Console.WriteLine("**TECLA 0 - PARA SAIR OU CANCELAR**\n");
                        Console.WriteLine("Introduza o id do produto a adicionar ao carrinho");
                        idPurchaseRepeat = Console.ReadLine();
                        if (idPurchaseRepeat == "0") break;
                       
                        if (productList.FindProduct(idPurchaseRepeat) == null)
                        {
                            Console.WriteLine("Id inválido!");
                        }

                    } while (productList.FindProduct(idPurchaseRepeat) == null);

                    Product productPurchaseRepeat = new Product();
                    if (idPurchaseRepeat != "0")
                    {
                        productPurchaseRepeat = productList.FindProduct(idPurchaseRepeat);
                    }
                    
                    

                    while (quantityPurchaseRepeat <= 0 && idPurchaseRepeat != "0")
                    {

                        Console.WriteLine("Introduza a quantidade");

                        while (float.TryParse(Console.ReadLine(), out quantityPurchaseRepeat) == false)
                        {
                            Console.WriteLine("Quantidade incorrecta, tente novamente:");
                        }

                        if (quantityPurchaseRepeat == 0) break;
                        if (quantityPurchaseRepeat > 0)
                        {
                            if (quantityPurchaseRepeat <= productPurchaseRepeat.Stock)
                            {
                                //INCORPORAR A QUANTIDADE NO PRODUTO A COMPRAR
                                productPurchaseRepeat.Stock = quantityPurchaseRepeat;
                                //INCORPORAR O PRODUTO NA LISTA DE PRODUTOS A COMPRAR
                                productPurchaseList.AddProduct(productPurchaseRepeat);
                                //remover o produto do stock
                                productList.RemoveStock(productPurchaseRepeat.Id, productPurchaseRepeat.Stock);
                                
                            }
                            else
                            {
                                Console.WriteLine("Nao tem stock");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Quantidade inválida!");
                            
                        }

                    } 

                }
            } while (repeat == 1);
            
            ProductList.GravarParaFicheiro(productList);
            return productPurchaseList;
        }


        public static void MenuFuncionarios(Employee activeuser)
        {
            int menuOption;

            EmployeeList employeeList = new EmployeeList();

            Console.WriteLine(activeuser.Name);
            do
            {
                employeeList.LerFicheiro();
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
                        Console.WriteLine("**TECLA 0 - PARA SAIR OU CANCELAR**\n");
                        Console.WriteLine(employeeList.ToString());
                        Console.WriteLine("ID: {0}\n",employeeList.employeeList.Count+1);
                        string id = Operator.AtribuirIDEmpregado(employeeList);
                        Console.WriteLine("Introduza o Nome\n");
                        string name = Console.ReadLine();
                        if (name == "0")
                        {
                            employeeList.ClearList();
                            break;
                        }
                        Console.WriteLine("Introduza a Password\n");
                        string password = Console.ReadLine();
                        if (password == "0")
                        {
                            employeeList.ClearList();
                            break;
                        }
                        Console.WriteLine("Qual o Cargo? \n");
                        Console.WriteLine("Para Gerente prima '0'\n");
                        Console.WriteLine("Para Repositor prima '1'\n");
                        Console.WriteLine("Para Caixa prima '2'\n");

                        bool result = Enum.TryParse(Console.ReadLine(), out EmployeeRole employeeRole) && Enum.IsDefined(typeof(EmployeeRole), employeeRole);
                        while (!result)
                        {
                            Console.WriteLine("Valor incorrecto, tente novamente");
                            result = Enum.TryParse(Console.ReadLine(), out employeeRole) && Enum.IsDefined(typeof(EmployeeRole), employeeRole);
                        }
                        
                        employeeList.NewEmployee(id, name, password, employeeRole);
                        employeeList.GravarParaFicheiro();
                        Console.WriteLine(employeeList.ToString());
                        employeeList.ClearList();
                        Console.WriteLine(employeeList.ToString());
                        break;
                    case 2:
                        Console.WriteLine("**TECLA 0 - PARA SAIR OU CANCELAR**\n");
                        Console.WriteLine(employeeList.ToString());
                        Console.WriteLine("Introduza o ID a remover\n");
                        string idARemover = Console.ReadLine();
                        if (idARemover == "0")
                        {
                            employeeList.ClearList();
                            break;
                        }
                        employeeList.RemoveEmployee(idARemover);
                        Console.WriteLine(employeeList.ToString());
                        employeeList.GravarParaFicheiro();
                        employeeList.ClearList();
                        Console.WriteLine(employeeList.ToString());
                        break;
                    case 3:
                        Console.WriteLine("**TECLA 0 - PARA SAIR OU CANCELAR**\n");
                        Console.WriteLine(employeeList.ToString());
                        Console.WriteLine("Introduza o ID do funcionário a editar\n");
                        string newId = Console.ReadLine();
                        if (newId == "0")
                        {
                            employeeList.ClearList();
                            break;
                        }
                        Console.WriteLine("**O QUE DESEJA ALTERAR? \n 1: Nome  |  2: password  | 3: Função**\n");
                        int opcaoAlterarFunc = -1;
                        while (int.TryParse(Console.ReadLine(), out opcaoAlterarFunc) == false)
                        {
                            Console.WriteLine("Opçao errada");
                        }

                        Console.Clear();

                        switch (opcaoAlterarFunc)
                        {
                            case 0:
                                Console.WriteLine("0");
                                break;
                            case 1:
                                Console.WriteLine("Introduza o novo nome\n");
                                string newName = Console.ReadLine();
                                employeeList.FindEmployee(newId).Name = newName;
                                break;
                            case 2:
                                Console.WriteLine("Introduza a nova password\n");
                                string newPassword = Console.ReadLine();
                                employeeList.FindEmployee(newId).Password = newPassword;
                                break;
                            case 3:
                                Console.WriteLine("Introduza a nova função\n");
                                Console.WriteLine("Para Gerente prima '0'\n");
                                Console.WriteLine("Para Repositor prima '1'\n");
                                Console.WriteLine("Para Caixa prima '2'\n");
                                bool result2 = Enum.TryParse(Console.ReadLine(), out EmployeeRole newEmployeeRole) && Enum.IsDefined(typeof(EmployeeRole), newEmployeeRole);
                                while (!result2)
                                {
                                    Console.WriteLine("Valor incorrecto, tente novamente");
                                    result = Enum.TryParse(Console.ReadLine(), out newEmployeeRole) && Enum.IsDefined(typeof(EmployeeRole), newEmployeeRole);
                                }
                                employeeList.FindEmployee(newId).EmployeeRole = newEmployeeRole;
                                break;
                            default:
                                Console.WriteLine("Opção Invalida");
                                break;
                        }

                        Console.WriteLine(employeeList.ToString());
                        employeeList.GravarParaFicheiro();
                        employeeList.ClearList();
                        Console.WriteLine(employeeList.ToString());
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
            ProductList productList = new ProductList();

            do
            {
                productList= ProductList.LerFicheiro();
                Console.WriteLine("************SUPERMERCADO BINHAS ONTE***************");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**                  Bem-vindo/a!                **");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**\t" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm") + "\t\t**");
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("1- Ver / Editar Stock\n");
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
                        break;
                    case 1:
                        MenuStock2(activeuser);
                        productList.ClearList();
                        break;
                    case 2:
                        Console.WriteLine("**TECLA 0 - PARA SAIR OU CANCELAR**\n");
                        Console.WriteLine(productList.ToString()); // Listar

                        Console.WriteLine("ID: {0}\n", productList.productList.Count + 1);
                        string idProdutoAAdicionar = Operator.AtribuirIDProduto(productList);

                        Console.WriteLine("Insira o Nome do Produto:");
                        string nomeDoProdutoAAdicionar = Console.ReadLine(); //nao pode ser nulo
                        while(nomeDoProdutoAAdicionar == "")
                        {
                            Console.WriteLine("Nome Incorrecto\nInsira o Nome do Produto:\n");
                            nomeDoProdutoAAdicionar = Console.ReadLine();
                        }
                        if (nomeDoProdutoAAdicionar == "0")
                        {
                            productList.ClearList();
                            break;
                        }

                        Console.WriteLine("Escolha o Stock do Produto:");
                        float stockProdutoAAdicionar;
                        while (float.TryParse(Console.ReadLine(), out stockProdutoAAdicionar) == false)
                        {
                            Console.WriteLine("Valor incorrecto, tente novamente:");
                        }
                        stockProdutoAAdicionar = Operator.VerificarValorNegativo(stockProdutoAAdicionar);
                        if (stockProdutoAAdicionar == 0)
                        {
                            productList.ClearList();
                            break;
                        }

                        Console.WriteLine("Escolha o Preço do Produto:");
                        float precoProdutoAAdicionar;
                        while (float.TryParse(Console.ReadLine(), out precoProdutoAAdicionar) == false)
                        {
                            Console.WriteLine("Valor incorrecto, tente novamente:");
                        }
                        precoProdutoAAdicionar = Operator.VerificarValorNegativo(precoProdutoAAdicionar);
                        if (precoProdutoAAdicionar == 0)
                        {
                            productList.ClearList();
                            break;
                        }

                        Console.WriteLine("Escolha a Tipo do Produto: Congelado = 0, Prateleira = 1, Enlatado = 2");
                        bool result = Enum.TryParse(Console.ReadLine(), out TypeOfProducts typeOfProducts) && Enum.IsDefined(typeof(TypeOfProducts), typeOfProducts); // Nao esta bem. Nao 
                        while (!result)
                        {  
                            Console.WriteLine("Valor incorrecto, tente novamente");
                            result = Enum.TryParse(Console.ReadLine(), out typeOfProducts) && Enum.IsDefined(typeof(TypeOfProducts), typeOfProducts);
                        }

                        Console.WriteLine("Escolha a Categoria: FrutasLegumes = 0, Carne = 1, Mercearia = 2");
                        bool result2 = Enum.TryParse(Console.ReadLine(), out Category categoria) && Enum.IsDefined(typeof(Category), categoria); 
                        while (!result2)
                        {
                            Console.WriteLine("Valor incorrecto, tente novamente");
                            result2 = Enum.TryParse(Console.ReadLine(), out categoria) && Enum.IsDefined(typeof(Category), categoria);
                        }

                        Product newProduct = new Product(idProdutoAAdicionar, nomeDoProdutoAAdicionar, stockProdutoAAdicionar, precoProdutoAAdicionar, typeOfProducts, categoria);

                        
                        Console.WriteLine(newProduct.ToString());

                        productList.AddProduct(newProduct);

                        Console.WriteLine(productList.ToString());  // Listar
                        ProductList.GravarParaFicheiro(productList);

                        productList.ClearList();

                        break;
                    case 3:
                        Console.WriteLine("**TECLA 0 - PARA SAIR OU CANCELAR**\n");
                        Console.WriteLine(productList.ToString());  // Listar
                        Console.WriteLine("escolha o id a remover:");
                        string produtoARemover = Console.ReadLine();
                        if (produtoARemover == "0")
                        {
                            productList.ClearList();
                            break;
                        }
                        productList.RemoveProduct(produtoARemover);
                        ProductList.GravarParaFicheiro(productList);
                        productList.ClearList();
                        break;
                    case 4:
                        Console.WriteLine("Vai remover o stock completo! Tem a certeza? \n(Opcao 1 - Limpar Stock| Outro numero para cancelar");
                        while (!int.TryParse(Console.ReadLine(), out limparStock))
                        {
                            Console.WriteLine("Opcao Errada");
                        }
                        if (limparStock == 1)
                        {
                            productList.ClearList();
                            ProductList.GravarParaFicheiro(productList);
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

            ProductList productList = new ProductList();

            do
            {
                productList= ProductList.LerFicheiro(); // lista produtos acima
                Console.WriteLine("************SUPERMERCADO BINHAS ONTE***************");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**                  Bem-vindo/a!                **");
                Console.WriteLine("**                                              **");
                Console.WriteLine("**\t" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm") + "\t\t**");
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("1- Ver Stock\n");
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
                        productList.ClearList();
                        break;
                    case 1:
                        Console.WriteLine(productList.ToString());
                        productList.ClearList();
                        break;
                    case 2:
                        Console.WriteLine(productList.ToString());
                        Console.WriteLine("**ADICIONAR STOCK**\n");
                        Console.WriteLine("**TECLA 0 - PARA SAIR OU CANCELAR**\n");
                        string idAddStock;
                        do
                        {
                            Console.WriteLine("Introduza o id do produto");
                            idAddStock = Console.ReadLine();
                            if (idAddStock == "0")
                            {
                                productList.ClearList();
                                break;
                            }
                            if (productList.FindProduct(idAddStock) == null)
                            {
                                Console.WriteLine("Id inválido!");
                            }
                            
                        } while (productList.FindProduct(idAddStock) == null);
                        if (idAddStock == "0") break;
                        Console.WriteLine("Introduza a quantidade:\n"); // 
                        float quantityAddStock;
                        while (float.TryParse(Console.ReadLine(), out quantityAddStock) == false)
                        {
                            Console.WriteLine("Quantidade incorrecta, tente novamente:");
                        }
                        quantityAddStock = Operator.VerificarValorNegativo(quantityAddStock);
                        quantityAddStock = Operator.Virgulas(quantityAddStock);


                        if (quantityAddStock == 0)
                        {
                            productList.ClearList();
                            break;
                        }
                        bool resultAddStock = productList.AddStock(idAddStock, quantityAddStock);
                        ProductList.GravarParaFicheiro(productList);
                        if (resultAddStock) // true
                        {
                            Console.WriteLine("Quantidade adicionada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Falhou");
                        }

                        Console.WriteLine(productList.ToString());
                        productList.ClearList();
                        break;
                    case 3:
                        Console.WriteLine(productList.ToString());
                        Console.WriteLine("**REMOVER STOCK**\n");
                        Console.WriteLine("**TECLA 0 - PARA SAIR OU CANCELAR**\n");
                        string idRemoveStock;
                        do
                        {
                            Console.WriteLine("Introduza o id do produto");
                            idRemoveStock = Console.ReadLine();
                            if (idRemoveStock == "0")
                            {
                                productList.ClearList();
                                break;
                            }
                            if (productList.FindProduct(idRemoveStock) == null)
                            {
                                Console.WriteLine("Id inválido!");
                            }

                        } while (productList.FindProduct(idRemoveStock) == null);
                        if (idRemoveStock == "0") break;
                        Console.WriteLine("Introduza a quantidade:\n");
                        float quantityRemoveStock;
                        while (float.TryParse(Console.ReadLine(), out quantityRemoveStock) == false)
                        {
                            Console.WriteLine("Quantidade incorrecta, tente novamente:");
                        }
                        
                        if (quantityRemoveStock == 0) {
                                productList.ClearList();
                                break;
                            }
                        quantityRemoveStock = Operator.VerificarValorNegativo(quantityRemoveStock);
                        bool resultRemoveStock = productList.RemoveStock(idRemoveStock, quantityRemoveStock);

                        ProductList.GravarParaFicheiro(productList);
                        if (resultRemoveStock) // true
                        {
                            Console.WriteLine("Quantidade removida com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Falhou");
                        }
                        Console.WriteLine(productList.ToString());
                        productList.ClearList();
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
