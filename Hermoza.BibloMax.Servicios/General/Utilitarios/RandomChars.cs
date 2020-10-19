using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hermoza.BibloMax.Servicios.General.Utilitarios
{
    public class RandomChars
    {

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomFecha(int lenght, string fecha)
        {
            return new string(Enumerable.Repeat(fecha, lenght)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
