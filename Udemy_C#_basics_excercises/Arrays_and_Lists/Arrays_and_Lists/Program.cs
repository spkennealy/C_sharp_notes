using System;
using System.Collections.Generic;

namespace Arrays_and_Lists
{
    class ArraysAndLists
    {
        public static void Main(string[] args)
        {
            ArraysAndLists.Exercise1();
            //ArraysAndLists.Exercise2();
            //ArraysAndLists.Exercise3();
            //ArraysAndLists.Exercise4();
            //ArraysAndLists.Exercise5();
        }

        // 1 - When you post a message on Facebook, depending on the number of people who like your post, Facebook displays
        // different information.

        // If no one likes your post, it doesn't display anything.
        // If only one person likes your post, it displays: [Friend's Name] likes your post.
        // If two people like your post, it displays: [Friend 1] and[Friend 2] like your post.
        // If more than two people like your post, it displays: [Friend 1], [Friend 2] and[Number of Other People] others liked
        // your post.

        // Write a program and continuously ask the user to enter different names, until the user presses Enter (without supplying
        // a name). Depending on the number of names provided, display a message based on the above pattern.

        public static void Exercise1()
        {
            var names = new List<string>();

            while (true)
            {
                Console.WriteLine("Please enter a name or press enter to end: ");
                var name = Console.ReadLine();

                if (name.Length == 0)
                {
                    break;
                }

                names.Add(name);

                if (names.Count > 2)
                {
                    Console.WriteLine("{0}, {1} and {2} others liked your post.", names[0], names[1], names.Count - 2);
                }
                else if (names.Count == 2)
                {
                    Console.WriteLine("{0} and {1} liked your post.", names[0], names[1]);
                }
                else if (names.Count == 1)
                {
                    Console.WriteLine(names[0] + " liked your post.");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        // 2- Write a program and ask the user to enter their name.Use an array to reverse the name and then store the result in
        // a new string. Display the reversed name on the console.

        //public static void Exercise2()
        //{

        //}

        // 3- Write a program and ask the user to enter 5 numbers.If a number has been previously entered, display an error message
        // and ask the user to re-try. Once the user successfully enters 5 unique numbers, sort them and display the result on the
        // console.

        //public static void Exercise3()
        //{

        //}

        // 4- Write a program and ask the user to continuously enter a number or type "Quit" to exit. The list of numbers may
        // include duplicates.Display the unique numbers that the user has entered.

        //public static void Exercise4()
        //{

        //}

        // 5- Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10). If the list is
        // empty or includes less than 5 numbers, display "Invalid List" and ask the user to re-try; otherwise, display the 3
        //  smallest numbers in the list.

        //public static void Exercise5()
        //{

        //}
    }
}
