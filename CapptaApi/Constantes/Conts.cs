using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CapptaApi.Constantes
{
    public static class Conts
    {
        
        public static string DadosCsv = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"AppData\dados.csv");
        
    }
}
