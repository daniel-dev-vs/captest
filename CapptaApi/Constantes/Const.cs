using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CapptaApi.Constantes
{
    public static class Const
    {
        
        public static string DadosCsv = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"AppData\dados.csv");
        public static string Mastercard = "Mastercard";
        public static string Visa = "Visa";
        public static string Stone = "Stone";

    }
}
