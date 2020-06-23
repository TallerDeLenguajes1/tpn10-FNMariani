using System;
using System.Collections.Generic;
using System.Text;

namespace TP10
{
    class Propiedad
    {
        public enum TipoDeOperacion
        {
            venta,
            alquiler
        }

        public enum TipoDePropiedad
        {
            departamento,
            casa,
            duplex,
            penthouse,
            terreno
        }

        float IVA = 0.21f;

        int id;                         // representa el número de propiedad ingresada
        TipoDePropiedad tpPropiedad;
        TipoDeOperacion tpOperacion;
        float tamanio;                  // punto flotante
        int cantBanios;
        int cantHabitaciones;
        string domicilio;               // string
        int precio;                     // Valor Entero
        bool estado;                    // bool activo / inactivo

        public int Id { get => id; set => id = value; }
        public TipoDePropiedad TpPropiedad { get => tpPropiedad; set => tpPropiedad = value; }
        public TipoDeOperacion TpOperacion { get => tpOperacion; set => tpOperacion = value; }
        public float Tamanio { get => tamanio; set => tamanio = value; }
        public int CantBanios { get => cantBanios; set => cantBanios = value; }
        public int CantHabitaciones { get => cantHabitaciones; set => cantHabitaciones = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public int Precio { get => precio; set => precio = value; }
        public bool Estado { get => estado; set => estado = value; }

        public float ValorDelInmueble()              // sólo devuelve un valor
        {
            float valor = 0;

            if(TpOperacion == TipoDeOperacion.venta)
            {
                Console.WriteLine("Esta para la venta");
                valor = precio + (precio * IVA) + (precio * 0.10f) + 10000; //precio + iva + 10% + costo de transferencia
            }
            else
            {
                Console.WriteLine("Esta para alquiler");
                valor = (precio * 1.02f) + (precio * 0.5f); // precio + 2% + 0.5% de costos
            }

            return valor;
        }

        public void Mostrar()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Tipo de Propiedad: " + tpPropiedad);
            Console.WriteLine("Tipo de Operacion: " + tpOperacion);
            Console.WriteLine("Tamanio: " + tamanio + " m2");
            Console.WriteLine("Cantidad de Banios: " + cantBanios);
            Console.WriteLine("Cantidad de Habitaciones: " + cantHabitaciones);
            Console.WriteLine("Domicilio: " + domicilio);
            Console.WriteLine("Precio: $" + precio);

            if (estado) {Console.WriteLine("Estado: Disponible");}
            else {Console.WriteLine("Estado: NO Disponible"); }

            Console.WriteLine("\n");
        }
        
    }
}
