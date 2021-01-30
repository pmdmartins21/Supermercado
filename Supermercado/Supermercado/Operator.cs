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
    }
}
