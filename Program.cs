using System;
using System.Linq;
using System.Collections;


// CTRL + K + D to format
namespace LINQ_SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Non-LINQ version
            int[] arr = { 41, 22, 42, 1412, 2, 5, 14, 78, 21, 25, 74, 24, 20, 100, 28, 55 };
            int val = 40;

            int count = 0;
            var arlist = new ArrayList(); // from System.Collections, it's like an array but with dynamic size

            // Alternate way of iterating: for (int i = 0; i < arr.Length; i++) { Console.WriteLine(arr[i]); }

            foreach (int num in arr)
            {
                if (num > val)
                {
                    count++;
                    arlist.Add(num);
                }

            }
            Console.WriteLine("Non-LINQ Version:");
            Console.WriteLine($"Values above {val}\nCount: {count}\nList: ");

            int l = 0;
            foreach (int num in arlist)
            {
                Console.Write(num);
                l++;
                if (l == arlist.Count) { Console.WriteLine("\nEnd of list"); }
                else { Console.Write(" "); }

            }

            /*
            // If we were stuck with old arrays, one could do a new array based on count to get the size of it, then add to it, like so:
            int[] arr2 = new int[count];
            int ind = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > val)
                {
                    arr2.SetValue(arr[i], ind); // Alt: arr2[ind] = arr[i];
                    
                    ind++;
                }
            }
            Array.Sort(arr2); //Sort ASC
            Array.Reverse(arr2); // Now it's DESC
            foreach(int num in arr2) { Console.WriteLine(num); }
            */

            /* LINQ version, assuming a table like below
             * Like Django, this works via CRUD [Create (Insert), Read (Select), Update, Delete]
            Table_1
            ------
            Col_1
            ------
            41
            42
            1412
            78
            74
            100
            55

            SELECT Col_1 // AS <Alias>
            FROM Table_1
            WHERE Col_1 > 40
            ORDER BY Col_1 DESC; // WHERE/GROUP BY/HAVING/ORDER BY (in that order)
            */

            // from <alias> in <coll | arr> [<clauses>] select <alias> // for LINQ order is different and alias is mandatory
            var arr3 =
                from i in arr
                where i > 40
                orderby i descending
                select i;
            Console.WriteLine("LINQ Version:");
            foreach (var i in arr3) {  Console.Write(i+" "); }
            Console.ReadLine();
        }
    }
}