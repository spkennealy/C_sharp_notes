 using System;

namespace Control_Flow
{
    public class Conditionals
    {
        public static void Main(string[] args)
        {
            //Conditionals.Excercise1();
            //Conditionals.Excercise2();
            //Conditionals.Excercise3();
            //Conditionals.Excercise4();
            //IterationStatements.Excercise1();
            IterationStatements.Excercise2();
            //IterationStatements.Excercise3();
            //IterationStatements.Excercise4();
            //IterationStatements.Excercise5();
        }

        // 1- Write a program and ask the user to enter a number. The number should be between 1 to 10. If the user enters a valid number,
        // display "Valid" on the console.Otherwise, display "Invalid". (This logic is used a lot in applications where values entered into
        // input boxes need to be validated.)

        public static void Excercise1()
        {
            Console.WriteLine("Please enter a number between 1 and 10: ");
            var input = Console.ReadLine();
            var number = Convert.ToInt32(input);
            if (number <= 10 && number >= 1)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Invalid");
        }

        // 2- Write a program which takes two numbers from the console and displays the maximum of the two.

        public static void Excercise2()
        {
            Console.WriteLine("Please enter a number: ");
            var input1 = Console.ReadLine();
            var num1 = Convert.ToInt32(input1);
            Console.WriteLine("Please enter another number: ");
            var input2 = Console.ReadLine();
            var num2 = Convert.ToInt32(input2);

            var max = num1 > num2 ? num1 : num2;

            Console.WriteLine("Max Number: " + max);
        }

        // 3- Write a program and ask the user to enter the width and height of an image.Then tell if the image is landscape or portrait.

        public static void Excercise3()
        {
            Console.WriteLine("Please enter a width: ");
            var input1 = Console.ReadLine();
            var width = Convert.ToInt32(input1);
            Console.WriteLine("Please enter a height: ");
            var input2 = Console.ReadLine();
            var height = Convert.ToInt32(input2);

            var orientation = width > height ? "landscape" : "portrait";
        }

        // 4- Your job is to write a program for a speed camera.For simplicity, ignore the details such as camera, sensors, etc and focus
        // purely on the logic.Write a program that asks the user to enter the speed limit. Once set, the program asks for the speed of a
        // car.If the user enters a value less than the speed limit, program should display Ok on the console.If the value is above the
        // speed limit, the program should calculate the number of demerit points.For every 5km/hr above the speed limit, 1 demerit points
        // should be incurred and displayed on the console. If the number of demerit points is above 12, the program should display License
        // Suspended.

        public static void Excercise4()
        {
            Console.WriteLine("Please enter a speed limit in km/hr: ");
            var input1 = Console.ReadLine();
            var speedLimit = Convert.ToInt32(input1);
            Console.WriteLine("Please enter the speed of the car: ");
            var input2 = Console.ReadLine();
            var carSpeed = Convert.ToInt32(input2);

            if (carSpeed <= speedLimit)
                Console.WriteLine("OK");
            else
            {
                var diff = carSpeed - speedLimit;
                var demerits = diff / 5;
                if (demerits >= 12)
                    Console.WriteLine("License Suspended!");
                else
                    Console.WriteLine("You have received " + demerits + " demerits.");
            }
        }
    }


    public class IterationStatements
    {

        // 1- Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. Display the count on
        // the console.

        public static void Excercise1()
        {
            var count = 0;
            for (var i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                    count += 1;
            }

            Console.WriteLine("Count of numbers divisible by 3: " + count);
        }

        // 2- Write a program and continuously ask the user to enter a number or "ok" to exit. Calculate the sum of all the
        // previously entered numbers and display it on the console.

        public static void Excercise2()
        {

        }

        // 3- Write a program and ask the user to enter a number.Compute the factorial of the number and print it on the console.
        // For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 and display it as 5! = 120.

        public static void Excercise3()
        {

        }

        // 4- Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number.If the
        // user guesses the number, display “You won"; otherwise, display “You lost". (To make sure the program is behaving
        // correctly, you can display the secret number on the console first.)

        public static void Excercise4()
        {

        }

        // 5- Write a program and ask the user to enter a series of numbers separated by comma.Find the maximum of the numbers
        // and display it on the console.For example, if the user enters “5, 3, 8, 1, 4", the program should display 8.

        public static void Excercise5()
        {

        }
    }
}