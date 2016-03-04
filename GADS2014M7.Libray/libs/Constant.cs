using System;
using System.IO;
namespace GADS2014M7.Libray.libs
{
    public class Constant
    {   
        public static string PATH_APP = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        public static string FILE_XML = "ExportaAlunos-Isvaldo" + XML_TYPE;
        public static string SOURCE_STATIC = "static";
        public static string FULL_PATH_XML_FILE = Path.Combine(PATH_APP, SOURCE_STATIC, FILE_XML);
        public static string DATA_FORMAT = "yyyyMMdd-HHmmsstt";
        public static string NAME_FOR_SAVE = "ExportaAlunos-IsvaldoFernandes" +
            "-" + DateTime.Now.ToString(DATA_FORMAT);
        public static string LOG_TYPE = "-Log.txt";
        public static string XML_TYPE = ".xml";
    }
}
