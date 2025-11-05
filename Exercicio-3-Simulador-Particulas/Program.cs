using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ExercicioSimuladorDeParticulas
{
    public struct Vector3{

        // Aqui usei uma sctruct simples.
        public float X, Y, Z;

        // Usei exemplo do exercicio 4
        public Vector3(float x, float y, float z) {X = x; Y = y; Z = z;
        }
             
        public void Exibir() 
        {
            Console.WriteLine($"Ponto: ({X}, {Y}, {Z})");
        }
    }

    // Criar a Particle que vai usar o Vector3.

    public class Particle
    {
        public Vector3 position;
        public float life;

        // Contrutor = Facilita para quando for inicializar o objeto Particle, ele ja receber os valores.
        //public Particle(Vector3 pos, float lifeValue)
        //{
        //    position = pos;
        //    life = lifeValue; 
        //}
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercício 3 (Média/Jogo): Simulador de Partículas");

            List<Particle> particulas = new List<Particle>();

            Random random = new Random();
            for (int i = 0; i < 5000000; i++)
            {
                Particle particle = new Particle();
                particle.position = new Vector3(
                    // (ex: position.X > 100).
                    (float)random.NextDouble() * 100,
                    (float)random.NextDouble() * 100,
                    (float)random.NextDouble() * 100
                );

                // O next ele vai gerar valor entra 0 e 1. Ex: 0.9999....
                // partículas que estão "vivas"(life > 0.5f)
                particle.life = (float)random.NextDouble();

                particulas.Add(particle);
            }

            // Console.WriteLine("Parte A (Coleta Incorreta)");

            List<Particle> particulasVivas = new List<Particle>();

            // 2. Cria a " bolsa " thread - safe para coletar os resultados 
            Console.WriteLine("Parte B(Coleta Correta):");
            ConcurrentBag<Particle> resultadosCorretos = new ConcurrentBag<Particle>();

            // Usar o ForEach para cada para sabermos se estão vivassss
            Parallel.ForEach(particulas, (particle) =>
            { 
                //string info = particulasVivas.life 

                if (particle.life > 0.5f)
                {
                    // AGORA TEMOS ELAS VIVASSSSSSSSSS
                    resultadosCorretos.Add(particle); // PONTO CRITICOOO Aqui da erro de IndexOutOfRange...
                }
            });

            Console.WriteLine($"Particulas vivas: {resultadosCorretos.Count}");

            // O por que do CurrentBag? Usamos ele porque ele foi projetada espeficicamente para elimitar o gargalo de conteção.
            // Como temos várias threads tentando adicionar valores em um mesmo lugar comum, o CurrentBag faz com que cada Thread receba sua "mochila",
            // no qual todo o seu conteudo sera jogado dentro dessa mochila e no final temos a soma de todas!! Simples e facil de aplicar
           
            // OUTRO PONTO: Aqui como foi usado um random para a vida, temos um numero rando de particulas vivas.
        
        }
    }
}

