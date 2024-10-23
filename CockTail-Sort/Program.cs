using CockTailSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //Numeros aleatorios de 1 a 10
        //int[] values = [9, 2, 5, 10, 1, 7, 3, 8, 6, 4];

        //Numeros aleatios de 1 a 20
        int[] values =[ 9, 2, 5, 10, 1, 7, 3, 8, 6, 4, 12, 15, 11, 14, 13, 20, 19, 18, 17, 16 ];

        //Numeros de 20 a 1 em forma decrescente
        //int[] values =[ 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 ];
        CockTail sorter = new ();
        bool enableVisualization = true; 

        //Criando novo vetor do mesmo tamanho
        int[] copyValues = new int[values.Length];

        //Copiando valores para uma copia do vetor
        for (int i = 0; i < values.Length; i++)
        {
            copyValues[i] = values[i];

            if(values[i]<= 0)
                enableVisualization = false;
        }

        Console.WriteLine("Array: ");
        Visualizer.Print(copyValues);
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        Console.Clear();

        sorter.Sort(values, enableVisualization);

        Console.WriteLine("Original Array: ");
        Visualizer.Print(copyValues);
        Console.WriteLine("Sorted with Cocktail: ");
        Visualizer.Print(values);
    }
}