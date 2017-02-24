using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20170223_SortersTestEvents
{
    class Program
    {
        public static Random rnd = new Random();
        static void Main()
        {
            Console.Title = "Тестирование производительности сортировок.";
            Console.WindowWidth = 100;
            bool bProgramRun = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите размер сортируемого массива:");
                int iSize = TypeUnsignedInteger();
                double[] adNumbers = GetRandomDoubleArray(iSize, rnd);
                TestSortMethod(new BubbleSorter(adNumbers));
                TestSortMethod(new CocktailSorter(adNumbers));
                TestSortMethod(new SelectionSorter(adNumbers));
                TestSortMethod(new InsertSorter(adNumbers));
                TestSortMethod(new HeapSorter(adNumbers));
                TestSortMethod(new ShellSorter(adNumbers));
                TestSortMethod(new MergeSorter(adNumbers));
                TestSortMethod(new QuickSorter(adNumbers));
                TestSortMethod(new QuickSorterM(adNumbers));
                Console.WriteLine("Хотите повторить? Y/N.");
                bProgramRun = TypeBoolean();
            } while (bProgramRun);
        }
        private static void TestSortMethod(Sorter s)
        {
            SortLogger sl = new SortLogger(s);            
            s.Run();
            Console.WriteLine(sl);
        }
        private static double[] GetRandomDoubleArray(int iSize, Random random)
        {
            double[] adArray = new double[iSize];
            for (int i = 0; i < adArray.Length; ++i)
            {
                adArray[i] = random.NextDouble();
            }
            return adArray;
        }
        private static bool TypeBoolean()
        {
            if (Console.ReadLine().Trim().ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static int TypeUnsignedInteger()
        {
            while (true)
            {
                int i;
                if (Int32.TryParse(Console.ReadLine().Trim(), out i))
                {
                    if (i > 0 || i <= Int32.MaxValue)
                    {
                        return i;
                    }
                    else
                    {
                        Console.Write("Введено не положительное число! Введите еще раз: ");
                    }
                }
                else
                {
                    Console.Write("Ошибка ввода! Введите еще раз: ");
                }
            }
        }
    }
}
