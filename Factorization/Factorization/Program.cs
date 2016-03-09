using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.Numeric;

namespace Factorization
{
    class Program
    {
        static void Main(string[] args)
        {           
            System.Console.WriteLine("-----------------------");
            System.Console.WriteLine("Factorization Algorythm");
            System.Console.WriteLine("-----------------------");
            System.Console.WriteLine(" by André Morais, 2011 ");

            ConsoleKeyInfo k =new ConsoleKeyInfo();

            while (k.Key == 0 || k.Key == ConsoleKey.Enter)
            {
                // Read parameters                
                ulong number = GetULongFromConsole("the integer to be factorized");
                ulong root = GetULongFromConsole("the root of the next perfect square after that integer");
                
                // MAX Values
                // 1844674407370955169
                // 4294967295

                Stopwatch sp = new Stopwatch();
                sp.Start();

                // Prepare parameters
                ulong height = root;
                ulong width = root;
                ulong heightN = 0;
                ulong widthN = 0;

                // Remove difference
                ulong difference = root * root - number;

                height -= difference / width;
                width += difference / height;
                heightN = difference % width;
                widthN = difference % height;

                // If either last row or last column are incomplete
                while (widthN > 0 || heightN > 0)
                {
                    // Transpose last row to last column
                    width += (widthN + heightN) / height;
                    widthN = 0;
                    heightN = (widthN + heightN) % height;

                    // If last column is incomplete, declare last row as a new assimetry
                    if (heightN > 0)
                    {
                        height--;
                        widthN = width;
                    }
                }

                //// Initialize matrix
                //int[,] matrix = new int[root,number];

                //// Reset matrix
                //for (int i = 0; i < root; i++)
                //    for (int j = 0; j < number; j++)
                //        if (j < root) matrix[i, j] = 1;
                //        else matrix[i, j] = 0;

                //// Remove difference
                //long difference = root * root - number;
               
                //if (doReport) PrintMatrix(matrix);                
               
                //while (difference > 0)
                //{
                //    int lastRow = GetMatrixHeight(matrix, 0) - 1;
                //    int widthLastRow = GetMatrixWidth(matrix, lastRow);

                //    while (widthLastRow > 0 && difference > 0)
                //    {
                //        widthLastRow--;
                //        matrix[lastRow, widthLastRow] = 0;
                //        difference--;
                //    }
                //}

                //if (doReport) PrintMatrix(matrix);

                //// Read values
                //int matrixHeight1 = GetMatrixHeight(matrix, 0);
                //int matrixWidth1 = GetMatrixWidth(matrix, 0);
                //int matrixHeightN = GetMatrixHeight(matrix, matrixWidth1 - 1);

                //// If it is not a rectangle
                //while (matrixHeight1 != matrixHeightN)
                //{
                //    // Get last row for deletion
                //    int matrixWidthN = GetMatrixWidth(matrix, matrixHeight1 - 1);
                //    // Delete it
                //    DeleteMatrixRow(ref matrix, matrixHeight1 - 1);
                //    matrixHeight1--;
                    
                //    // Add the same amount of elements
                //    while (matrixWidthN > 0)
                //    {
                //        // Get last column for insertion
                //        int lastCol = GetMatrixWidth(matrix, 0) - 1;
                //        // Get current height 
                //        int heightLastCol = GetMatrixHeight(matrix, lastCol);

                //        // If column is full, add a new empty one
                //        if (heightLastCol == matrixHeight1)
                //        {
                //            heightLastCol = 0;
                //            lastCol++;
                //        }

                //        // If height is not the maximum available amount and there are still elements to add
                //        while (heightLastCol < matrixHeight1 && matrixWidthN > 0)
                //        {                            
                //            // Insert value at current height
                //            matrix[heightLastCol, lastCol] = 1;
                //            matrixWidthN--;
                //            heightLastCol++;
                //        }                        
                //    }

                //    if (doReport) PrintMatrix(matrix);

                //    // Reset values
                //    matrixHeight1 = GetMatrixHeight(matrix, 0);
                //    matrixWidth1 = GetMatrixWidth(matrix, 0);
                //    matrixHeightN = GetMatrixHeight(matrix, matrixWidth1 - 1);
                //}
                //sp.Stop();
                System.Console.WriteLine(string.Format("The number {0} has been factorized such that : {0}={1}x{2}:", number, width, height));
                System.Console.WriteLine(string.Format("Processed in {0}ms",sp.ElapsedMilliseconds));
                System.Console.Write("Press enter to continue and any other key to exit...");
                k = System.Console.ReadKey();
            }
        }

        public static ulong GetULongFromConsole(string description)
        {            
            ulong number = 0;

            while (number == 0)
            {
                System.Console.WriteLine();
                System.Console.Write(string.Format("Please enter {0}:", description));
                string numberStr = System.Console.ReadLine();
                try
                {
                    number = Convert.ToUInt64(numberStr);
                }
                catch (Exception)
                {
                    System.Console.WriteLine(string.Format("Input data does not match {0}. Please try again...",description));
                }
            }
            return number;
        }

    //    public static void PrintMatrix(int[,] matrix)
    //    {
    //        for (int i = 0; i < matrix.GetLength(0); i++)
    //        {
    //            System.Console.Write("|");
    //            for (int j = 0; j < matrix.GetLength(1); j++)
    //                System.Console.Write("\t" + matrix[i, j]);
    //            System.Console.WriteLine("\t|");
    //        }

    //        System.Console.WriteLine(string.Format("Matrix is now {0} wide and {1} high, on first instances of each dimension", GetMatrixWidth(matrix, 0), GetMatrixHeight(matrix, 0)));
    //    }

    //    public static int GetMatrixHeight(int[,] matrix, int col)
    //    {
    //        int result = 0;
    //        for (int i = 0; i < matrix.GetLength(0); i++)
    //        {
    //            if (matrix[i,col] == 0) break;

    //            result += matrix[i, col];                                
    //        }
    //        return result;
    //    }

    //    public static int GetMatrixWidth(int[,] matrix, int row)
    //    {
    //        int result = 0;
    //        for (int i = 0; i < matrix.GetLength(1); i++)
    //        {
    //            if (matrix[row,i] == 0) break;

    //            result += matrix[row,i];
    //        }
    //        return result;
    //    }

    //    public static void DeleteMatrixRow(ref int[,] matrix, int row)
    //    {           
    //        for (int i = 0; i < matrix.GetLength(1); i++)
    //        {
    //            if (matrix[row, i] == 0) break;

    //            matrix[row, i] = 0;
    //        }            
    //    }
    }
}
