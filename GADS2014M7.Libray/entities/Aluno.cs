using System;
using System.ComponentModel;
using System.Text;

namespace GADS2014M7.Libray
{
    public class Aluno
    {
        public virtual int matricula {get;set;}
        public virtual string nome { get; set; }
        public virtual string sobrenome { get; set; }
        public virtual string codigoCurso { get; set; }
        public virtual string nomeCurso { get; set; }
        public virtual Boolean statusAluno { get; set; }

        public override string ToString()
        {
            StringBuilder sd = new StringBuilder();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
                sd.Append(descriptor.Name + " = " + descriptor.GetValue(this) + "\n");
            return sd.ToString();  
        }

    }      
}
