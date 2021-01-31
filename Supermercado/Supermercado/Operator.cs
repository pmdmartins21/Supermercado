using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    [Serializable]
    class Operator
    {
        public static float VerificarValorNegativo(float valorAVerificar)
        {
            if (valorAVerificar < 0)
            {
                Console.WriteLine("Valor introduzido negativo, transformado em {0}", Math.Abs(valorAVerificar));
                return Math.Abs(valorAVerificar);
            }
            return valorAVerificar;
        }
        public static float Virgulas(float valorAVerificar)
        {
            string input;
            float valorComPonto;
            input = valorAVerificar.ToString();
            input.Replace(',', '.');
            valorComPonto = float.Parse(input);
            return valorComPonto;
        }

        public static void UpdatePosicaoListaEmpregados(EmployeeList el) // Desnecessario
        {
            for (int i = 0; i < el.employeeList.Count; i++)
            {
                if(int.Parse(el.employeeList[i].Id) != (i+1))
                {
                    el.employeeList[i].Id = (i+1).ToString();
                }
            }
        }

        public static string AtribuirIDEmpregado(EmployeeList el)
        {
            string id;
            Employee lastEmployee = el.employeeList[el.employeeList.Count-1];
            id = (int.Parse(lastEmployee.Id) + 1).ToString();
            return id;
        }

        public static string AtribuirIDProduto(ProductList pl)
        {
            string id;
            if (pl.productList.Count > 0)
            {
                Product lastProduct = pl.productList[pl.productList.Count - 1];
                id = (int.Parse(lastProduct.Id) + 1).ToString();
               
            }
            else
            {
                id = "1";
            }
            return id;
        }

        public static int AtribuirIDFatura(InvoiceList il)
        {
            int id;
            if (il.invoiceListing.Count > 0)
            {
                Invoice lastInvoice = il.invoiceListing[il.invoiceListing.Count - 1];
                id = lastInvoice.InvoiceNumber + 1;
            }
            else
            {
                id = 1;
            }
            
            return id;
        }
    }
}
