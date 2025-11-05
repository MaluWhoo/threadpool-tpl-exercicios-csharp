using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExercicioContadorParalelo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercício 1 (Baixa): O Contador Paralelo");
            Console.WriteLine("Iniciando contagem...");

            long longTotal = 0;
            Parallel.For(0, 10000000, (i) =>
            {
                //longTotal += 1;
                // Sem o Interlocked, o resultado é inconsistente. Acontecendo a race condition.

                // thread - safe
                // Solução 2: Interlocked (Operações Atômicas)
                Interlocked.Increment(ref longTotal);
            });

            Console.WriteLine("Calculo de background terminou.");
            Console.WriteLine($"Resultado final: {longTotal}");

            Thread.Sleep(1000);
            Console.ReadKey();
        }
    }
}
