using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays_and_Lists
{
    class ArraysAndLists
    {
        public static void Main(string[] args)
        {
            //ArraysAndLists.Exercise1();
            //ArraysAndLists.Exercise2();
            //ArraysAndLists.Exercise3();
            //ArraysAndLists.Exercise4();
            ArraysAndLists.Exercise5();
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

        public static void Exercise2()
        {
            Console.WriteLine("Please enter your name: ");
            var name = Console.ReadLine();
            var array = new char[name.Length];

            var i = 0;

            while (i < name.Length)
            {
                array[i] = name[i];
                i++;
            }

            Array.Reverse(array);

            var reversed = new String(array);

            Console.WriteLine("Here is your name reversed: " + reversed);
        }

        // 3- Write a program and ask the user to enter 5 numbers.If a number has been previously entered, display an error message
        // and ask the user to re-try. Once the user successfully enters 5 unique numbers, sort them and display the result on the
        // console.

        public static void Exercise3()
        {
            var nums = new List<int>();

            while (nums.Count < 5)
            {
                Console.WriteLine("Please enter a number: ");
                var num = Convert.ToInt32(Console.ReadLine());

                if (nums.Contains(num))
                {
                    Console.WriteLine("You've already entered that number, please try again.");
                    continue;
                }

                nums.Add(num);
            }

            nums.Sort();
            foreach(var n in nums)
            { 
                Console.WriteLine(n);
            }
        }

        // 4- Write a program and ask the user to continuously enter a number or type "Quit" to exit. The list of numbers may
        // include duplicates. Display the unique numbers that the user has entered.

        public static void Exercise4()
        {
            var nums = new List<int>();

            while(true)
            {
                Console.WriteLine("Please enter a number: ");
                var input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;

                var num = Convert.ToInt32(input);

                if (!nums.Contains(num))
                    nums.Add(num);

                Console.WriteLine("Unique nums: ");
                foreach(var n in nums)
                {
                    Console.WriteLine(n);
                }
            }
        }

        // 5- Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10). If the list is
        // empty or includes less than 5 numbers, display "Invalid List" and ask the user to re-try; otherwise, display the 3
        // smallest numbers in the list.

        public static void Exercise5()
        {
            string[] elements;

            while (true)
            {
                Console.WriteLine("Please enter at least 5 numbers separated by a comma (ex: 5, 1, 9, 2, 10): ");
                var input = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(input))
                {
                    elements = input.Split(',');
                    if (elements.Length > 4)
                        break;
                }

                Console.WriteLine("Invalid list, please try again.");
            }

            var numbers = new List<int>();
            foreach (var num in elements)
                numbers.Add(Convert.ToInt32(num));

            numbers.Sort();

            Console.WriteLine("The 3 smallest numbers are: ");
            var i = 0;
            while (i < 3)
            {
                Console.WriteLine(numbers[i]);
                i++;
            }
        }
    }
}
