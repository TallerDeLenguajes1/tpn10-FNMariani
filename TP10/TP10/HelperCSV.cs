using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace TP10
{
    static public class HelperCSV
    {
        public static List<string[]> LeerCsv(string rutaDeArchivo, string nombreDeArchivo, char caracter)
        {
            FileStream MiArchivo = new FileStream(rutaDeArchivo + nombreDeArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);

            string Linea;
            List<string[]> LecturaDelArchivo = new List<string[]>();

            while((Linea = StrReader.ReadLine()) != null)
            {
                string[] Fila = Linea.Split(caracter);
                LecturaDelArchivo.Add(Fila);
            }

            MiArchivo.Close();
            return LecturaDelArchivo;
        }

        /*public static void GuardarCsv(string rutaDeArchivo, string nombreDeArchivo, List<Propiedad> datos)
        {
            var datos2 = datos;
            using (var writer = new StreamWriter(rutaDeArchivo + nombreDeArchivo))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(datos2);
            }
        }*/
    }
}
