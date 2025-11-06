using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExercicioInicializacaoSistemasParallelInvoke
{
    internal class Program
    {

        // Exercício 8 (Média/Esqueleto): Inicialização de Sistemas com Parallel.Invoke

        // --- Metodos de Inicializacao (Nao modificar ) ---

        // --- Metodos de Inicializacao (Nao modificar ) ---
        static void CarregarSistemaDeAudio()
        {
            Console.WriteLine("... Carregando Audio ... ");
            Thread.Sleep(1500);
            // 1.5 s
            Console.WriteLine(" Audio OK!");
        }

        static void InicializarIA()
        {
            Console.WriteLine("... Inicializando IA ... ");
            Thread.Sleep(2000); // 2s
            Console.WriteLine("IA OK!");
        }

        static void ConectarServidorRede()
        {
            Console.WriteLine("... Conectando a Rede ... ");
            Thread.Sleep(1000);
            // 1s
            Console.WriteLine(" Rede OK!");
        }

        // --- Metodo Principal ---
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            // --- TAREFA 1: Rodar Sequencial ---
            Console.WriteLine(" Iniciando inicializacao Sequencial (lenta)...");

            sw.Start();
            CarregarSistemaDeAudio();
            InicializarIA();
            ConectarServidorRede();
            sw.Stop();

            // Tempo total esperado : 1.5 + 2 + 1 = ~4.5 s
            Console.WriteLine($" Sequencial  {sw.ElapsedMilliseconds / 1000} s");


            // --- TAREFA 2: Rodar Paralelo ---
            Console.WriteLine(" Iniciando inicializacao Paralela (rapida)...");

            sw.Restart();
            Parallel.Invoke(
                () => { // Tarefa
                    CarregarSistemaDeAudio();
                },
                () => {
                    InicializarIA();
                },
                () => {
                    CarregarSistemaDeAudio();
                }
            );
            sw.Stop();

            //
            // --- COLOQUE SEU CODIGO Parallel . Invoke AQUI ---
            // Chame os tres metodos ( CarregarSistemaDeAudio ,
            // InicializarIA , ConectarServidorRede )
            // usando uma unica chamada Parallel . Invoke .
            //


            // Tempo total esperado : ~2s (o tempo da tarefa mais longa )

            Console.WriteLine($" Paralelo: {sw.ElapsedMilliseconds / 1000} s");
            Console.ReadKey();
        }
    }
}
