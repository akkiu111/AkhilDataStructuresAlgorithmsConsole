using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    class Program
    {
        static void Main(string[] args)
        {

            var output = placeNQueens(4);
            Console.Read();
        }

        private static IList<IList<string>> placeNQueens(int n)
        {
            string[,] matrix = new string[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = ".";
                }
            }

            IList<IList<string>> output = new List<IList<string>>();
            placeNQueensHelper(0, matrix, n, output);

            return output;
        }

        private static void placeNQueensHelper(int row, string[,] matrix, int n, IList<IList<string>> output)
        {

            if (row == n)
            {
                addMatrixToOutput(output, matrix);
                return;
            }


            for (int j = 0; j < n; j++)
            {
                if (isSafeToPlaceQueen(row, j, matrix, n))
                {
                    matrix[row, j] = "Q";
                    placeNQueensHelper(row + 1, matrix, n, output);
                    matrix[row, j] = ".";
                }
                if (j == n - 1)
                {
                    return;
                }

            }
        }

        private static void addMatrixToOutput(IList<IList<string>> output, string[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            IList<string> current = new List<string>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]);

                }
                current.Add(sb.ToString());
                if (i != matrix.GetLength(0) - 1)
                {
                    sb.Append(",");
                }
                sb = new StringBuilder();
            }

            output.Add(current);
        }

        private static bool isSafeToPlaceQueen(int i, int j, string[,] matrix, int n)
        {
            // row check
            for (int col = 0; col < n; col++)
            {
                if (matrix[i, col] == "Q")
                {
                    return false;
                }
            }

            // col check
            for (int row = 0; row < n; row++)
            {
                if (matrix[row, j] == "Q")
                {
                    return false;
                }
            }

            // top left diagonals check
            for (int topDiagRow = i - 1, leftDiagCol = j - 1;
                topDiagRow >= 0 && leftDiagCol >= 0;
                topDiagRow--, leftDiagCol--)
            {
                if (matrix[topDiagRow, leftDiagCol] == "Q")
                {
                    return false;
                }
            }

            // top right diagonals check
            for (int topDiagRow = i - 1, rightDiagCol = j + 1;
                topDiagRow >= 0 && rightDiagCol < n;
                topDiagRow--, rightDiagCol++)
            {
                if (matrix[topDiagRow, rightDiagCol] == "Q")
                {
                    return false;
                }
            }

            // bottom left diagonals check

            for (int bottomDiagRow = i + 1, leftDiagCol = j - 1;
               leftDiagCol >= 0 && bottomDiagRow < n;
               bottomDiagRow++, leftDiagCol--)
            {
                if (matrix[bottomDiagRow, leftDiagCol] == "Q")
                {
                    return false;
                }
            }

            // bottom right diagonals check

            for (int bottomDiagRow = i + 1, rightDiagCol = j + 1;
                 bottomDiagRow < n && rightDiagCol < n;
                 bottomDiagRow++, rightDiagCol++)
            {
                if (matrix[bottomDiagRow, rightDiagCol] == "Q")
                {
                    return false;
                }
            }


            return true;
        }
    }
}
