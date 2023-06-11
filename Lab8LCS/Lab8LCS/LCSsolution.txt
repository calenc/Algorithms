using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8LCS
{
    class LCSsolution
    {
        public static string LCS(string s, string t)
        {
            string leftArrow = "\u2190";
            string upArrow = "\u2191";
            string answer = "";

            int[,] cTable = new int[s.Length + 1, t.Length + 1];
            string[,] bTable = new string[s.Length + 1, t.Length + 1];

            for (int i = 0; i < s.Length + 1; i++)
            {
                cTable[i, 0] = 0;
                bTable[i, 0] = 0.ToString();
            }

            for (int k = 0; k < t.Length + 1; k++)
            {
                cTable[0, k] = 0;
                bTable[0, k] = 0.ToString();
            }
            
            for (int j = 1; j < s.Length + 1; j++)
            {
                for (int g = 1; g < t.Length + 1; g++)
                {
                    if (s[j - 1].Equals(t[g - 1]))
                    {
                        cTable[j, g] = cTable[j - 1, g - 1] + 1;
                        bTable[j, g] = "d";
                    }
                    else if (!s[j - 1].Equals(t[g - 1]) && cTable[j - 1, g] > cTable[j, g - 1])
                    {
                        cTable[j, g] = cTable[j - 1, g];
                        bTable[j, g] = upArrow;
                    }
                    else if (!s[j - 1].Equals(t[g - 1]) && cTable[j - 1, g] < cTable[j, g - 1])
                    {
                        cTable[j, g] = cTable[j, g - 1];
                        bTable[j, g] = leftArrow;
                    }
                    else if (!s[j - 1].Equals(t[g - 1]) && cTable[j - 1, g] == cTable[j, g - 1])
                    {
                        cTable[j, g] = cTable[j - 1, g];
                        bTable[j, g] = upArrow;
                    }
                }
            }

            string tPrint = "";
            for (int i = 0; i < t.Length; i++)
            {
                tPrint += t[i] + " ";
            }

            Console.WriteLine("    {0}", tPrint);
            Console.Write(" ");
            for (int i = 0; i < t.Length + 1; i++)
            {
                Console.Write(" " + cTable[0, i]);
            }
            Console.Write("\n");
            for (int i = 1; i < s.Length + 1; i++)
            {
                Console.Write(s[i - 1]);
                for (int k = 0; k < t.Length + 1; k++)
                {
                    Console.Write(" " + cTable[i, k]);
                }
                Console.Write("\n");
            }

            Console.Write("\n");
            Console.WriteLine("    {0}", tPrint);
            Console.Write(" ");
            for (int i = 0; i < t.Length + 1; i++)
            {
                Console.Write(" " + bTable[0, i]);
            }
            Console.Write("\n");
            for (int i = 1; i < s.Length + 1; i++)
            {
                Console.Write(s[i - 1]);
                for (int k = 0; k < t.Length + 1; k++)
                {
                    Console.Write(" " + bTable[i, k]);
                }
                Console.Write("\n");
            }

            Console.WriteLine(" ");

            for (int p = t.Length, h = s.Length; p > 0; p--)
            {
                if (bTable[h, p] == upArrow)
                {
                    h--;
                    p++;
                }
                else if (bTable[h, p] == "d")
                {
                    answer += t[p - 1];
                    h--;
                    if (answer.Length == cTable[s.Length, t.Length])
                    {
                        p = 0;
                    }
                }
            }

            char[] solution = answer.ToCharArray();
            Array.Reverse(solution);
            string lcs = new string(solution);
            return lcs;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the first string: ");
            string first = Console.ReadLine();
            Console.WriteLine("Please enter the second string: ");
            string second = Console.ReadLine();
            string solution = LCS(first, second);
            Console.WriteLine(solution);
        }
    }
}
