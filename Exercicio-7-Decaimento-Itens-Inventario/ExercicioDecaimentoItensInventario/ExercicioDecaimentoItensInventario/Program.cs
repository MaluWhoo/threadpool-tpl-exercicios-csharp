using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioDecaimentoItensInventario
{
    internal class Program
    {

        // Exercício 7 (Baixa/Esqueleto): Decaimento de Itens no Inventário

        // --- Classe do Jogo (Nao modificar ) ---
        public class Item
        {
            public int ID;
            public float Durabilidade;
            public Item(int id)
            {
                this.ID = id;
                this.Durabilidade = 100.0f;
            }

        // Aplica o decaimento . So mexe em dados locais .
            public void AplicarDecaimento(float taxa)
            {
                    if (Durabilidade > 0)
                    {
                        Durabilidade -= taxa;
                        if (Durabilidade < 0) Durabilidade = 0;
                    }
            }
        }   // --- Fim da Classe do Jogo ---
        



        static void Main(string[] args)
        {
            List<Item> todosItens = new List<Item>();
            int totalItens = 10000000; // 10 Milhoes de itens
            for (int i = 0; i < totalItens; i++)
            {
                todosItens.Add(new Item(i));
            }

            float taxaDecaimento = 0.5f;
            Stopwatch sw = new Stopwatch();

            // --- TAREFA 1: Rodar Sequencial ---
            Console.WriteLine(" Iniciando decaimento sequencial (lento)...");
            sw.Start();
            foreach (var item in todosItens)
            {
                item.AplicarDecaimento(taxaDecaimento);
            }
            sw.Stop();
            Console.WriteLine($" Sequencial:{ sw.ElapsedMilliseconds }ms") ;


            // --- TAREFA 2: Rodar Paralelo ---
            Console.WriteLine("\nIniciando decaimento paralelo (rapido)...");
            sw.Restart();
            // conjunto, depois unidade
            Parallel.ForEach(todosItens, (item) => {

                item.AplicarDecaimento(taxaDecaimento);

            });
            sw.Stop();


            //
            // --- COLOQUE SEU CODIGO Parallel . ForEach AQUI ---
            // Substitua o loop ’ foreach ’ acima por um ’ Parallel.ForEach ’

            // que chame item . AplicarDecaimento ( taxaDecaimento )
            //

            Console.WriteLine($" Paralelo: {sw.ElapsedMilliseconds} ms");
            Console.ReadKey();

        }
    }
}

