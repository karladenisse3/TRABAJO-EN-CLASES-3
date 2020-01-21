using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoEnClases
{
    class Program
    {


        public static  bool primos(int NumerosAleatorios)
        {
            int divisor = 2;
            int resto = 0;
            while (divisor < NumerosAleatorios)
            {
                resto = NumerosAleatorios % divisor;
                if (resto == 0)
                {
                    return false;
                }
                divisor = divisor + 1;

            }
            return true;
        }

        public static bool noPrimos(int NumerosAleatorios)
        {
            int divisor = 2;
            int resto = 0;
            while (divisor < NumerosAleatorios)
            {
                resto = NumerosAleatorios % divisor;
                if (resto == 0)
                {
                    return true;
                }
                divisor = divisor + 1;

            }
            return false;
        }

        public static bool pares (int NumerosAleatorios)
        {
            if (NumerosAleatorios % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public static bool impares(int NumerosAleatorios)
        {
            if (NumerosAleatorios % 2 == 1)
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            List<int> listanumerosAleatorios
                 = new List<int> {12,1,125,13,58,45,69,87,14,2,5,87,100,
                     2,56,47,31,25,36,54,74,84,95,41,25,36,23,125,52,14,123,
                     254,12,65,68,95,84,82,14,24,100,9,18,12,47,58,65,74,85,96
             };

            //MOSTRAR POR CONSOLA TODOS LOS NÚMEROS PRIMOS.
            var numerosPrimos =
                (from numerosAleatorios in listanumerosAleatorios
                 where primos(numerosAleatorios)
                 select numerosAleatorios
                 );

            Console.WriteLine("Numeros Primos:");

            foreach (var item in numerosPrimos)
            {
                Console.WriteLine(" " + item);
            }

            //MOSTRAR POR CONSOLA LA SUMA DE TODOS LOS ELEMENTOS.
            IEnumerable<int> resultadoSum =
                from numero in listanumerosAleatorios
                select numero;

            Console.WriteLine("\nLa suma de todos los elementos es: \n" + " " + resultadoSum.Sum());

            //GENERAR UNA NUEVA LISTA CON EL CUADRADO DE LOS NÚMEROS.
            var numerosCuadrados =
                from numerosAleatorios in listanumerosAleatorios
                let average = listanumerosAleatorios.Average()
                let Cuadrado = Math.Pow(numerosAleatorios, 2)
                where Cuadrado > average
                select numerosAleatorios;

            Console.WriteLine("\nNumeros cuadrados: ");

            foreach (var item in numerosCuadrados)
            {
                Console.WriteLine(" El cuadrado del numero {0} es {1}.", item, Math.Pow(item, 2));
            }

            //GENERAR UNA NUEVA LISTA CON LOS NÚMEROS QUE NO SON PRIMOS.
            var numerosNoPrimos =
                (from numerosAleatorios in listanumerosAleatorios
                 where noPrimos(numerosAleatorios)
                 select numerosAleatorios
                 );

            Console.WriteLine("\nNumeros que no son primos:");

            foreach (var item in numerosNoPrimos)
            {
                Console.WriteLine(" " + item);
            }

            //OBTENER EL PROMEDIO DE TODOS LOS NÚMEROS MAYORES A 50.
            var promedioNumeros50 =
                from numerosAleatorios in listanumerosAleatorios
                where numerosAleatorios > 50
                select numerosAleatorios;
            Console.WriteLine("\nPromedio de los numeros mayores a 50 : ");
            Console.WriteLine(" {0} ", promedioNumeros50.Average());

            //CONTAR EN LA LISTA LA CANTIDAD DE NÚMEROS PARES E IMPARES. ESTE PROBLEMA DEBE
            //RESOLVERSE EN UNA SENTENCIA O EN UNA SOLA CONSULTA.

            IEnumerable<int> paresEimpares =
                (from numero in listanumerosAleatorios
                 select numero);

            Console.WriteLine("\nCantidad de numeros Pares e Impares: ");
            Console.WriteLine("\n Pares: " + paresEimpares.Count(pares));
            Console.WriteLine(" Impares: " + paresEimpares.Count(impares));


            //MOSTRAR POR CONSOLA CADA ELEMENTO Y LA CANTIDAD DE VECES QUE SE REPITE EN LA LISTA.

            var NumeroRepetidos = from numerosAleatorios in listanumerosAleatorios
                                  select numerosAleatorios;
            Console.WriteLine("\nCantidad de veces que se repite en la lista: ");
            foreach (var item in NumeroRepetidos.GroupBy(x => x))
            {
                Console.WriteLine(" El número " + $"{item.Key} se repite {item.Count()} veces");
            }


            //MOSTRAR EN CONSOLA LOS ELEMENTOS DE FORMA DESCENDENTE.

            var NumeroDescendente = from numerosAleatorios in listanumerosAleatorios
                                    orderby numerosAleatorios descending
                                    select numerosAleatorios;
            Console.WriteLine("\nElementos de forma descendente: ");
            foreach (var item in NumeroDescendente)
            {

                Console.WriteLine(" " + item);
            }


            //MOSTRAR EN CONSOLA LOS NÚMEROS ÚNICOS (NO SE REPITEN).


            var NumerosUnicos = listanumerosAleatorios
                .GroupBy(x => x)
                .Where(y => y.
                Count() == 1)
                .Select(n => new
            {
                val = n.Key
            }).ToList();
            Console.WriteLine("\nLos numeros unicos son: " );
            foreach (var item in NumerosUnicos)
            {
                Console.WriteLine(item);
            }

            //SUMAR TODOS LOS NÚMEROS ÚNICOS DE LA LISTA.         
            var SumaNumerosUnicos = (
                from xy in NumerosUnicos
                select xy.val).Sum();
                
            Console.WriteLine("\nLa suma de los numeros unicos es: \n" + " " + SumaNumerosUnicos);


            Console.ReadKey();
        }
    }
}
