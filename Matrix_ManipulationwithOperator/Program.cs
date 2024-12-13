using System;
using System.Linq;

namespace Matrix_ManipulationwithOperator
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Matrix Sample with Slicing-like Operations");
            Console.WriteLine("===========================================\n");

            // 1D Array
            double[] array = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6 };

            // Simulating slicing operations
            Console.WriteLine("Original Array:");
            Console.WriteLine(string.Join(", ", array));

            Console.WriteLine("\nFirst 5 elements (like [:5]):");
            Console.WriteLine(string.Join(", ", Slice(array, 0, 5)));

            Console.WriteLine("\nLast 3 elements (like [-3:]):");
            Console.WriteLine(string.Join(", ", Slice(array, array.Length - 3, array.Length)));

            Console.WriteLine("\nEvery 2nd element (like ::2):");
            Console.WriteLine(string.Join(", ", SliceStep(array, step: 2)));

            Console.WriteLine("\nReversed Array (like [::-1]):");
            Console.WriteLine(string.Join(", ", SliceReverse(array)));

            // 2D Array (Matrix)
            double[,] matrix = {
                { 1.1, 2.2, 3.3 },
                { 4.4, 5.5, 6.6 },
                { 7.7, 8.8, 9.9 }
            };

            Console.WriteLine("\nOriginal Matrix:");
            PrintMatrix(matrix);

            Console.WriteLine("\nFirst row:");
            Console.WriteLine(string.Join(", ", GetRow(matrix, 0)));

            Console.WriteLine("\nSecond column:");
            Console.WriteLine(string.Join(", ", GetColumn(matrix, 1)));

            Console.WriteLine("\nSubmatrix (top-left 2x2):");
            PrintMatrix(GetSubMatrix(matrix, 0, 0, 2, 2));

            Console.WriteLine("\nProgram completed. Press any key to exit...");
            Console.ReadKey();
        }

        // Simulating slicing for a 1D array
        public static double[] Slice(double[] array, int start, int end)
        {
            return array.Skip(start).Take(end - start).ToArray();
        }

        // Simulating step slicing for a 1D array
        public static double[] SliceStep(double[] array, int step)
        {
            return array.Where((value, index) => index % step == 0).ToArray();
        }

        // Reversing a 1D array
        public static double[] SliceReverse(double[] array)
        {
            return array.Reverse().ToArray();
        }

        // Get a specific row from a 2D array
        public static double[] GetRow(double[,] matrix, int rowIndex)
        {
            int cols = matrix.GetLength(1);
            double[] row = new double[cols];
            for (int col = 0; col < cols; col++)
            {
                row[col] = matrix[rowIndex, col];
            }
            return row;
        }

        // Get a specific column from a 2D array
        public static double[] GetColumn(double[,] matrix, int colIndex)
        {
            int rows = matrix.GetLength(0);
            double[] column = new double[rows];
            for (int row = 0; row < rows; row++)
            {
                column[row] = matrix[row, colIndex];
            }
            return column;
        }

        // Get a submatrix from a 2D array
        public static double[,] GetSubMatrix(double[,] matrix, int startRow, int startCol, int rowCount, int colCount)
        {
            double[,] subMatrix = new double[rowCount, colCount];
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    subMatrix[row, col] = matrix[startRow + row, startCol + col];
                }
            }
            return subMatrix;
        }

        // Print a 2D array
        public static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
