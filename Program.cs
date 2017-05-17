using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            string[] str;
            double det = 1;
            const double EPS = 1E-9;
            int n;
            Console.WriteLine("A program for finding the determinant of a matrix by Gaussian");
            Console.WriteLine("Example of matrix input n=4:\n6 9 -8 -12\n4 6 -6 -9\n-2 -4 6 9\n-3 -4 5 7");
            Console.WriteLine("Enter the size of the matrix nxn:");
            n = int.Parse(Console.ReadLine());
            double[][] a = new double[n][];
            double[][] b = new double[1][];
            b[0] = new double[n];
            Console.WriteLine("Enter n lines of n elements:");
            for (int i = 0; i < n; i++)
            {
                s = Console.ReadLine();
                str = s.Split(' ');
                a[i] = new double[n];
                for (int j = 0; j < n; j++)
                {
                    a[i][j] = double.Parse(str[j]);
                }
            }
            for (int i = 0; i < n; ++i)
            {
                int k = i;
                for (int j = i + 1; j < n; ++j)
                    if (Math.Abs(a[j][i]) > Math.Abs(a[k][i]))
                        k = j;
                if (Math.Abs(a[k][i]) < EPS)
                {
                    det = 0;
                    break;
                }
                b[0] = a[i];
                a[i] = a[k];
                a[k] = b[0];
                if (i != k)
                    det = -det;
                det *= a[i][i];
                for (int j = i + 1; j < n; ++j)
                    a[i][j] /= a[i][i];
                for (int j = 0; j < n; ++j)
                    if ((j != i) && (Math.Abs(a[j][i]) > EPS))
                        for (k = i + 1; k < n; ++k)
                            a[j][k] -= a[i][k] * a[j][i];
            }
            Console.WriteLine("The matrix determinant = {0}",det);
            Console.ReadLine();
        }
    }
}
