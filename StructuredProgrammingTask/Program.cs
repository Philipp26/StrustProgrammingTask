using System;

namespace StructuredProgrammingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            var size = rnd.Next(5, 10);

            var array = new int[size, size];

            ArrayRandomInitializer(array, rnd);

            Console.WriteLine("Исходня сгенерированная матрица:\n");

            ArrayOutput(array);

            var elementUnderMainDiagonal = GetMinElementUnderMainDiagonal(array);

            var elementOverSideDiagonal = GetMaxElementOverSideDiagonal(array);

            Console.WriteLine("Наименьший элемент под главной диагональю: {0}\n", elementUnderMainDiagonal);

            Console.WriteLine("Наибольшой элемент над побочной диагональю: {0}\n", elementOverSideDiagonal);       

            TransPositionElements(array, elementUnderMainDiagonal, elementOverSideDiagonal);

            Console.WriteLine("Массив после перестановки элементов\n");

            ArrayOutput(array);
            
            Console.ReadKey();
        }

        private static void TransPositionElements(int[,] array, int elementUnderMainDiagonal, int elementOverSideDiagonal)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j] == elementUnderMainDiagonal)
                        array[i, j] = elementOverSideDiagonal;

                    else if (array[i, j] == elementOverSideDiagonal)
                        array[i, j] = elementUnderMainDiagonal;
        }

        private static int GetMaxElementOverSideDiagonal(int[,] array)
        {
            var maxElement = array[0, 0];

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j >= array.GetLength(1)- 1 - i)                    
                        continue;                 

                    if (array[i, j] > maxElement)
                        maxElement = array[i, j];
                }

            return maxElement;
        }

        private static int GetMinElementUnderMainDiagonal(int[,] array)
        {
            var minElement = array[0,0];

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (i <= j)                                           
                        continue;                                      
                    
                    else if (array[i,j] < minElement)
                        minElement = array[i, j]; 
                }

            return minElement;
        }

        static void ArrayRandomInitializer(int[,] array, Random rnd)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = rnd.Next(10, 100);
        }

        static void ArrayOutput(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] + " ");
                Console.WriteLine("\n");
            }
        }
    }
}
