using System;
using System.Collections.Generic;

namespace Working_with_Text
{
    class Text
    {
        public static void Main(string[] args)
        {
            //Text.Exercise1();
            //Text.Exercise2();
            Text.Exercise3();
            //Text.Exercise4();
            //Text.Exercise5();
        }


        // 1- Write a program and ask the user to enter a few numbers separated by a hyphen. Work out if the numbers
        // are consecutive. For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", display a message: "Consecutive";
        // otherwise, display "Not Consecutive".

        public static void Exercise1()
        {
            Console.WriteLine("Please enter a few numbers separated by a hyphen (ex. 5-6-7-8-9): ");
            var input = Console.ReadLine().Split('-');
            var numbers = new List<int>();

            for (var i = 0; i < input.Length; i++)
            {
                var num = int.Parse(input[i]);
                numbers.Add(num);
            }

            numbers.Sort();

            var isConsecutive = true;
            for (var j = 1; j < numbers.Count; j++)
            {
                if (numbers[j] != numbers[j-1] + 1)
                {
                    isConsecutive = false;
                    break;
                }
            }

            var message = isConsecutive ? "Consecutive" : "Not Consecutive";
            Console.WriteLine(message);
        }

        // 2- Write a program and ask the user to enter a few numbers separated by a hyphen. If the user simply presses
        // Enter, without supplying an input, exit immediately; otherwise, check to see if there are duplicates. If so,
        // display "Duplicate" on the console.

        public static void Exercise2()
        {
            Console.WriteLine("Please enter a few numbers separated by a hyphen (ex. 5-6-5-7-2): ");
            var input = Console.ReadLine();

            if (String.IsNullOrEmpty(input))
            {
                return;
            }

            var hasDuplicates = false;
            var nums = new List<int>();

            foreach (var num in input.Split('-'))
            {
                var convertedNum = Convert.ToInt32(num);
                if (!nums.Contains(convertedNum))
                {
                    nums.Add(convertedNum);
                } else
                {
                    hasDuplicates = true;
                    break;
                }
            }

            var message = hasDuplicates ? "Duplicate" : "No Duplicates";
            Console.WriteLine(message);
        }

        // 3- Write a program and ask the user to enter a time value in the 24-hour time format(e.g. 19:00). A valid
        // time should be between 00:00 and 23:59. If the time is valid, display "Ok"; otherwise, display "Invalid Time".
        // If the user doesn't provide any values, consider it as invalid time. 

        public static void Exercise3()
        {
            Console.WriteLine("Please enter a time value in the 24-hour format (ex. 19:00 or 06:00): ");
            var input = Console.ReadLine().Split(':');

            if (input.Length != 2)
            {
                Console.WriteLine("Invalid Time");
                return;
            }
            else
            {
                var hours = Convert.ToInt32(input[0]);
                var minutes = Convert.ToInt32(input[1]);

                if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59)
                {
                    Console.WriteLine("Invalid Time");
                    return;
                }
            }

            Console.WriteLine("OK");
        }

        // 4- Write a program and ask the user to enter a few words separated by a space.Use the words to create a
        // variable name with PascalCase.For example, if the user types: "number of students", display "NumberOfStudents".
        // Make sure that the program is not dependent on the input.So, if the user types "NUMBER OF STUDENTS", the
        // program should still display "NumberOfStudents".

        //public static void Exercise4()
        //{

        //}

        // 5- Write a program and ask the user to enter an English word. Count the number of vowels (a, e, o, u, i)
        // in the word. So, if the user enters "inadequate", the program should display 6 on the console.

        //public static void Exercise5()
        //{

        //}

    }
}
