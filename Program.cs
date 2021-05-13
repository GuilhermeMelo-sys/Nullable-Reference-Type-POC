using System.Collections.Generic;

namespace NullableReferenceTypePOC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pessoa1 = new Pessoa { Id = null, Nome = "Guilherme", Idade = 19 };
            var alimentos = new List<Alimento> { new Alimento { Nome = "Minhoca", ValorEnergtico = 65 } };
            var passaro = new Passaro { Apelido = "Joja", Alimentos = alimentos };
        }
    }


#nullable disable
    public class Passaro
    {
        public string Apelido { get; set; }
        public string Nicho { get; set; }
        public List<Alimento> Alimentos { get; set; }
    }
    public class Alimento
    {
        public string Nome { get; set; }
        public int ValorEnergtico { get; set; }
    }
#nullable restore

    public class Pessoa
    {
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
    }
}