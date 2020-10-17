using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static Random rnd = new Random();
        private const int leftBorder = 0;
        private const int rightBorder = 15;
        private const string path = "../../../ArraySum.txt";
        
        static void Main(string[] args)
        {
            int n, m;
            
            n = GetNumber("Введите N: ");
            m = GetNumber("Введите M: ");

            int[] a, b;
            
            InitializeArray(out a, n, leftBorder, rightBorder);
            InitializeArray(out b, m, leftBorder, rightBorder);

            int[] c = ArraySum(a, b);

            string arrays = BeautifulArrayToString(a, b, c);

            Console.WriteLine(arrays);

            try
            {
                File.WriteAllText(path, arrays);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        static int GetNumber(string message)
        {
            int n;

            do
            {
                Console.WriteLine(message);
            } while (!(int.TryParse(Console.ReadLine(), out n) && n >= 0 && n <= 1000));

            return n;
        }

        static void InitializeArray(out int[] array, int length, int a, int b)
        {
            array = new int[length];
            
            for (int i = 0; i < length; ++i)
                array[i] = rnd.Next(a, b + 1);
        }

        static int[] ArraySum(int[] a, int[] b)
        {
            (a, b) = a.Length <= b.Length ? (a, b) : (b, a);
            int[] c = new int[b.Length];

            for (int i = 0; i < a.Length; ++i)
                c[i] = a[i] + b[i];

            for (int i = a.Length; i < c.Length; ++i)
                c[i] = b[i];

            return c;
        }

        static string ArrayToString(int[] array)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < array.Length - 1; ++i)
                str.Append(array[i] + ", ");

            str.Append(array[^1] + Environment.NewLine);

            return str.ToString();
        }

        static string BeautifulArrayToString(int[] a, int[] b, int[] c)
        {
            StringBuilder str = new StringBuilder();

            str.Append(ArrayToString(a));
            str.Append("+" + Environment.NewLine);
            str.Append(ArrayToString(b));
            str.Append("=" + Environment.NewLine);
            str.Append(ArrayToString(c));

            return str.ToString();
        }

        static void DateTimePractice()
        {
            DateTime time = DateTime.Now;
            int n = GetNumber("Введите n: ");
            Console.WriteLine(time.AddDays(n));
        }
    }
}