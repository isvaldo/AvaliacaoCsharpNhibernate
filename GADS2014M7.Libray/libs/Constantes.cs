using System;
using System.IO;
namespace GADS2014M7.Libray.libs
{
    public class Constantes
    {   
        public static string PATH_APP = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        public static string ARQUIVO_XML = "ExportaAlunos-Isvaldo.xml";
        public static string NOME_PASTA = "static";
        public static string FULL_PATH_XML_FILE = Path.Combine(PATH_APP, NOME_PASTA, ARQUIVO_XML);
        public static string DATA_FORMAT = "yyyyMMdd-HHmmsstt";
        public static string SAVE_NAME = "ExportaAlunos-IsvaldoFernandes" +
            "-" + DateTime.Now.ToString(DATA_FORMAT);
        public static string LOG_TYPE = "-Log.txt";
        public static string XML_TYPE = ".xml";
    }
}
