using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CockTailSort
{
    public class Visualizer
    {

        private int delay = 500;
        //Metodo para mostrar linhas
        //Se for verdadeiro, esta avancando
        //Se for falso, esta voltando
        public void DisplayBars(int[] array, int currentIndex = -1, bool movingForward = true, bool sorted = false)
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
                    //Define a cor da barra
                    if (sorted)
                    {
                        //Verde para barras ordenadas
                        Console.ForegroundColor = ConsoleColor.Green; 
                    }
                    else if (j == currentIndex)
                    {
                        //Vermelho para a barra atual
                        Console.ForegroundColor = ConsoleColor.Red; 
                    }
                    //If ternario
                    else if (j == (movingForward ? currentIndex + 1 : currentIndex - 1))
                    {
                        //Ciano para a barra seguinte
                        Console.ForegroundColor = ConsoleColor.Cyan; 
                    }
                    else
                    {
                        //Cor padrao para outras barras
                        Console.ForegroundColor = ConsoleColor.White; 
                    }

                    Console.Write(array[j] >= i ? "\u2503 " : "  ");
                }
                Console.WriteLine();
            }

            // Restaura a cor padrao
            Console.ResetColor();

            // Exibe os contadores de comparacoes e movimentos
            DisplayCaption(array);
            //Espera para visualizar
            if (!sorted)
            {
                Thread.Sleep(delay);
            }
        }

        //Metodo para mostrar todas as barras verdes ao final
        public void DisplaySortedBars(int[] array)
        {
            bool sorted = true;
            bool movingForward =true;
            DisplayBars(array, 1, movingForward, sorted);
        }

        //Metodo para mostrar menu com trocas e vezes comparadas
        public void DisplayCaption(int[] array)
        {
            CockTail cockTail = new();
            //Linha separadora
            Visualizer.CreateLine(array);
            Console.WriteLine($"Comparisons: {CockTail.ComparisonCount}");
            Console.WriteLine($"Times Swapped: {CockTail.SwapCount}");
            Visualizer.CreateLine(array);
        }

        //Metodo para criar linha
        public static void CreateLine(int[] array){
            Console.WriteLine(new string('=', array.Length * 2)); 
        }

        //Metodo para exibir vetor com numeros
        public static void  Print(int[] array)
        {
            Console.Write("[ ");
            foreach (int a in array)
            {
                Thread.Sleep(100);
                Console.Write($"{a} ");
            }
            Console.Write("]");
            Console.WriteLine("");
        }
    }
}