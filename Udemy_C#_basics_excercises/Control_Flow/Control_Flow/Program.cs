 using System;

namespace Control_Flow
{
    public class Conditionals
    {
        public static void Main(string[] args)
        {
            Conditionals.Excercise1();
            Conditionals.Excercise2();
            Conditionals.Excercise3();
            Conditionals.Excercise4();
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
}