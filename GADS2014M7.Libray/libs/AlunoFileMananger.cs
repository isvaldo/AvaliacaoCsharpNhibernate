using System;
using System.Collections.Generic;
using System.IO;

namespace GADS2014M7.Libray.libs
{
    public class AlunoFileMananger
    {
        public static void saveLog(List<Aluno> alunos)
        {
            string nameToSave = setType(Constant.LOG_TYPE);
            using (StreamWriter  file = new StreamWriter(BuildPathByName(nameToSave))) 
            {
                alunos.ForEach(a => Console.WriteLine(a.ToString()));
            }
        }
        public static string setType(string format)
        {
            return Constant.NAME_FOR_SAVE + format;
        }

        public static void saveXML()
        {
            string nameToSaveXml = setType(Constant.XML_TYPE);
            File.Copy(Constant.FULL_PATH_XML_FILE, BuildPathByName(nameToSaveXml));
        }

        public static String BuildPathByName(string fileName)
        {
            return Path.Combine(Constant.PATH_APP, Constant.SOURCE_STATIC, fileName);
        }
    }
}
