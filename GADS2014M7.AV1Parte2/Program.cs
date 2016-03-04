using System;
using GADS2014M7.Libray;
using GADS2014M7.Libray.libs;
using System.Xml.Linq;
using System.Collections.Generic;
namespace GADS2014M7.AV1Parte2
{
    class Program
    {
        static void Main(string[] args)
        {
           // NHibernateHelper.GeraSchema(); // cria banco de dados
            string fileName = Constant.FULL_PATH_XML_FILE;
            XDocument xmlDocument = XDocument.Load(fileName); // recebe o modelo
            ParseAluno<XDocument> parse = new ParseAluno<XDocument>(xmlDocument); // chama Alguem competente para fazer parse de aluno
            List<Aluno> alunos = parse.getFromXml(); // recebe a lista prontinha do parse
            alunos.ForEach(a => Console.WriteLine(a.ToString())); // printa tudo na tela
            AlunoFileMananger.saveXML(); // muda o nome do arquivo xml
            AlunoFileMananger.saveLog(alunos); // salva um log tb
            Console.Read(); // lock na tela
        }
    }
}
