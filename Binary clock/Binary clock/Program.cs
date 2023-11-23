using System;
using System.Threading;

namespace Binary_clock
{
    internal class Program
    {
        static void Clock(int[] a, int[] b)
        {
            Console.Clear();
            Console.WriteLine("-|---|---|---|");
            Console.WriteLine(" |H H|M M|S S|");
            Console.WriteLine("-|---|---|---|");
            Console.WriteLine("8|  {0}|  {1}|  {2}|", a[0], a[6], a[13]);
            Console.WriteLine("4|  {0}|{1} {2}|{3} {4}|", a[1], a[10], a[7], a[17], a[14]);
            Console.WriteLine("2|{0} {1}|{2} {3}|{4} {5}|", a[4], a[2], a[11], a[8], a[18], a[15]);
            Console.WriteLine("1|{0} {1}|{2} {3}|{4} {5}|", a[5], a[3], a[12], a[9],a[19], a[16]);
            Console.WriteLine("-|---|---|---|");
            Console.WriteLine(" |{0} {1}:{2} {3}:{4} {5}|", b[1], b[0], b[3], b[2], b[5], b[4]);
            Console.WriteLine("-|---|---|---|");
        }
        static void Check0(int b,ref int[] a)
        {
            if (b >= 8) { a[0] = 1; b -= 8;}
            if (b >= 4) { a[1] = 1; b -= 4; }
            if (b >= 2) { a[2] = 1; b -= 2; }
            if (b == 1) { a[3] = 1; b -= 1; }
        }
        static void Check1(int b, ref int[] a)
        {
            if (b >= 2) { a[4] = 1; b -= 2; }
            if (b == 1) { a[5] = 1; b -= 1; }
        }
        static void Check2(int b, ref int[] a)
        {
            if (b >= 8) { a[6] = 1; b -= 8; }
            if (b >= 4) { a[7] = 1; b -= 4; }
            if (b >= 2) { a[8] = 1; b -= 2; }
            if (b == 1) { a[9] = 1; b -= 1; }
        }
        static void Check3(int b, ref int[] a)
        {
            if (b >= 4) { a[10] = 1; b -= 4; }
            if (b >= 2) { a[11] = 1; b -= 2; }
            if (b == 1) { a[12] = 1; b -= 1; }
        }
        static void Check4(int b, ref int[] a)
        {
            if (b >= 8) { a[13] = 1; b -= 8; }
            if (b >= 4) { a[14] = 1; b -= 4; }
            if (b >= 2) { a[15] = 1; b -= 2; }
            if (b == 1) { a[16] = 1; b -= 1; }
        }
        static void Check5(int b, ref int[] a)
        {
            if (b >= 4) { a[17] = 1; b -= 4; }
            if (b >= 2) { a[18] = 1; b -= 2; }
            if (b == 1) { a[19] = 1; b -= 1; }
        }
        static void Main()
        {
            int nr = 0, i = 0;
            int[] b = new int[6];
            int[] a = new int[21];
            string x = Console.ReadLine();
            string[] tokens = x.Split(':');
            foreach (string token in tokens)
            {
                nr = int.Parse(token);
                while (nr != 0)
                {
                    b[i] = nr % 10;
                    i++;
                    nr /= 10;
                }
            }
            while (true)
            {
                Check0(b[0], ref a);
                Check1(b[1], ref a);
                Check2(b[2], ref a);
                Check3(b[3], ref a);
                Check4(b[4], ref a);
                Check5(b[5], ref a);
                Clock(a, b);
                for (i = 0; i < 20; i++)
                    a[i] = 0;
                b[4]++;
                if (b[4] > 9)
                {
                    b[4] = 0;
                    b[5]++;
                    if (b[5] > 5)
                    {
                        b[5] = 0;
                        b[2]++;
                        if (b[2] > 9)
                        {
                            b[2] = 0;
                            b[3]++;
                            if (b[3] > 5)
                            {
                                b[3] = 0;
                                b[0]++;
                                if (b[0] == 4 && b[1] == 2)
                                {
                                    b[0] = 0;
                                    b[1] = 0;
                                }
                                if (b[0] > 9)
                                {
                                    b[0] = 0;
                                    b[1]++;
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
