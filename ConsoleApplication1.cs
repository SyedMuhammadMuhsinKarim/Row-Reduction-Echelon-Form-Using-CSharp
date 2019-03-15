using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix = new double[4, 5] { {1, 2, 4, 8, 5.3}, {1, 5.5, 30.25, 166.375, 5.5}, {1, 11, 121 , 1331, 10.2}, {1, 13, 169, 2197, 9.35} };
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            double[,] result = new double[row, col];
            Console.WriteLine("Row = {0}, Col = {1}",  row, col);
            
            pivotFinding(matrix, 0, row, col);
            Console.ReadKey();
        }

        static void pivotFinding(double [,] matrix, int nCol, int row, int col) 
        {
            double[,] result = new double[row, col];
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    result[r, c] = matrix[r, c];
                }
            }

            int i = 0;
            int j = nCol;
            while(i < row) {
               if(matrix[i,j] == 0) {
                   i++;
                }
               else if (matrix[i, j] != 0) {
                   if(matrix[i,j] != 1 && (i != col || i == col)) {
                       for(int k = 0; k < col; k++) {
                            result[j, k] = matrix[j, k]/matrix[nCol,nCol];
                       }
                        i++;
                        break;
                   }
                    else if (matrix[i, j] == 1) {
                        break;
                    }
               } 
            }

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = result[r, c];
                }
            }

            Echelon(matrix, nCol, col, row);
        }

        static void Echelon(double[,] matrix, int nCol, int col, int row) {
            int k = nCol;
            double [,] result = new double[row, col];

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    result[r, c] = matrix[r, c];
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i != nCol)
                    {
                        result[i, j] = matrix[i, j] - (matrix[nCol, j] * matrix[i, nCol]);
                    }
                }
            }

            Console.WriteLine("Process: {0}", nCol + 1);
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = result[r,c];
                    Console.Write(result[r, c] + "     ");
                }
                Console.WriteLine();
            }

            nCol = nCol + 1;
            if (nCol < row) {
                pivotFinding(matrix, nCol, row, col);
            }
        }
    }
}
