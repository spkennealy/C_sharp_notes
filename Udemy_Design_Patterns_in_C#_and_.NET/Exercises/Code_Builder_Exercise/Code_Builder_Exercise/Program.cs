using System;

namespace Code_Builder_Exercise
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }

    public class CodeBuilder
    {
        // TODO
        public string Code;

        public CodeBuilder(string className)
        {
            Code = $"public class {className}\n" + "{\n";
        }

        public CodeBuilder AddField(string name, string type)
        {
            Code += $"  public {type} {name};\n";
            return this;
        }

        public override string ToString()
        {
            return Code + "}";
        }
    }
}
