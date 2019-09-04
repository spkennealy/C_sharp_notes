using System;

namespace Design_A_Stack
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // A Stack is a data structure for storing a list of elements in a LIFO(last in, first out) fashion.

            // We should be able to use this stack class as follows:
            // var stack = new Stack(); stack.Push(1); stack.Push(2); stack.Push(3);
            // Console.WriteLine(stack.Pop()); Console.WriteLine(stack.Pop()); Console.WriteLine(stack.Pop());
            // The output of this program will be: 3 2 1

            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            //stack.Clear();

            stack.Pop();
            stack.Pop();
            stack.Pop();
        }
    }
}
