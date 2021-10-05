using System;
using System.Collections.Generic;

namespace merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random(1811092381);
            for (int i = 0; i < 10; i++)
            {
                var test = new List<int>();
                for (int j = 0; j < 20; j++)
                {
                    test.Add(random.Next(0,500));
                }

                printList(test);
                Console.WriteLine("ソート実行");
                test = sort(test);
                printList(test);
                Console.WriteLine();
            }
        }

        static void printList(List<int> intList)
        {
            foreach (var i in intList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        static List<int> sort(List<int> intList)
        {
            if (intList.Count <= 1) return intList;
            //配列をふたつに分割
            var first = new List<int>();
            var latter = new List<int>();
            for (int i = 0; i < intList.Count/2; i++)
            {
                first.Add(intList[i]);
            }
            for (int i = intList.Count/2; i < intList.Count; i++)
            {
                latter.Add(intList[i]);
            }
            //それぞれをソートする
            first = sort(first);
            latter = sort(latter);
            //それぞれをマージする
            return merge(first, latter);
        }

        static List<int> merge(List<int> first, List<int> latter)
        {
            var result = new List<int>();
            int i = 0, j = 0;
            //どちらかが最大に到達するまでマージ
            while (i < first.Count && j < latter.Count)
            {
                if (first[i] < latter[j])
                {
                    result.Add(first[i]);
                    i++;
                }
                else
                {
                    
                    result.Add(latter[j]);
                    j++;
                }
            }
            //まだどっちかがマージしきれてないので、その分をマージする
            if (i < first.Count)
            {
                for (; i < first.Count; i++)
                {
                    result.Add(first[i]);
                }
            }
            else
            {
                for (; j < first.Count; j++)
                {
                    result.Add(latter[j]);
                }
            }

            return result;
        }
        
    }
}