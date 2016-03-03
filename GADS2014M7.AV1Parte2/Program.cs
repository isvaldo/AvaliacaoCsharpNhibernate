using System;
using GADS2014M7.Libray;
using GADS2014M7.Libray.libs;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
namespace GADS2014M7.AV1Parte2
{
    class Program
    {
        public static string fileName = @"C:\Users\isvaldoPC\documents\visual studio 2013\Projects\GADS2014M7.AV1Parte2.Isvaldo\GADS2014M7.AV1Parte2\static\ExportaAlunos-Isvaldo.xml";
       
        static void Main(string[] args)
        {
            NHibernateHelper.GeraSchema();
            string path =  Path.GetFullPath(fileName);
            XDocument xmlDocument = XDocument.Load(path);
            ParseAluno<XDocument> parse = new ParseAluno<XDocument>(xmlDocument);

            List<Aluno> alunos = parse.getFromXml();

            foreach (Aluno aluno in  alunos){
                Console.Write(aluno.nome+"\n");
            }

            Console.Read();

        }
    }
}
