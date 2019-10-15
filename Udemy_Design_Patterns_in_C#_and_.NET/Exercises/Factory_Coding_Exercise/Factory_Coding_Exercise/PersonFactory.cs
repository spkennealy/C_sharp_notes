using static System.Console;

namespace Factory_Coding_Exercise
{
    public class PersonFactory
    {
        private int count;

        public PersonFactory()
        {
            count = 0;
        }

        public Person CreatePerson(string name)
        {
            var person = new Person();
            person.Name = name;
            person.Id = count;
            count++;
            WriteLine($"Created {person.Name} with the id of {person.Id}.");
            return person;
        }
    }
}
