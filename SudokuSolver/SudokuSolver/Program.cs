using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<List<int>>
            {
                new List<int> {3, 0, 6, 5, 0, 8, 4, 0, 0},
                new List<int> {5, 2, 0, 0, 0, 0, 0, 0, 0},
                new List<int> {0, 8, 7, 0, 0, 0, 0, 3, 1},
                new List<int> {0, 0, 3, 0, 1, 0, 0, 8, 0},
                new List<int> {9, 0, 0, 8, 6, 3, 0, 0, 5},
                new List<int> {0, 5, 0, 0, 9, 0, 6, 0, 0},
                new List<int> {1, 3, 0, 0, 0, 0, 2, 5, 0},
                new List<int> {0, 0, 0, 0, 0, 0, 0, 7, 4},
                new List<int> {0, 0, 5, 2, 0, 6, 3, 0, 0}
            };

            var output = sudokuPuzzle(input);

            Console.WriteLine("-------------------------");
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("-------------------------");
                }
                Console.Write("| ");
                for (int j = 0; j < 9; j++)
                {                  
                    Console.Write(output[i][j] + " ");
                    if (j % 3 == 2 && j != 0)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------");

            Console.ReadLine();
        }

        private static int[] getZeroValueCoordinate(List<List<int>> sudoku)
        {
            for (int row = 0; row < sudoku.Count; row++)
            {
                for (int col = 0; col < sudoku[row].Count; col++)
                {
                    if(sudoku[row][col] == 0)
                    {
                        return new int[] { row, col };
                    }

                    if (row == sudoku.Count - 1 && col == sudoku.Count - 1)
                    {
                        return new int[] { -1, -1 };
                    }

                }

            }

            return new int[] { -1, -1 };
        }

        private static List<List<int>> sudokuPuzzle(List<List<int>> sudoku)
        {

            solveSudoku(sudoku);

            return sudoku;
        }

        private static bool solveSudoku(List<List<int>> sudoku)
        {
            int[] rowCol = getZeroValueCoordinate(sudoku);
            if (rowCol[0] == -1)
            {
                return true;
            }
            int row = rowCol[0];
            int col = rowCol[1];
            for (int val = 1; val <= 9; val++)
            {
                if (isValidPlacement(val, row, col, sudoku))
                {
                    sudoku[row][col] = val;
                    if (solveSudoku(sudoku))
                    {
                        return true;
                    }
                 
                    sudoku[row][col] = 0;
                    
                   
                }

            }

            return false;
        }

        private static bool isValidPlacement(int val, int row, int col, List<List<int>> sudoku)
        {
            //Checking entire row
            for(int currentCol = 0; currentCol < sudoku[row].Count; currentCol++)
            {
                if(sudoku[row][currentCol] == val)
                {
                    return false;
                }
            }

            //Checking entire column
            for (int currentRow = 0; currentRow < sudoku.Count; currentRow++)
            {
                if (sudoku[currentRow][col] == val)
                {
                    return false;
                }
            }

            //Checking entire subGrid
            int subGridRowStart = 0;
            if (row >= 3 && row <= 5) {
                subGridRowStart = 3;
              }
            else if (row >= 6 && row <= 8)
            {
                subGridRowStart = 6;
            }

            int subGridColStart = 0;
            if (col >= 3 && col <= 5)
            {
                subGridColStart = 3;
            }
            else if (col >= 6 && col <= 8)
            {
                subGridColStart = 6;
            }

            for(int i = subGridRowStart; i < subGridRowStart + 3; i++)
            {
                for (int j = subGridColStart; j < subGridColStart + 3; j++)
                {
                    if( i == row && j == col)
                    {
                        continue;
                    }

                    if(sudoku[i][j] == val)
                    {
                        return false;
                    }
                }

            }

            return true;

        }
    }

    /*
     *  class Program
    {
        static void Main(string[] args)
        {
            var output = new List<List<int>>
            {
                new List<int> {3, 0, 6, 5, 0, 8, 4, 0, 0},
                new List<int> {5, 2, 0, 0, 0, 0, 0, 0, 0},
                new List<int> {0, 8, 7, 0, 0, 0, 0, 3, 1},
                new List<int> {0, 0, 3, 0, 1, 0, 0, 8, 0},
                new List<int> {9, 0, 0, 8, 6, 3, 0, 0, 5},
                new List<int> {0, 5, 0, 0, 9, 0, 6, 0, 0},
                new List<int> {1, 3, 0, 0, 0, 0, 2, 5, 0},
                new List<int> {0, 0, 0, 0, 0, 0, 0, 7, 4},
                new List<int> {0, 0, 5, 2, 0, 6, 3, 0, 0}
            };

             sudokuPuzzle(output);

            Console.WriteLine("-------------------------");
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("-------------------------");
                }
                Console.Write("| ");
                for (int j = 0; j < 9; j++)
                {                  
                    Console.Write(output[i][j] + " ");
                    if (j % 3 == 2 && j != 0)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------");

            Console.ReadLine();
        }

        private static void sudokuPuzzle(List<List<int>> sudoku)
        {

            solveSudoku(sudoku);

        }

        private static bool solveSudoku(List<List<int>> sudoku)
        {

            for (int row = 0; row < sudoku.Count; row++)
            {
                for (int col = 0; col < sudoku[row].Count; col++)
                {
                    if (sudoku[row][col] == 0)
                    {
                        for (int val = 1; val <= 9; val++)
                        {
                            if (isValidPlacement(val, row, col, sudoku))
                            {
                                sudoku[row][col] = val;
                                if (solveSudoku(sudoku))
                                {
                                    return true;
                                }
                                else
                                {
                                    sudoku[row][col] = 0;
                                }

                            }

                        }

                        return false;

                    }
                }
            }

                        
            return true;
        }

        private static bool isValidPlacement(int val, int row, int col, List<List<int>> sudoku)
        {
            //Checking entire row
            for(int currentCol = 0; currentCol < sudoku[row].Count; currentCol++)
            {
                if(sudoku[row][currentCol] == val)
                {
                    return false;
                }
            }

            //Checking entire column
            for (int currentRow = 0; currentRow < sudoku.Count; currentRow++)
            {
                if (sudoku[currentRow][col] == val)
                {
                    return false;
                }
            }

            //Checking entire subGrid
            int subGridRowStart = 0;
            if (row >= 3 && row <= 5) {
                subGridRowStart = 3;
              }
            else if (row >= 6 && row <= 8)
            {
                subGridRowStart = 6;
            }

            int subGridColStart = 0;
            if (col >= 3 && col <= 5)
            {
                subGridColStart = 3;
            }
            else if (col >= 6 && col <= 8)
            {
                subGridColStart = 6;
            }

            for(int i = subGridRowStart; i < subGridRowStart + 3; i++)
            {
                for (int j = subGridColStart; j < subGridColStart + 3; j++)
                {
                    if( i == row && j == col)
                    {
                        continue;
                    }

                    if(sudoku[i][j] == val)
                    {
                        return false;
                    }
                }

            }

            return true;

        }
    }
     */
}
