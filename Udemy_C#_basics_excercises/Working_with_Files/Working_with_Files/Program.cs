using System;
using System.IO;

namespace Working_with_Files
{
    class Files
    {
        public static void Main(string[] args)
        {
            Files.Exercise1();
            //Files.Exercise2();
        }

        // 1- Write a program that reads a text file and displays the number of words.

        public static void Exercise1()
        {
            var text = File.ReadAllText(@"/Users/seankennealy/Desktop/Insightly/C_sharp_notes/Udemy_C#_basics_excercises/Working_with_Files/Working_with_Files/GSW.txt");
            var textWithoutNewLines = text.Replace(System.Environment.NewLine, "");
            Console.WriteLine(textWithoutNewLines);
            var wordCount = textWithoutNewLines.Split(' ').Length;
            Console.WriteLine("Total words: " + wordCount);
        }

        // 2- Write a program that reads a text file and displays the longest word in the file.

        //public static void Exercise2()
        //{

        //}
    }
}
