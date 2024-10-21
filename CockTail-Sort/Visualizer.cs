using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CockTailSort
{
    public class Visualizer
    {
        //Metodo para mostrar linhas
        //Se for verdadeiro, esta avancando
        //Se for falso, esta voltando
        public void DisplayBars(int[] array, int currentIndex = -1, bool movingForward = true)
        {
            Console.Clear();

            //Encontra a altura maxima para alinhar corretamente
            //Usando a bibliote Linq para acessar o metodo Max()
            //Armazena o maior numero dentro da array
            int maxHeight = array.Max();

            //Exibe as barras
            for (int i = maxHeight; i > 0; i--)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    //Define a cor da barra com base no indice atual
                    //A barra que esta sendo comparada
                    if (j == currentIndex) 
                    {
                        //Cor da barra atual
                        Console.ForegroundColor = ConsoleColor.Green; 
                    }
                    //A barra seguinte
                    //If ternario
                    //Se estiver movendo para frente index atual +1, senao index atual -1
                    else if (j == (movingForward ? currentIndex + 1 : currentIndex - 1)) 
                    {
                        //Cor da barra seguinte
                        Console.ForegroundColor = ConsoleColor.Red; 
                    }
                    else
                    {
                        //Cor padrao para outras barras
                        Console.ForegroundColor = ConsoleColor.White; 
                    }

                    if (array[j] >= i)
                        //Desenha a barra por codigo Unicode
                        Console.Write("\u2503 "); 
                    else
                        //Espaço para manter o alinhamento
                        Console.Write("  ");
                }
                Console.WriteLine();
            }

            // Restaura a cor padrao
            Console.ResetColor();

            // Exibe os contadores de comparacoes e movimentos
            DisplayCaption(array);
            //Espera para visualizar
            Thread.Sleep(500); 
        }

        //Metodo para mostrar todas as barras verdes ao final
        public void DisplaySortedBars(int[] array)
        {
            Console.Clear(); 

            int maxHeight = array.Max(); 

            //Define a cor verde para todas as barras
            Console.ForegroundColor = ConsoleColor.Green;

            // Exibe todas as barras em verde
            for (int i = maxHeight; i > 0; i--)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] >= i)
                        Console.Write("\u2503 "); 
                    else
                        Console.Write("  "); 
                }
                Console.WriteLine();
            }

            //Restaura a cor padrao apos a exibição das barras
            Console.ResetColor();
            DisplayCaption(array);
        }

        //Metodo para mostrar menu com trocas e vezes comparadas
        public void DisplayCaption(int[] array)
        {
            CockTail cockTail = new();
            //Linha separadora
            Console.WriteLine(new string('=', array.Length * 2)); 
            Console.WriteLine($"Comparisons: {CockTail.ComparisonCount}");
            Console.WriteLine($"Times Swapped: {CockTail.SwapCount}");
            Console.WriteLine(new string('=', array.Length * 2));
        }
    }
}