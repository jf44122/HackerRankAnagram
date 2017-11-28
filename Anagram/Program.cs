using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
class Solution
{

    static int anagram(string s)
    {
        if (s.Length % 2 != 0)
            return -1;
        else
        {
            char[] firstHalf = s.Take(s.Length / 2).ToArray();
            char[] secondHalf = s.Skip(s.Length / 2).ToArray();
            byte[] first = new byte[firstHalf.Length];
            byte[] second = new byte[secondHalf.Length];
            for (int counter = 0; counter < first.Length; counter++)
            {
                first[counter] = Convert.ToByte(firstHalf[counter]);
            }
            for (int counter = 0; counter < second.Length; counter++)
            {
                second[counter] = Convert.ToByte(secondHalf[counter]);
            }
            Array.Sort<byte>(first);
            Array.Sort<byte>(second);
            int firstCounter = 0;
            int secondCounter = 0;
            int matches = 0;
            matches = Matcher(first, firstCounter, second, secondCounter, matches);
            return (first.Length - matches);
        }
    }
    static int Matcher(byte[] first, int firstCounter, byte[] second, int secondCounter, int matches)
    {
        if ((firstCounter == first.Length) || (secondCounter == second.Length))
        {
            return matches;
        }

        else if (first[firstCounter] == second[secondCounter])
        {
            ++matches;
            ++firstCounter;
            ++secondCounter;
            matches = Matcher(first, firstCounter, second, secondCounter, matches);
        }

        else if (first[firstCounter] < second[secondCounter])
        {
            firstCounter += 1;
            matches = Matcher(first, firstCounter, second, secondCounter, matches);
        }
        else
        {
            secondCounter += 1;
            matches = Matcher(first, firstCounter, second, secondCounter, matches);
        }
        return matches;
    }


    static void Main(String[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < q; a0++)
        {
            string s = Console.ReadLine();
            int result = anagram(s);
            Console.WriteLine(result);
        }
    }
}

