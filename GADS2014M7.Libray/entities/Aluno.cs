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
