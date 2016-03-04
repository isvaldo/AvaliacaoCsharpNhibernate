using System;
using System.Collections.Generic;
using System.IO;

namespace GADS2014M7.Libray.libs
{
    public class AlunoFileMananger
    {
        public static void saveLog(List<Aluno> alunos)
        {
            string nomeSaveLog = setType(Constantes.LOG_TYPE);
            using (StreamWriter  file = new StreamWriter(getCaminhoArquivo(nomeSaveLog))) 
            {
                alunos.ForEach(a => Console.WriteLine(a.ToString()));
            }
        }
        public static string setType(string formato)
        {
            return Constantes.SAVE_NAME + formato;
        }

        public static void saveXML()
        {
            string nomeSaveXml = setType(Constantes.XML_TYPE);
            File.Copy(Constantes.FULL_PATH_XML_FILE, getCaminhoArquivo(nomeSaveXml));
        }

        public static String getCaminhoArquivo(string nomeArquivo)
        {
            return Path.Combine(Constantes.PATH_APP, Constantes.NOME_PASTA, nomeArquivo);
        }
    }
}
