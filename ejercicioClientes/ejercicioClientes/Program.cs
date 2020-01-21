using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ejercicioClientes.Clases;

namespace ejercicioClientes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>()
            {

                new Cliente() { Identificacion = 1305684932, Nombre = "José Cedeño" },
                new Cliente() { Identificacion = 1306304551, Nombre= "Felipe Crespo"},
                new Cliente() { Identificacion = 1315267836, Nombre = "Mauricio Chauski" },
                new Cliente() { Identificacion = 1358493928, Nombre = "Raúl Binueza" },
                new Cliente() { Identificacion = 1325920493, Nombre = "Estefania Velez" },
                new Cliente() { Identificacion = 1395038630, Nombre = "Monica Venecia" },
                new Cliente() { Identificacion = 1358493978, Nombre = "Monica Cruz" },
                new Cliente() { Identificacion = 1324638593, Nombre = "Matilde Napa" },
                new Cliente() { Identificacion = 1302839293, Nombre= "Adriana Crespo"},
                new Cliente() { Identificacion = 1324646749, Nombre = "Eliana Chavez" }
            };

            List<Factura> facturas = new List<Factura>()
            {
                new Factura () {Identificacion = 1306304551,  fecha= new DateTime (2019,08,12) , Observacion= "Silla", Total= 13.50 }, //F.C
                new Factura () {Identificacion = 1305684932, fecha= new DateTime (2017,09,10), Observacion= "Sillon", Total= 100.99 },//J.C

                new Factura () {Identificacion = 1315267836, fecha= new DateTime (2000,05,09), Observacion= "Mesa", Total= 140.50 },//M.C

                new Factura () {Identificacion = 1358493928, fecha= new DateTime (2019,10,05), Observacion= "Juego de Muebles", Total= 330.50 },// R.B

                new Factura () {Identificacion = 1325920493, fecha= new DateTime (2020,11,13), Observacion= "Plato ", Total= 30.50 },//E.V
                new Factura () {Identificacion = 1395038630, fecha= new DateTime (2030,10,10), Observacion= "Plato ", Total= 15.60 },// M.V
                new Factura () {Identificacion = 1358493928, fecha= new DateTime (2019,10,12), Observacion= "Base para Televisor Smart ", Total= 60.90 },//R.B
                new Factura () {Identificacion = 1324638593, fecha= new DateTime (2019,10,08), Observacion= "Cucharasx10", Total= 15.50 },// M.N
                new Factura () {Identificacion = 1306304551, fecha= new DateTime (2019,10,02), Observacion= "Platos ", Total= 10.30 },//F.C
                 new Factura () {Identificacion = 1306304551, fecha= new DateTime (2019,11,06), Observacion= "Platos ", Total= 10.30 },//F.C
                new Factura () {Identificacion = 1324646749, fecha= new DateTime (2019,10,12), Observacion= "Mesa de centro", Total= 90.99 },//E.C

            };
            // CLientes con mayor monto de ventas
            var consultaporMonto = (from cliente in clientes
                                    join factura in facturas
                                    on cliente.Identificacion equals factura.Identificacion
                                    orderby factura.Total descending
                                    select new { Cliente = cliente, Factura = factura }
                                     ).Take(3);
            
                           
             
            Console.WriteLine("------------Consultas----------- ");
            Console.WriteLine("Clientes con Monto mayor de ventas ");
            foreach (var item in consultaporMonto)
            {
                var Clientes = item.Cliente;
                var Facturas = item.Factura;

                Console.WriteLine("Nombre:{0}   Monto:{1} ", item.Cliente.Nombre, item.Factura.Total);
            }

            // CLientes con menor monto de ventas
            var consultaporMonto2 = (from cliente2 in clientes
                                     join factura2 in facturas
                                     on cliente2.Identificacion equals factura2.Identificacion

                                     orderby factura2.Total ascending
                                     
                                    select new { Cliente = cliente2, Factura = factura2 }
                                    ).Take(3);

            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("Clientes con Monto menor de ventas ");
            foreach (var item in consultaporMonto2)
            {
                var Clientes = item.Cliente;
                var Facturas = item.Factura;

                Console.WriteLine("Nombre:{0}   Monto:{1} ", item.Cliente.Nombre, item.Factura.Total);
            }

            
            //el cliente con mas ventas realizadas
            Console.WriteLine("--------------------------");
            Console.WriteLine("Cliente con mas ventas");
            var ventasreal = (from factura in facturas
                              join cliente in clientes
                               on factura.Identificacion equals cliente.Identificacion

                              group cliente by cliente.Nombre into nom

                              orderby nom.Count() descending
                              select new {   client = nom.Key , Cliente = nom.Count() }).Take(1);

            foreach (var item in ventasreal)
            {
            
                     
                Console.WriteLine("Nombre:{0}   Cantidad de Ventas: {1} ", item.client , item.Cliente);
            }

            //cada cliente con su venta realizada

            Console.WriteLine("--------------------------");
            Console.WriteLine("Cliente y sus ventas");
            var clienyven = (from cliente2 in clientes
                             join factura2 in facturas
                             on cliente2.Identificacion equals factura2.Identificacion

                             orderby factura2.Total ascending

                             select new { Cliente = cliente2, Factura = factura2 }
                                    );

            foreach (var item in clienyven)
            {
                var Clientes = item.Cliente;
                var Facturas = item.Factura;

                Console.WriteLine("El cliente {0}  ha tenido {1} ventas ", item.Cliente.Nombre, item.Factura.Total );
            }

           //ventas realizadas en el año 2019 
            Console.WriteLine("--------------------------");
            Console.WriteLine("Ventas en 2019");
            var conaño = (from factura in facturas
                          join cliente in clientes
                             on factura.Identificacion equals cliente.Identificacion
                             
                          where factura.fecha.Year == 2019

                          select new { Cliente = cliente.Nombre, Factura = factura }
                          );

            foreach (var item in conaño)
            {
                var Clientes = item.Cliente;
                var Facturas = item.Factura;

                Console.WriteLine("Nombre:{0}  año {1} ",item.Cliente , item.Factura.fecha);
               
            }


            //Venta Antigua
            Console.WriteLine("--------------------------");
            Console.WriteLine("Ventas antigua");
            var conanti = (from factura in facturas
                          join cliente in clientes
                             on factura.Identificacion equals cliente.Identificacion
                             orderby factura.fecha ascending
                          

                          select new { Cliente = cliente.Nombre, Factura = factura }
                          ).Take(1);

            foreach (var item in conanti)
            {
                var Clientes = item.Cliente;
                var Facturas = item.Factura;

                Console.WriteLine("Nombre:{0}  año {1} ", item.Cliente, item.Factura.fecha);

            }

            //Venta con Plato 
            Console.WriteLine("--------------------------");
            Console.WriteLine("Ventas con Observacion Plato");
             var  plato = (from factura in facturas
                           join cliente in clientes
                             on factura.Identificacion equals cliente.Identificacion

                           where factura.Observacion.ToUpper() == "Plato ".ToUpper()
                                          select new { Cliente= cliente.Nombre , Factura = factura.Observacion }).ToList();

            foreach (var item in plato)
            {
                Console.WriteLine("Nombre:{0}  Observacion: {1} ", item.Cliente, item.Factura);

            }

            Console.ReadKey();

        }
    }
}
