using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace TP10
{
    class Program
    {

        static void Main(string[] args)
        {
            int index = 0;
            var rnd = new Random();

            //Leemos domicilio y tipo de propiedad
            string nombreDeArchivo = "datos.csv";
            string rutaDeArchivo = @"C:\Taller1\tpn10-FNMariani\TP10\TP10\bin\Debug\";

            List<string[]> LecturaDelArchivo = HelperCSV.LeerCsv(rutaDeArchivo, nombreDeArchivo, ',');

            List<Propiedad> propiedades = new List<Propiedad>();

            foreach (string[] filas in LecturaDelArchivo)
            {
                Propiedad propiedad = new Propiedad();

                propiedad.Id = index;
                propiedad.TpPropiedad = (Propiedad.TipoDePropiedad)Enum.Parse(typeof(Propiedad.TipoDePropiedad), filas[1]);
                propiedad.TpOperacion = (Propiedad.TipoDeOperacion)rnd.Next(Enum.GetNames(typeof(Propiedad.TipoDeOperacion)).Length);
                propiedad.Tamanio = rnd.Next(40, 120);
                propiedad.CantBanios = rnd.Next(1, 2);
                propiedad.CantHabitaciones = rnd.Next(1, 5);
                propiedad.Domicilio = filas[0];
                propiedad.Precio = rnd.Next(10000, 1000000);
                propiedad.Estado = rnd.Next(2) == 0;

                propiedades.Add(propiedad);

                index++;
            }

            foreach (Propiedad prop in propiedades)
            {
                prop.Mostrar();
            }

            //Guardamos el archivo con los datos completos
            using (var writer = new StreamWriter(rutaDeArchivo + "inmobiliaria.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(propiedades);
            }
        }
    }
}
