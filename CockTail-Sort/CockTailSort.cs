using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CockTailSort
{
    public class CockTail
    {
        public static int SwapCount { get; private set; }
        public static int ComparisonCount { get; private set; }

        //Metodo que faz a organizacao
        public int[] Sort(int[] array)
        {
            Visualizer visualizer = new ();
            //Iniciando contadores
            SwapCount = 0;
            ComparisonCount = 0;

            bool swapped = true;
            //Lower sempre sera 0, e upper sera o tamanho do vetor -1
            int lower = 0;
            int upper = array.Length - 1;

            while (swapped)
            {
                swapped = false;
                //Movimento para frente
                for (int i = lower; i < upper; i++)
                {
                    ComparisonCount++;
                    //Exibe a barra atual antes da comparacao
                    //Compara com a barra pintada de vermelha
                    visualizer.DisplayBars(array, i, true); 

                    //Se o elemento atual e maior, troca
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                        visualizer.DisplayBars(array, i + 1, true);
                        swapped = true;
                        SwapCount++;

                        //Verifica se o array esta ordenado apos a troca
                        if (CheckIfSorted(array))
                            return array;
                    }
                    else
                    {
                        //Mostra a barra que nao foi trocada
                        visualizer.DisplayBars(array, i, false); 
                    }
                }

                // Se nenhuma troca foi feita, o array esta ordenado
                if (!swapped)
                {
                    visualizer.DisplaySortedBars(array);
                    return array;
                }

                swapped = false;
                // Reduz o limite superior
                upper--;

                //Movimento para tras
                //Ajustado para garantir que i - 1 nao saia dos limites
                for (int i = upper; i >= lower + 1; i--) 
                {
                    ComparisonCount++;
                    visualizer.DisplayBars(array, i, false); 

                    //Se o elemento atual e menor, troca
                    if (array[i] < array[i - 1])
                    {
                        Swap(array, i, i - 1);
                        visualizer.DisplayBars(array, i - 1, false);
                        swapped = true;
                        SwapCount++;

                        if (CheckIfSorted(array))
                            return array;
                        
                    }
                }
                //Aumenta o limite inferior
                lower++;
            }

            //Exibe o array ordenado apos a conclusao
            visualizer.DisplaySortedBars(array);
            return array;
        }

        //Metodo para verificar se o array esta ordenado
        private bool CheckIfSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                    return false; 
            }

            //Se chegar aqui, o array esta ordenado
            Visualizer visualizer = new();
            //Chama metodo para pintar as barras de verde
            visualizer.DisplaySortedBars(array);
            return true;
        }

        //Metodo para trocar
        public void Swap(int[] array, int first, int second)
        {
            int temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        //Metodo para exibir vetor com numeros
        public void Print(int[] array)
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