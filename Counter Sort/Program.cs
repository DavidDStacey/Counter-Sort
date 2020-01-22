using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

/// <summary>
/// DAVID STACEY
/// 9/13/18
/// SORT NUMBERS IN ARRAYS
/// </summary>
namespace Counter_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            // NOTE: Not all loops will display - runs out of space in window -
            for (int j = 1; j < 1001; j++)
            {
                // max and min for random
                int Min = 0;
                int Max = 101;
                // create new random array 
                // numbers in array will be from 0 to 100
                int[] randArray = new int[100000];
                Random randNum = new Random();
                for (int i = 0; i < randArray.Length; i++)
                {
                    randArray[i] = randNum.Next(Min, Max);
                }

                // outputs
                WriteLine("\n\n----- Loop number: " + j + " -----\n");
                WriteLine("Original array: ");
                Output(randArray);
                WriteLine("\n\nSorted array: ");
                Sorter(randArray);
            }
            // keeps console open until a key is pressed
            ReadKey();
        }
        /// <summary>
        /// sorter
        /// </summary>
        /// <param name="x">passing along the array</param>
        static void Sorter(int[] x)
        {
            // makes sorted array
            int[] sortedArray = new int[x.Length];
            // max and min ints
            int minVal = x[0];
            int maxVal = x[0];
            
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] < minVal) minVal = x[i];
                else if (x[i] > maxVal) maxVal = x[i];
            }

            int[] counts = new int[maxVal - minVal + 1];

            for (int i = 0; i < x.Length; i++)
            {
                counts[x[i] - minVal]++;
            }

            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
            }

            for (int i = x.Length - 1; i >= 0; i--)
            {
                sortedArray[counts[x[i] - minVal]--] = x[i];
            }
            Output(sortedArray);            
            IsSorted(sortedArray);
        }
        /// <summary>
        /// creates the output string for sorted arrays
        /// </summary>
        /// <param name="s"></param>
        static void Output(int[] s)
        {         
            foreach (var i in s)
            {
                Write(i.ToString() + " ");
            }
        }
        /// <summary>
        /// Checks the sorted array to see if it is correctly sorted
        /// </summary>
        /// <param name="s"></param>
        static void IsSorted(int[] s)
        {
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] > s[i])
                {
                    // if incorrectly sorted a messagebox appears and then the application is forcefully exited
                    MessageBox.Show("Inccorectly sorted. The application will now close.");
                    Environment.Exit(0);
                }
            }
            Write("\nCorrectly sorted.");
        }
    }
}