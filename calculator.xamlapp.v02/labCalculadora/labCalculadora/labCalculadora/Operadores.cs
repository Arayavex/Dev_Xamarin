using System;

namespace labCalculadora
{
    internal class Operadores
    {
        public static double Calcular(double value1, double value2, string op)
        {
            double result = 0;

            //Condicional Switch para definir cual operador se va utilizar
            switch (op)
            {
                case "+"://suma
                    result = value1 + value2;
                    break;
                case "-"://resta
                    result = value1 - value2;
                    break;
                case "×"://multiplicacion
                    result = value1 * value2;
                    break;
                case "÷"://division
                    result = value1 / value2;
                    break;
            }
            return result; //retorna un resultado de la operacion
        }
    }
}