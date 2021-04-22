using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedMatrixValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new List<List<int>>();
            matrix.Add(new List<int>(){
            1, 3, 7, 4, 5
        });
            matrix.Add(new List<int>(){
            2, 5, 9, 3, 3
        });
            matrix.Add(new List<int>(){
            1, 8, 5, 3, 5
        });
            matrix.Add(new List<int>(){
            5, 0, 3, 5, 6
        });
            matrix.Add(new List<int>(){
            3, 8, 3, 5, 6
        });
            matrix.Add(new List<int>(){
            1, 0, 3, 0, 5
        });
            //	var expected = new List<int>(){
            //	3, 5
            //};
            var output = RepeatedMatrixValues(matrix);
            output = RepeatedMatrixValues(new List<List<int>>{ new List<int> { 1, 0 },
                new List<int> { 1, 0 } });
            Console.ReadLine();
        }

        public static List<int> RepeatedMatrixValues(List<List<int>> matrix)
        {
            // Write your code here.
            List<int> output = new List<int>();
            Dictionary<int, MatrixResult> ht = new Dictionary<int, MatrixResult>();
            checkSmallerMatrixAndAssignForMinSpace(matrix, ht);

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    if (ht.ContainsKey(matrix[i][j]) && ht[matrix[i][j]].rowCount == i)
                    {
                        ht[matrix[i][j]].rowCount = ht[matrix[i][j]].rowCount + 1;
                    }
                }
            }


            for (int j = 0; j < matrix[0].Count; j++)
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (ht.ContainsKey(matrix[i][j]) && ht[matrix[i][j]].colCount == j)
                    {
                        ht[matrix[i][j]].colCount = ht[matrix[i][j]].colCount + 1;
                    }
                }
            }

            foreach (var ele in ht.Values)
            {
                if (ele.rowCount == matrix.Count && ele.colCount == matrix[0].Count)
                {
                    output.Add(ele.val);
                }
            }


            return output;
        }

        private static void checkSmallerMatrixAndAssignForMinSpace(List<List<int>> matrix, Dictionary<int, MatrixResult> ht)
        {

            List<int> smallMatrix = matrix[0];
            if (matrix.Count < matrix[0].Count)
            {
                smallMatrix = new List<int>();
                foreach (var ele in matrix)
                {
                    smallMatrix.Add(ele[0]);
                }
            }


            foreach (var ele in smallMatrix)
            {
                if (!ht.ContainsKey(ele))
                {
                    ht.Add(ele, new MatrixResult(ele, 0, 0));
                }
            }

        }


        public class MatrixResult
        {
            public int val;
            public int rowCount;
            public int colCount;

            public MatrixResult(int val, int rowCount, int colCount)
            {
                this.val = val;
                this.rowCount = rowCount;
                this.colCount = colCount;
            }
        }
    }
}
