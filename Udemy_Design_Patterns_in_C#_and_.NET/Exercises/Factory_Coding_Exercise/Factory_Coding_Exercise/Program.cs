using System;

namespace Factory_Coding_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var personFactory = new PersonFactory();
            personFactory.CreatePerson("Sean");
            personFactory.CreatePerson("Kierstyn");
            personFactory.CreatePerson("Emilia");
            personFactory.CreatePerson("Kyle");
            personFactory.CreatePerson("Kiley");
        }
    }
}
