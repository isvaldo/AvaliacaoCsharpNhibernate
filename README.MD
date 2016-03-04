# Trabalho de 'C#''

## classes principais 

### ParseAluno.cs
``` C#
  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GADS2014M7.Libray.libs
{
    public class  ParseAluno<T>
    {
        private readonly T AlunoSource;
        public ParseAluno(T source)
        {
            this.AlunoSource = source;
        }
        public List<Aluno> getFromXml()
        {
            if (typeof(T) == typeof(XDocument))
            {
                XDocument source = (XDocument)(object)this.AlunoSource;
                List<Aluno> alunos = new List<Aluno>();


                source.Descendants("Aluno").ToList<XElement>().ForEach(
                    aluno => {
                        Aluno alunoNew = new Aluno();
                        alunoNew.nome = aluno.Element("Nome").Value;
                        alunoNew.matricula = Convert.ToInt32(aluno.Element("Matricula").Value);
                        alunoNew.statusAluno = aluno.Element("StatusAluno").Value.Equals("0") ? false : true;
                        alunoNew.codigoCurso = aluno.Element("CodigoCurso").Value;
                        alunoNew.nomeCurso = aluno.Element("NomeCurso").Value;
                        alunos.Add(alunoNew);
                    });
                return alunos;
            }
            else
            {
                throw new InvalidOperationException("Error on parsing XML File");
            }
        }

        public void getFromJson()
        {
            throw new NotImplementedException("Error, function not suported yet, ask paulo mal if i can implement it");
        }
    }
}

	
``` 

### AlunoFileMananger.cs

``` C#
using System;
using System.Collections.Generic;
using System.IO;

namespace GADS2014M7.Libray.libs
{
    public class AlunoFileMananger
    {
        public static void saveLog(List<Aluno> alunos)
        {
            string nameToSave = setType(Constantes.LOG_TYPE);
            using (StreamWriter  file = new StreamWriter(BuildPathByName(nameToSave))) 
            {
                alunos.ForEach(a => Console.WriteLine(a.ToString()));
            }
        }
        public static string setType(string formato)
        {
            return Constantes.NAME_FOR_SAVE + formato;
        }

        public static void saveXML()
        {
            string nameToSaveXml = setType(Constantes.XML_TYPE);
            File.Copy(Constantes.FULL_PATH_XML_FILE, BuildPathByName(nameToSaveXml));
        }

        public static String BuildPathByName(string fileName)
        {
            return Path.Combine(Constantes.PATH_APP, Constantes.SOURCE_STATIC, fileName);
        }
    }
}

```

### Program.cs

``` C#
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
            string fileName = Constantes.FULL_PATH_XML_FILE;
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

 ```
 
### Aluno.cs

``` C#

using System;
using System.ComponentModel;
using System.Text;

namespace GADS2014M7.Libray
{
    public class Aluno
    {
        public int matricula {get;set;}
        public string  nome {get;set;}
        public string sobrenome {get;set;}
        public string codigoCurso {get;set;}
        public string nomeCurso {get;set;}
        public Boolean statusAluno { get; set; }

        public override string ToString()
        {
            StringBuilder sd = new StringBuilder();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(this);
                sd.Append(name + " = " + value+"\n");
            }
            return sd.ToString();  
        }

    }      
}

```

### Constantes.cs

``` C#
using System;
using System.IO;
namespace GADS2014M7.Libray.libs
{
    public class Constant
    {   
        public static string PATH_APP = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        public static string FILE_XML = "ExportaAlunos-Isvaldo.xml";
        public static string SOURCE_STATIC = "static";
        public static string FULL_PATH_XML_FILE = Path.Combine(PATH_APP, SOURCE_STATIC, FILE_XML);
        public static string DATA_FORMAT = "yyyyMMdd-HHmmsstt";
        public static string NAME_FOR_SAVE = "ExportaAlunos-IsvaldoFernandes" +
            "-" + DateTime.Now.ToString(DATA_FORMAT);
        public static string LOG_TYPE = "-Log.txt";
        public static string XML_TYPE = ".xml";
    }
}
```


