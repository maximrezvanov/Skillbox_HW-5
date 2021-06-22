using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int rowMatrix;
            int colMatrix;

            Random rand = new Random();

            Console.WriteLine("Enter the dimension of the matrix in A x B format");

            while (!int.TryParse(Console.ReadLine(), out rowMatrix) || rowMatrix <= 0)
            {
                Console.WriteLine("Invalid input");
            }

            // условие "colMatrix != rowMatrix" необходимо для корректного выполнения метода умножения матриц
            while (!int.TryParse(Console.ReadLine(), out colMatrix) || colMatrix <= 0 || colMatrix != rowMatrix)
            {
                Console.WriteLine("Invalid input");
            }


            int[,] exampleMatrix = new int[rowMatrix, colMatrix];

            for (int i = 0; i < exampleMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < exampleMatrix.GetLength(1); j++)
                {
                    exampleMatrix[i, j] = rand.Next(1, 6);
                    Console.Write(exampleMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("check multiplication method");

            Multiplication(exampleMatrix, 2);

            int[,] Multiplication(int[,] matrix, int factor)
            {
                int[,] newMatrix = matrix;
                for (int i = 0; i < newMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < newMatrix.GetLength(1); j++)
                    {
                        Console.Write($"{newMatrix[i, j] * factor} ");
                    }
                    Console.WriteLine();
                }
                return newMatrix;
            }

            Console.WriteLine();
            Console.WriteLine("check add method");
            Console.WriteLine("exampleMatrix += exampleMatrix2");

            var exampleMatrix2 = exampleMatrix;
            AddMatrix(exampleMatrix, exampleMatrix2);

            int[,] AddMatrix(int[,] matrix1, int[,] matrix2)
            {
                var newMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

                while (matrix1.GetLength(1) != matrix2.GetLength(1) || matrix1.GetLength(0) != matrix2.GetLength(0))
                {
                    Console.WriteLine("Different matrix sizes");
                }

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        newMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                        Console.Write(newMatrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                return newMatrix;

            }

            Console.WriteLine();
            Console.WriteLine("check substract method");
            Console.WriteLine("exampleMatrix -= exampleMatrix2");

            SubtractMatrix(exampleMatrix, exampleMatrix2);

            int[,] SubtractMatrix(int[,] matrix1, int[,] matrix2)
            {
                var newMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];



                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        newMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                        Console.Write(newMatrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                return newMatrix;
            }

            Console.WriteLine();
            Console.WriteLine("check matrix multiplication method");
            Console.WriteLine("exampleMatrix *= exampleMatrix2");

            MultiplacationMatrix(exampleMatrix, exampleMatrix2);

            int[,] MultiplacationMatrix(int[,] matrix1, int[,] matrix2)
            {
                var newMatrix = new int[matrix1.GetLength(1), matrix2.GetLength(1)];

                while (matrix1.GetLength(0) != matrix2.GetLength(1))
                {
                    Console.WriteLine("Different matrix sizes");
                }

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        newMatrix[i, j] = 0;
                        for (int k = 0; k < matrix1.GetLength(1); k++)
                        {
                            newMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                        }

                        Console.Write(newMatrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                return newMatrix;
            }

            Console.ReadKey();

            // 5.2
            Console.WriteLine("Enter your string (return min and max word)");
            string strTest = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("return max string");

            GetStringWithMinimalWord(strTest);

            string GetStringWithMinimalWord(string text)
            {
                string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string str = words[0];

                for (int i = 0; i < words.Length; i++)
                {
                    if (str.Length > words[i].Length)
                        str = words[i];
                }
                Console.WriteLine(str);
                return str;

            }

            Console.WriteLine();

            Console.WriteLine("return max string");

            GetStringWithMaximalWordLength(strTest);

            List<String> GetStringWithMaximalWordLength(string text)
            {
                List<string> maxLengthWorldsList = new List<string>();

                string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string str = words[0];

                for (int i = 0; i < words.Length; i++)
                {
                    if (str.Length <= words[i].Length)
                    {
                        str = words[i];
                        maxLengthWorldsList.Add(str);
                    }
                }

                foreach (var s in maxLengthWorldsList)
                {
                    if (s.Length == str.Length)
                        Console.WriteLine(s);
                }

                return maxLengthWorldsList;

            }
            // 5.3
            Console.WriteLine("Task 5.3");

            Console.WriteLine("return nondublicate string");

            string test = "ПППОООГГГООООДДДААА";
            string test2 = "Ххххоооорррооошшшиий деееннннь";

            RemoveDublicateChar(test.ToLower());
            RemoveDublicateChar(test2.ToLower());

            char[] RemoveDublicateChar(string s)
            {
                char[] c = new char[s.Length];
                int unique = 0;
                c[unique] = s[0];
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i - 1] != s[i])
                        c[++unique] = s[i];
                }

                Console.WriteLine(c);

                return c;
            }

            Console.WriteLine("Task 5.4");

            Console.WriteLine("Check progression");

            CheckProgression();
            void CheckProgression()
            {
                Console.WriteLine("Enter array size - more than 1))");
                int n = Convert.ToInt32(Console.ReadLine());
                int[] numbers = new int[n];
                bool isArifmethic = true;
                bool isGeometric = true;
                

                Console.WriteLine("Enter array:");

                for (int i = 0; i < n; i++)
                {
                    numbers[i] = Convert.ToInt32(Console.ReadLine());
                }

                int arifm = numbers[1] - numbers[0];
                int geometric = numbers[1] / numbers[0];

                for (int i = 0; i < n; i++)
                { 
                    if (numbers[i] != (numbers[0] + (i) * arifm))
                    {
                        isArifmethic = false;
                        break;
                    }

                    else if (numbers[i + 1] != numbers[i] * geometric)
                    {
                        isGeometric = false;
                        break;
                    }
                }

                if (isArifmethic)
                    Console.WriteLine("Arifmethic progression");

                if (isGeometric)
                    Console.WriteLine("Geometric progression");

                if (!isArifmethic && !isGeometric)
                    Console.WriteLine("not progression");

            }

            Console.WriteLine();

            Console.WriteLine("Task 5.5");

            uint example = AckermannF(3, 1);
            Console.WriteLine(example);

            uint AckermannF(uint n, uint m)
            {
                if (n == 0)
                    return m + 1;
                else
                  if ((n != 0) && (m == 0))
                    return AckermannF(n - 1, 1);
                else
                    return AckermannF(n - 1, AckermannF(n, m - 1));
            }

            Console.ReadKey();
        }
    }
}
