using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExercicioGeracaoMapaAltura
{
    internal class Program
    {
        // Exercício 6 (Média/Esqueleto): Geração de Mapa de Altura (Height-map)

        
        // Funcao " lenta " que calcula a altura de um ponto do terreno

        static float CalcularAltura(int x, int y)
        {
            // Simula um calculo complexo (ex: Perlin Noise )
            Thread.Sleep(1);
            // Nao remova isso !
            return (x * y) % 100;
            // Valor placeholder
        }


        static void Main(string[] args)
        {

            int largura = 5; //512;
            int altura = 5; //512;
            float[] mapaDeAltura = new float[largura * altura];

            Stopwatch sw = new Stopwatch();

            // --- TAREFA 1: Rodar Sequencial ---
            Console.WriteLine(" Iniciando geracao sequencial (lenta)...");
            sw.Start() ;
            for (int x = 0; x < largura; x++)
            {
                for (int y = 0; y < altura; y++)
                {
                    int indice = x * largura + y;
                    mapaDeAltura[indice] = CalcularAltura(x, y);
                }
            }
            sw.Stop();
            Console.WriteLine($" Sequencial: { sw.ElapsedMilliseconds } ms");


            // --- TAREFA 2: Rodar Paralelo ---
            // Dica : Paralelize APENAS o loop externo (o loop do ’ x ’)

            // For de um numero para outro (o, 0)

            Console.WriteLine("\nIniciando geracao paralela (rapida)...");
            sw.Restart();
            Parallel.For(0, largura, (i)=> {

                for (int y = 0; y < altura; y++)
                {
                    int indice = i * largura + y;
                    mapaDeAltura[indice] = CalcularAltura(i, y);
                }

            });
            sw.Stop();

            //
            // --- COLOQUE SEU CODIGO Parallel.For AQUI ---
            // Substitua o loop ’for (int x ...) ’ por um ’ Parallel.For ’

            // Mantenha o loop interno ’for (int y ...) ’ como esta
            //

            Console.WriteLine($" Paralelo: {sw.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
