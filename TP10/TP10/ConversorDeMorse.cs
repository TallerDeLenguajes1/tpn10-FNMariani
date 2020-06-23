using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ConversorDeMorse
    {
        static Dictionary<char, String> morseDict = new Dictionary<char, String>()
        {
            {'A' , ".-"},
            {'B' , "-..."},
            {'C' , "-.-."},
            {'D' , "-.."},
            {'E' , "."},
            {'F' , "..-."},
            {'G' , "--."},
            {'H' , "...."},
            {'I' , ".."},
            {'J' , ".---"},
            {'K' , "-.-"},
            {'L' , ".-.."},
            {'M' , "--"},
            {'N' , "-."},
            {'O' , "---"},
            {'P' , ".--."},
            {'Q' , "--.-"},
            {'R' , ".-."},
            {'S' , "..."},
            {'T' , "-"},
            {'U' , "..-"},
            {'V' , "...-"},
            {'W' , ".--"},
            {'X' , "-..-"},
            {'Y' , "-.--"},
            {'Z' , "--.."},
            {'0' , "-----"},
            {'1' , ".----"},
            {'2' , "..---"},
            {'3' , "...--"},
            {'4' , "....-"},
            {'5' , "....."},
            {'6' , "-...."},
            {'7' , "--..."},
            {'8' , "---.."},
            {'9' , "----."},
        };

        public static string MorseATexto​(string morse)
        {
            string texto = "";
            string aux = "";

            for (int i = 0; i < morse.Length; i++)
            {
                if(morse [i] == '/')
                {
                    texto += ' ';
                }
                else
                {
                    if (morse[i] != ' ')
                    {
                        aux += morse[i];
                    }
                    else
                    {
                        foreach (KeyValuePair<char, string> item in morseDict)
                        {
                            if (aux == item.Value)
                            {
                                texto += item.Key;
                                aux = "";
                            }
                        }
                    }
                }
            }

            return texto;
        }

        public static string TextoAMorse​(string texto)
        {
            string morse = "";

            foreach(char caracter in texto)
            {
                if(caracter == ' ')
                {
                    morse += "/ ";
                }
                else
                {
                    morse += morseDict[caracter] + " ";
                }
            }

            return morse;
        }

        public static Byte[] MorseAAudio(string morse)
        {
            List<Byte[]> files = new List<Byte[]>();

            var punto = File.ReadAllBytes(Path.Combine(@"C:\Taller1\tpn10-FNMariani\TP10\TP10\", "punto.mp3"));
            files.Add(punto);
            var raya = File.ReadAllBytes(Path.Combine(@"C:\Taller1\tpn10-FNMariani\TP10\TP10\", "raya.mp3"));
            files.Add(raya);
            var silencio = File.ReadAllBytes(Path.Combine(@"C:\Taller1\tpn10-FNMariani\TP10\TP10\", "silencio.mp3"));
            files.Add(silencio);

            List<Byte[]> audios = new List<Byte[]>();

            for (int i = 0; i < morse.Length; i++)
            {
                switch (morse[i])
                {
                    case '/':
                        //Agregar 2 silencio
                        audios.Add(silencio);
                        audios.Add(silencio);
                        break;
                    case ' ':
                        //Agregar silencio
                        audios.Add(silencio);
                        break;
                    case '.':
                        //Agregar punto
                        audios.Add(punto);
                        break;
                    case '-':
                        //Agregar raya
                        audios.Add(raya);
                        break;
                }
            }

            byte[] array = audios.SelectMany(a => a).ToArray();

            return array;
        }
    }
}
