using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ExercicioAtualizacaoBonusBuffs
{

    // Exercício 5 (Baixa/Esqueleto): Atualização de Bônus (Buffs)

    // Objetivo: Usar Parallel.ForEach para acelerar uma tarefa "embaraçosamente paralela"(embarrassingly parallel).

    // --- Classe do Jogo (Nao modificar ) ---
    public class Buff {

        public string Nome;
        public float TempoRestante;
        public bool Ativo;

        public Buff(Random rand) {

            Nome = " Buff_ " + rand.Next(100);
            TempoRestante = (float)rand.NextDouble() * 30.0f; // 0 a 30s
            Ativo = true;
        }


        // Metodo que " gasta " o tempo do buff
        public void Update(float deltaTime)
        {

            if (!Ativo) return;
            TempoRestante -= deltaTime;
            if (TempoRestante <= 0)
            {
                Ativo = false;
            }
        }
    }
    //// --- Fim da Classe do Jogo ---


    // --- Metodo Principal ---
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();
            List<Buff> todosBuffs = new List<Buff>();

            int totalBuffs = 5000000; // 5 Milhoes de buffs
            for (int i = 0; i < totalBuffs; i++)
            {
                todosBuffs.Add(new Buff(rand));
            }
            
            float deltaTime = 0.1f; // Simulando 100 ms de tick
            Stopwatch sw = new Stopwatch();

            // --- TAREFA 1: Rodar Sequencial ---
            Console.WriteLine(" Iniciando update sequencial (lento)...");
            sw.Start();
            foreach (var buff in todosBuffs)
            {
                buff.Update(deltaTime);
            }
            sw.Stop();
            Console.WriteLine($" Sequencial: { sw.ElapsedMilliseconds } ms");


            // --- TAREFA 2: Rodar Paralelo ---
            Console.WriteLine("\nIniciando update paralelo (rapido)...");
            sw.Restart();
            Parallel.ForEach(todosBuffs, (buff) =>
            {
                buff.Update(deltaTime);
            });
            sw.Stop();
            Console.WriteLine($" Paralelo: {sw.ElapsedMilliseconds} ms");

            //
            // --- COLOQUE SEU CODIGO Parallel . ForEach AQUI ---
            // Substitua o loop ’foreach ’ acima por um ’Parallel.ForEach ’
            //

            // PARA NAO EU ESQUECER 
            // O primeiro parametro é todos da coleção enquanto o segundo é somente cada elemento de forma individual.

            Console.ReadKey();
        }
    }
}
