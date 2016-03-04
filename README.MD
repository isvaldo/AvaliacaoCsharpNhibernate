# Trabalho de C#


## classes principais 


```
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
	
	´´´ 