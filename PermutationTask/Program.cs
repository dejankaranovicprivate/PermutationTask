using System;
using System.Collections.Generic;

namespace PermutationTask
{
    class Program
    {
        static List<string> AllPermutationsStr1 = new List<string>();

        static void Main(string[] args)
        {
            String str1 = "abc";
            String str2 = "foacabaccccacccbaz";

            var n = str1.Length;

            Permute(str1, 0, n - 1);

            FindAndPrintPermutationNumAndIndexes(str2);

            Console.ReadLine();
        }

        private static void Permute(string str, int l, int r)
        {
            if (l == r)
                AllPermutationsStr1.Add(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = Swap(str, l, i);
                    Permute(str, l + 1, r);
                    str = Swap(str, l, i);
                }
            }
        }

        public static string Swap(string a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

        private static void FindAndPrintPermutationNumAndIndexes(string str2)
        {
            var permutationNum = 0;
            var indexes = new List<int>();

            foreach (var str1PermutationItem in AllPermutationsStr1)
            {
                if(str2.Contains(str1PermutationItem))
                {
                    permutationNum++;
                    indexes.Add(str2.IndexOf(str1PermutationItem));
                }
            }

            Console.WriteLine("Permutation number: " + permutationNum);
            Console.WriteLine("Indexes: ");
            foreach(var index in indexes)
                Console.WriteLine(index);
        }
    }
}
