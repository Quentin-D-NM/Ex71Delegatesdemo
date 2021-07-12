using System;

namespace Delegatedemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter some text: ");
            String text = Console.ReadLine();

            //DispStrDelegate saying1 = new DispStrDelegate(Capitalize);
            //DispStrDelegate saying2 = new DispStrDelegate(LowerCased);
            //DispStrDelegate saying3 = new DispStrDelegate(Console.WriteLine);

            //saying1(text);
            //saying2(text);
            //saying3(text);

            //multi cast delegates
            DispStrDelegate sayings = new DispStrDelegate(Capitalize);
            sayings += new DispStrDelegate(LowerCased);
            sayings += new DispStrDelegate(Console.WriteLine);

            //Console.WriteLine("Running multi cast directly: ");
            //sayings(text);

            //Console.WriteLine("Running by passing delegate to another method: ");
            //RunMyDelegate(sayings, text);

            //Console.WriteLine("Running by passing in a lambda expression: ");
            //RunMyDelegate((string t) => { Console.WriteLine("Lambda: " + t); }, text);

            //Console.WriteLine("Lambda without type: ");
            //RunMyDelegate((t) => { Console.WriteLine("Lambda: " + t); }, text);

            //Console.WriteLine("Lambda without parenthesis: ");
            //RunMyDelegate(t => { Console.WriteLine("Lambda2: " + t); }, text);

            sayings += t => { Console.WriteLine("Lambda3: " + t); };
            Console.WriteLine("Three Delegates and a lambda: ");
            RunMyDelegate(sayings, text);
        }

        delegate void DispStrDelegate(string param);

        static void RunMyDelegate(DispStrDelegate del, string textParam)
        {
            del(textParam);
        }

        static void Capitalize(string text)
        {
            Console.WriteLine("Your input capatilized -->" + text.ToUpper());

        }

        static void LowerCased(string text)
        {
            Console.WriteLine("Your Input lower cased -->" + text.ToLower());
        }

    }
}
