using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    class Operator
    {
        [Serializable]
        public static float VerificarValorNegativo(float valorAVerificar)
        {
            if (valorAVerificar < 0)
            {
                Console.WriteLine("Valor introduzido negativo, transformado em {0}", Math.Abs(valorAVerificar));
                return Math.Abs(valorAVerificar);
            }
            return valorAVerificar;
        }
    }
}
