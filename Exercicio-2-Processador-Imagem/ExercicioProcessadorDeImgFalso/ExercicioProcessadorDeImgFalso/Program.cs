using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioProcessadorDeImgFalso
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int totalPixels = 1000; //10;  // Tamanho da imagem (4K)

            Console.WriteLine("Exercício 2 (Média): Processador de Imagem Falso");
            Console.WriteLine("Iniciando processamento de imagem...");

            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            // Usando For - Sequencial 
            sw1.Start();
            for (int i = 0; i < totalPixels; i++)
            {
                ProcessarPixel(i);
                Console.WriteLine($"Pixel processado: {i}");
            }
            sw1.Stop();

            // Usando Parallel.For - Paralelo
            sw2.Start();
            Parallel.For(0, totalPixels, (i) =>
            {
                ProcessarPixel(totalPixels);
            });
            sw2.Stop();

            Console.WriteLine($"Tempo do For: {sw1.ElapsedMilliseconds} ms");
            Console.WriteLine($"Tempo do Parallel.For: {sw2.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }

        public static void ProcessarPixel(int pixelIndex)
        {
            // Crie um método void que simula trabalho pesado
            System.Threading.Thread.Sleep(1); // Simula trabalho pesado
        }         

    }
}
