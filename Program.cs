using System;
using System.Collections.Generic;
using System.Linq;

namespace NullableReferenceTypePOC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var passaro = new Passaro { Nome = "Joja" };

            // Sem riscos, mesmo com a lista vazia.
            foreach (var item in passaro.AlimentosNonNullable)
            {
                Console.WriteLine(item.Nome);
            }

            // Throw NullReferenceException.
            foreach (var item in passaro.AlimentosNullable)
            {
                Console.WriteLine(item.Nome);
            }
        }
    }

    public class Passaro
    {
        public string Nome { get; set; } = string.Empty;

        // O compilador obriga o set da lista...
        public IEnumerable<Alimento> AlimentosNonNullable { get; set; } = Enumerable.Empty<Alimento>();

#nullable disable

        // Aqui, permitimos que a propriedade seja iniciada sem valor (null).
        public IEnumerable<Alimento> AlimentosNullable { get; set; }

#nullable restore
    }

    public class Alimento
    {
        public string? Nome { get; set; }
        public int ValorEnergtico { get; set; }
    }
}