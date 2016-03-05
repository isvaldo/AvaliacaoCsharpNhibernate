using System;
using GADS2014M7.Libray;
using GADS2014M7.Libray.libs;
using System.Xml.Linq;
using System.Collections.Generic;
using NHibernate;
namespace GADS2014M7.AV1Parte2
{
    class Program
    {
        static void Main(string[] args)
        {
            ISession AlunoRepository = NHibernateHelper.OpenSession();
            string fileName = Constant.FULL_PATH_XML_FILE;
            XDocument xmlDocument = XDocument.Load(fileName); 
            ParseAluno<XDocument> parse = new ParseAluno<XDocument>(xmlDocument); 
            List<Aluno> alunos = parse.getFromXml(); 
            alunos.ForEach(a => Console.WriteLine(a.ToString()));
            alunos.ForEach(a => AlunoRepository.Save(a)); 
            AlunoFileMananger.saveXML(); 
            AlunoFileMananger.saveLog(alunos); 
            Console.Read(); 
        }
    }
}
