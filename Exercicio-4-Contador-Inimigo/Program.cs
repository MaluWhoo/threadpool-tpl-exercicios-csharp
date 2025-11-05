using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ExercicioContadorInimigo
{
    // --- Classes do Jogo (Nao modificar ) ---

    // Objetivo: Identificar e corrigir uma race condition em um contexto de jogo usando Interlocked.

    public struct Vector2
    {
        public float X, Y;
        public Vector2(float x, float y) { X = x; Y = y; }

        public static float Distance(Vector2 a, Vector2 b)
        {
            float dx = a.X - b.X;
            float dy = a.Y - b.Y;
            return (float)Math.Sqrt(dx*dx + dy*dy);
        }
    }

    public class Inimigo
    {
        public Vector2 Posicao;
        public Inimigo(Random rand)
        {
            Posicao = new Vector2((float)rand.NextDouble() * 1000,
            (float)rand.NextDouble() * 1000);
        }

    }
    // --- Fim das Classes do Jogo ---


    // --- Metodo Principal ---
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exercício 4 (Média/Esqueleto): Contador de Inimigos em Alcance
            Console.WriteLine("Exercício 4 - Contador de Inimigos em Alcance ");

            Random rand = new Random();
            List<Inimigo> todosInimigos = new List<Inimigo>();

            for (int i = 0; i < 1000000; i++)
            { // 1 Milhao de inimigos
                todosInimigos.Add(new Inimigo(rand));
            }

             Vector2 posJogador = new Vector2(500, 500);
             float raioAgro = 50.0f;

             int inimigosProximos = 0;

            // --- TAREFA : O CODIGO ABAIXO ESTA ERRADO ---
            // Ele sofre de uma race condition e NUNCA reporta o numero correto.
            // 1. Rode o codigo e veja o resultado ( sera baixo e inconsistente ). = Resposta: O codigo ainda n foi corrigoido, assim temos um valor baixo ali por volta do 7600.
            // 2. Corrija a linha " inimigosProximos ++;" usando Interlocked.

            Parallel.ForEach(todosInimigos, (inimigo) =>
             {
                  if (Vector2.Distance(inimigo.Posicao, posJogador) < raioAgro) {

                     // Adicionar o InterLocked
                     Interlocked.Increment(ref inimigosProximos); // Com ele adicionado os valoes são acima de 7800!!
                     // inimigosProximos++; // <--- ESTA LINHA ESTA ERRADA !
                  }
             });

              Console.WriteLine($" Total de inimigos proximos: {inimigosProximos}");

              // (O numero correto , sequencial , e geralmente por volta de 7800 - 7900)
        }
    }
    
}
